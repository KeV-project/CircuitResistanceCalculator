using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public class Resistor : Element
	{
		public Resistor(double value) : base(value)
		{

		}

		public override Complex CalculateZ(double frequency)
		{
			return new Complex(0, 0);
		}
	}
}
