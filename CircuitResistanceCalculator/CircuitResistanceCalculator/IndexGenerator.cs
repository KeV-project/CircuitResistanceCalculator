﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="IndexGenerator"> предназначен для назначения
	/// индекса пассивным элементам электрической цепи
	/// </summary>
	public static class IndexGenerator
	{
		/// <summary>
		/// Последний выданный индекс резистивному элементу
		/// </summary>
		private static byte _resistorLastIndex = 0;
		/// <summary>
		/// Последний выданный индекс индуктивному элементу
		/// </summary>
		private static byte _indectorLastIndex = 0;
		/// <summary>
		/// Последний выданный индекс емкостному элементу
		/// </summary>
		private static byte _capacitorLastIndex = 0;

		/// <summary>
		/// Список всех элементов электрической цепи
		/// </summary>
		private static List<ElementBase> _elements;

		/// <summary>
		/// Инициализирует совйства класса <see cref="IndexGenerator">
		/// </summary>
		static IndexGenerator()
		{
			_elements = new List<ElementBase>();
		}

		/// <summary>
		/// Добавляет элемент в список класса <see cref="IndexGenerator">
		/// и назначает ему актуальный индекс
		/// </summary>
		/// <param name="element">Новый элемент цепи</param>
		public static void SetIndex(ElementBase newElement)
		{
			_elements.Add(newElement);

			if (newElement is Resistor)
			{
				newElement.Index = ++_resistorLastIndex;
			}
			else if(newElement is Inductor)
			{
				newElement.Index = ++_indectorLastIndex;
			}
			else
			{
				newElement.Index = ++_capacitorLastIndex;
			}
		}
	}
}
