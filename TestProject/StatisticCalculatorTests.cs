using Monte_Karlo.Utilites.Calculators;

namespace TestProject
{
    [TestClass]
    public class StatisticCalculatorTests
    {
        // Проверяет правильность вычисления медианы при нечётном количестве элементов
        [TestMethod]
        public void CalculateMedian_ReturnsCorrectForOddCount()
        {
            // Arrange
            var values = new List<double> { 1, 3, 5, 7, 9 };
            double expected = 5;

            // Act
            double result = StatisticCalculator.CalculateMedian(values);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // Проверяет правильность вычисления медианы при чётном количестве элементов
        [TestMethod]
        public void CalculateMedian_ReturnsCorrectForEvenCount()
        {
            // Arrange
            var values = new List<double> { 1, 3, 5, 7, 9, 11 };
            double expected = 6;

            // Act
            double result = StatisticCalculator.CalculateMedian(values);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // Проверяет правильность вычисления моды
        [TestMethod]
        public void CalculateMode_ReturnsMostFrequentValue()
        {
            // Arrange
            var values = new List<double> { 1, 2, 2, 3, 4 };
            double expected = 2;

            // Act
            double result = StatisticCalculator.CalculateMode(values);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // Проверяет правильность вычисления дисперсии
        [TestMethod]
        public void CalculateVariance_ReturnsCorrectValue()
        {
            // Arrange
            var values = new List<double> { 1, 2, 3, 4, 5 };
            double mean = 3;
            double expected = (4 + 1 + 0 + 1 + 4) / 5.0;

            // Act
            double result = StatisticCalculator.CalculateVariance(values);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        // Проверяет правильность вычисления стандартного отклонения при уже вычисленной дисперсии
        [TestMethod]
        public void CalculateStandardDeviation_ReturnsCorrectValue()
        {
            // Arrange
            double variance = 4;
            double expected = 2;

            // Act
            double result = StatisticCalculator.CalculateStandardDeviation(variance);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        // Проверяет правильность вычисления стандартного отклонения
        [TestMethod]
        public void CalculateStandardDeviation_FromList_ReturnsCorrectValue()
        {
            // Arrange
            var values = new List<double> { 1, 2, 3, 4, 5 };
            double variance = 2;
            double expected = Math.Sqrt(variance);

            // Act
            double result = StatisticCalculator.CalculateStandardDeviation(values);

            // Assert
            Assert.AreEqual(expected, result, 0.0001);
        }

        // Проверяет правильность вычисления размаха
        [TestMethod]
        public void CalculateRange_ReturnsDifferenceBetweenMaxAndMin()
        {
            // Arrange
            var values = new List<double> { 1, 5, 3, 9, 2 };
            double expected = 8;

            // Act
            double result = StatisticCalculator.CalculateRange(values);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}