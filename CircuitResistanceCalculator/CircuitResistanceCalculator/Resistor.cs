using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public class Resistor : Node
	{
		public byte Index { get; set; }
		public double Value { get; set; }
		public Resistor(double value) : base()
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

			ValueChangedEvent?.Invoke();
		}

		public override event ValueChanged ValueChangedEvent;
	}
}
