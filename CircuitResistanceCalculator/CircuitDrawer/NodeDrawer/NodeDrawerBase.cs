using System.Drawing;

namespace CircuitVisualization.NodeDrawer
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
