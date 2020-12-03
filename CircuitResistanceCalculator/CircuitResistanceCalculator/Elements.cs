using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public static class Elements
	{
		private static byte _resistorLastIndex = 0;
		private static byte _indectorLastIndex = 0;
		private static byte _capacitorLastIndex = 0;

		private static List<Element> _elements;

		static Elements()
		{
			_elements = new List<Element>();
		}

		public static void SetIndex(Element element)
		{ 

			if (element is Resistor)
			{
				element.Index = ++_resistorLastIndex;
			}
			else if(element is Inductor)
			{
				element.Index = ++_indectorLastIndex;
			}
			else
			{
				element.Index = _capacitorLastIndex;
			}

			_elements.Add(element);
		}
	}
}
