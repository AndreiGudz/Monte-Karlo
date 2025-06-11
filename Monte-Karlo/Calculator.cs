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
        public static double CalculateAnalyticArea(Circle circle)
        {
            Point center = circle.circleCenter;
            double R = circle.radius;
            Direction direction = circle.direction;
            double C = circle.C;

            if (R == 0)
                throw new ArgumentException("R == 0");

            if (direction == Direction.horizontal)
            {
                double yLine = C;
                double d = Math.Abs(yLine - center.Y);  // расстояние от центра до хорды
                double h = Math.Abs(R - d);             // расстояние от хорды до окружности
                double CircleArea = Math.PI * R * R;

                if (d >= R)
                    return CircleArea;
                if (h == R)
                    return CircleArea / 2;

                double segmentArea = GetSegmentArea(R, d);
                return CircleArea - segmentArea;
            }
            else
            {
                double xLine = C;
                double h = Math.Abs(center.X - xLine);  // расстояние от центра до хорды
                double d = Math.Abs(R - h);             // расстояние от хорды до окружности

                if (d >= R)
                    return (xLine > center.X) ? 0 : Math.PI * R * R;
                if (h == R)
                    return Math.PI * R * R / 2;

                double segmentArea = GetSegmentArea(R, d);
                return Math.PI * R * R - segmentArea;
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
