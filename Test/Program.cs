using Monte_Karlo.Utilites.Calculators;
using Monte_Karlo.DataBase;
using Monte_Karlo.Models;
using Monte_Karlo.Utilites;
using Monte_Karlo.Utilites.Calculators;
using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    internal class Program
    {
        private static DatabaseHelper _bd;
        private static PointsGenerator _pg = new PointsGenerator();
        private static Stopwatch[] stopwatchs = new Stopwatch[7];

        static void Main(string[] args)
        {
            new GeneratePointsTest().GeneratePoints_CheckCorrectWorkWithStartParametrs_ReturnCorrectResult();
            Console.WriteLine("Finish");
            Console.ReadLine();
        }

        public class GeneratePointsTest
        {
            private Circle circle = new Circle();
            private int pointsCount = 100_000;
            public void GeneratePoints_CheckCorrectWorkWithStartParametrs_ReturnCorrectResult()
            {
                // Arrange
                double expectedRealSquer = 10.1096d;
                double expectedMonteCarloPercentError = 0.05d;
                double expectedDelta = expectedRealSquer * expectedMonteCarloPercentError;

                // Act
                var currentPoints = LocalGenerator(circle, pointsCount);
                double realSquare = Calculator.CalculateAnalyticArea(circle);
                var roundedRealSquare = Math.Round(realSquare, 4);

                double monteCarloSquare = Calculator.CalculateMonteCarloArea(
                    circle.radius,
                    currentPoints.Points.Count,
                    currentPoints.CuttedPoints.Count);
                var roundedMonteCarloSquare = Math.Round(monteCarloSquare, 4);

                // Assert
                Assert.AreEqual(expectedRealSquer, realSquare, 0.001);
                Assert.AreEqual(realSquare, monteCarloSquare, expectedDelta);
            }

            private PointsData LocalGenerator(Circle circle, int count)
            {
                var newPoints = new PointsData();
                newPoints.Points = new List<PointF>(count);

                float radius = circle.radius;

                var parallelOptions = new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                LocalGeneratePoints(newPoints, count, radius, parallelOptions);
                CalculateIncludedPoints(newPoints, radius, parallelOptions);
                CalculateCuttedPoints(newPoints, circle, parallelOptions);

                return newPoints;
            }

            private static void LocalGeneratePoints(PointsData pointsData, int count, float radius, ParallelOptions parallelOptions)
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
}
