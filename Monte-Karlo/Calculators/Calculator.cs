using Monte_Karlo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monte_Karlo.Calculators
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
                double d = Math.Abs(center.Y - yLine);  // расстояние от центра до хорды
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
                double d = Math.Abs(center.X - xLine);  // расстояние от центра до хорды
                double h = Math.Abs(R - d);             // расстояние от хорды до окружности
                double CircleArea = Math.PI * R * R;

                if (d >= R)
                    return CircleArea;
                if (h == R)
                    return CircleArea / 2;

                double segmentArea = GetSegmentArea(R, d);
                return CircleArea - segmentArea;
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
            double squareArea = 4 * radius * radius;
            return cuttedPoints / (double)allPoints * squareArea;
        }

        public static double CalculateAbsoluteError(double expectedResult, double actualResult) => expectedResult - actualResult;

        public static double CalculateRelativeError(double expectedResult, double actualResult)
        {
            return Math.Abs(CalculateAbsoluteError(expectedResult, actualResult)) / actualResult * 100d;
        }
    }
}
