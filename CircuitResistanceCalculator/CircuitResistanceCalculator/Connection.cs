using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public abstract class Connection : Node
	{
		public List<Node> Connections { get; set; }

		public Connection()
		{
			Connections = new List<Node>();
		}

		public void AddNode(Node node)
		{
			if(node is Element)
			{
				((Element)node).Index = Elements.GetIndex((Element)node);
			}
			node.ValueChanged += ChangeValue;
			Connections.Add(node);
		}

		public void ChangeValue(object obj, EventArgs e)
		{
			ValueChanged?.Invoke(this, EventArgs.Empty);
		}

		public override event EventHandler<EventArgs> ValueChanged;
	}
}
