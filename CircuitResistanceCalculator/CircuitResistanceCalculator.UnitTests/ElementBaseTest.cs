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
			Resistor resistor = (Resistor)InitCircuit.Circuit.Connection[0];
			int expectedIndex = 1;

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
			Resistor resistor = (Resistor)InitCircuit.Circuit.Connection[0];

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
			Resistor resistor = (Resistor)InitCircuit.Circuit.Connection[0];
			double expectedValue = 2000.0;

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
			ElementBase currentElement = 
				(ElementBase)InitCircuit.Circuit.Connection[5];
			ElementBase expectedNewElement = new Inductor(0.03);

			// act
			currentElement.ChangeElement(expectedNewElement);
			ElementBase actualNewElement = 
				(ElementBase)InitCircuit.Circuit.Connection[5];

			// assert
			Assert.AreEqual(expectedNewElement, actualNewElement, 
				"Метод неккоректно производит замену элементов");

			Assert.IsTrue(currentElement.IsValueChangedNull(),
				"Событие ValueChanged должно быть отписано от обработчика");
			Assert.IsTrue(currentElement.IsNodeChangedNull(),
				"Событтие NodeChanged должно быть отписано от обработчика");
			Assert.IsTrue(currentElement.IsNodeRemovedNull(),
				"Событие NodeRemoved должно быть отписано от обработчика");

			Assert.IsFalse(actualNewElement.IsValueChangedNull(), 
				"Событие ValueChanged должно быть подписано на обработчик");
			Assert.IsFalse(actualNewElement.IsNodeChangedNull(), 
				"Событтие NodeChanged должно быть подписано на обработчик");
			Assert.IsFalse(actualNewElement.IsNodeRemovedNull(), 
				"Событие NodeRemoved должно быть подписано на обработчик");

		}

		[Test(Description = "Негативный тест метода ChangeElement")]
		public void TestChangeElement_IncorrectValue()
		{
			// arrenge
			Resistor currentElement = 
				(Resistor)InitCircuit.Circuit.Connection[6];
			Resistor newElement = new Resistor(1500.0);

			double expectedValue = 1500.0;

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
			NodeBase removedElement = InitCircuit.Circuit.Connection[7];
			// act
			removedElement.RemoveNode();

			// assert
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				InitCircuit.Circuit.Connection[7].RemoveNode();
			},
			"Должно возникать исключение при обращении к несущестующему элементу");
			Assert.IsTrue(((ElementBase)removedElement).IsValueChangedNull(),
				"Событие ValueChanged должно быть отписано от обработчика");
			Assert.IsTrue(((ElementBase)removedElement).IsNodeChangedNull(),
				"Событие NodeChanged должно быть отписано от обработчика");
			Assert.IsTrue(((ElementBase)removedElement).IsNodeRemovedNull(),
				"Событие NodeRemoved должно быть отписано от обработчика");
		}

		[Test(Description = "Позитивный тест метода IsValueChangedNull")]
		public void IsValueChangedNull_CorrectValue()
		{
			// arrenge
			int circuitConnectionCount = InitCircuit.
				Circuit.Connection.GetNodesCount();
			Resistor resistor = new Resistor(1000.0);
			bool expectedMethodRaised = true;

			// act
			bool actualMethodRaised = resistor.IsValueChangedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Подписка на обработчик события не должны быть зафиксирована");
		}

		[Test(Description = "Негативный тест метода IsValueChangedNull")]
		public void IsValueChangedNull_IncorrectValue()
		{
			// arrenge
			Resistor resistor = (Resistor)InitCircuit.Circuit.Connection[0];
			bool expectedMethodRaised = false;

			// act
			bool actualMethodRaised = resistor.IsValueChangedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Метод не зафиксировал подписку события на обработчик");
		}

		[Test(Description = "Позитивный тест метода IsNodeChangedNull")]
		public void IsNodeChangedNull_CorrectValue()
		{
			// arrenge
			int circuitConnectionCount = InitCircuit.
				Circuit.Connection.GetNodesCount();
			Resistor resistor = new Resistor(1000.0);
			bool expectedMethodRaised = true;

			// act
			bool actualMethodRaised = resistor.IsNodeChangedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Подписка на обработчик события не должны быть зафиксирована");
		}

		[Test(Description = "Негативный тест метода IsNodeChangedNull")]
		public void IsNodeChangedNull_Incorrect()
		{
			// arrenge
			Resistor resistor = (Resistor)InitCircuit.Circuit.Connection[0];
			bool expectedMethodRaised = false;

			// act
			bool actualMethodRaised = resistor.IsNodeChangedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Метод не зафиксировал подписку события на обработчик");
		}

		[Test(Description = "Позитивный тест метода IsNodeRemovedNull")]
		public void IsNodeRemovedNull_CorrectValue()
		{
			// arrenge
			int circuitConnectionCount = InitCircuit.
				Circuit.Connection.GetNodesCount();
			Resistor resistor = new Resistor(1000.0);
			bool expectedMethodRaised = true;

			// act
			bool actualMethodRaised = resistor.IsNodeRemovedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Подписка на обработчик события не должны быть зафиксирована");
		}

		[Test(Description = "Негативный тест метода IsNodeRemovedNull")]
		public void IsNodeRemovedNull_IncorrectValue()
		{
			// arrenge
			Resistor resistor = (Resistor)InitCircuit.Circuit.Connection[0];
			bool expectedMethodRaised = false;

			// act
			bool actualMethodRaised = resistor.IsNodeRemovedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Метод не зафиксировал подписку события на обработчик");
		}
	}
}
