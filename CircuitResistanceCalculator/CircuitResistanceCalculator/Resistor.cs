using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public class Resistor : IElement
	{
		public int Id { get; set; }
		public int Index { get; set; }
		public double Value { get; set; }

		public Complex CalculateZ(double frequency)
		{
			return new Complex(0, 0);
		}

		event ValueChanged Event;
	}
}
