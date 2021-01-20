using System;
using System.IO;
using NUnit.Framework;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

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
			SerialConnection serialConnection = new SerialConnection();
			ElementBase expectedElement = new Resistor(5000.0, 1);
			serialConnection.AddNode(expectedElement);

			// act
			ElementBase actualElement = (ElementBase)serialConnection[0];

			// assert
			Assert.AreEqual(expectedElement, actualElement,
				"Геттер индексатора возвращает неверный объект");
		}

		[Test(Description = "Позитивный тест метода GetNodesCount")]
		public void GetNodesCount_CorrectValue()
		{
			// setup
			SerialConnection serialConnection = new SerialConnection();
			ElementBase expectedElement = new Resistor(5000.0, 1);
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
			ConnectionBase connection = new SerialConnection();
			ElementBase newElement = new Resistor(2000.0, 1);
			int expectedConnectionNodesCount = 1;

			// act
			connection.AddNode(newElement);
			int actualConnectionNodesCount = connection.NodesCount;

			// assert
			Assert.AreEqual(expectedConnectionNodesCount,
				actualConnectionNodesCount, "Метод некорректно " +
				"добавляет узел в список соединения");
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newElement,
				nameof(ElementBase.NodeRemoved));
		}

		[Test(Description = "Позитивный тест метода ReplaceNode")]
		public void ChangeConnection()
		{
			// setup
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
			currentConnection.ReplaceNode(newConnection);

			// assert
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(newConnection,
				nameof(ElementBase.NodeRemoved));

			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
					currentConnection, nameof(ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
					currentConnection, nameof(ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}

		[Test(Description = "Негативный тест метода ReplaceNode")]
		public void TestChangedConnection_IncorrectValue()
		{
			// setup
			SerialConnection serialConnection = new SerialConnection();
			ConnectionBase currentConnection = new ParallelConnection();
			serialConnection.AddNode(currentConnection);
			ConnectionBase newConnection = new ParallelConnection();

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
			SerialConnection serialConnection = new SerialConnection();
			ConnectionBase removedConnection = new ParallelConnection();
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
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
					removedConnection, nameof(ElementBase.NodeChanged));
			}, "Событие NodeChanged должно быть отписано от обработчика");
			Assert.Throws<ArgumentNullException>(() =>
			{
				HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
					removedConnection, nameof(ElementBase.NodeRemoved));
			}, "Событие NodeRemoved должно быть отписано от обработчика");
		}

		[Test(Description = "Позитивный тест метода SubscribeNodesToEvents")]
		public void TestSubscribeNodesToEvents_CorrectValue()
		{
			// setup
			FileInfo path = new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit.notes");
			ConnectionBase circut = Serializer.Serializer.ReadCircuit(path);

			// act
			circut.SubscribeNodesToEvents();

			// assert
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(circut[0],
				nameof(ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(circut[0],
				nameof(ElementBase.NodeRemoved));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
				((ConnectionBase)circut[0])[0], nameof(ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
				((ConnectionBase)circut[0])[0], nameof(ElementBase.NodeRemoved));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
				((ConnectionBase)circut[0])[1], nameof(ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
				((ConnectionBase)circut[0])[1], nameof(ElementBase.NodeRemoved));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
				((ConnectionBase)circut[0])[2], nameof(ElementBase.NodeChanged));
			HelperMethods.HelperMethods.VerifyDelegateAttachedTo(
				((ConnectionBase)circut[0])[2], nameof(ElementBase.NodeRemoved));

		}

		[Test(Description = "Позитивный тест метода CompareTo")]
		public void TestCompareTo_CorrectValue()
		{
			// setup
			ConnectionBase circut1 = new SerialConnection();
			ParallelConnection parallelConnection1 = new ParallelConnection();
			Resistor resistor1 = new Resistor(1000, 1);
			Inductor inductor1 = new Inductor(0.016, 1);
			Capacitor capacitor1 = new Capacitor(0.00022116, 1);

			circut1.AddNode(parallelConnection1);
			parallelConnection1.AddNode(resistor1);
			parallelConnection1.AddNode(inductor1);
			parallelConnection1.AddNode(capacitor1);

			ConnectionBase circut2 = new SerialConnection();
			ParallelConnection parallelConnection2 = new ParallelConnection();
			Resistor resistor2 = new Resistor(1000, 1);
			Inductor inductor2 = new Inductor(0.016, 1);
			Capacitor capacitor2 = new Capacitor(0.00022116, 1);

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
			ConnectionBase circut1 = new SerialConnection();
			ParallelConnection parallelConnection1 = new ParallelConnection();
			Resistor resistor1 = new Resistor(1000, 1);
			Inductor inductor1 = new Inductor(0.016, 1);
			Capacitor capacitor1 = new Capacitor(0.00022116, 1);

			circut1.AddNode(parallelConnection1);
			parallelConnection1.AddNode(resistor1);
			parallelConnection1.AddNode(inductor1);
			parallelConnection1.AddNode(capacitor1);

			ConnectionBase circut2 = new SerialConnection();
			SerialConnection serialConnection2 = new SerialConnection();
			Resistor resistor2 = new Resistor(1000, 1);
			Inductor inductor2 = new Inductor(0.016, 1);
			Capacitor capacitor2 = new Capacitor(0.00022116, 1);


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
