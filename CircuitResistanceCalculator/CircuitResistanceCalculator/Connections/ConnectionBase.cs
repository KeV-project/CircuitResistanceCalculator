using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	public abstract class ConnectionBase : Node.NodeBase
	{
		//TODO: set можно убрать, т.к. используется только внутри +
		/// <summary>
		/// Сожержит список узлов подцепи, представляющих 
		/// элементы или тип их соединения
		/// </summary>
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

		//TODO: Т.к. тут нет такого свойства - тегу не к чему привязаться +
		/// <summary>
		/// Событие, возникающее при изменении свойства 
		/// value какого-либо элемента списка
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

			((Node.NodeBase)obj).ValueChanged -= ChangeValue;
			((Node.NodeBase)obj).NodeChanged -= ReplaceNode;
			((Node.NodeBase)obj).NodeRemoved -= RemoveNode;
			Nodes.Remove((Node.NodeBase)obj);

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
			((Node.NodeBase)obj).ValueChanged -= ChangeValue;
			((Node.NodeBase)obj).NodeChanged -= ReplaceNode;
			((Node.NodeBase)obj).NodeRemoved -= RemoveNode;
			Nodes.Remove((Node.NodeBase)obj);
		}

		/// <summary>
		/// Событие, возникающее при попытке удалить узел из цепи
		/// </summary>
		public override event EventHandler<EventArgs> NodeRemoved;
	}
}
