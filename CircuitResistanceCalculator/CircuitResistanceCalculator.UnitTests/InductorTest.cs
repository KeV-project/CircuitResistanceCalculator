using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace CircuitResistanceCalculator.UnitTests
{
    [TestFixture]
    class InductorTest
	{
        [Test(Description = "Позитивный тест конструктора Indector")]
        public void TestConstructor_CorrectValue()
        {
            // arrange
            int expectedId = 0;
            int expectedIndex = 0;
            double expectedValue = 1000.0;

            // act
            Inductor inductor = new Inductor(1000.0);
            int actualId = inductor.Id;
            int actualIndex = inductor.Index;
            double actualValue = inductor.Value;

            // assert
            Assert.AreEqual(expectedId, actualId, "Конструктор неверно " +
                "инициализирует свойство Id");
            Assert.AreEqual(expectedIndex, actualIndex, "Конструктор неверно " +
                "инициализирует свойство Index");
            Assert.AreEqual(expectedValue, actualValue, "Конструктор неверно " +
                "инициализирует свойство Value");
        }

        [Test(Description = "Позитивный тест метода CalculateZ")]
        public void TestCalculateZ_CorrectValue()
        {
            // arrenge
            Inductor inductor = new Inductor(0.016);
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
