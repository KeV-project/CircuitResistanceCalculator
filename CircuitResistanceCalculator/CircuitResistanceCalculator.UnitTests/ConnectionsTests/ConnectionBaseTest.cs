using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

//TODO: Если класс вложен в папку, namespace долен быть составным
namespace CircuitResistanceCalculator.UnitTests
{
	[TestFixture]
	class ConnectionBaseTest
	{
		[Test(Description = "Позитивный тест геттера индексатора Nodes")]
		public void TestIndexerGet_CorrectValue()
		{
			//TODO: Это уже мой косяк, когда я объяснял. В процессе работы с тестами выяснилось, что мы на внутреннем семинаре приняли формате не ААА, а
			//TODO: SAA, где S - это Setup, т.е. Setup понятнее чем Arrange. Тут можете не исправлять, а дальше, когда будете писать тесты - пожалуйста
			//TODO: придерживайтесь SAA
			// arrenge
			SerialConnection serialConnection = new SerialConnection();
			ElementBase expectedElement = new Resistor(5000.0, 1);
			serialConnection.AddNode(expectedElement);

			// act
			ElementBase actualElement = (ElementBase)serialConnection[0];

			// Assert
			Assert.AreEqual(expectedElement, actualElement,
				"Геттер индексатора возвращает неверный объект");
		}

		[Test(Description = "Позитивный тест метода GetNodesCount")]
		public void GetNodesCount_CorrectValue()
		{
			// arrenge
			SerialConnection serialConnection = new SerialConnection();
			ElementBase expectedElement = new Resistor(5000.0, 1);
			serialConnection.AddNode(expectedElement);
			int expectedNodesCount = 1;

			// act
			int actualNodesCount = serialConnection.GetNodesCount();

			Assert.AreEqual(expectedNodesCount, actualNodesCount,
				"Метод возвращает неверное количество узлов " +
				"в списке соединения");
		}

		[Test(Description = "Позитивный тест метода AddNode")]
		public void TestAddNode_AddElement()
		{
			// arrenge
			ConnectionBase connection = new SerialConnection();
			ElementBase newElement = new Resistor(2000.0, 1);
			int expectedConnectionNodesCount = 1;

			// act
			connection.AddNode(newElement);
			int actualConnectionNodesCount = connection.GetNodesCount();

			// assert
			Assert.AreEqual(expectedConnectionNodesCount,
				actualConnectionNodesCount, "Метод некорректно " +
				"добавляет узел в список соединения");
			HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(ElementBase.ValueChanged));
			HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(ElementBase.NodeChanged));
			HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(ElementBase.NodeRemoved));
		}

		[Test(Description = "Позитивный тест метода ChangeConnection")]
		public void ChangeConnection()
		{
			// arrenge
			SerialConnection serialConnection = new SerialConnection();

			Capacitor capacitor = new Capacitor(0.000004, 1);
			ConnectionBase currentConnection = new SerialConnection();
			Resistor resistor = new Resistor(1000.0, 1);
			ParallelConnection parallelConnection = new ParallelConnection();
			Inductor inductor = new Inductor(0.004, 1);

			serialConnection.AddNode(capacitor);
			serialConnection.AddNode(currentConnection);
			currentConnection.AddNode(parallelConnection);
			currentConnection.AddNode(resistor);
			parallelConnection.AddNode(inductor);

			ConnectionBase newConnection = new ParallelConnection();

			// act
			currentConnection.ChangeConnection(newConnection);

			// assert
			HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(ElementBase.ValueChanged));
			HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(ElementBase.NodeChanged));
			HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(ElementBase.NodeRemoved));

			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(currentConnection,
					nameof(ElementBase.ValueChanged));
			}, "Событие ValueChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(currentConnection,
					nameof(ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(currentConnection,
					nameof(ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}

		[Test(Description = "Негативный тест метода ChangeConnection")]
		public void TestChangedConnection_IncorrectValue()
		{
			// arrenge
			SerialConnection serialConnection = new SerialConnection();
			ConnectionBase currentConnection = new ParallelConnection();
			serialConnection.AddNode(currentConnection);
			ConnectionBase newConnection = new ParallelConnection();

			// act
			currentConnection.ChangeConnection(newConnection);

			// assert
			Assert.AreEqual(serialConnection[0], currentConnection, 
				"Метод неверно обрабатывает попытку заменить " +
				"текущее соединение на объект того же типа");
		}

		[Test(Description = "Позитивный тест метода RemoveNode")]
		public void TestRemoveNode_CorrectValue()
		{
			// arrenge
			SerialConnection serialConnection = new SerialConnection();
			ConnectionBase removedConnection = new ParallelConnection();
			serialConnection.AddNode(removedConnection);
			int expectedSerialConnectionNodesCount = 0;

			// act
			serialConnection.RemoveNode();
			int actualSerialConnectionNodesCount = serialConnection.GetNodesCount();

			// assert
			Assert.AreEqual(expectedSerialConnectionNodesCount, 
				actualSerialConnectionNodesCount, "Метод некорректно выполняет " +
				"удаление соединения из списка родительского узла");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(removedConnection,
					nameof(ElementBase.ValueChanged));
			}, "Событие ValueChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(removedConnection,
					nameof(ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(removedConnection,
					nameof(ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}
	}
}
