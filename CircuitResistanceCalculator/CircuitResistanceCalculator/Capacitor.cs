using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="Capacitor"> предназначен для 
	/// представления емкостного элемента 
	/// электрической цепи
	/// </summary>
	public class Capacitor : Element
	{
		/// <summary>
		/// Инициализирует объект класса <see cref="Capacitor">
		/// </summary>
		/// <param name="value">Номинал элемента</param>
		public Capacitor(double value) : base(value)
		{

		}

		/// <summary>
		/// Производит рассчет комплексного соротивления конденсатора
		/// </summary>
		/// <param name="frequency"> Частота сигнала</param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			return new Complex(0, -1) * 1 / 
				(2 * Math.PI * frequency * Value);
		}
	}
}
