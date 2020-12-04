using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public static class IndexGenerator
	{
		private static int _lastIndex;

		static IndexGenerator()
		{
			_lastIndex = 0;
		}

		public static int GetIndex()
		{
			return ++_lastIndex;
		}
	}
}
