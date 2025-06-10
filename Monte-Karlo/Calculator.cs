using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo
{
    public class Calculator
    {
        // расчет площади сегмента через интеграл
        public static double CalculateIntegralArea(Point center, double R, Direction direction,
            double C, double steps = 10000)
        {
            double sum = 0;
            if (direction == Direction.horizontal)
            {
                double start = center.Y - R, end = center.Y + R;
                if (C < center.Y)
                    start = C;
                else
                    end = C;
                sum = GetIntegral(start, end, (t) => 2 * Math.Sqrt(Math.Pow(R, 2) - Math.Pow(t - center.Y, 2)));
            }
            else if (direction == Direction.vertical)
            {
                double start = center.X - R, end = center.X + R;
                if (C < center.X)
                    start = C;
                else
                    end = C;
                sum = GetIntegral(start, end, (t) => 2 * Math.Sqrt(Math.Pow(R, 2) - Math.Pow(t - center.X, 2)));
            }
            return sum;
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

        public static double CalculateAnalyticArea(Point Center, double R, Direction direction, double C)
        {
            if (R == 0)
                throw new ArgumentException("R == 0");

            if (direction == Direction.horizontal)
            {
                double yLine = C;
                double d = Math.Abs(yLine - Center.Y);  // расстояние от центра до линии
                double h = Math.Abs(R - d);             // расстояние от линии до окружности

                if (d >= R)
                    return (yLine > Center.Y) ? 0 : Math.PI * R * R;
                if (d == h)
                    return Math.PI * R * R / 2;

                double segmentArea = GetSegmentArea(R, d);
                return (yLine > Center.Y) ? 
                    Math.PI * R * R - segmentArea : 
                    segmentArea;
            }
            else
            {
                double xLine = C;
                double h = Math.Abs(Center.X - xLine);  // расстояние от центра до линии
                double d = Math.Abs(R - h);             // расстояние от линии до окружности

                if (d >= R)
                    return (xLine > Center.X) ? 0 : Math.PI * R * R;
                if (d == h)
                    return Math.PI * R * R / 2;

                double segmentArea = GetSegmentArea(R, d);
                return (xLine > Center.Y) ?
                    Math.PI * R * R - segmentArea :
                    segmentArea;
            }
        }

        // https://en.wikipedia.org/wiki/Circular_segment
        private static double GetSegmentArea(double R, double d)
        {
            return R * R * Math.Acos(d / R) - d * Math.Sqrt(R * R - d * d);
        }

        public static double CircleSuare(double R) => Math.PI * R * R;

        public static double CalculateMonteCarloArea(float radius)
        {
            int allPoints = PointsGenerator.Points.Count;
            int cuttedPoints = PointsGenerator.CuttedPoints.Count;
            double squareArea = Math.Pow(radius * 2, 2);
            return cuttedPoints / (double)allPoints * squareArea;
        }
    }
}
