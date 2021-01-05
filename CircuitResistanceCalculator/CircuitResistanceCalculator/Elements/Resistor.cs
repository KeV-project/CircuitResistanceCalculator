using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Elements
{
	/// <summary>
	/// //TODO: Не закрыт тег <see... должно быть <see cref=".."/>
	/// Класс <see cref="Resistor"> предназначен для 
	/// представления резистивного элемента 
	/// электрической цепи
	/// </summary>
	public class Resistor : ElementBase
	{
		/// <summary>
		/// //TODO: Не закрыт тег <see... должно быть <see cref=".."/>
		/// Инициализирует объект класса <see cref="Resistor">
		/// </summary>
		/// //TODO: XML комментарии стоят не для всех аргументов
		/// <param name="value">Номинал элемента</param>
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
			//TODO: Округление на нижнем уровне - плохая практика, т.к. это приведёт к потери точности.
			return new Complex(Math.Round(Value, 3), 0);
		}
	}
}
