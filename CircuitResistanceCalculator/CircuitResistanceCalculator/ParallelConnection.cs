using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	class ParallelConnection : Node
	{
		private List<Node> _nodes;

		public override Complex CalculateZ(double frequency)
		{
			return new Complex(0, 0);
		}
	}
}
