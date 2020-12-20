using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public static class IdGenerator
	{
		/// <summary>
		/// Последний выданный узлу идентификатор
		/// </summary>
		private static int _lastId;

		/// <summary>
		/// Инициализирует Id
		/// </summary>
		static IdGenerator()
		{
			_lastId = 0;
		}

		/// <summary>
		/// Выдает Id новому объекту
		/// </summary>
		/// <returns>Актуальный идентификатор</returns>
		public static int GetId()
		{
			return ++_lastId;
		}
	}
}
