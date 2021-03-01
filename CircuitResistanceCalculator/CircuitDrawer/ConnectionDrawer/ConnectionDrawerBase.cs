using System.Collections.Generic;
using CircuitVisualization.NodeDrawer;
using CircuitVisualization.ElementDrawer;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connection;
using CircuitResistanceCalculator.Element;

namespace CircuitVisualization.ConnectionDrawer
{
	/// <summary>
	/// Класс <see cref="ConnectionDrawerBase"/> предназначен для
	/// отрисовки соединения элементов на макете электрической цепи
 	/// </summary>
	public abstract class ConnectionDrawerBase : NodeDrawerBase
	{
		/// <summary>
		/// Дочерние узлы соединения
		/// </summary>
		private List<NodeDrawerBase> Nodes { get; }

		/// <summary>
		/// Инициализирует свойста объекта класса <see cref="ConnectionDrawerBase"/>
		/// </summary>
		protected ConnectionDrawerBase()
		{
			Nodes = new List<NodeDrawerBase>();
		}

		/// <summary>
		/// Возвращает дочерний элемент соединения по
		/// указанному индексу
		/// </summary>
		/// <param name="index">Индекс возвращаемого элемента</param>
		/// <returns>Дочерний элемент соединения 
		/// по указанному индексу</returns>
		public NodeDrawerBase this[int index]
		{
			get
			{
				return Nodes[index];
			}
		}

		/// <summary>
		/// Возвращает количество дочерних элементов соединения
		/// </summary>
		public int NodesCount
		{
			get
			{
				return Nodes.Count;
			}
		}

		/// <summary>
		/// Возвращает количество элементов в соединении
		/// и во всех его вложенных цепях
		/// </summary>
		public abstract int ElementsCount { get; }

		/// <summary>
		/// Добавляет узел в соединение
		/// </summary>
		/// <param name="node">Новый узел</param>
		public void AddNode(NodeBase node)
		{
			switch (node)
			{
				case SerialConnection serialConnection:
				{
					SerialConnectionDrawer serialConnectionDrawer =
						new SerialConnectionDrawer();
					Nodes.Add(serialConnectionDrawer);
					for (int i = 0; i < serialConnection.NodesCount; i++)
					{
						serialConnectionDrawer.AddNode(serialConnection[i]);
					}
					break;
				}
				case ParallelConnection parallelConnection:
				{
					ParallelConnectionDrawer parallelConnectionDrawer =
						new ParallelConnectionDrawer();
					Nodes.Add(parallelConnectionDrawer);
					for (int i = 0; i < parallelConnection.NodesCount; i++)
					{
						parallelConnectionDrawer.AddNode(parallelConnection[i]);
					}
					break;
				}
				case Resistor resistor:
				{
					Nodes.Add(new ResistorDrawer());
					break;
				}
				case Inductor inductor:
				{
					Nodes.Add(new InductorDrawer());
					break;
				}
				default:
				{
					Nodes.Add(new CapacitorDrawer());
					break;
				}
			}
		}
	}
}
