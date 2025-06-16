using Monte_Karlo.DataBase;
using Monte_Karlo.Models;
using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            int totalPoints = 100;
            for (int i = 0; i < 10; i++)
                DatabaseHelper.SaveResults(circle, totalPoints, 50, 45, 1, 1);
            var result = DatabaseHelper.GetData(circle, totalPoints);
            Console.WriteLine(result);
            foreach (var item in result.Results)
            { 
                Console.WriteLine($"{item.Id:d4} - {item.PointsInSegment}");
            }
            Console.ReadLine();

            var context = new AppDbContext();
            context.Database.EnsureDeleted();
        }
    }
}
