using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="ParallelConnection"> представляет узел цепи,
	/// организующий параллельное соединение элементов
	/// </summary>
	public class ParallelConnection : ConnectionBase
	{
		/// <summary>
		/// Расчитывает общее сопротивление параллельной цепи
		/// </summary>
		/// <param name="frequency">Частота сигнала</param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			Complex circuitResistance = new Complex(0,0);

			for(int i = 0; i < GetNodesCount(); i++)
			{
				circuitResistance += 1 / this[i].CalculateZ(frequency);
			}

			circuitResistance = 1 / circuitResistance;
			return new Complex(Math.Round(circuitResistance.Real, 3),
				Math.Round(circuitResistance.Imaginary, 3));
		}
	}
}
