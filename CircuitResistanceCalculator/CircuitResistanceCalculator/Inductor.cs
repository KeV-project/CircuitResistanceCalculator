using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public class Inductor : Node
	{
		private static byte _lastIndex = 0;
		public byte Index { get; private set; }
		public double Value { get; set; }
		public Inductor(double value) : base()
		{
			Index = 0;
		}
		public override Complex CalculateZ(double frequency)
		{
			return new Complex(0, 0);
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
