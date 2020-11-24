using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	abstract class Node
	{
		public int Id { get; set; }

		public abstract Complex CalculateZ(double frequency);
		public Node()
		{
			Id = 0;
		}
	}
}
