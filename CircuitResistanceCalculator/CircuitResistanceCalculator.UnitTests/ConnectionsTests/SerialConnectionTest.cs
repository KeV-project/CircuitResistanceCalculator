using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace CircuitResistanceCalculator.UnitTests.ConnectionsTests
{
	[TestFixture]
	class SerialConnectionTest
	{
		[Test(Description = "Позитивный тест метода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			// setup
			Connections.SerialConnection serialConnection = 
				new Connections.SerialConnection();

			Elements.Resistor resistor = new Elements.Resistor(1000.0, 1);
			Elements.Inductor inductor = new Elements.Inductor(0.016, 1);
			Elements.Capacitor capacitor = new Elements.Capacitor(0.00022116, 1);

			serialConnection.AddNode(resistor);
			serialConnection.AddNode(inductor);
			serialConnection.AddNode(capacitor);

			double frequency = 50.0;
			Complex expectedZ = new Complex(1000, -9.376);

			// act
			Complex actualZ = serialConnection.CalculateZ(frequency);

			// assert
			Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
				"рассчитывает комплексное сопротивление " +
				"последовательно цепи");

		}
	}
}
