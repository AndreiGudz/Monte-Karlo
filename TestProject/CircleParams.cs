using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monte_Karlo.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestProject
{
    [TestClass]
    public class CircleParamsTests
    {
        // Проверяет, что конструктор по умолчанию инициализирует коллекцию Results
        [TestMethod]
        public void CircleParams_DefaultConstructor_InitializesResultsList()
        {
            // Arrange & Act
            var circleParams = new CircleParams();

            // Assert
            Assert.IsNotNull(circleParams.Results);
            Assert.AreEqual(0, circleParams.Results.Count);
        }

        // Проверяет корректность установки и получения значений всех свойств класса
        [TestMethod]
        public void CircleParams_Properties_CanBeSetAndGet()
        {
            // Arrange
            var circleParams = new CircleParams
            {
                Id = 1,
                CenterX = 2.5,
                CenterY = 3.5,
                Radius = 10,
                Direction = Direction.vertical,
                C = 4.2,
                TotalPoints = 10000,
                AnalyticalResult = 78.54
            };

            // Act & Assert
            Assert.AreEqual(1, circleParams.Id);
            Assert.AreEqual(2.5, circleParams.CenterX);
            Assert.AreEqual(3.5, circleParams.CenterY);
            Assert.AreEqual(10, circleParams.Radius);
            Assert.AreEqual(Direction.vertical, circleParams.Direction);
            Assert.AreEqual(4.2, circleParams.C);
            Assert.AreEqual(10000, circleParams.TotalPoints);
            Assert.AreEqual(78.54, circleParams.AnalyticalResult);
        }

        // Проверяет возможность добавления элементов в коллекцию Results
        [TestMethod]
        public void CircleParams_Results_CanBeAdded()
        {
            // Arrange
            var circleParams = new CircleParams();
            var result = new SimulationResult { Id = 1 };

            // Act
            circleParams.Results.Add(result);

            // Assert
            Assert.AreEqual(1, circleParams.Results.Count);
            Assert.AreEqual(1, circleParams.Results[0].Id);
        }

        // Проверяет, что метод ToString возвращает строку с ожидаемым форматом и данными
        [TestMethod]
        public void CircleParams_ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var circleParams = new CircleParams
            {
                Id = 1,
                CenterX = 2.5,
                CenterY = 3.5,
                Radius = 10,
                Direction = Direction.vertical,
                C = 4.2,
                TotalPoints = 10000,
                AnalyticalResult = 78.54
            };

            // Act
            var result = circleParams.ToString();

            // Assert
            StringAssert.Contains(result, "Id: 1");
            StringAssert.Contains(result, "CenterX: 2,5");
            StringAssert.Contains(result, "CenterY: 3,5");
            StringAssert.Contains(result, "Radius: 10");
            StringAssert.Contains(result, "Direction: vertical");
            StringAssert.Contains(result, "C: 4,2");
            StringAssert.Contains(result, "TotalPoints: 10000");
            StringAssert.Contains(result, "AnalyticalResult: 78,54");
            StringAssert.Contains(result, "ResultsCount: 0");
        }
    }
}