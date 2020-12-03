using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public class Elements
	{
		private byte _resistorLastIndex = 0;
		private byte _indectorLastIndex = 0;
		private byte _capacitorLastIndex = 0;

		private List<Element> _elements;

		public Elements()
		{
			_elements = new List<Element>();
		}

		public void AddElement(Element element)
		{
			_elements.Add(element);
		}
	}
}
