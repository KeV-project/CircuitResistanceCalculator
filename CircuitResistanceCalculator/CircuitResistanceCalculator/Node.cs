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
		public int Id { get; set; }
		public Node()
		{
			Id = 0;
		}

		public abstract Complex CalculateZ(double frequency);

		public delegate void ValueChanged();
		public virtual event ValueChanged ValueChangedEvent;
	}
}
