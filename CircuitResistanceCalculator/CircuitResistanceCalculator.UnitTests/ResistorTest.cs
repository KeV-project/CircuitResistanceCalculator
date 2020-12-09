using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CircuitResistanceCalculator;
using System.Numerics;

namespace CircuitResistanceCalculator.UnitTests
{
    [TestFixture]
    public class ResistorTest
    {
        //[Test(Description = "Позитивный тест геттера Id")]
        //public void TestIdGet_CorrectValue()
        //{
        //    // arrange
        //    Resistor resistor = new Resistor(1000.0);
        //    resistor.SetId();
        //    int expected = 1;

        //    // act
        //    int actual = resistor.Id;

        //    // assert
        //    Assert.AreEqual(expected, actual, "Геттер Id " +
        //        "возвращает некорректное значение");
        //}

        //[Test(Description = "Негативный тест метода SetId")]
        //public void TestSetId_IncorrectValue()
        //{
        //    // arrange
        //    Resistor resistor = new Resistor(1000.0);
        //    resistor.SetId();
        //    int expected = 2;

        //    // act
        //    resistor.SetId();
        //    int actual = resistor.Id;

        //    // assert
        //    Assert.AreEqual(expected, actual, "Метод SetId " +
        //        "не должен переопределять Id элемента");
        //}

        //[Test(Description = "Позитивный тест геттера Index")]
        //public void TestGetIndex_CorrectValue()
        //{
        //    // arrange
        //    Resistor resistor = new Resistor(1000.0);
        //    resistor.Index = 2;
        //    int expected = 2;

        //    // act
        //    int actual = resistor.Index;

        //    // assert
        //    Assert.AreEqual(expected, actual, "Геттер Index " +
        //        "возвращает некорректное значение");

        //}

        //[Test(Description = "Негативный тест сеттера Index")]
        //public void TestSetIndex_IncorrectValue()
        //{
        //    // arrange
        //    Resistor resistor = new Resistor(1000.0);

        //    // assert
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        resistor.Index = -1;
        //    }, "Должно возникать исключение если новый индек элемента " +
        //    "не входит в диапазон [0, 2147483647]");
        //}

        //[Test(Description = "Позитивный тест геттера Value")]
        //public void TestGetValaue_CorrectValue()
        //{
        //    // arrange
        //    Resistor resistor = new Resistor(1000.0);
        //    double expected = 1000.0;

        //    // act
        //    double actual = resistor.Value;

        //    // assert
        //    Assert.AreEqual(expected, actual, "Геттер Value " +
        //        "возвращает некорректное значение");
        //}

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

  //      [Test(Description = "Позитивный тест метода ChangeElement")]
  //      public void TestChangeElement_CorrectValue()
  //      {
  //          // arrange
  //          Resistor expectedCurrentElement = new Resistor(1000.0);
  //          Capacitor expectedNewElement = new Capacitor(2000.0);

  //          bool eventRaised = false;
  //          ElementBase actualCurrentElement = null;
  //          ElementBase actualNewElement = null;
  //          expectedCurrentElement.NodeChanged += delegate (object node,
  //              ChangeNodeArgs e)
  //          {
  //              eventRaised = true;
  //              actualCurrentElement = (ElementBase)node;
  //              actualNewElement = (ElementBase)e.Node;
  //          };

  //          // act
  //          expectedCurrentElement.ChangeElement(expectedNewElement);

  //          // assert
  //          Assert.IsTrue(eventRaised, "Должно вызываться " +
  //              "событие NodeChanged");
  //          Assert.AreEqual(expectedCurrentElement, actualCurrentElement,
  //              "В обработчик события должен передаваться заменяемый объект");
  //          Assert.AreEqual(expectedNewElement, actualNewElement,
  //              "В обработчик события должен передаваться новый объект");
  //      }

  //      [Test(Description = "Негативный тест метода ChangeElement")]
  //      public void TestChangeElement_IncorrectValue()
  //      {
  //          // arrenge
  //          Resistor currentElement = new Resistor(1000.0);
  //          Resistor newElement = new Resistor(2000.0);

  //          double expectedValue = 2000.0;

  //          // act
  //          currentElement.ChangeElement(newElement);
  //          double actualValue = currentElement.Value;

  //          // assert
  //          Assert.AreEqual(expectedValue, actualValue, "Метод " +
  //              "ChangeElement неверно обрабатывает случай передачи " +
  //              "в качестве параметров элементов, имеющих одинаковый тип");

  //      }

  //      [Test(Description = "Позитивный тест метода RemoveNode")]
  //      public void TestRemoveNode_CorrectValue()
		//{
  //          // arrenge
  //          Resistor resistor = new Resistor(1000.0);

  //          bool eventRaised = false;
  //          resistor.NodeRemoved += delegate (object node, EventArgs e)
  //          {
  //              eventRaised = true;
  //          };

  //          // act
  //          resistor.RemoveNode();

  //          // assert
  //          Assert.IsTrue(eventRaised, "Событие должно вызывать обработчик");
		//}

        [Test(Description = "Позитивный тест метода CalculateZ")]
        public void TestCalculateZ_CorrectValue()
		{
            // arrenge
            Resistor resistor = new Resistor(1000.0);
            Complex expectedZ = new Complex(1000.0, 0);

            // act
            double frequency = 50;
            Complex actualZ = resistor.CalculateZ(frequency);

            // assert
            Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
                "рассчитывает комплексное сопротивление резистора");
		}
    }
}
