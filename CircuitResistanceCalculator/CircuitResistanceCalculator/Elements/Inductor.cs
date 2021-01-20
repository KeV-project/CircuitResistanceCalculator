using System;
using System.Numerics;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Elements
{
	/// <summary>
	/// //TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
	/// Класс <see cref="Inductor"/> предназначен для 
	/// представления индуктивного элемента 
	/// электрической цепи
	/// </summary>
	public class Inductor : ElementBase
	{
		/// <summary>
		/// //TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
		/// Инициализирует объект класса <see cref="Inductor"/>
		/// </summary>
		/// //TODO: XML комментарии стоят не для всех аргументов +
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
			Complex inductorZ = new Complex(0, 1) * 2 * Math.Round(Math.PI, 2) 
				* frequency * Value;
			//TODO: Округление на нижнем уровне - плохая практика, т.к. это приведёт к потери точности. +
			return new Complex(inductorZ.Real, inductorZ.Imaginary);
		}
	}
}
