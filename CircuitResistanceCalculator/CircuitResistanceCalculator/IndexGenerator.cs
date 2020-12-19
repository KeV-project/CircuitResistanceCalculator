using System;
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
		private static byte ResistorLastIndex { get; set; } = 0;
		/// <summary>
		/// Последний выданный индекс индуктивному элементу
		/// </summary>
		private static byte IndectorLastIndex { get; set; } = 0;
		/// <summary>
		/// Последний выданный индекс емкостному элементу
		/// </summary>
		private static byte CapacitorLastIndex { get; set; } = 0;

		/// <summary>
		/// Список всех элементов электрической цепи
		/// </summary>
		private static List<ElementBase> Elements { get; set; }

		/// <summary>
		/// Инициализирует совйства класса <see cref="IndexGenerator">
		/// </summary>
		static IndexGenerator()
		{
			Elements = new List<ElementBase>();
		}

		/// <summary>
		/// Добавляет элемент в список класса <see cref="IndexGenerator">
		/// и назначает ему актуальный индекс
		/// </summary>
		/// <param name="element">Новый элемент цепи</param>
		public static void SetIndex(ElementBase newElement)
		{
			Elements.Add(newElement);

			if (newElement is Resistor)
			{
				newElement.Index = ++ResistorLastIndex;
			}
			else if(newElement is Inductor)
			{
				newElement.Index = ++IndectorLastIndex;
			}
			else
			{
				newElement.Index = ++CapacitorLastIndex;
			}
		}

		/// <summary>
		/// Удаляет этемент из списка класса <see cref="IndexGenerator">
		/// и переопределяет индексы оставшихся элементов
		/// </summary>
		/// <param name="removedElement">Удаляемый элемент</param>
		public static void RemoveElement(ElementBase removedElement)
		{
			Elements.Remove(removedElement);

			ResistorLastIndex = 0;
			IndectorLastIndex = 0;
			CapacitorLastIndex = 0;

			foreach(ElementBase element in Elements)
			{
				if (element is Resistor)
				{
					element.Index = ++ResistorLastIndex;
				}
				else if (element is Inductor)
				{
					element.Index = ++IndectorLastIndex;
				}
				else
				{
					element.Index = ++CapacitorLastIndex;
				}
			}
		}
	}
}
