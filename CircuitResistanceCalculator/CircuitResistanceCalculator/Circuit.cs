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
			node.ValueChangedEvent += ValueChanged;
			_nodes.Add(node);
		}

		public Complex[] CalculateZ(double[] frequencies)
		{
			return null;
		}

		public void ValueChanged()
		{
			CircutChangedEvent?.Invoke();
		}

		public delegate void CircutChanged();
		public event CircutChanged CircutChangedEvent;
	}
}
