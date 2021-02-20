using System.Collections.Generic;
using System.Drawing;
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
		/// Возвращает дочерний элемент соединения по
		/// указанному индексу
		/// </summary>
		/// <param name="index">Индекс возвращаемого элемента</param>
		/// <returns>Дочерний элемент соединения 
		/// по указанному индексу</returns>
		public NodeDrawerBase this[int index] => Nodes[index];

		/// <summary>
		/// Возвращает цвет линии соединения
		/// </summary>
		public override Color LineColor
		{
			get
			{
				return Color.Black;
			}
		}

		/// <summary>
		/// Возвращает ширину линии соединения в пикселях
		/// </summary>
		public override int LineWidth
		{
			get
			{
				return 2;
			}
		}

		/// <summary>
		/// Возвращает ширину корня соединения
		/// </summary>
		public int RootWidth
		{
			get
			{
				return 40;
			}
		}

		/// <summary>
		/// Возвращает расстояние между соседними элементами
		/// по координате Y в пикселях
		/// </summary>
		public int ElementsDistanceHeight
		{
			get
			{
				return 10;
			}
		}

		/// <summary>
		/// Инициализирует свойста объекта класса <see cref="ConnectionDrawerBase"/>
		/// </summary>
		protected ConnectionDrawerBase()
		{
			Nodes = new List<NodeDrawerBase>();
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
