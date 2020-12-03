using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public class Serial : Connection
	{
		public override Complex CalculateZ(double frequency)
		{
			Complex circuitResistance = new Complex(0, 0);

			foreach (Node node in Connections)
			{
				circuitResistance += node.CalculateZ(frequency);
			}
			return circuitResistance;
		}
	}
}
