using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="Inductor"> предназначен для 
	/// представления индуктивного элемента 
	/// электрической цепи
	/// </summary>
	public class Inductor : ElementBase
	{
		/// <summary>
		/// Инициализирует объект класса <see cref="Inductor">
		/// </summary>
		/// <param name="value">Номинал элемента</param>
		public Inductor(double value) : base(value)
		{

		}

		/// <summary>
		/// Производит рассчет комплексного соротивления 
		/// катушки индуктивности
		/// </summary>
		/// <param name="frequency"> Частота сигнала</param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			Complex inductorZ = new Complex(0, 1) * 2 * Math.Round(Math.PI, 2) 
				* frequency * Value;
			return new Complex(Math.Round(inductorZ.Real, 3),
				Math.Round(inductorZ.Imaginary, 3));
		}
	}
}
