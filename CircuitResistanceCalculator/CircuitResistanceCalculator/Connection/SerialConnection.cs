using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="SerialConnection"> представляет узел цепи,
	/// организующий последовательное соединение элементов
	/// </summary>
	public class SerialConnection : ConnectionBase
	{
		/// <summary>
		/// Расчитывает общее сопротивление последовательное цепи
		/// </summary>
		/// <param name="frequency">Частота сигнала</param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			Complex circuitResistance = new Complex(0, 0);

			for (int i = 0; i < GetNodesCount(); i++)
			{
				circuitResistance += this[i].CalculateZ(frequency);
			}
			
			return new Complex(Math.Round(circuitResistance.Real,  3), 
				Math.Round(circuitResistance.Imaginary, 3));
		}
	}
}
