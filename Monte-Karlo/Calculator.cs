using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo
{
    public enum Direction 
    { 
        horizontal,
        vertical
    }
    public class Calculator
    {
        // Аналитический расчет площади сегмента
        public static double CalculateAnalyticArea(double x0, double y0, double R, Direction direction,
            double C, double steps = 100000000)
        {
            double sum = 0;
            if (direction == Direction.horizontal)
            {
                double yLine = C;
                double start = y0 - R, end = y0 + R;
                if (C <= y0)
                    start = C;
                else
                    end = C;
                double stepSize = (end - start) / steps;
                sum = GetIntegral(start, end, (t) => 2 * Math.Sqrt(Math.Pow(R, 2) - Math.Pow(t - y0, 2)));
            }
            else if (direction == Direction.vertical)
            {
                double xLine = C;
                double start = x0 - R, end = x0 + R;
                if (C <= x0)
                    start = C;
                else
                    end = C;
                double stepSize = (end - start) / steps;
                sum = GetIntegral(start, end, (t) => 2 * Math.Sqrt(Math.Pow(R, 2) - Math.Pow(t - x0, 2)));
            }
            return sum;
        }



        // Метод Монте-Карло для оценки площади
        public static double CalculateMonteCarloArea(double x0, double y0, double R, Direction direction, double C, int iterations)
        {
            throw new NotImplementedException();
            Random rand = new Random();
            int hits = 0;
            double xMin = x0 - R, xMax = x0 + R;
            double yMin = y0 - R, yMax = y0 + R;

            for (int i = 0; i < iterations; i++)
            {
                double x = xMin + rand.NextDouble() * (xMax - xMin);
                double y = yMin + rand.NextDouble() * (yMax - yMin);

                bool inCircle = Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2) <= R * R;
                bool inSegment = false;

                if (direction == Direction.horizontal)
                    inSegment = (C > y0) ? (y <= C) : (y >= C);
                else if (direction == Direction.vertical)
                    inSegment = (C > x0) ? (x <= C) : (x >= C);

                if (inCircle && inSegment)
                    hits++;
            }

            double boundingArea = (xMax - xMin) * (yMax - yMin);
            return boundingArea * hits / iterations;
        }

        public static double GetIntegral(double start, double end, Func<double, double> func, double steps = 10000)
        {
            if (start > end)
            {
                return -GetIntegral(end, start, func, steps);
            }
            double stepSize = (end - start) / steps;
            double sum = 0.0;
            for (int i = 0; i < steps; i++)
            {
                double x = start + (i + 0.5) * stepSize;
                sum += func(x) * stepSize;
            }
            return sum;
        }
    }
}
