using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using CircuitResistanceCalculator.Node;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Elements
{
	//TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
	/// <summary>
	/// Класс <see cref="ElementBase"/> представляет базовый 
	/// функционал для пассивных элементов
	/// электрической цепи
	/// </summary>
	[DataContract]
	public abstract class ElementBase : Node.NodeBase,
		IComparable<Node.NodeBase>
	{
		/// <summary>
		/// Содержит индекс элемента цепи
		/// </summary>
		[DataMember]
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
				Validators.ValueValidator.AssertValueInRange(value, minIndex, 
					maxIndex, "индекс элемента");
				_index = value;
			}
		}

		/// <summary>
		/// Содержит номинал элемента
		/// </summary>
		[DataMember]
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
				const double minValue = 0;
				const double maxValue = 1000000000.0;
				Validators.ValueValidator.AssertValueInRange(value, minValue, 
					maxValue, "номинал элемента");
				_value = value;
			}
		}

		//TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
		/// <summary>
		/// Инициализирует общие свойства наследников 
		/// класса <see cref="ElementBase"/>
		/// </summary>
		/// //TODO: XML комментарии стоят не для всех аргументов +
		/// <param name="value">Номинал элемета</param>
		/// <param name="index">Индекс элемента</param>
		protected ElementBase(double value, int index) : base()
		{
			Value = value;
			Index = index;
		}

		/// <summary>
		/// Вызывает цепочку событий для замены текущего элемента
		/// </summary>
		/// <param name="newElement">Новый элемент</param>
		public override void ReplaceNode(Node.NodeBase newElement)
		{
			if(newElement.GetType() != this.GetType())
			{
				NodeChanged?.Invoke(this, new Node.AddedNodeArgs(newElement));
			}
			else
			{
				Value = ((ElementBase)newElement).Value;
			}
		}

		/// <summary>
		/// Событие, возникающее при попытке заменить текущий 
		/// элемент цепи. Предназначено для замены текущего 
		/// элемента и вызова перерасчета цепи
		/// </summary>
		public override event EventHandler<Node.AddedNodeArgs> NodeChanged;

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
		/// Устанавливает идентичность элементов цепи
		/// </summary>
		/// <param name="node">Объект для сравнения</param>
		/// <returns>Возвращает 1, если объекты равны.
		/// Возвращает 0, если объекты не равны<returns>
		public override int CompareTo(NodeBase node)
		{
			if(this.GetType() == node.GetType() &&
				((ElementBase)this).Index == ((ElementBase)node).Index &&
				((ElementBase)this).Value == ((ElementBase)this).Value)
			{
				return 1;
			}
			return 0;
		}
	}
}
