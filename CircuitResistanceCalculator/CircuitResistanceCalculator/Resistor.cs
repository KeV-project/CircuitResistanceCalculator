﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	class Resistor : Node
	{
		public int Index { get; set; }
		public double Value { get; set; }
		public Resistor(double value) : base()
		{
			Index = 0;
		}
	}
}
