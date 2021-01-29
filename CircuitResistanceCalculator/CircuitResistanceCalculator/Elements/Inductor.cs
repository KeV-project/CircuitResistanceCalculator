﻿using System;
using System.Numerics;

namespace CircuitResistanceCalculator.Elements
{
	/// <summary>
	/// Класс <see cref="Inductor"/> предназначен для 
	/// представления индуктивного элемента 
	/// электрической цепи
	/// </summary>
	public class Inductor : ElementBase
	{
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
			//TODO: Зачем вы округляете Пи? о_О
			Complex inductorZ = new Complex(0, 1) * 2 * Math.Round(Math.PI, 2) 
				* frequency * Value;

			return new Complex(inductorZ.Real, inductorZ.Imaginary);
		}
	}
}
