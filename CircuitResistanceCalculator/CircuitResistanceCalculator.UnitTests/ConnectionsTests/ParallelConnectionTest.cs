using System;
using NUnit.Framework;
using System.Numerics;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.UnitTests.ConnectionsTests
{
	[TestFixture]
	class ParallelConnectionTest
	{
		[Test(Description = "Позитивный тест метода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			// setup
			ParallelConnection parallelConnection = new ParallelConnection();

			Resistor resistor = new Resistor(1000.0, 1);
			Inductor inductor = new Inductor(0.016, 1);
			Capacitor capacitor = new Capacitor(0.00022116, 1);

			parallelConnection.AddNode(resistor);
			parallelConnection.AddNode(inductor);
			parallelConnection.AddNode(capacitor);

			double frequency = 50.0;
			Complex expectedZ = new Complex(0.06, 7.716);

			// act
			Complex actualZ = parallelConnection.CalculateZ(frequency);
			actualZ = new Complex(Math.Round(actualZ.Real, 2), 
				Math.Round(actualZ.Imaginary, 3));

			// assert
			Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
				"рассчитывает комплексное сопротивление " +
				"последовательно цепи");
		}
	}
}
