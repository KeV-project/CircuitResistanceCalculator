using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace CircuitResistanceCalculator.UnitTests
{
	//[TestFixture]
	//class ConnectionBaseTest
	//{
	//	private SerialConnection SerialConnection
	//	{
	//		get
	//		{
	//			SerialConnection serialConnection = new SerialConnection();
	//			ParallelConnection parallelConnection = new ParallelConnection();
	//			serialConnection.AddNode(parallelConnection);
	//			parallelConnection.AddNode(new Resistor(1000.0));
	//			parallelConnection.AddNode(new Resistor(2000.0));
	//			serialConnection.AddNode(new Inductor(10.0));
	//			serialConnection.AddNode(new Capacitor(50.0));

	//			return serialConnection;
	//		}
	//	}

	//	[Test (Description = "Позитивный тест геттера индексатора Nodes")]
	//	public void TestIndexerGet_CorrectValue()
	//	{
	//		// arrenge
	//		SerialConnection serialConnection = SerialConnection;
	//		ElementBase expectedElement = new Resistor(5000.0);
	//		serialConnection.AddNode(expectedElement);

	//		// act
	//		ElementBase actualElement = (ElementBase)serialConnection[3];

	//		// Assert
	//		Assert.AreEqual(expectedElement, actualElement, 
	//			"Геттер индексатора вернул неверный элемент");
	//	}

	//	[Test(Description = "Позитивный тест метода GetNodesCount")]
	//	public void GetNodesCount_CorrectValue()
	//	{
	//		// arrenge
	//		int expectedNodesCount = 3;

	//		// act
	//		int actualNodesCount = SerialConnection.GetNodesCount();

	//		Assert.AreEqual(expectedNodesCount, actualNodesCount,
	//			"Метод возвращает неверное количество узлов " +
	//			"в списке соединения");
	//	}

	//	[Test(Description = "Позитивный тест метода AddNode " +
	//		"для добавления узла типа элемент")]
	//	public void TestAddNode_AddElement()
	//	{
	//		// arrenge
	//		SerialConnection serialConnection = SerialConnection;
	//		ElementBase expectedElement = new Resistor(5000.0);
	//		int expectedId = 7;
	//		int expectedIndex = 3;
	//		double expectedValue = 5000.0;

	//		// act
	//		serialConnection.AddNode(expectedElement);
	//		ElementBase actualElement = (ElementBase)serialConnection[3];
	//		int actualId = serialConnection[3].Id;
	//		int actualIndex = ((ElementBase)serialConnection[3]).Index;
	//		double actualValue = ((ElementBase)serialConnection[3]).Value;

	//		// assert
	//		Assert.AreEqual(expectedElement, actualElement, 
	//			"Метод неверно добавляет элемент в список соединения");
	//		Assert.AreEqual(expectedId, actualId, 
	//			"Id добавляемого и добавленного в список объектов " +
	//			"не совпадают");
	//		Assert.AreEqual(expectedIndex, actualIndex, 
	//			"Индексы добавляемого и добавленного в список " +
	//			"объектов не совпадают");
	//		Assert.AreEqual(expectedValue, actualValue, 
	//			"Номиналы добавляемого и добавленного в список " +
	//			"объектвов не совпадают");
	//		Assert.IsFalse(actualElement.IsValueChangedNull(), 
	//			"Событие ValueChanged добавленного в список " +
	//			"объекта не было подписано на обработчик");
	//		Assert.IsFalse(actualElement.IsNodeChangedNull(), 
	//			"Событие NodeChnged добавленного в список " +
	//			"объекта не было подписано на обработчик");
	//		Assert.IsFalse(actualElement.IsNodeRemovedNull(), 
	//			"Событие NodeRemoved добавленного в список " +
	//			"объекта не было подписано на обработчик");
	//	}

	//	[Test(Description = "Позитивный тест метода AddNode для " +
	//		"для добавления узла типа соединение")]
	//	public void TestAddNode_AddConnection()
	//	{
	//		// arrenge
	//		SerialConnection serialConnection = SerialConnection;
	//		ConnectionBase expectedConnection = new ParallelConnection();

	//		// act
	//		serialConnection.AddNode(expectedConnection);
	//		ConnectionBase actualConnection = (ConnectionBase)serialConnection[3];

	//		// assert
	//		Assert.AreEqual(expectedConnection, actualConnection, 
	//			"Метод неверно добавляет узел типа соединение " +
	//			"в список соединения");
	//		Assert.IsFalse(actualConnection.IsValueChangedNull(), 
	//			"Событи ValueChanged добавленного в список объекта " +
	//			"не было подписано на обработчик");
	//		Assert.IsFalse(actualConnection.IsNodeChangedNull(), 
	//			"Событие NodeChanged добавленного в список объекта " +
	//			"не было подписано на обработчки");
	//		Assert.IsFalse(actualConnection.IsNodeRemovedNull(),
	//			"Событие NodeRemoved добавленного в список объека " +
	//			"не было подписано на обработчик");
	//	}
	//}
}
