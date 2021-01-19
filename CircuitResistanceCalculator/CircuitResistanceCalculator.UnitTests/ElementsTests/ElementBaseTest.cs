using System;
using NUnit.Framework;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

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
			Resistor resistor = new Resistor(2000, expectedIndex);
			
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
				Resistor resistor = new Resistor(2000.0, inCorrectIndex);
			}, "Должно возникать исключение если новый индек элемента " +
			"не входит в диапазон [0, 2147483647]");
		}

		[Test(Description = "Позитивный тест геттера Value")]
		public void TestGetValaue_CorrectValue()
		{
			// setup
			double expectedValue = 2000.0;
			Resistor resistor = new Resistor(expectedValue, 1);
			
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
			SerialConnection serialConnection = new SerialConnection();
			ElementBase currentElement = new Resistor(2000.0, 1);
			serialConnection.AddNode(currentElement);
			ElementBase newElement = new Inductor(0.005, 1);

			// act
			currentElement.ReplaceNode(newElement);

			// assert
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newElement, 
				nameof(ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newElement, 
				nameof(ElementBase.NodeRemoved));

			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(currentElement, 
					nameof(ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(currentElement, 
					nameof(ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");

		}

		[Test(Description = "Негативный тест метода ReplaceNode")]
		public void TestChangeElement_IncorrectValue()
		{
			// setup
			SerialConnection serialConnection = new SerialConnection();
			ElementBase currentElement = new Resistor(1000.0, 1);
			serialConnection.AddNode(currentElement);
			ElementBase newElement = new Resistor(2000.0, 1);

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
			SerialConnection serialConnection = new SerialConnection();
			ElementBase removedElement = new Resistor(1000.0, 1);
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
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
					removedElement, nameof(ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
					removedElement, nameof(ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}

		[Test(Description = "Позитивный тест метода CompareTo")]
		public void TestCompareTo_CorrectValue()
		{
			// setup
			Resistor resistor1 = new Resistor(1000, 1);
			Resistor resistor2 = new Resistor(1000, 1);

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
			Resistor resistor = new Resistor(1000, 1);
			Inductor inductor = new Inductor(0.016, 1);

			int expectedCompareResult = 0;

			// act
			int actualCompareResult = resistor.CompareTo(inductor);

			// assert
			Assert.AreEqual(expectedCompareResult, actualCompareResult,
				"Метод неверно сравнивает идентичные элементы");
		}
	}
}
