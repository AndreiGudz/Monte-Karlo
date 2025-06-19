using Monte_Karlo.Calculators;
using Monte_Karlo.DataBase;
using Monte_Karlo.Models;
using Monte_Karlo.Utilites;
using System;

namespace Test
{
    internal class Program
    {
        private static DatabaseHelper _bd;
        private static PointsGenerator _pg;

        static async Task Main(string[] args)
        {
            _bd = new DatabaseHelper();
            _bd.InitializeDatabase();
            _pg = new PointsGenerator();

            Circle circle = new Circle();
            int totalPoints = 100;
            for (int i = 0; i < 2_000; i++)
            {
                var task = Body(circle, totalPoints);
                Console.WriteLine($"{i}\t");
                await task;

            }

            var context = new AppDbContext();
        }

        private static async Task Body(Circle circle, int totalPoints)
        {
            await _pg.GenerateRandomPointsAsync(circle, totalPoints, new CancellationToken());
            var realSquare = Calculator.CalculateAnalyticArea(circle);
            var monteCarloSquare = Calculator.CalculateMonteCarloArea(
                circle.radius,
                _pg.Points.Count,
                _pg.CuttedPoints.Count);
            _bd.SaveResults(
                circle,
                totalPoints,
                _pg.IncludedPoints.Count,
                _pg.CuttedPoints.Count,
                realSquare,
                monteCarloSquare);
        }
    }
}
