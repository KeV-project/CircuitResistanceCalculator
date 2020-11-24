using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	class SerialConnection : Node
	{
		private List<Node> _nodes;
		public override Complex CalculateZ(double frequency)
		{
			return new Complex(0, 0);
		}
	}
}
