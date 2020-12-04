using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="Element"> представляет базовый 
	/// функционал для пассивных элементов
	/// электрической цепи
	/// </summary>
	public abstract class Element : Node
	{
		/// <summary>
		/// Предназначено для нумерации пассивных 
		/// элементов электрической цепи
		/// </summary>
		public int Index { 
			get
			{
				return Index;
			}
			set
			{
				const int minIndex = 1;
				const int maxIndex = Int32.MaxValue;
				ValueValidator.AssertValueInRange(value, minIndex, 
					maxIndex, "индекс элемента");
				Value = value;
			}
		}

		/// <summary>
		/// Хранит номинал элемента
		/// </summary>
		public double Value 
		{ 
			get
			{
				return Value;
			}
			private set
			{
				const double minValue = 0.000000000001;
				const double maxValue = 1000000000.0;
				ValueValidator.AssertValueInRange(value, minValue, 
					maxValue, "номинал элемента");

			}
		}

		/// <summary>
		/// Инициализирует общие свойства наследников 
		/// класса <see cref="Element">
		/// </summary>
		/// <param name="value"></param>
		public Element(double value) : base()
		{
			Index = 0;
			Value = value;
		}

		/// <summary>
		/// Метод предоставляет возможность 
		/// изменить значение свойства <see cref="Value">
		/// из внешнего кода
		/// </summary>
		/// <param name="value">Новое значение 
		/// свойства <see cref="Value"></param>
		public void ChangeValue(double value)
		{
			if (Value != value)
			{
				Value = value;
			}

			ValueChanged?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Событие, возникающее при изменении свойства 
		/// <see cref="Value">, предназныченное для
		/// перерасчета цепи
		/// </summary>
		public override event EventHandler<EventArgs> ValueChanged;
	}
}
