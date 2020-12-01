using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public abstract class Node
	{
		public int LastId { get; private set; } = 0;
		public int Id { get; private set; }

		public Node()
		{
			Id = ++LastId;
		}

		public abstract Complex CalculateZ(double frequency);

		
		public virtual event EventHandler<EventArgs> ValueChanged;
	}
}
