using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator.UnitTests
{
	public static class InitCircuit
	{
		public static Circuit Circuit { get; private set; }

		static InitCircuit()
		{
			Circuit = new Circuit();
			ParallelConnection parallelConnection = new ParallelConnection();
			Circuit.Connection = parallelConnection;

			parallelConnection.AddNode(new Resistor(2000.0));
			parallelConnection.AddNode(new Inductor(0.016));
			parallelConnection.AddNode(new Capacitor(0.00022116));

			SerialConnection serialConnection = new SerialConnection();
			parallelConnection.AddNode(serialConnection);
			serialConnection.AddNode(new Resistor(1000.0));
			serialConnection.AddNode(new Inductor(0.016));
			serialConnection.AddNode(new Capacitor(0.00022116));

			ParallelConnection parallelConnection2 = new ParallelConnection();
			parallelConnection.AddNode(parallelConnection2);
			parallelConnection2.AddNode(new Resistor(1000.0));
			parallelConnection2.AddNode(new Inductor(0.016));
			parallelConnection2.AddNode(new Capacitor(0.00022116));
		}
	}
}
