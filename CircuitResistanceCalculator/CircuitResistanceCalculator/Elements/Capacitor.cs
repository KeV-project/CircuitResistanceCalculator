using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Elements
{
	//TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
	/// <summary>
	/// Класс <see cref="Capacitor"/> предназначен для 
	/// представления емкостного элемента 
	/// электрической цепи
	/// </summary>
	public class Capacitor : ElementBase
	{
		//TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
		/// <summary>
		/// Инициализирует объект класса <see cref="Capacitor"/>
		/// </summary>
		/// TODO: XML комментарии стоят не для всех аргументов +
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
			Complex capacitorZ = new Complex(0, -1) * 1 / 
				(2 * Math.Round(Math.PI, 2) * frequency * Value);
            //TODO: Округление на нижнем уровне - плохая практика, т.к. это приведёт к потери точности. +
			return new Complex(capacitorZ.Real, capacitorZ.Imaginary);
		}
	}
}
