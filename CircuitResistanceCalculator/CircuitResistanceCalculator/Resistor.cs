using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="Resistor"> предназначен для 
	/// представления резистивного элемента 
	/// электрической цепи
	/// </summary>
	public class Resistor : Element
	{
		/// <summary>
		/// Инициализирует объект класса <see cref="Resistor">
		/// </summary>
		/// <param name="value"></param>
		public Resistor(double value) : base(value)
		{

		}

		/// <summary>
		/// Производит рассчет комплексного соротивления резистора
		/// </summary>
		/// <param name="frequency"> Частота сигнала</param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			return new Complex(Value, 0);
		}
	}
}
