using System.Numerics;

namespace CircuitResistanceCalculator.Element
{
	/// <summary>
	/// Класс <see cref="Resistor"/> предназначен для 
	/// представления резистивного элемента 
	/// электрической цепи
	/// </summary>
	public class Resistor : ElementBase
	{
		/// <summary>
		/// Возвращает имя элемента, состоящее из
		/// обозначения и назначенного индекса
		/// </summary>
		public override string Name 
		{ 
			get
			{
				return "R" + Index;
			}
		}

		/// <summary>
		/// Инициализирует объект класса <see cref="Resistor"/>
		/// </summary>
		/// <param name="value">Номинал элемента</param>
		/// <param name="index">Индекс элемента</param>
		public Resistor(double value, int index) : base(value, index)
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
