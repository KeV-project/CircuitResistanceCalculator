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
	class ElementBaseTest
	{
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

		[Test(Description = "Позитивный тест метода ChangeElement")]
		public void TestChangeElement_CorrectValue()
		{
			// arrange
			Resistor expectedCurrentElement = new Resistor(1000.0);
			Capacitor expectedNewElement = new Capacitor(2000.0);

			bool eventRaised = false;
			ElementBase actualCurrentElement = null;
			ElementBase actualNewElement = null;
			expectedCurrentElement.NodeChanged += delegate (object node,
				ChangeNodeArgs e)
			{
				eventRaised = true;
				actualCurrentElement = (ElementBase)node;
				actualNewElement = (ElementBase)e.Node;
			};

			// act
			expectedCurrentElement.ChangeElement(expectedNewElement);

			// assert
			Assert.IsTrue(eventRaised, "Должно вызываться " +
				"событие NodeChanged");
			Assert.AreEqual(expectedCurrentElement, actualCurrentElement,
				"В обработчик события должен передаваться заменяемый объект");
			Assert.AreEqual(expectedNewElement, actualNewElement,
				"В обработчик события должен передаваться новый объект");
		}

		[Test(Description = "Негативный тест метода ChangeElement")]
		public void TestChangeElement_IncorrectValue()
		{
			// arrenge
			Resistor currentElement = new Resistor(1000.0);
			Resistor newElement = new Resistor(2000.0);

			double expectedValue = 2000.0;

			// act
			currentElement.ChangeElement(newElement);
			double actualValue = currentElement.Value;

			// assert
			Assert.AreEqual(expectedValue, actualValue, "Метод " +
				"ChangeElement неверно обрабатывает случай передачи " +
				"в качестве параметров элементов, имеющих одинаковый тип");

		}

		[Test(Description = "Позитивный тест метода RemoveNode")]
		public void TestRemoveNode_CorrectValue()
		{
			// arrenge
			Resistor resistor = new Resistor(1000.0);

			bool eventRaised = false;
			resistor.NodeRemoved += delegate (object node, EventArgs e)
			{
				eventRaised = true;
			};

			// act
			resistor.RemoveNode();

			// assert
			Assert.IsTrue(eventRaised, "Событие должно вызывать обработчик");
		}
	}
}
