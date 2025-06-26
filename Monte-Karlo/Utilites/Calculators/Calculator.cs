// Статистический класс для вычисления площади большего сегмента окружности
// Методы для аналитического вычисления площади и методом Монте-Карло
// Также вспомогательные методы с вычислениями
using Monte_Karlo.Models;

namespace Monte_Karlo.Utilites.Calculators
{
    public static class Calculator
    {
        // Вычисление площади большего сектора аналитически
        public static double CalculateAnalyticArea(Circle circle)
        {
            Point center = circle.circleCenter;
            double R = circle.radius;
            Direction direction = circle.direction;
            double C = circle.C;

            if (R <= 0)
                throw new ArgumentException("R <= 0");

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

        // Вычисление площади сектора окружности
        // ссылка на формулу https://en.wikipedia.org/wiki/Circular_segment
        private static double GetSegmentArea(double R, double d)
        {
            return R * R * Math.Acos(d / R) - d * Math.Sqrt(R * R - d * d);
        }

        // Площадь круга
        public static double CircleSuare(double R) => Math.PI * R * R;

        // Вычисление площади большего сектора методом Монте-Карло
        public static double CalculateMonteCarloArea(float radius, int allPoints, int cuttedPoints)
        {
            double squareArea = 4 * radius * radius;
            return cuttedPoints / (double)allPoints * squareArea;
        }

        // Вычисление абсолютной погрешности
        public static double CalculateAbsoluteError(double expectedResult, double actualResult)
        {
            var result = expectedResult - actualResult;
            result = RoundToTwoSignificantDigits(result, 2);
            return result;
        }

        // Вычисление относительной погрешности
        public static double CalculateRelativeError(double expectedResult, double actualResult)
        {
            if (expectedResult <= 0)
                throw new ArgumentException("Ожидаемое значение не может быть <= 0");
            if (actualResult < 0)
                throw new ArgumentException("Полученное значение не может быть < 0");
            var result = Math.Abs(CalculateAbsoluteError(expectedResult, actualResult)) / expectedResult * 100d;
            result = RoundToTwoSignificantDigits(result, 2);
            return result;
        }

        // Округление до определённого количества значащих цифр
        public static double RoundToTwoSignificantDigits(double value, int significantDigits)
        {
            if (value == 0.0)
                return 0.0;

            int log10 = (int)Math.Floor(Math.Log10(Math.Abs(value)));
            double scale = Math.Pow(10, significantDigits - log10 - 1);
            double rounded = Math.Round(value * scale) / scale;
            return rounded;
        }
    }
}
