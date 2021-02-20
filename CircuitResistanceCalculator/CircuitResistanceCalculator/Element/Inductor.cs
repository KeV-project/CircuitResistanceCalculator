using System;
using System.Numerics;

namespace CircuitResistanceCalculator.Element
{
	/// <summary>
	/// Класс <see cref="Inductor"/> предназначен для 
	/// представления индуктивного элемента 
	/// электрической цепи
	/// </summary>
	public class Inductor : ElementBase
	{
		/// <summary>
		/// Возвращает имя элемента, состоящее из
		/// обозначения и назначенного индекса
		/// </summary>
		public override string Name
		{
			get
			{
				return "L" + Index;
			}
		}

		/// <summary>
		/// Инициализирует объект класса <see cref="Inductor"/>
		/// </summary>
		/// <param name="value">Номинал элемента</param>
		/// <param name="index">Индекс элемента</param>
		public Inductor(double value, int index) : base(value, index)
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
			Complex z = new Complex(0, 1) * 2 * Math.PI
				* frequency * Value;

			return z;
		}
	}
}
