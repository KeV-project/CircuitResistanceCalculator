using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculator.UnitTests.SerializerTest
{
	class SerializerTest
	{
		private const int POSITIVE_TESTS_COUNT = 3;

		private static FileInfo[] Path
		{
			get
			{
				FileInfo[] path = new FileInfo[POSITIVE_TESTS_COUNT]
					{
						new FileInfo(Environment.GetFolderPath(
							Environment.SpecialFolder.ApplicationData) +
							"\\CircuitResistanceCalculator1\\" + "TestCircuit1.notes"),
						new FileInfo(Environment.GetFolderPath(
							Environment.SpecialFolder.ApplicationData) +
							"\\CircuitResistanceCalculator2\\" + "TestCircuit2.notes"),
						new FileInfo(Environment.GetFolderPath(
							Environment.SpecialFolder.ApplicationData) +
							"\\CircuitResistanceCalculator3\\" + "TestCircuit3.notes")
					};

				path[0].Directory.Create();
				path[0].Create().Close();
				path[1].Directory.Create();

				return path;
			}
		}

		[TestCaseSource(nameof(ProjectManagerTestData))]
		public void TestSaveProject_CorrectValue(
			Func<(FileInfo[], ConnectionBase)> initFunc,
			Action<ConnectionBase, FileInfo> arrangeAction,
			string assertMessage)
		{
			// arrange
			(FileInfo[] path, ConnectionBase expected) = initFunc.Invoke();

			for (int i = 0; i < POSITIVE_TESTS_COUNT; i++)
			{
				// act
				arrangeAction.Invoke(expected, path[i]);

				var actual = Serializer.Serializer.ReadCircuit(path[i]);

				// assert
				var result = Convert.ToBoolean(expected.CompareTo(actual));
				Assert.IsTrue(result, assertMessage);

				path[i].Delete();
				path[i].Directory.Delete();
			}
		}

		private static IEnumerable<TestCaseData> ProjectManagerTestData
		{
			get
			{
				ConnectionBase circut = new SerialConnection();
				ParallelConnection parallelConnection = new ParallelConnection();
				Resistor resistor = new Resistor(1000, 1);
				Inductor inductor = new Inductor(0.016, 1);
				Capacitor capacitor = new Capacitor(0.00022116, 1);

				circut.AddNode(parallelConnection);
				parallelConnection.AddNode(resistor);
				parallelConnection.AddNode(inductor);
				parallelConnection.AddNode(capacitor);

				var initFunc1 = new Func<(FileInfo[], ConnectionBase)>(
					() => (Path, circut));
				var initFunc2 = new Func<(FileInfo[], ConnectionBase)>(
					() => (Path, new Connections.SerialConnection()));
				var arrangeAction = new Action<ConnectionBase, FileInfo>(
						Serializer.Serializer.SaveCircuit);
				var arrangeEmpty = new Action<ConnectionBase, FileInfo>(
					(project, info) => { });

				var serializationMessage =
					"Искажение данных при сериализации объекта";
				var deserializationMessage =
					"Искажение данных при десериализации объекта";

				yield return new TestCaseData(initFunc1, arrangeAction, 
					serializationMessage).SetName("Позитивнынй тест SaveCircuit");
				yield return new TestCaseData(initFunc2, arrangeEmpty, 
					deserializationMessage).SetName("Позитивный тест ReadCircuit " +
					"(чтение пустого файла)");
				yield return new TestCaseData(initFunc1, arrangeAction, 
					deserializationMessage).SetName("Позитивный тест ReadCircuit " +
					"(чтение проекта из файла)");
			}
		}
	}
}
