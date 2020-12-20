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
	class CircuitTest
	{
		[Test(Description = "Позитивный тест геттера Connection")]
		public void TestConnectionGet_CorrectValue()
		{
			// arrenge
			Circuit circuit = new Circuit();
			ConnectionBase expectedConnection = InitCircuit.Circuit.Connection;
			circuit.SetConnection(expectedConnection);

			// act
			ConnectionBase actualConnection = circuit.Connection;

			// assert
			Assert.AreEqual(expectedConnection, actualConnection, 
				"Геттер Connection возвращает некорректное значение");
		}

		[Test(Description = "Позитивный тест метода SetConnection")]
		public void TestSetConnection_CorrectValue()
		{
			// arrenge
			Circuit circuit = new Circuit();
			ConnectionBase expectedConnection = InitCircuit.Circuit.Connection;

			// act
			circuit.SetConnection(expectedConnection);
			ConnectionBase actualConnection = circuit.Connection;

			// assert
			Assert.AreEqual(expectedConnection, actualConnection, 
				"Метод неверно задает корневое соединение цепи");
		}

		[Test(Description = "Негативный тест метода SetConnection")]
		public void TestSetConnection_IncorrectValue()
		{
			// assert
			Assert.Throws<Exception>(() =>
			{
				InitCircuit.Circuit.SetConnection(new ParallelConnection());
			});
		}

		//[Test(Description = "Негативный тест метода ReplaceConnection")]
		//public void TestReplaceConnection_IncorrectValue()
		//{
		//	// arrenge
		//	Circuit circuit = InitCircuit.Circuit;
		//	circuit.Connection.ChangeConnection(new ParallelConnection());
		//	ConnectionBase expectedConnection = circuit.Connection;

		//	// act
		//	InitCircuit.Circuit.Connection.ChangeConnection(new ParallelConnection());
		//	ConnectionBase actualConnection = InitCircuit.Circuit.Connection;

		//	// assert
		//	Assert.AreEqual(expectedConnection, actualConnection,
		//		"Метод не должен заменять узел, если его тип " +
		//		"совпадает с типом нового объекта");

		//}

		//[Test(Description = "Позитивный тест метода ReplaceConnection")]
		//public void TestReplaceConnection_CorrectValue()
		//{
		//	// arrenge
		//	Circuit circuit = InitCircuit.Circuit;
		//	ConnectionBase currentConnection = new ParallelConnection();
		//	circuit.Connection.ChangeConnection(currentConnection);
		//	ConnectionBase expectedNewConnection = new SerialConnection();

		//	// act
		//	circuit.Connection.ChangeConnection(expectedNewConnection);
		//	ConnectionBase actualNewConnection = circuit.Connection;

		//	// assert
		//	Assert.AreEqual(expectedNewConnection, actualNewConnection,
		//		"Метод неверно заменяет корневое соединение");

		//	Assert.IsTrue(currentConnection.IsValueChangedNull(),
		//		"Событие ValueChanged замененного объекта " +
		//		"должно быть отписано от обработчкиа");
		//	Assert.IsTrue(currentConnection.IsNodeChangedNull(),
		//		"Событие NodeChanged замененного объекта " +
		//		"должно быть отписано от обработчкиа");
		//	Assert.IsTrue(currentConnection.IsNodeRemovedNull(),
		//		"Событие NodeRemoved замененного объекта " +
		//		"должно быть отписано от обработчкиа");

		//	Assert.IsFalse(actualNewConnection.IsValueChangedNull(),
		//		"Событие ValueChanged нового узла " +
		//		"должно быть подписано на обработчки");
		//	Assert.IsFalse(actualNewConnection.IsNodeChangedNull(),
		//		"Событие NodeChanged нового узла " +
		//		"должно быть подписано на обработчки");
		//	Assert.IsFalse(actualNewConnection.IsNodeRemovedNull(),
		//		"Событие NodeRemoved нового узла " +
		//		"должно быть подписано на обработчки");
		//}

		[Test(Description = "Позитивный тест метода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			// arrenge
			Circuit circuit = new Circuit();
			circuit.SetConnection((ConnectionBase)InitCircuit.Circuit.Connection[4]);
			const int frequenciesCount = 1;
			double[] frequencies = new double[frequenciesCount]
			{
				50.0
			};
			Complex expectedZ = new Complex(0.06, 7.716);

			// act
			Complex actualZ = circuit.CalculateZ(frequencies)[0];

			// assert
			Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
				"рассчитывает комплексное сопротивление цепи");
		}
	}
}
