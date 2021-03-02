using System;
using System.IO;
using System.Collections.Generic;
using CircuitResistanceCalculator.Connection;
using CircuitResistanceCalculator.Element;
using CircuitResistanceCalculator.Serializer;

namespace CircuitResistanceCalculatorUI.CreatingTemplates
{
	/// <summary>
	/// Класс <see cref="Templates"/> предназначен для создания 
	/// и сериализации шаблонных цепей, необходимых для 
	/// удобства тестирования работы приложения
	/// </summary>
	public static class Templates
	{
		/// <summary>
		/// Хранит пути к файлам для сериализации шаблонных цепей
		/// </summary>
		public static readonly List<FileInfo> TemplatesPath = new List<FileInfo>()
		{
			new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit1.notes"),
			new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit2.notes"),
			new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit3.notes"),
			new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit4.notes"),
			new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit5.notes")
		};

		/// <summary>
		/// Создание первого шаблона
		/// </summary>
		private static void CreateTemplates1()
		{
			SerialConnection circuit = new SerialConnection();
			SerialConnection serialConnection = new SerialConnection();
			Resistor resistor = new Resistor(1000.0, 1);
			Inductor inductor = new Inductor(0.016, 1);
			Capacitor capacitor = new Capacitor(0.00022116, 1);

			circuit.AddNode(serialConnection);
			serialConnection.AddNode(resistor);
			serialConnection.AddNode(inductor);
			serialConnection.AddNode(capacitor);

			Serializer.SaveCircuit(circuit, TemplatesPath[0]);
		}

		/// <summary>
		/// Создание второго шаблона
		/// </summary>
		private static void CreateTemplates2()
		{
			SerialConnection circuit = new SerialConnection();
			ParallelConnection parallelConnection = new ParallelConnection();
			Resistor resistor = new Resistor(1000.0, 1);
			Inductor inductor = new Inductor(0.016, 1);
			Capacitor capacitor = new Capacitor(0.00022116, 1);

			circuit.AddNode(parallelConnection);
			parallelConnection.AddNode(resistor);
			parallelConnection.AddNode(inductor);
			parallelConnection.AddNode(capacitor);

			Serializer.SaveCircuit(circuit, TemplatesPath[1]);
		}

		/// <summary>
		/// Создание третьего шаблона
		/// </summary>
		private static void CreateTemplates3()
		{
			SerialConnection circuit = new SerialConnection();
			ParallelConnection parallelConnection = new ParallelConnection();
			Resistor resistor1 = new Resistor(1000.0, 1);
			Resistor resistor2 = new Resistor(2000.0, 2);
			Resistor resistor3 = new Resistor(3000.0, 3);

			circuit.AddNode(parallelConnection);
			parallelConnection.AddNode(resistor1);
			parallelConnection.AddNode(resistor2);
			parallelConnection.AddNode(resistor3);

			Serializer.SaveCircuit(circuit, TemplatesPath[2]);
		}

		/// <summary>
		/// Создание четвертого шаблона
		/// </summary>
		private static void CreateTemplates4()
		{
			SerialConnection circuit = new SerialConnection();
			ParallelConnection parallelConnection = new ParallelConnection();
			SerialConnection serialConnection1 = new SerialConnection();
			SerialConnection serialConnection2 = new SerialConnection();
			SerialConnection serialConnection3 = new SerialConnection();
			Resistor resistor1 = new Resistor(1000.0, 1);
			Inductor inductor1 = new Inductor(0.02, 1);
			Resistor resistor2 = new Resistor(2000.0, 2);
			Capacitor capacitor2 = new Capacitor(0.0002, 2);
			Inductor inductor3 = new Inductor(0.03, 3);
			Capacitor capacitor3 = new Capacitor(0.0003, 3);

			circuit.AddNode(parallelConnection);
			parallelConnection.AddNode(serialConnection1);
			parallelConnection.AddNode(serialConnection2);
			parallelConnection.AddNode(serialConnection3);
			serialConnection1.AddNode(resistor1);
			serialConnection1.AddNode(inductor1);
			serialConnection2.AddNode(resistor2);
			serialConnection2.AddNode(capacitor2);
			serialConnection3.AddNode(inductor3);
			serialConnection3.AddNode(capacitor3);

			Serializer.SaveCircuit(circuit, TemplatesPath[3]);
		}

		/// <summary>
		/// Создание пятого шаблона
		/// </summary>
		private static void CreateTemplates5()
		{
			SerialConnection circuit = new SerialConnection();
			SerialConnection serialConnection = new SerialConnection();
			ParallelConnection parallelConnection1 = new ParallelConnection();
			ParallelConnection parallelConnection2 = new ParallelConnection();
			Resistor resistor1 = new Resistor(1000.0, 1);
			Inductor inductor1 = new Inductor(0.016, 1);
			Inductor inductor2 = new Inductor(0.035, 2);
			Capacitor capacitor2 = new Capacitor(0.00022116, 2);

			circuit.AddNode(serialConnection);
			serialConnection.AddNode(parallelConnection1);
			serialConnection.AddNode(parallelConnection2);
			parallelConnection1.AddNode(resistor1);
			parallelConnection1.AddNode(inductor1);
			parallelConnection2.AddNode(inductor2);
			parallelConnection2.AddNode(capacitor2);

			Serializer.SaveCircuit(circuit, TemplatesPath[4]);
		}

		/// <summary>
		/// Создание шаблонов для тестирования приложения
		/// </summary>
		public static void CreateTemplates()
		{
			CreateTemplates1();
			CreateTemplates2();
			CreateTemplates3();
			CreateTemplates4();
			CreateTemplates5();
		}
	}
}
