using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Если класс вложен в папку, namespace долен быть составным
namespace CircuitResistanceCalculator
{
	//TODO: XML комментарии?
	public class ChangeNodeArgs : EventArgs
	{
		public NodeBase Node { get; private set; }

		public ChangeNodeArgs(NodeBase node)
		{
			Node = node;
		}
	}
}
