using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public class SerialConnection : Node
	{
		private List<Node> _nodes;
		public void AddNode(Node node)
		{
			node.ValueChanged += ChangeValue;
			_nodes.Add(node);
		}
		public override Complex CalculateZ(double frequency)
		{
			Complex circuitResistance = new Complex(0, 0);

			foreach (Node node in _nodes)
			{
				circuitResistance += node.CalculateZ(frequency);
			}
			return circuitResistance;
		}

		public void ChangeValue(object obj, EventArgs e)
		{
			ValueChanged?.Invoke(this, EventArgs.Empty);
		}

		public override event EventHandler<EventArgs> ValueChanged;
	}
}
