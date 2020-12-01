using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public class ParallelConnection : Node
	{
		private List<Node> _nodes;

		public ParallelConnection()
		{
			_nodes = new List<Node>();
		}

		public void AddNode(Node node)
		{
			node.ValueChanged += ChangeValue;
			_nodes.Add(node);
		}
		public override Complex CalculateZ(double frequency)
		{
			Complex circuitResistance = new Complex(0,0);

			foreach(Node node in _nodes)
			{
				circuitResistance += 1 / node.CalculateZ(frequency);
			}
			return 1 / circuitResistance;
		}

		public void ChangeValue(object obj,  EventArgs e)
		{
			ValueChanged?.Invoke(this, EventArgs.Empty);
		}

		public override event EventHandler<EventArgs> ValueChanged;
	}
}
