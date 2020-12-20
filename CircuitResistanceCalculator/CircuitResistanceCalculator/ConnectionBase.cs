using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="ConnectionBase"> предоставляет общий 
	/// функционал узелов дерева, определяющих тип соединения элементов
	/// </summary>
	public abstract class ConnectionBase : NodeBase
	{
		/// <summary>
		/// Сожержит список узлов подцепи, представляющих 
		/// элементы или тип их соединения
		/// </summary>
		private List<NodeBase> Nodes { get; set; }

		/// <summary>
		/// Позволяет получить или добавить узел в список 
		/// по указанному индуксу
		/// </summary>
		/// <param name="index">Индекс возвращаемого узла
		/// или позиция для добавления узла в список</param>
		/// <returns>Возвращает узел по указанному индексу</returns>
		public NodeBase this[int index] => Nodes[index];

		/// <summary>
		/// Инициализирует общие свойства наследников 
		/// класса <see cref="ConnectionBase">
		/// </summary>
		public ConnectionBase()
		{
			Nodes = new List<NodeBase>();
		}

		/// <summary>
		/// Возвращает количество узлов в списке соединения
		/// </summary>
		/// <returns></returns>
		public int GetNodesCount()
		{
			return Nodes.Count;
		}

		/// <summary>
		/// Добавляет узел в подцепь
		/// </summary>
		/// <param name="node">Новый узел</param>
		public void AddNode(NodeBase node)
		{
			if(node is ElementBase)
			{
				IndexGenerator.SetIndex((ElementBase)node);
			}
			
			node.ValueChanged += ChangeValue;
			node.NodeChanged += ReplaceNode;
			node.NodeRemoved += RemoveNode;

			Nodes.Add(node);
		}

		/// <summary>
		/// Вызывавает событие перерасчета цепи при изменении
		/// какого-либо элемента списка
		/// </summary>
		/// <param name="obj">Узел, вызвавший метод</param>
		/// <param name="e">Прочие данные</param>
		private void ChangeValue(object obj, EventArgs e)
		{
			ValueChanged?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Событие, возникающее при изменении свойства 
		/// <see cref="Value"> какого-либо элемента списка
		/// </summary>
		public override event EventHandler<EventArgs> ValueChanged;

		/// <summary>
		/// Вызывает цепочку события для замены текущего объкта
		/// в дереве электрической цепи
		/// </summary>
		/// <param name="newConnection">Новый узел</param>
		public void ChangeConnection(ConnectionBase newConnection)
		{
			if (newConnection.GetType() != this.GetType())
			{
				for (int i = 0; i < Nodes.Count; i++)
				{
					newConnection.AddNode(this[i]);
				}
				this.NodeChanged?.Invoke(this, new ChangeNodeArgs(newConnection));
			}
		}

		/// <summary>
		/// Вызывает метод <see cref="ReplaceNode(object, ChangeNodeArgs)"> 
		/// родительского объекта для замены выбранного узла в списке
		/// </summary>
		public override event EventHandler<ChangeNodeArgs> NodeChanged;

		/// <summary>
		/// Заменяет выбранный узел на новый в скиске дочерних узлов
		/// </summary>
		/// <param name="obj">Заменяемый узел</param>
		/// <param name="e">Хранит новый объект списка</param>
		private void ReplaceNode(object obj, ChangeNodeArgs e)
		{
			int index = 0;
			for (int i = 0; i < Nodes.Count; i++)
			{
				if(this[i] == obj)
				{
					break;
				}
				index = i + 1;
			}

			((NodeBase)obj).ValueChanged -= ChangeValue;
			((NodeBase)obj).NodeChanged -= ReplaceNode;
			((NodeBase)obj).NodeRemoved -= RemoveNode;
			Nodes.Remove((NodeBase)obj);

			e.Node.ValueChanged += ChangeValue;
			e.Node.NodeChanged += ReplaceNode;
			e.Node.NodeRemoved += RemoveNode;
			Nodes.Insert(index, e.Node);
		}

		/// <summary>
		/// Вызывет цепочку событий для удаления текущего узла из цепи
		/// </summary>
		public override void RemoveNode()
		{
			for(int i = 0; i < Nodes.Count; i++)
			{
				this[i].RemoveNode();
			}
			NodeRemoved?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Удаляет узел из цепи
		/// </summary>
		/// <param name="obj">Удаляемый узел</param>
		/// <param name="e">Прочие данные</param>
		private void RemoveNode(object obj, EventArgs e)
		{
			((NodeBase)obj).ValueChanged -= ChangeValue;
			((NodeBase)obj).NodeChanged -= ReplaceNode;
			((NodeBase)obj).NodeRemoved -= RemoveNode;
			Nodes.Remove((NodeBase)obj);
		}

		/// <summary>
		/// Событие, возникающее при попытке удалить узел из цепи
		/// </summary>
		public override event EventHandler<EventArgs> NodeRemoved;


		/// <summary>
		/// Метод предназначен для проверки подписки события
		/// <see cref="ValueChanged"> на обработчик 
		/// </summary>
		/// <returns>true, если событие не подписано на обработчик,
		/// false - если событие подписано на обработчик</returns>
		public bool IsValueChangedNull()
		{
			return ValueChanged == null;
		}

		/// <summary>
		/// Метод предназначен для проверки подписки события
		/// <see cref="NodeChanged"> на обработчик 
		/// </summary>
		/// <returns>true, если событие не подписано на обработчик,
		/// false - если событие подписано на обработчик</returns>
		public bool IsNodeChangedNull()
		{
			return NodeChanged == null;
		}

		/// <summary>
		/// Метод предназначен для проверки подписки события
		/// <see cref="NodeRemoved"> на обработчик 
		/// </summary>
		/// <returns>true, если событие не подписано на обработчик,
		/// false - если событие подписано на обработчик</returns>
		public bool IsNodeRemovedNull()
		{
			return NodeRemoved == null;
		}
	}
}
