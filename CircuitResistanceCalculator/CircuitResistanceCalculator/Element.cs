using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public abstract class Element : Node
	{
		public int Index { 
			get
			{
				return Index;
			}
			set
			{
				const int minIndex = 1;
				const int maxIndex = Int32.MaxValue;
				ValueValidator.AssertValueInRange(value, minIndex, 
					maxIndex, "индекс элемента");
				Value = value;
			}
		}

		public double Value 
		{ 
			get
			{
				return Value;
			}
			private set
			{
				const double minValue = 0.000000000001;
				const double maxValue = 1000000000.99999999999;
				ValueValidator.AssertValueInRange(value, minValue, 
					maxValue, "номинал элемента");

			}
		}

		public Element(double value) : base()
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
