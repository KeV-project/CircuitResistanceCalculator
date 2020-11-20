using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
    public class Data
    {
		public double Frequency { get; set; }
		public double CircuitResistance { get; set; }

		public Data(double frequency, double circuitResistance)
		{
			Frequency = frequency;
			CircuitResistance = circuitResistance;
		}
	}
}
