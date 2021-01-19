using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CircuitResistanceCalculator.Node;

// Почему не наоборот CircuitResistanceCalculator.Connections?

//TODO: Правильнее тогда Connection.CircuitResistanceCalculator в качестве namespace +
//TODO: Проблема есть практически в каждом классе, который вложен в папку. +
//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Connections
{
	/// <summary>
	/// Класс <see cref="ConnectionBase"/> предоставляет общий 
	/// функционал узелов дерева, определяющих тип соединения элементов
	/// </summary>
	[DataContract]
	public abstract class ConnectionBase : Node.NodeBase,
		IComparable<Node.NodeBase>
	{
		//TODO: set можно убрать, т.к. используется только внутри +
		/// <summary>
		/// Сожержит список узлов подцепи, представляющих 
		/// элементы или тип их соединения
		/// </summary>
		[DataMember]
		private List<Node.NodeBase> Nodes { get; }

		/// <summary>
		/// Позволяет получить или добавить узел в список 
		/// по указанному индуксу
		/// </summary>
		/// <param name="index">Индекс возвращаемого узла
		/// или позиция для добавления узла в список</param>
		/// <returns>Возвращает узел по указанному индексу</returns>
		public Node.NodeBase this[int index] => Nodes[index];

		//TODO: В свойство вместо метода +
		/// <summary>
		/// Возвращает количество узлов в списке соединения
		/// </summary>
		/// <returns>Количество узлов в списке соединения</returns>
		[DataMember]
		public int NodesCount 
		{
			get
			{
				return Nodes.Count;
			}
		}

		//TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
		/// <summary>
		/// Инициализирует общие свойства наследников 
		/// класса <see cref="ConnectionBase"/>
		/// </summary>
		protected ConnectionBase()
		{
			Nodes = new List<Node.NodeBase>();
		}

		/// <summary>
		/// Добавляет узел в подцепь
		/// </summary>
		/// <param name="node">Новый узел</param>
		public void AddNode(Node.NodeBase node)
		{ 
			node.NodeChanged += ReplaceNode;
			node.NodeRemoved += RemoveNode;

			Nodes.Add(node);
		}

		/// <summary>
		/// Вызывает цепочку события для замены текущего объкта
		/// в дереве электрической цепи
		/// </summary>
		/// <param name="newConnection">Новый узел</param>
		public override void ReplaceNode(Node.NodeBase newConnection)
		{
			if (newConnection.GetType() != this.GetType())
			{
				for (int i = 0; i < Nodes.Count; i++)
				{
					((ConnectionBase)newConnection).AddNode(this[i]);
				}
				this.NodeChanged?.Invoke(this, new Node.AddedNodeArgs(newConnection));
			}
		}

		//TODO: В комментарии неверная информация, т.к. это просто событие, обработчик в котором может вызвать всё что угодно т.к. +
		//TODO: событие публичное
		/// <summary>
		/// Событие, возникающее при попытке заменить текущий узел в цепи
		/// </summary>
		public override event EventHandler<Node.AddedNodeArgs> NodeChanged;

		/// <summary>
		/// Заменяет выбранный узел на новый в скиске дочерних узлов
		/// </summary>
		/// <param name="obj">Заменяемый узел</param>
		/// <param name="e">Хранит новый объект списка</param>
		private void ReplaceNode(object obj, Node.AddedNodeArgs e)
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

			((Node.NodeBase)obj).NodeChanged -= ReplaceNode;
			((Node.NodeBase)obj).NodeRemoved -= RemoveNode;
			Nodes.Remove((Node.NodeBase)obj);

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
			((Node.NodeBase)obj).NodeChanged -= ReplaceNode;
			((Node.NodeBase)obj).NodeRemoved -= RemoveNode;
			Nodes.Remove((Node.NodeBase)obj);
		}

		/// <summary>
		/// Событие, возникающее при попытке удалить узел из цепи
		/// </summary>
		public override event EventHandler<EventArgs> NodeRemoved;

		
		/// <summary>
		/// Устанавливает идентичность цепей
		/// </summary>
		/// <param name="circuit">Объект для сравнения</param>
		/// <returns>Возвращает 1, если объекты равны.
		/// Возвращает 0, если объекты не равны<returns>
		public override int CompareTo(NodeBase node)
		{
			if (node is ConnectionBase)
			{
				if (this.GetType() == node.GetType() &&
					((ConnectionBase)this).NodesCount ==
					((ConnectionBase)this).NodesCount)
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
			}
			else
			{
				return 0;
			}

			return 1;
		}
	}
}
