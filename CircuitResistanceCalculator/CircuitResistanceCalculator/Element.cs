using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public abstract class Element : Node
	{
		public byte Index { get; set; }

		public double Value { get; private set; }

		public Element(double value)
		{
			Value = value;
		}

		public void ChangeValue(double value)
		{
			if (Value != value)
			{
				Value = value;
			}

			ValueChanged?.Invoke(this, EventArgs.Empty);
		}

		public override event EventHandler<EventArgs> ValueChanged;
	}
}
