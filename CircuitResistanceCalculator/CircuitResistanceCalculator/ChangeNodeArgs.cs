using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitResistanceCalculator
{
	public class ChangeNodeArgs : EventArgs
	{
		public NodeBase Node { get; private set; }

		public ChangeNodeArgs(NodeBase node)
		{
			Node = node;
		}
	}
}
