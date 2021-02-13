using System;
using NUnit.Framework;
using System.Numerics;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculator.UnitTests.ConnectionsTests
{
	[TestFixture]
	class SerialConnectionTest
	{
		[Test(Description = "Позитивный тест метода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			// setup
			SerialConnection serialConnection = new SerialConnection();

			Resistor resistor = new Resistor(1000.0, 1);
			Inductor inductor = new Inductor(0.016, 1);
			Capacitor capacitor = new Capacitor(0.00022116, 1);

			serialConnection.AddNode(resistor);
			serialConnection.AddNode(inductor);
			serialConnection.AddNode(capacitor);

			double frequency = 50.0;
			Complex expectedZ = new Complex(1000, 19.419);

			// act
			Complex actualZ = serialConnection.CalculateZ(frequency);
			actualZ = new Complex(actualZ.Real, Math.Round(actualZ.Imaginary, 3));

			// assert
			Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
				"рассчитывает комплексное сопротивление " +
				"последовательно цепи");

		}
	}
}
