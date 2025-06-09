using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo
{
    public static class MonteCarloCalculator
    {
        public static List<PointF> Points { get; private set; } = new();

        public static void GenerateRandomPoints(float radius, int count)
        {
            var random = new Random();

            Points.Clear();
            Points = new List<PointF>(count);

            for (int i = 0; i < count; i++)
            {
                float x = (float)random.NextDouble() * radius * 2;
                float y = (float)random.NextDouble() * radius * 2;
                Points.Add(new PointF(x, y));
            }
        }
    }
}
