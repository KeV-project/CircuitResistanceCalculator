using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	class Resistor : Node
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
			if(value != Value && ValueChanged != null)
			{
				//ValueChanged.Invoke();
			}
		}

		event EventHandler ValueChanged;
	}
}
