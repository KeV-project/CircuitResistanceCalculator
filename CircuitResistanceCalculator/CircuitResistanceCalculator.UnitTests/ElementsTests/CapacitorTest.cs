using System;
using NUnit.Framework;
using System.Numerics;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculator.UnitTests.ElementsTests
{
	[TestFixture]
	class CapacitorTest
    { 
        [Test(Description = "Позитивный тест конструктора Capacitor")]
        public void TestConstructor_CorrectValue()
        {
            // setup
            int expectedIndex = 1;
            double expectedValue = 0.00022116;

            // act
            Capacitor capacitor = new Capacitor(expectedValue, 
                expectedIndex);
            int actualIndex = capacitor.Index;
            double actualValue = capacitor.Value;

            // assert
            Assert.AreEqual(expectedIndex, actualIndex, "Конструктор " +
                "неверно инициализирует свойство Index");
            Assert.AreEqual(expectedValue, actualValue, "Конструктор " +
                "неверно инициализирует свойство Value");
        }

        [Test(Description = "Позитивный тест метода CalculateZ")]
        public void TestCalculateZ_CorrectValue()
        {
            // setup
            Capacitor capacitor = new Capacitor(0.00022116, 1) ;
            Complex expectedZ = new Complex(0, 14.4);

            // act
            double frequency = 50;
            Complex actualZ = capacitor.CalculateZ(frequency);
            actualZ = new Complex(actualZ.Real, 
                Math.Round(actualZ.Imaginary, 1));

            // assert
            Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
                "рассчитывает комплексное сопротивление конденсатора");
        }
    }
}
