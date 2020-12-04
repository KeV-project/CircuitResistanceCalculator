﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="Parallel"> представляет узел цепи,
	/// организующий параллельное соединение элементов
	/// </summary>
	public class Parallel : Connection
	{
		/// <summary>
		/// Расчитывает общее сопротивление параллельной цепи
		/// </summary>
		/// <param name="frequency">Частота сигнала</param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			Complex circuitResistance = new Complex(0,0);

			foreach(Node node in Connections)
			{
				circuitResistance += 1 / node.CalculateZ(frequency);
			}
			return 1 / circuitResistance;
		}
	}
}
