using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="ElementBase"> представляет базовый 
	/// функционал для пассивных элементов
	/// электрической цепи
	/// </summary>
	public abstract class ElementBase : NodeBase
	{
		/// <summary>
		/// Содержит индекс элемента цепи
		/// </summary>
		private int _index;

		/// <summary>
		/// Задает и возвращает индекс элемента цепи
		/// </summary>
		public int Index 
		{ 
			get
			{
				return _index;
			}
			set
			{
				const int minIndex = 0;
				const int maxIndex = Int32.MaxValue;
				ValueValidator.AssertValueInRange(value, minIndex, 
					maxIndex, "индекс элемента");
				_index = value;
			}
		}

		/// <summary>
		/// Содержит номинал элемента
		/// </summary>
		private double _value;

		/// <summary>
		/// Задает и возвращает номинал элемента
		/// </summary>
		public double Value 
		{ 
			get
			{
				return _value;
			}
			set
			{
				const double minValue = 0.000000000001;
				const double maxValue = 1000000000.0;
				ValueValidator.AssertValueInRange(value, minValue, 
					maxValue, "номинал элемента");

				if (_value != value)
				{
					_value = value;
					ValueChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// Инициализирует общие свойства наследников 
		/// класса <see cref="ElementBase">
		/// </summary>
		/// <param name="value"></param>
		public ElementBase(double value) : base()
		{
			Index = 0;
			Value = value;
		}

		/// <summary>
		/// Событие, возникающее при изменении значения свойства 
		/// <see cref="Value">, предназныченное для
		/// вызова перерасчета цепи
		/// </summary>
		public override event EventHandler<EventArgs> ValueChanged;

		/// <summary>
		/// Вызывает цепочку событий для замены текущего элемента
		/// </summary>
		/// <param name="newElement">Новый элемент</param>
		public void ChangeElement(ElementBase newElement)
		{
			if(newElement.GetType() != this.GetType())
			{
				NodeChanged?.Invoke(this, new ChangeNodeArgs(newElement));
			}
			else
			{
				Value = newElement.Value;
			}
		}

		/// <summary>
		/// Событие, возникающее при попытке заменить текущий 
		/// элемент цепи. Предназначено для замены текущего 
		/// элемента и вызова перерасчета цепи
		/// </summary>
		public override event EventHandler<ChangeNodeArgs> NodeChanged;

		/// <summary>
		/// Вызывает цепочку событий для удаления текущего элемента цепи
		/// </summary>
		public override void RemoveNode()
		{
			NodeRemoved?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Событие, возникающее при попытке удалить элемент из цепи.
		/// Предназначено для удаления текущего элемента и вызова 
		/// перерасчета цепи.
		/// </summary>
		public override event EventHandler<EventArgs> NodeRemoved;

		/// <summary>
		/// Метод предназначен для проверки подписки события
		/// <see cref="ValueChanged">по обработчик 
		/// </summary>
		/// <returns>true, если событие не подписано на обработчик,
		/// false - если событие подписано на обработчик</returns>
		public bool IsValueChangedNull()
		{
			return ValueChanged == null;
		}

		/// <summary>
		/// Метод предназначен для проверки подписки события
		/// <see cref="NodeChanged">по обработчик 
		/// </summary>
		/// <returns>true, если событие не подписано на обработчик,
		/// false - если событие подписано на обработчик</returns>
		public bool IsNodeChangedNull()
		{
			return NodeChanged == null;
		}

		/// <summary>
		/// Метод предназначен для проверки подписки события
		/// <see cref="NodeRemoved">по обработчик 
		/// </summary>
		/// <returns>true, если событие не подписано на обработчик,
		/// false - если событие подписано на обработчик</returns>
		public bool IsNodeRemovedNull()
		{
			return NodeRemoved == null;
		}
	}
}
