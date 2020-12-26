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
			// arrange
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
			// arrange
			double expectedValue = 2000.0;
			Resistor resistor = new Resistor(expectedValue, 1);
			

			// act
			double actualValue = resistor.Value;

			// assert
			Assert.AreEqual(expectedValue, actualValue, "Геттер Value " +
				"возвращает некорректное значение");
		}

		[Test(Description = "Позитивный тест метода ChangeElement")]
		public void TestChangeElement_CorrectValue()
		{
			// arrange
			SerialConnection serialConnection = new SerialConnection();
			ElementBase currentElement = new Resistor(2000.0, 1);
			serialConnection.AddNode(currentElement);
			ElementBase newElement = new Inductor(0.005, 1);

			// act
			currentElement.ChangeElement(newElement);

			// assert
			HelperMethods.VerifyDelegateAttachedTo(newElement, 
				nameof(ElementBase.ValueChanged));
			HelperMethods.VerifyDelegateAttachedTo(newElement, 
				nameof(ElementBase.NodeChanged));
			HelperMethods.VerifyDelegateAttachedTo(newElement, 
				nameof(ElementBase.NodeRemoved));

			Assert.Throws<ArgumentNullException>(()=>
			{
				HelperMethods.VerifyDelegateAttachedTo(currentElement, 
					nameof(ElementBase.ValueChanged));
			}, "Событие ValueChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(currentElement, 
					nameof(ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(currentElement, 
					nameof(ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");

		}

		//[Test(Description = "Негативный тест метода ChangeElement")]
		//public void TestChangeElement_IncorrectValue()
		//{
		//	// arrenge
		//	Resistor currentElement = 
		//		(Resistor)InitCircuit.Circuit.Connection[6];
		//	Resistor newElement = new Resistor(1500.0);

		//	double expectedValue = 1500.0;

		//	// act
		//	currentElement.ChangeElement(newElement);
		//	double actualValue = currentElement.Value;

		//	// assert
		//	Assert.AreEqual(expectedValue, actualValue, "Метод " +
		//		"ChangeElement неверно обрабатывает случай передачи " +
		//		"в качестве параметров элементов, имеющих одинаковый тип");

		//}

		//[Test(Description = "Позитивный тест метода RemoveNode")]
		//public void TestRemoveNode_CorrectValue()
		//{
		//	// arrenge
		//	NodeBase removedElement = InitCircuit.Circuit.Connection[7];
		//	// act
		//	removedElement.RemoveNode();

		//	// assert
		//	Assert.Throws<ArgumentOutOfRangeException>(() =>
		//	{
		//		InitCircuit.Circuit.Connection[7].RemoveNode();
		//	},
		//	"Должно возникать исключение при обращении к несущестующему элементу");
		//	Assert.IsTrue(((ElementBase)removedElement).IsValueChangedNull(),
		//		"Событие ValueChanged должно быть отписано от обработчика");
		//	Assert.IsTrue(((ElementBase)removedElement).IsNodeChangedNull(),
		//		"Событие NodeChanged должно быть отписано от обработчика");
		//	Assert.IsTrue(((ElementBase)removedElement).IsNodeRemovedNull(),
		//		"Событие NodeRemoved должно быть отписано от обработчика");
		//}
	}
}
