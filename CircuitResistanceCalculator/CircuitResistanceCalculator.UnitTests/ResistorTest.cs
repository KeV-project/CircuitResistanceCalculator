using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CircuitResistanceCalculator;

namespace CircuitResistanceCalculator.UnitTests
{
    [TestFixture]
    public class ResistorTest
    {
        [Test(Description = "Позитивный тест геттера Id")]
        public void TestIdGet_CorrectValue()
        {
            // arrange
            Resistor resistor = new Resistor(1000.0);
            resistor.SetId();
            int expected = 1;

            // act
            int actual = resistor.Id;

            // assert
            Assert.AreEqual(expected, actual, "Геттер Id " +
                "возвращает некорректное значение");
        }

        [Test(Description = "Негативный тест метода SetId")]
        public void TestSetId_IncorrectValue()
        {
            // arrange
            Resistor resistor = new Resistor(1000.0);
            resistor.SetId();
            int expected = 2;

            // act
            resistor.SetId();
            int actual = resistor.Id;

            // assert
            Assert.AreEqual(expected, actual, "Метод SetId " +
                "не должен переопределять Id элемента");
        }

        [Test(Description = "Позитивный тест геттера Index")]
        public void TestGetIndex_CorrectValue()
        {
            // arrange
            Resistor resistor = new Resistor(1000.0);
            resistor.Index = 2;
            int expected = 2;

            // act
            int actual = resistor.Index;

            // assert
            Assert.AreEqual(expected, actual, "Геттер Index " +
                "возвращает некорректное значение");

        }

        [Test(Description = "Негативный тест сеттера Index")]
        public void TestSetIndex_IncorrectValue()
        {
            // arrange
            Resistor resistor = new Resistor(1000.0);

            // assert
            Assert.Throws<ArgumentException>(() =>
            {
                resistor.Index = -1;
            }, "Должно возникать исключение если новый индек элемента " +
            "не входит в диапазон [0, 2147483647]");
        }

        [Test(Description = "Позитивный тест геттера Value")]
        public void TestGetValaue_CorrectValue()
		{
            // arrange
            Resistor resistor = new Resistor(1000.0);
            double expected = 1000.0;

            // act
            double actual = resistor.Value;

            // assert
            Assert.AreEqual(expected, actual, "Геттер Value " +
                "возвращает некорректное значение");
		}

		[Test(Description = "Позитивный тест конструктора Resistor")]
		public void TestConstructor_CorrectValue()
		{
            // arrange
            int expectedId = 0;
            int expectedIndex = 0;
            double expectedValue = 1000.0; 

            // act
            Resistor resistor = new Resistor(1000.0);
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

	}
}
