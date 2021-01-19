using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace CircuitResistanceCalculator.UnitTests.ElementsTests
{
	[TestFixture]
	class ElementBaseTest
	{
		[Test(Description = "Позитивный тест геттера Index")]
		public void TestGetIndex_CorrectValue()
		{
			// setup
			int expectedIndex = 1;
			Elements.Resistor resistor = 
				new Elements.Resistor(2000, expectedIndex);
			
			// act
			int actualIndex = resistor.Index;

			// assert
			Assert.AreEqual(expectedIndex, actualIndex, "Геттер Index " +
				"возвращает некорректное значение");
		}

		[Test(Description = "Негативный тест сеттера Index")]
		public void TestSetIndex_IncorrectValue()
		{
			// setup
			int inCorrectIndex = -5;

			// assert
			Assert.Throws<ArgumentException>(() =>
			{
				Elements.Resistor resistor = 
				new Elements.Resistor(2000.0, inCorrectIndex);
			}, "Должно возникать исключение если новый индек элемента " +
			"не входит в диапазон [0, 2147483647]");
		}

		[Test(Description = "Позитивный тест геттера Value")]
		public void TestGetValaue_CorrectValue()
		{
			// setup
			double expectedValue = 2000.0;
			Elements.Resistor resistor = 
				new Elements.Resistor(expectedValue, 1);
			
			// act
			double actualValue = resistor.Value;

			// assert
			Assert.AreEqual(expectedValue, actualValue, "Геттер Value " +
				"возвращает некорректное значение");
		}

		[Test(Description = "Позитивный тест метода ReplaceNode")]
		public void TestChangeElement_CorrectValue()
		{
			// setup
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();
			Elements.ElementBase currentElement = 
				new Elements.Resistor(2000.0, 1);
			serialConnection.AddNode(currentElement);
			Elements.ElementBase newElement = 
				new Elements.Inductor(0.005, 1);

			// act
			currentElement.ReplaceNode(newElement);

			// assert
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newElement, 
				nameof(Elements.ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newElement, 
				nameof(Elements.ElementBase.NodeRemoved));

			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(currentElement, 
					nameof(Elements.ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(currentElement, 
					nameof(Elements.ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");

		}

		[Test(Description = "Негативный тест метода ReplaceNode")]
		public void TestChangeElement_IncorrectValue()
		{
			// setup
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();
			Elements.ElementBase currentElement = 
				new Elements.Resistor(1000.0, 1);
			serialConnection.AddNode(currentElement);
			Elements.ElementBase newElement = 
				new Elements.Resistor(2000.0, 1);

			double expectedValue = 2000.0;

			// act
			currentElement.ReplaceNode(newElement);
			double actualValue = currentElement.Value;

			// assert
			Assert.AreEqual(expectedValue, actualValue, "Метод " +
				"ChangeElement неверно обрабатывает попытку " +
				"заменить текущий элемент объектом того же типа");
		}

		[Test(Description = "Позитивный тест метода RemoveNode")]
		public void TestRemoveNode_CorrectValue()
		{
			// setup
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();
			Elements.ElementBase removedElement = 
				new Elements.Resistor(1000.0, 1);
			serialConnection.AddNode(removedElement);

			int expectedSerialConnectionNodesCount = 0;

			// act
			removedElement.RemoveNode();

			int actualSerialConnectionNodesCount = serialConnection.NodesCount;

			// assert
			Assert.AreEqual(expectedSerialConnectionNodesCount, 
				actualSerialConnectionNodesCount, "Метод не удаляет элемент " +
				"из списка родительского узла");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(removedElement,
					nameof(Elements.ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(removedElement,
					nameof(Elements.ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}

		[Test(Description = "Позитивный тест метода CompareTo")]
		public void TestCompareTo_CorrectValue()
		{
			// setup
			Elements.Resistor resistor1 = new Elements.Resistor(1000, 1);
			Elements.Resistor resistor2 = new Elements.Resistor(1000, 1);

			int expectedCompareResult = 1;

			// act
			int actualCompareResult = resistor1.CompareTo(resistor2);

			// assert
			Assert.AreEqual(expectedCompareResult, actualCompareResult, 
				"Метод неверно сравнивает идентичные элементы");
		}

		[Test(Description = "Негативный тест метода CompareTo")]
		public void TestCompareTo_IncorrectValue()
		{
			// setup
			Elements.Resistor resistor = new Elements.Resistor(1000, 1);
			Elements.Inductor inductor = new Elements.Inductor(0.016, 1);

			int expectedCompareResult = 0;

			// act
			int actualCompareResult = resistor.CompareTo(inductor);

			// assert
			Assert.AreEqual(expectedCompareResult, actualCompareResult,
				"Метод неверно сравнивает идентичные элементы");
		}
	}
}
