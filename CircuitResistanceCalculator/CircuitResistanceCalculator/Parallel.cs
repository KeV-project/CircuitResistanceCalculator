using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public class Parallel : Connection
	{
		public override Complex CalculateZ(double frequency)
		{
			Complex circuitResistance = new Complex(0,0);

			foreach(Node node in Connections)
			{
				circuitResistance += 1 / node.CalculateZ(frequency);
			}
			return 1 / circuitResistance;
		}
	}
}
