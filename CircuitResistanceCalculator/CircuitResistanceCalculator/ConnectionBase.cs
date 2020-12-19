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
			node.SetId();

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
			if(newConnection.GetType() != this.GetType())
			{
				foreach(NodeBase node in Nodes)
				{
					newConnection.AddNode(node);
				}
			}

			this.NodeChanged?.Invoke(this, new ChangeNodeArgs(newConnection));
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
			foreach(NodeBase node in Nodes)
			{
				if(node == obj)
				{
					break;
				}
				index++;
			}

			((NodeBase)obj).ValueChanged -= ChangeValue;
			((NodeBase)obj).NodeChanged -= ReplaceNode;
			Nodes.Remove((NodeBase)obj);

			e.Node.ValueChanged += ChangeValue;
			e.Node.NodeChanged += ReplaceNode;
			Nodes.Insert(index, e.Node);
		}

		public override void RemoveNode()
		{
			foreach (NodeBase node in Nodes)
			{
				node.RemoveNode();
			}
			NodeRemoved?.Invoke(this, EventArgs.Empty);
		}

		private void RemoveNode(object obj, EventArgs e)
		{
			((NodeBase)obj).ValueChanged -= ChangeValue;
			((NodeBase)obj).NodeChanged -= ReplaceNode;
			((NodeBase)obj).NodeRemoved -= RemoveNode;
			Nodes.Remove((NodeBase)obj);
		}

		public override event EventHandler<EventArgs> NodeRemoved;

		public EventHandler<EventArgs> GetChangeValueDelegate()
		{
			return ChangeValue;
		}
	}
}
