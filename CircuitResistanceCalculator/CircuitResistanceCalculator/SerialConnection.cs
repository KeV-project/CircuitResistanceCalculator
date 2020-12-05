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

			foreach (NodeBase node in Nodes)
			{
				circuitResistance += node.CalculateZ(frequency);
			}
			return circuitResistance;
		}
	}
}
