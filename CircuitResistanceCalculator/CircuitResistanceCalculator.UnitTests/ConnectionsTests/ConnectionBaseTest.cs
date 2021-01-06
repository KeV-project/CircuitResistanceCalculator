using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.UnitTests.ConnectionsTests
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
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();
			Elements.ElementBase expectedElement = 
				new Elements.Resistor(5000.0, 1);
			serialConnection.AddNode(expectedElement);

			// act
			Elements.ElementBase actualElement = 
				(Elements.ElementBase)serialConnection[0];

			// Assert
			Assert.AreEqual(expectedElement, actualElement,
				"Геттер индексатора возвращает неверный объект");
		}

		[Test(Description = "Позитивный тест метода GetNodesCount")]
		public void GetNodesCount_CorrectValue()
		{
			// arrenge
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();
			Elements.ElementBase expectedElement = 
				new Elements.Resistor(5000.0, 1);
			serialConnection.AddNode(expectedElement);
			int expectedNodesCount = 1;

			// act
			int actualNodesCount = serialConnection.NodesCount;

			Assert.AreEqual(expectedNodesCount, actualNodesCount,
				"Метод возвращает неверное количество узлов " +
				"в списке соединения");
		}

		[Test(Description = "Позитивный тест метода AddNode")]
		public void TestAddNode_AddElement()
		{
			// arrenge
			Connections.ConnectionBase connection = 
				new Connections.SerialConnection();
			Elements.ElementBase newElement = new Elements.Resistor(2000.0, 1);
			int expectedConnectionNodesCount = 1;

			// act
			connection.AddNode(newElement);
			int actualConnectionNodesCount = connection.NodesCount;

			// assert
			Assert.AreEqual(expectedConnectionNodesCount,
				actualConnectionNodesCount, "Метод некорректно " +
				"добавляет узел в список соединения");
			HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(Elements.ElementBase.ValueChanged));
			HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(Elements.ElementBase.NodeChanged));
			HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(Elements.ElementBase.NodeRemoved));
		}

		[Test(Description = "Позитивный тест метода ChangeConnection")]
		public void ChangeConnection()
		{
			// arrenge
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();

			Elements.Capacitor capacitor = new Elements.Capacitor(0.000004, 1);
			Connections.ConnectionBase currentConnection = 
				new Connections.SerialConnection();
			Elements.Resistor resistor = new Elements.Resistor(1000.0, 1);
			Connections.ParallelConnection parallelConnection = 
				new Connections.ParallelConnection();
			Elements.Inductor inductor = new Elements.Inductor(0.004, 1);

			serialConnection.AddNode(capacitor);
			serialConnection.AddNode(currentConnection);
			currentConnection.AddNode(parallelConnection);
			currentConnection.AddNode(resistor);
			parallelConnection.AddNode(inductor);

			Connections.ConnectionBase newConnection = 
				new Connections.ParallelConnection();

			// act
			currentConnection.ChangeConnection(newConnection);

			// assert
			HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(Elements.ElementBase.ValueChanged));
			HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(Elements.ElementBase.NodeChanged));
			HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(Elements.ElementBase.NodeRemoved));

			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(currentConnection,
					nameof(Elements.ElementBase.ValueChanged));
			}, "Событие ValueChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(currentConnection,
					nameof(Elements.ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(currentConnection,
					nameof(Elements.ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}

		[Test(Description = "Негативный тест метода ChangeConnection")]
		public void TestChangedConnection_IncorrectValue()
		{
			// arrenge
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();
			Connections.ConnectionBase currentConnection = 
				new Connections.ParallelConnection();
			serialConnection.AddNode(currentConnection);
			Connections.ConnectionBase newConnection = 
				new Connections.ParallelConnection();

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
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();
			Connections.ConnectionBase removedConnection = 
				new Connections.ParallelConnection();
			serialConnection.AddNode(removedConnection);
			int expectedSerialConnectionNodesCount = 0;

			// act
			serialConnection.RemoveNode();
			int actualSerialConnectionNodesCount = serialConnection.NodesCount;

			// assert
			Assert.AreEqual(expectedSerialConnectionNodesCount, 
				actualSerialConnectionNodesCount, "Метод некорректно выполняет " +
				"удаление соединения из списка родительского узла");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(removedConnection,
					nameof(Elements.ElementBase.ValueChanged));
			}, "Событие ValueChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(removedConnection,
					nameof(Elements.ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.VerifyDelegateAttachedTo(removedConnection,
					nameof(Elements.ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}
	}
}
