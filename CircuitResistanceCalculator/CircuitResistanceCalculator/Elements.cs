using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="Elements"> предназначен для назначения
	/// индекса пассивным элементам электрической цепи
	/// </summary>
	public static class Elements
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
		private static List<Element> _elements;

		/// <summary>
		/// Инициализирует совйства класса <see cref="Elements">
		/// </summary>
		static Elements()
		{
			_elements = new List<Element>();
		}

		/// <summary>
		/// Добавляет элемент в список класса <see cref="Elements">
		/// и назначает ему актуальный индекс
		/// </summary>
		/// <param name="element">Новый элемент цепи</param>
		public static void SetIndex(Element element)
		{ 

			if (element is Resistor)
			{
				element.Index = ++_resistorLastIndex;
			}
			else if(element is Inductor)
			{
				element.Index = ++_indectorLastIndex;
			}
			else
			{
				element.Index = _capacitorLastIndex;
			}

			_elements.Add(element);
		}
	}
}
