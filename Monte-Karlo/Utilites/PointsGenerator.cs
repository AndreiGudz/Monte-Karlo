﻿// Класс для генерации случайных точек и вычисления их принадлежности кругу и сегменту
using Monte_Karlo.Models;
using System.Collections.Concurrent;

namespace Monte_Karlo.Utilites
{
    public class PointsGenerator
    {
        private readonly Mutex _mutex = new();  // Мьютекс для потокобезопасного доступа
        private PointsData _currentPoints = new();  // Текущий набор точек

        // Генерирует новые случайные точки и вычисляет их принадлежность
        public async Task GenerateRandomPointsAsync(Circle circle, int count, CancellationToken token)
        {
            try
            {
                _mutex.WaitOne();  // Блокировка для потокобезопасности
                token.ThrowIfCancellationRequested();

                var newPoints = new PointsData();
                newPoints.Points = new List<PointF>(count);

                float radius = circle.radius;

                await Task.Run(() =>
                {
                    var parallelOptions = new ParallelOptions
                    {
                        CancellationToken = token,
                        MaxDegreeOfParallelism = Environment.ProcessorCount
                    };

                    // Генерация точек
                    GeneratePoints(newPoints, count, radius, parallelOptions);
                    token.ThrowIfCancellationRequested();

                    // Вычисление точек внутри круга
                    CalculateIncludedPoints(newPoints, radius, parallelOptions);
                    token.ThrowIfCancellationRequested();

                    // Вычисление точек в сегменте
                    CalculateCuttedPoints(newPoints, circle, parallelOptions);
                }, token);

                _currentPoints = newPoints;  // Сохранение результатов
            }
            finally
            {
                _mutex.ReleaseMutex();  // Освобождение блокировки
            }
        }

        // Пересчитывает точки в сегменте для существующего набора точек
        public async Task CalculateCuttedPointsAsync(Circle circle, int count, CancellationToken token)
        {
            if (_currentPoints.Points.Count == 0)
            {
                await GenerateRandomPointsAsync(circle, count, token);
                return;
            }

            try
            {
                _mutex.WaitOne();
                token.ThrowIfCancellationRequested();

                await Task.Run(() =>
                {
                    var parallelOptions = new ParallelOptions
                    {
                        CancellationToken = token,
                        MaxDegreeOfParallelism = Environment.ProcessorCount
                    };
                    CalculateCuttedPoints(_currentPoints, circle, parallelOptions);
                }, token);
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }

        // Очищает текущий набор точек
        public void ClearPoints()
        {
            _currentPoints = new PointsData();
        }

        // Возвращает текущий набор точек
        public PointsData GetCurrentPoints()
        {
            return _currentPoints;
        }

        // Генерирует случайные точки в квадрате [-radius, radius] x [-radius, radius]
        private static void GeneratePoints(PointsData pointsData, int count, float radius, ParallelOptions parallelOptions)
        {
            var random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

            var points = new PointF[count];
            Parallel.For(0, count, parallelOptions, i =>
            {
                float x = (float)random.Value.NextDouble() * radius * 2 - radius;
                float y = (float)random.Value.NextDouble() * radius * 2 - radius;
                points[i] = new PointF(x, y);
            });

            pointsData.Points = points.ToList();
        }

        // Фильтрует точки, попавшие внутрь круга
        private static void CalculateIncludedPoints(PointsData pointsData, float radius, ParallelOptions parallelOptions)
        {
            float radiusSquared = radius * radius;
            var includedPoints = new ConcurrentBag<PointF>();

            Parallel.ForEach(pointsData.Points, parallelOptions, point =>
            {
                float distanceSquared = point.X * point.X + point.Y * point.Y;

                if (distanceSquared < radiusSquared)
                {
                    includedPoints.Add(point);
                }
            });

            pointsData.IncludedPoints = includedPoints.ToList();
        }

        // Фильтрует точки, попавшие в заданный сегмент круга
        private static void CalculateCuttedPoints(PointsData pointsData, Circle circle, ParallelOptions parallelOptions)
        {
            if (pointsData.IncludedPoints.Count == 0)
                return;

            var cuttedPoints = new ConcurrentBag<PointF>();
            Point center = circle.circleCenter;
            Direction direction = circle.direction;
            float C = circle.C;

            if (direction == Direction.vertical)
            {
                bool lefter = C < center.X;
                float centerX = center.X;

                Parallel.ForEach(pointsData.IncludedPoints, parallelOptions, point =>
                {
                    bool condition = lefter
                        ? point.X + centerX >= C
                        : point.X + centerX <= C;

                    if (condition)
                    {
                        cuttedPoints.Add(point);
                    }
                });
            }
            else // horizontal
            {
                bool downer = C < center.Y;
                float centerY = center.Y;

                Parallel.ForEach(pointsData.IncludedPoints, parallelOptions, point =>
                {
                    bool condition = downer
                        ? centerY + point.Y >= C
                        : centerY + point.Y <= C;

                    if (condition)
                    {
                        cuttedPoints.Add(point);
                    }
                });
            }

            pointsData.CuttedPoints.Clear();
            pointsData.CuttedPoints = cuttedPoints.ToList();
        }
    }
}