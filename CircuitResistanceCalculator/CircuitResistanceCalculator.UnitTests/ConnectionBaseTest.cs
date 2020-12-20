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
	class ConnectionBaseTest
	{
		[Test(Description = "Позитивный тест геттера индексатора Nodes")]
		public void TestIndexerGet_CorrectValue()
		{
			// arrenge
			SerialConnection serialConnection = 
				(SerialConnection)InitCircuit.Circuit.Connection[3];
			ElementBase expectedElement = new Resistor(5000.0);
			serialConnection.AddNode(expectedElement);

			// act
			ElementBase actualElement = (ElementBase)serialConnection[3];

			// Assert
			Assert.AreEqual(expectedElement, actualElement,
				"Геттер индексатора вернул неверный элемент");

			serialConnection[3].RemoveNode();
		}

		[Test(Description = "Позитивный тест метода GetNodesCount")]
		public void GetNodesCount_CorrectValue()
		{
			// arrenge
			int expectedNodesCount = 3;

			// act
			int actualNodesCount = ((SerialConnection)InitCircuit.
				Circuit.Connection[3]).GetNodesCount(); ;

			Assert.AreEqual(expectedNodesCount, actualNodesCount,
				"Метод возвращает неверное количество узлов " +
				"в списке соединения");
		}

		[Test(Description = "Позитивный тест метода AddNode " +
			"для добавления узла типа элемент")]
		public void TestAddNode_AddElement()
		{
			// arrenge
			SerialConnection serialConnection = 
				(SerialConnection)InitCircuit.Circuit.Connection[3];
			ElementBase expectedElement = new Resistor(5000.0);

			// act
			serialConnection.AddNode(expectedElement);
			ElementBase actualElement = (ElementBase)serialConnection[3];

			// assert
			Assert.AreEqual(expectedElement, actualElement,
				"Метод неверно добавляет элемент в список соединения");
			Assert.IsFalse(actualElement.IsValueChangedNull(),
				"Событие ValueChanged добавленного в список " +
				"объекта не было подписано на обработчик");
			Assert.IsFalse(actualElement.IsNodeChangedNull(),
				"Событие NodeChnged добавленного в список " +
				"объекта не было подписано на обработчик");
			Assert.IsFalse(actualElement.IsNodeRemovedNull(),
				"Событие NodeRemoved добавленного в список " +
				"объекта не было подписано на обработчик");

			serialConnection[3].RemoveNode();
		}

		[Test(Description = "Позитивный тест метода AddNode для " +
			"для добавления узла типа соединение")]
		public void TestAddNode_AddConnection()
		{
			// arrenge
			SerialConnection serialConnection = 
				(SerialConnection)InitCircuit.Circuit.Connection[3];
			ConnectionBase expectedConnection = new ParallelConnection();

			// act
			serialConnection.AddNode(expectedConnection);
			ConnectionBase actualConnection = (ConnectionBase)serialConnection[3];

			// assert
			Assert.AreEqual(expectedConnection, actualConnection,
				"Метод неверно добавляет узел типа соединение " +
				"в список соединения");
			Assert.IsFalse(actualConnection.IsValueChangedNull(),
				"Событи ValueChanged добавленного в список объекта " +
				"не было подписано на обработчик");
			Assert.IsFalse(actualConnection.IsNodeChangedNull(),
				"Событие NodeChanged добавленного в список объекта " +
				"не было подписано на обработчки");
			Assert.IsFalse(actualConnection.IsNodeRemovedNull(),
				"Событие NodeRemoved добавленного в список объека " +
				"не было подписано на обработчик");

			serialConnection[3].RemoveNode();
		}

		[Test(Description = "Позитивный тест метода ChangeConnection")]
		public void ChangeConnection()
		{
			// arrenge
			SerialConnection serialConnection = new SerialConnection();
			Resistor resistor = new Resistor(1000.0);
			serialConnection.AddNode(resistor);
			InitCircuit.Circuit.Connection.AddNode(serialConnection);
			int expectedCircuitConnectionCount =
				InitCircuit.Circuit.Connection.GetNodesCount();
			ConnectionBase expectedConnection = new ParallelConnection();

			// act
			serialConnection.ChangeConnection(expectedConnection);
			int actualCircuitConnectionCount =
				InitCircuit.Circuit.Connection.GetNodesCount();

			// assert
			Assert.AreEqual(expectedCircuitConnectionCount, 
				actualCircuitConnectionCount, "Количество элементов в " +
				"списке родительского узла не должно меняться после " +
				"замены элемента");
			Assert.AreEqual(InitCircuit.Circuit.
				Connection[expectedCircuitConnectionCount - 1], 
				expectedConnection, "Замена узла типа соединение " +
				"происходит некорректно");

			Assert.IsTrue(serialConnection.IsValueChangedNull(),
				"Событие ValueChanged удаленного элемента должно быть " +
				"отписано от обработчиков");
			Assert.IsTrue(serialConnection.IsNodeChangedNull(),
				"Событие NodeChanged удаленного элемента должно быть " +
				"отписано от обработчиков");
			Assert.IsTrue(serialConnection.IsNodeRemovedNull(),
				"Событие NodeRemoved удаленного элемента должно быть " +
				"отписано от обработчиков");

			Assert.IsFalse(resistor.IsValueChangedNull(), "Событие ValueChanged " +
				"удаленного элемента должно быть отписано от обработчиков");
			Assert.IsFalse(resistor.IsNodeChangedNull(), "Событие NodeChanged " +
				"удаленного элемента должно быть отписано от обработчиков");
			Assert.IsFalse(resistor.IsNodeRemovedNull(), "Событие NodeRemoved " +
				"удаленного элемента должно быть отписано от обработчиков");

			Assert.IsFalse(expectedConnection.IsValueChangedNull(), 
				"После добавления в цепь событие ValueChanged нового элемента " +
				"должно быть подписано на событие");
			Assert.IsFalse(expectedConnection.IsNodeChangedNull(),
				"После добавления в цепь событие NodeChanged нового элемента " +
				"должно быть подписано на событие");
			Assert.IsFalse(expectedConnection.IsNodeRemovedNull(),
				"После добавления в цепь событие NodeRemoved нового элемента " +
				"должно быть подписано на событие");

			InitCircuit.Circuit.Connection[expectedCircuitConnectionCount - 1].
				RemoveNode();
		}

		[Test(Description = "Негативный тест метода ChangeConnection")]
		public void TestChangedConnection_IncorrectValue()
		{
			// arrenge
			ConnectionBase expectedConnection = InitCircuit.Circuit.Connection;

			// act
			expectedConnection.ChangeConnection(new ParallelConnection());

			// assert
			Assert.AreEqual(expectedConnection, InitCircuit.Circuit.Connection, 
				"Метод не должен заменять текущий узел, если его тип " +
				"совпадает с типом нового узла");
		}

		[Test(Description = "Позитивный тест метода RemoveNode")]
		public void TestRemoveNode_CorrectValue()
		{
			// arrenge
			int expectedCircuitConnectionCount = 
				InitCircuit.Circuit.Connection.GetNodesCount();
			SerialConnection serialConnection = new SerialConnection();
			Resistor resistor = new Resistor(1000.0);
			serialConnection.AddNode(resistor);
			InitCircuit.Circuit.Connection.AddNode(serialConnection);

			// act
			((ConnectionBase)InitCircuit.Circuit.
				Connection[expectedCircuitConnectionCount]).RemoveNode();
			int actualCircuitConnectionCount = 
				InitCircuit.Circuit.Connection.GetNodesCount();

			// assert
			Assert.AreEqual(expectedCircuitConnectionCount, 
				actualCircuitConnectionCount, "Количество узлов в " +
				"списке соединения не должно было измениться");
			
			Assert.IsTrue(resistor.IsValueChangedNull(), "Событие ValueChanged " +
				"удаленного элемента должно быть отписано от обработчиков");
			Assert.IsTrue(resistor.IsNodeChangedNull(), "Событие NodeChanged " +
				"удаленного элемента должно быть отписано от обработчиков");
			Assert.IsTrue(resistor.IsNodeRemovedNull(), "Событие NodeRemoved " +
				"удаленного элемента должно быть отписано от обработчиков");

			Assert.IsTrue(serialConnection.IsValueChangedNull(), 
				"Событие ValueChanged удаленного элемента должно быть " +
				"отписано от обработчиков");
			Assert.IsTrue(serialConnection.IsNodeChangedNull(),
				"Событие NodeChanged удаленного элемента должно быть " +
				"отписано от обработчиков");
			Assert.IsTrue(serialConnection.IsNodeRemovedNull(),
				"Событие NodeRemoved удаленного элемента должно быть " +
				"отписано от обработчиков");
		}

		[Test(Description = "Позитивный тест метода IsValueChangedNull")]
		public void IsValueChangedNull_CorrectValue()
		{
			// arrenge
			int circuitConnectionCount = InitCircuit.
				Circuit.Connection.GetNodesCount();
			ParallelConnection parallelConnection = new ParallelConnection();
			bool expectedMethodRaised = true;

			// act
			bool actualMethodRaised = parallelConnection.IsValueChangedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Подписка на обработчик события не должны быть зафиксирована");
		}

		[Test(Description = "Негативный тест метода IsValueChangedNull")]
		public void IsValueChangedNull_IncorrectValue()
		{
			// arrenge
			ParallelConnection parallelConnection = 
				(ParallelConnection)InitCircuit.Circuit.Connection;
			bool expectedMethodRaised = false;

			// act
			bool actualMethodRaised = parallelConnection.IsValueChangedNull();

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
			ParallelConnection parallelConnection = new ParallelConnection();
			bool expectedMethodRaised = true;

			// act
			bool actualMethodRaised = parallelConnection.IsNodeChangedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Подписка на обработчик события не должны быть зафиксирована");
		}

		[Test(Description = "Негативный тест метода IsNodeChangedNull")]
		public void IsNodeChangedNull_Incorrect()
		{
			// arrenge
			ParallelConnection parallelConnection =
				(ParallelConnection)InitCircuit.Circuit.Connection;
			bool expectedMethodRaised = false;

			// act
			bool actualMethodRaised = parallelConnection.IsNodeChangedNull();

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
			ParallelConnection parallelConnection = new ParallelConnection();
			bool expectedMethodRaised = true;

			// act
			bool actualMethodRaised = parallelConnection.IsNodeRemovedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Подписка на обработчик события не должны быть зафиксирована");
		}

		[Test(Description = "Негативный тест метода IsNodeRemovedNull")]
		public void IsNodeRemovedNull_IncorrectValue()
		{
			// arrenge
			ParallelConnection parallelConnection =
				(ParallelConnection)InitCircuit.Circuit.Connection[4];
			bool expectedMethodRaised = false;

			// act
			bool actualMethodRaised = parallelConnection.IsNodeRemovedNull();

			// assert
			Assert.AreEqual(expectedMethodRaised, actualMethodRaised,
				"Метод не зафиксировал подписку события на обработчик");
		}
	}
}
