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
	class CapacitorTest
    { 
        [Test(Description = "Позитивный тест конструктора Capacitor")]
        public void TestConstructor_CorrectValue()
        {
            // arrange
            int expectedId = 4;
            int expectedIndex = 1;
            double expectedValue = 0.00022116;

            // act
            Capacitor capacitor = (Capacitor)InitCircuit.Circuit.Connection[2];
            int actualId = capacitor.Id;
            int actualIndex = capacitor.Index;
            double actualValue = capacitor.Value;

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
            Capacitor capacitor = (Capacitor)InitCircuit.Circuit.Connection[2];
            Complex expectedZ = new Complex(0, -14.4);

            // act
            double frequency = 50;
            Complex actualZ = capacitor.CalculateZ(frequency);

            // assert
            Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
                "рассчитывает комплексное сопротивление конденсатора");
        }
    }
}
