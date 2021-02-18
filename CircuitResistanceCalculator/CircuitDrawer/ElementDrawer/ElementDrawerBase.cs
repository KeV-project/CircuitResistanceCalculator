using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircuitDrawer.NodeDrawer;

namespace CircuitDrawer.ElementDrawer
{
	public abstract class ElementDrawerBase : NodeDrawerBase
	{
		public static int Height
		{
			get
			{
				return 40;
			}
		}
	}
}
