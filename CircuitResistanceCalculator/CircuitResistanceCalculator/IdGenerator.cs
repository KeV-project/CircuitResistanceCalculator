using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public static class IdGenerator
	{
		private static int _lastId;

		static IdGenerator()
		{
			_lastId = 0;
		}

		public static int GetId()
		{
			return ++_lastId;
		}
	}
}
