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
		public abstract Color LineColor { get; }

		public abstract int LineWidth { get; }

		public abstract int Height { get; }

		public abstract int Width { get; }

		public abstract void Draw(Bitmap bitmap, int x, int y);
	}
}
