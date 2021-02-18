using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CircuitDrawer.NodeDrawer
{
	public abstract class NodeDrawerBase
	{
		public abstract int ConnectionWidth { get; }

		public abstract void Draw(Bitmap bitmap, int x, int y);
	}
}
