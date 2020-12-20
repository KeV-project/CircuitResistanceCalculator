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
			// Id = 1
			ParallelConnection parallelConnection = new ParallelConnection();
			Circuit.SetConnection(parallelConnection);

			//////////////////////////////////////////////////////////////////////////////////////////
			// Id = 2, Index = 1
			parallelConnection.AddNode(new Resistor(2000.0));
			// Id = 3, Index = 1
			parallelConnection.AddNode(new Inductor(0.016));
			// Id = 4, Index = 1
			parallelConnection.AddNode(new Capacitor(0.00022116));

			// Id = 5
			SerialConnection serialConnection = new SerialConnection();
			parallelConnection.AddNode(serialConnection);
			// Id = 6, Index = 2
			serialConnection.AddNode(new Resistor(1000.0));
			// Id = 7, Index = 2
			serialConnection.AddNode(new Inductor(0.016));
			// Id = 8, Index = 2
			serialConnection.AddNode(new Capacitor(0.00022116));
			
			// Id = 9
			ParallelConnection parallelConnection2 = new ParallelConnection();
			parallelConnection.AddNode(parallelConnection2);
			// Id = 10, Index = 3
			parallelConnection2.AddNode(new Resistor(1000.0));
			// Id = 11, Index = 3
			parallelConnection2.AddNode(new Inductor(0.016));
			// Id = 12, Index = 3
			parallelConnection2.AddNode(new Capacitor(0.00022116));
			////////////////////////////////////////////////////////////////////////////////////////////

			// Id = 13, Index = 4
			parallelConnection.AddNode(new Resistor (3000.0));
			// Id = 14, Index = 5
			parallelConnection.AddNode(new Resistor(5000.0));
			// Id = 15, Index = 4
			parallelConnection.AddNode(new Inductor(0.005));
		}
	}
}
