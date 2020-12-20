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
	class ParallelConnectionTest
	{
		[Test(Description = "Позитивный тест метода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			// arrenge
			ParallelConnection parallelConnection = 
				(ParallelConnection)InitCircuit.Circuit.Connection[4];

			double frequency = 50.0;
			Complex expectedZ = new Complex(0.06, 7.716);

			// act
			Complex actualZ = parallelConnection.CalculateZ(frequency);

			// assert
			Assert.AreEqual(expectedZ, actualZ, "Метод неверно " +
				"рассчитывает комплексное сопротивление " +
				"последовательно цепи");

		}
	}
}
