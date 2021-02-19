using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CircuitDrawer.NodeDrawer;
using CircuitDrawer.ElementDrawer;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

namespace CircuitDrawer.ConnectionDrawer
{
	public abstract class ConnectionDrawerBase : NodeDrawerBase
	{
		private List<NodeDrawerBase> Nodes { get; }

		public NodeDrawerBase this[int index] => Nodes[index];

		public override Color LineColor
		{
			get
			{
				return Color.Black;
			}
		}

		public override int LineWidth
		{
			get
			{
				return 2;
			}
		}

		public int RootWidth
		{
			get
			{
				return 40;
			}
		}

		public int ElementsDistanceHeight
		{
			get
			{
				return 10;
			}
		}

		protected ConnectionDrawerBase()
		{
			Nodes = new List<NodeDrawerBase>();
		}

		public int NodesCount
		{
			get
			{
				return Nodes.Count;
			}
		}

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
