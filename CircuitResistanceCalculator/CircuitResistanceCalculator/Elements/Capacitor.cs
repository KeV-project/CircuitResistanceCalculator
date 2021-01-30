using System;
using System.Numerics;

namespace CircuitResistanceCalculator.Elements
{
	/// <summary>
	/// Класс <see cref="Capacitor"/> предназначен для 
	/// представления емкостного элемента 
	/// электрической цепи
	/// </summary>
	public class Capacitor : ElementBase
	{
		/// <summary>
		/// Инициализирует объект класса <see cref="Capacitor"/>
		/// </summary>
		/// <param name="value">Номинал элемента</param>
		/// <param name="index">Индекс элемента</param>
		public Capacitor(double value, int index) : base(value, index)
		{

		}

		/// <summary>
		/// Производит расчет комплексного соротивления конденсатора
		/// </summary>
		/// <param name="frequency"> Частота сигнала</param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			//TODO: Зачем вы округляете Пи? о_О
			Complex capacitorZ = new Complex(0, -1) * 1 / 
				(2 * Math.Round(Math.PI, 2) * frequency * Value);

			return new Complex(capacitorZ.Real, capacitorZ.Imaginary);
		}
	}
}
