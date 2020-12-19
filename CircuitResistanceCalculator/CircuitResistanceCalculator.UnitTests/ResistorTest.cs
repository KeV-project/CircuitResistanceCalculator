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
    public class ResistorTest
    {
        [Test(Description = "Позитивный тест конструктора Resistor")]
        public void TestConstructor_CorrectValue()
        {
            // arrange
            int expectedId = 2;
            int expectedIndex = 1;
            double expectedValue = 2000.0;

            // act
            Resistor resistor = (Resistor)InitCircuit.Circuit.Connection[0];
            int actualId = resistor.Id;
            int actualIndex = resistor.Index;
            double actualValue = resistor.Value;

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
            Resistor resistor = (Resistor)InitCircuit.Circuit.Connection[0];
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
