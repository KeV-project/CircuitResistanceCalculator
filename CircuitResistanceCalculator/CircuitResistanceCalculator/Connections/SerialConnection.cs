using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Connections
{
	//TODO: Не закрыт тег <see... должно быть <see cref=".."/>
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
			//TODO: Округление на нижнем уровне - плохая практика, т.к. это приведёт к потери точности.
			return new Complex(Math.Round(circuitResistance.Real,  3), 
				Math.Round(circuitResistance.Imaginary, 3));
		}
	}
}
