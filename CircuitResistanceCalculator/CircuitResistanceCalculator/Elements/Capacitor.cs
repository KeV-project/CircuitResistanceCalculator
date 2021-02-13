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
		/// Возвращает имя элемента, состоящее из
		/// обозначения и назначенного индекса
		/// </summary>
		public override string Name
		{
			get
			{
				return "C" + Index;
			}
		}

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
			Complex z = -1 / (2 * Math.PI * frequency * Value * new Complex(0, 1));

			return z;
		}
	}
}
