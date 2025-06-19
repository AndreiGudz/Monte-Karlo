using Monte_Karlo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monte_Karlo.Utilites
{
    public delegate Task GeneratorAsyncAction(Circle circle, int count = 0, CancellationToken token = default);

    public class PointsGenerator
    {
        public List<PointF> Points { get; private set; } = new();
        public List<PointF> IncludedPoints { get; private set; } = new();
        public List<PointF> ExcludedPoints { get; private set; } = new();
        public List<PointF> CuttedPoints { get; private set; } = new();

        private Mutex mutex = new();

        public async Task GenerateRandomPointsAsync(Circle circle, int count, CancellationToken token)
        {
            try
            {
                mutex.WaitOne();

                ClearPoints();
                Points = new List<PointF>(count);

                float radius = circle.radius;
                Random random = new();

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
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public async Task CalculateCuttedPointsAsync(Circle circle, int count, CancellationToken token)
        {
            if (Points.Count == 0)
            {
                await GenerateRandomPointsAsync(circle, count, token);
                return;
            }

            try
            {
                mutex.WaitOne();
                await Task.Run(() =>
                {
                    var parallelOptions = new ParallelOptions { CancellationToken = token };
                    CalculateCuttedPoints(circle, parallelOptions);
                }, token);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        public void ClearPoints()
        {
            Points.Clear();
            IncludedPoints.Clear();
            ExcludedPoints.Clear();
            CuttedPoints.Clear();
        }

        private void Generate(int count, float radius, ParallelOptions parallelOptions)
        {
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

        private void CalculateIncludedPoints(float radius, ParallelOptions parallelOptions)
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

        private void CalculateCuttedPoints(Circle circle, ParallelOptions parallelOptions)
        {


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
                        ? point.X + centerX >= C
                        : point.X + centerX <= C;

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
                        ? centerY + point.Y >= C
                        : centerY + point.Y <= C;

                    if (condition)
                    {
                        lock (CuttedPoints)
                            CuttedPoints.Add(point);
                    }
                });
            }
        }
    }
}
