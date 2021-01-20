using NUnit.Framework;
using System.Numerics;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculator.UnitTests.ElementsTests
{
    [TestFixture]
    public class ResistorTest
    {
        [Test(Description = "Позитивный тест конструктора Resistor")]
        public void TestConstructor_CorrectValue()
        {
            // setup
            int expectedIndex = 1;
            double expectedValue = 2000.0;

            // act
            Resistor resistor = new Resistor(expectedValue, expectedIndex);
            int actualIndex = resistor.Index;
            double actualValue = resistor.Value;

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
            Resistor resistor = new Resistor(2000.0, 1);
            Complex expectedZ = new Complex(2000.0, 0);

            // act
            double frequency = 50;
            Complex actualZ = resistor.CalculateZ(frequency);

            // assert
            Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
                "рассчитывает комплексное сопротивление резистора");
		}
    }
}
