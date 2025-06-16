using Monte_Karlo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monte_Karlo
{
    public static class PointsGenerator
    {
        private static Mutex mutex = new();
        public static List<PointF> Points { get; private set; } = new();

        public static List<PointF> IncludedPoints { get; private set; } = new();
        public static List<PointF> ExcludedPoints { get; private set; } = new();
        public static List<PointF> CuttedPoints { get; private set; } = new();

        public static async Task GenerateRandomPointsAsync(Circle circle, int count,  CancellationToken token = default)
        {
            
            Point center = circle.circleCenter;
            float radius = circle.radius;
            Direction direction = circle.direction;
            float C = circle.C;

            Random random = new();
            ClearPoints();

            Points = new List<PointF>(count);

            await Task.Run(() =>
            {
                var parallelOptions = new ParallelOptions { CancellationToken = token };
                Generate(count, radius, parallelOptions);
                token.ThrowIfCancellationRequested();
                CalculateIncludedPoints(radius, parallelOptions);
                token.ThrowIfCancellationRequested();
                CalculateCuttedPoints(circle, parallelOptions);
            }, token);
        }

        private static void Generate(int count, float radius, ParallelOptions parallelOptions)
        {
            try
            {
                mutex.WaitOne();
                var threadLocalRandom = new ThreadLocal<Random>(() =>
                {
                    int seed = Guid.NewGuid().GetHashCode();
                    return new Random(seed);
                });

                Parallel.For(0, count, parallelOptions, (i) =>
                {
                    float x = (float)threadLocalRandom.Value.NextDouble() * radius * 2 - radius;
                    float y = (float)threadLocalRandom.Value.NextDouble() * radius * 2 - radius;
                    lock (Points)
                    {
                        Points.Add(new PointF(x, y));
                    }
                });
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public static void ClearPoints()
        {
            Points.Clear();
            IncludedPoints.Clear();
            ExcludedPoints.Clear();
            CuttedPoints.Clear();
        }

        private static void CalculateIncludedPoints(float radius, ParallelOptions parallelOptions)
        {
            float radiusSquared = radius * radius;

            Parallel.ForEach(Points, parallelOptions, point =>
            {
                float distanceSquared = point.X * point.X + point.Y * point.Y;

                if (distanceSquared < radiusSquared)
                {
                    lock (IncludedPoints) 
                        IncludedPoints.Add(point);
                }
                else
                {
                    lock (ExcludedPoints) 
                        ExcludedPoints.Add(point);
                }
            });
        }

        public static void CalculateCuttedPoints(Circle circle, ParallelOptions parallelOptions)
        {
            try
            {
                mutex.WaitOne();

                if (IncludedPoints.Count == 0)
                    return;

                CuttedPoints.Clear();
                Point center = circle.circleCenter;
                Direction direction = circle.direction;
                float C = circle.C;

                if (direction == Direction.vertical)
                {
                    bool lefter = C < center.X;
                    float centerX = center.X;

                    Parallel.ForEach(IncludedPoints, parallelOptions, point =>
                    {
                        bool condition = lefter
                            ? (point.X + centerX >= C)
                            : (point.X + centerX <= C);

                        if (condition)
                        {
                            lock (CuttedPoints)
                                CuttedPoints.Add(point);
                        }
                    });
                }
                else // horizontal
                {
                    bool downer = C < center.Y;
                    float centerY = center.Y;

                    Parallel.ForEach(IncludedPoints, parallelOptions, point =>
                    {
                        bool condition = downer
                            ? (centerY + point.Y >= C)
                            : (centerY + point.Y <= C);

                        if (condition)
                        {
                            lock (CuttedPoints)
                                CuttedPoints.Add(point);
                        }
                    });
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
