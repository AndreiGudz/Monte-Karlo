// Статический класс для вычисление статистических характеристик выборки

namespace Monte_Karlo.Utilites.Calculators
{
    public static class StatisticCalculator
    {
        // Медиана
        public static double CalculateMedian(List<double> values)
        {
            var sorted = values.OrderBy(x => x).ToList();
            int count = sorted.Count;

            if (count % 2 == 0)
                return (sorted[count / 2 - 1] + sorted[count / 2]) / 2;
            else
                return sorted[count / 2];
        }

        // Мода
        public static double CalculateMode(List<double> values)
        {
            return values.GroupBy(x => x)
                       .OrderByDescending(g => g.Count())
                       .First()
                       .Key;
        }

        // Дисперсия
        public static double CalculateVariance(List<double> values)
        {
            double mean = values.Average();
            return values.Average(Xi => Math.Pow(mean - Xi, 2));
        }

        // Среднее отклонение
        public static double CalculateStandardDeviation(double variance)
        {
            return Math.Sqrt(variance);
        }

        // Среднее отклонение через список
        public static double CalculateStandardDeviation(List<double> values)
        {
            return CalculateStandardDeviation(CalculateVariance(values));
        }

        // Размах выборки
        public static double CalculateRange(List<double> values) => values.Max() - values.Min();
    }
}
