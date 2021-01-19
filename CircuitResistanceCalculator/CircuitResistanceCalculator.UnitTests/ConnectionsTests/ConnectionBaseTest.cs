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
			//TODO: придерживайтесь SAA +
			// setup
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();
			Elements.ElementBase expectedElement = 
				new Elements.Resistor(5000.0, 1);
			serialConnection.AddNode(expectedElement);

			// act
			Elements.ElementBase actualElement = 
				(Elements.ElementBase)serialConnection[0];

			// assert
			Assert.AreEqual(expectedElement, actualElement,
				"Геттер индексатора возвращает неверный объект");
		}

		[Test(Description = "Позитивный тест метода GetNodesCount")]
		public void GetNodesCount_CorrectValue()
		{
			// setup
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
			// setup
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
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(Elements.ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(Elements.ElementBase.NodeRemoved));
		}

		[Test(Description = "Позитивный тест метода ReplaceNode")]
		public void ChangeConnection()
		{
			// setup
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
			currentConnection.ReplaceNode(newConnection);

			// assert
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(Elements.ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(Elements.ElementBase.NodeRemoved));

			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(currentConnection,
					nameof(Elements.ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(currentConnection,
					nameof(Elements.ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}

		[Test(Description = "Негативный тест метода ReplaceNode")]
		public void TestChangedConnection_IncorrectValue()
		{
			// setup
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();
			Connections.ConnectionBase currentConnection = 
				new Connections.ParallelConnection();
			serialConnection.AddNode(currentConnection);
			Connections.ConnectionBase newConnection = 
				new Connections.ParallelConnection();

			// act
			currentConnection.ReplaceNode(newConnection);

			// assert
			Assert.AreEqual(serialConnection[0], currentConnection, 
				"Метод неверно обрабатывает попытку заменить " +
				"текущее соединение на объект того же типа");
		}

		[Test(Description = "Позитивный тест метода RemoveNode")]
		public void TestRemoveNode_CorrectValue()
		{
			// setup
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
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(removedConnection,
					nameof(Elements.ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(removedConnection,
					nameof(Elements.ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}

		[Test(Description = "Позитивный тест метода CompareTo")]
		public void TestCompareTo_CorrectValue()
		{
			// setup
			Connections.ConnectionBase circut1 = 
				new Connections.SerialConnection();
			Connections.ParallelConnection parallelConnection1 =
				new Connections.ParallelConnection();
			Elements.Resistor resistor1 = new Elements.Resistor(1000, 1);
			Elements.Inductor inductor1 = new Elements.Inductor(0.016, 1);
			Elements.Capacitor capacitor1 = new Elements.Capacitor(0.00022116, 1);

			circut1.AddNode(parallelConnection1);
			parallelConnection1.AddNode(resistor1);
			parallelConnection1.AddNode(inductor1);
			parallelConnection1.AddNode(capacitor1);

			Connections.ConnectionBase circut2 =
				new Connections.SerialConnection();
			Connections.ParallelConnection parallelConnection2 =
				new Connections.ParallelConnection();
			Elements.Resistor resistor2 = new Elements.Resistor(1000, 1);
			Elements.Inductor inductor2 = new Elements.Inductor(0.016, 1);
			Elements.Capacitor capacitor2 = new Elements.Capacitor(0.00022116, 1);

			circut2.AddNode(parallelConnection2);
			parallelConnection2.AddNode(resistor2);
			parallelConnection2.AddNode(inductor2);
			parallelConnection2.AddNode(capacitor2);

			int expectedCompareResult = 1;

			// act
			int actualCompareResult = circut1.CompareTo(circut2);

			// assert
			Assert.AreEqual(expectedCompareResult, actualCompareResult, 
				"Метод неверно сравнивает идентичные объекты");
		}

		[Test(Description = "Негативный тест метода CompareTo")]
		public void TestCompareTo_IncorrectValue()
		{
			// setup
			Connections.ConnectionBase circut1 =
				new Connections.SerialConnection();
			Connections.ParallelConnection parallelConnection1 =
				new Connections.ParallelConnection();
			Elements.Resistor resistor1 = new Elements.Resistor(1000, 1);
			Elements.Inductor inductor1 = new Elements.Inductor(0.016, 1);
			Elements.Capacitor capacitor1 = new Elements.Capacitor(0.00022116, 1);

			circut1.AddNode(parallelConnection1);
			parallelConnection1.AddNode(resistor1);
			parallelConnection1.AddNode(inductor1);
			parallelConnection1.AddNode(capacitor1);

			Connections.ConnectionBase circut2 =
				new Connections.SerialConnection();
			Connections.SerialConnection serialConnection2 =
				new Connections.SerialConnection();
			Elements.Resistor resistor2 = new Elements.Resistor(1000, 1);
			Elements.Inductor inductor2 = new Elements.Inductor(0.016, 1);
			Elements.Capacitor capacitor2 = new Elements.Capacitor(0.00022116, 1);


			circut2.AddNode(serialConnection2);
			serialConnection2.AddNode(resistor2);
			serialConnection2.AddNode(inductor2);
			serialConnection2.AddNode(capacitor2);
			

			int expectedCompareResult = 0;

			// act
			int actualCompareResult = circut1.CompareTo(circut2);

			// assert
			Assert.AreEqual(expectedCompareResult, actualCompareResult,
				"Метод неверно сравнивает идентичные объекты");
		}
	}
}
