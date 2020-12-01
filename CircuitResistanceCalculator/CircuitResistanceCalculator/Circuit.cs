using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public class Circuit
	{
		private List<Node> _nodes;

		public Circuit()
		{
			_nodes = new List<Node>();
		}

		public void AddNode(Node node)
		{
			node.ValueChanged += ValueChanged;
			_nodes.Add(node);
		}

		public Complex[] CalculateZ(double[] frequencies)
		{
			return null;
		}

		public void ValueChanged(object obj, EventArgs e)
		{
			CircuitChanged?.Invoke(this, EventArgs.Empty);
		}

		public virtual event EventHandler<EventArgs> CircuitChanged;
	}
}
