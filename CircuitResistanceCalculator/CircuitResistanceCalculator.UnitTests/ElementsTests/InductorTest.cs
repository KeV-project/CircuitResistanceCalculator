using NUnit.Framework;
using System.Numerics;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculator.UnitTests.ElementsTests
{
    [TestFixture]
    class InductorTest
	{
        [Test(Description = "Позитивный тест конструктора Indector")]
        public void TestConstructor_CorrectValue()
        {
            // setup
            int expectedIndex = 1;
            double expectedValue = 0.016;

            // act
            Inductor inductor = new Inductor(expectedValue, expectedIndex);
            int actualIndex = inductor.Index;
            double actualValue = inductor.Value;

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
            Inductor inductor = new Inductor(0.016, 1);
            Complex expectedZ = new Complex(0, 5.024);

            // act
            double frequency = 50;
            Complex actualZ = inductor.CalculateZ(frequency);

            // assert
            Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
                "рассчитывает комплексное сопротивление индуктора");
        }
    }
}
