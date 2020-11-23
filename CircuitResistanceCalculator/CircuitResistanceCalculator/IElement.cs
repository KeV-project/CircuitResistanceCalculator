﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public delegate void ValueChanged(object element, object data);
	public interface IElement
	{
		int Id { get; set; }
		int Index { get; set; }
		double Value { get; set; }
		Complex CalculateZ(double frequency);
		
		event ValueChanged Event;
	}
}
