using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CircuitResistanceCalculator.Node;

namespace CircuitResistanceCalculator.Connections
{
	/// <summary>
	/// Класс <see cref="ConnectionBase"/> предоставляет общий 
	/// функционал узелов дерева, определяющих тип соединения элементов
	/// </summary>
	[DataContract]
	public abstract class ConnectionBase : NodeBase,
		IComparable<NodeBase>
	{
		/// <summary>
		/// Сожержит список узлов подцепи, представляющих 
		/// элементы или тип их соединения
		/// </summary>
		[DataMember]
		private List<NodeBase> Nodes { get; }

		/// <summary>
		/// Позволяет получить или добавить узел в список 
		/// по указанному индуксу
		/// </summary>
		/// <param name="index">Индекс возвращаемого узла
		/// или позиция для добавления узла в список</param>
		/// <returns>Возвращает узел по указанному индексу</returns>
		public NodeBase this[int index] => Nodes[index];

		/// <summary>
		/// Возвращает количество узлов в списке соединения
		/// </summary>
		/// <returns>Количество узлов в списке соединения</returns>
		[DataMember]
		public int NodesCount => Nodes.Count;

		/// <summary>
		/// Инициализирует общие свойства наследников 
		/// класса <see cref="ConnectionBase"/>
		/// </summary>
		protected ConnectionBase()
		{
			Nodes = new List<NodeBase>();
		}

		/// <summary>
		/// Добавляет узел в подцепь
		/// </summary>
		/// <param name="node">Новый узел</param>
		public void AddNode(NodeBase node)
		{ 
			if(node is ConnectionBase)
			{
				((ConnectionBase)node).NodeAdded += RecalculateCircuit;
			}
			node.NodeChanged += ReplaceNode;
			node.NodeRemoved += RemoveNode;

			Nodes.Add(node);

			NodeAdded?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Вызывает событие родительского узла 
		/// для перерасчета цепи 
		/// </summary>
		/// <param name="connection">Дочерний узел</param>
		/// <param name="e">Дополнительная информация</param>
		private void RecalculateCircuit(object connection, EventArgs e)
		{
			NodeAdded?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Событие, возникающее после добавления нового узла в цепь
		/// </summary>
		public event EventHandler<EventArgs> NodeAdded;

		/// <summary>
		/// Вызывает цепочку события для замены текущего объкта
		/// в дереве электрической цепи
		/// </summary>
		/// <param name="newConnection">Новый узел</param>
		public override void ReplaceNode(NodeBase newConnection)
		{
			if (newConnection.GetType() != GetType())
			{
				NodeChanged?.Invoke(this, new AddedNodeArgs(newConnection));
			}
		}

		/// <summary>
		/// Событие, возникающее при попытке заменить текущий узел в цепи
		/// </summary>
		public override event EventHandler<AddedNodeArgs> NodeChanged;

		/// <summary>
		/// Заменяет выбранный узел на новый в скиске дочерних узлов
		/// </summary>
		/// <param name="obj">Заменяемый узел</param>
		/// <param name="e">Хранит новый объект списка</param>
		private void ReplaceNode(object currentNode, AddedNodeArgs e)
		{
			if(e.Node != null)
			{
				int index = 0;
				for (int i = 0; i < Nodes.Count; i++)
				{
					if (this[i] == currentNode)
					{
						break;
					}
					index = i + 1;
				}
				if(currentNode is ConnectionBase)
				{
					((ConnectionBase)currentNode).NodeAdded -= RecalculateCircuit;
				}
				((NodeBase)currentNode).NodeChanged -= ReplaceNode;
				((NodeBase)currentNode).NodeRemoved -= RemoveNode;
				Nodes.Remove((NodeBase)currentNode);

				if (currentNode is ConnectionBase)
				{
					((ConnectionBase)e.Node).NodeAdded += RecalculateCircuit;
				}
				e.Node.NodeChanged += ReplaceNode;
				e.Node.NodeRemoved += RemoveNode;
				Nodes.Insert(index, e.Node);
				NodeChanged?.Invoke(this, new AddedNodeArgs(null));
			}
			else
			{
				NodeChanged?.Invoke(this, new AddedNodeArgs(null));
			}
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
		/// <param name="node">Удаляемый узел</param>
		/// <param name="e">Прочие данные</param>
		private void RemoveNode(object node, EventArgs e)
		{
			if(node != null)
			{
				if(node is ConnectionBase)
				{
					((ConnectionBase)node).NodeAdded -= RecalculateCircuit;
				}
				((NodeBase)node).NodeChanged -= ReplaceNode;
				((NodeBase)node).NodeRemoved -= RemoveNode;
				Nodes.Remove((NodeBase)node);
				RemoveNode(null, EventArgs.Empty);
			}
			else
			{
				NodeRemoved?.Invoke(null, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Событие, возникающее при попытке удалить узел из цепи
		/// </summary>
		public override event EventHandler<EventArgs> NodeRemoved;

		/// <summary>
		/// Подписывает события дочерних узлов на обработчики
		/// </summary>
		public void SubscribeNodesToEvents()
		{
			for(int i = 0; i < NodesCount; i++)
			{
				this[i].NodeChanged += ReplaceNode;
				this[i].NodeRemoved += RemoveNode;
				if (this[i] is ConnectionBase)
				{
					((ConnectionBase)this[i]).NodeAdded += RecalculateCircuit;
					((ConnectionBase)this[i]).SubscribeNodesToEvents();
				}
			}
		}

		/// <summary>
		/// Устанавливает идентичность цепей
		/// </summary>
		/// <param name="circuit">Объект для сравнения</param>
		/// <returns>Возвращает 1, если объекты равны.
		/// Возвращает 0, если объекты не равны</returns>
		public override int CompareTo(NodeBase node)
		{
			if (node is ConnectionBase && 
				GetType() == node.GetType() &&
				(NodesCount == ((ConnectionBase)node).NodesCount))
			{
				for (int i = 0; i < this.NodesCount; i++)
				{
					if (this[i].CompareTo(((ConnectionBase)node)[i]) == 0)
					{
						return 0;
					}
				}
			}
			else
			{
				return 0;
			}
			return 1;
		}
	}
}
