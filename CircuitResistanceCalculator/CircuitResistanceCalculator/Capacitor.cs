using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	class Capacitor : Node
	{
		public byte Index { get; set; }
		public double Value { get; set; }
		public Capacitor(double value) : base()
		{
			Index = 0;
		}
		public override Complex CalculateZ(double frequency)
		{
			return new Complex(0, 0);
		}
	}
}
