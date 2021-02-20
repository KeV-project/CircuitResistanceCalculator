using System.Drawing;
using CircuitVisualization.Drawers;

namespace CircuitVisualization.ElementDrawer
{
	public class CapacitorDrawer : ElementDrawerBase
	{
		private const int WIDTH = 20;
		private const int HEIGHT = 40;

		public override void Draw(Bitmap bitmap, int x, int y)
		{
			Drawer.DrawLine(bitmap, x, y, x += (Width - WIDTH) / 2, y,
				LineColor, LineWidth);

			Drawer.DrawLine(bitmap, x, y - HEIGHT / 2, x, y + HEIGHT / 2,
				LineColor, LineWidth);
			Drawer.DrawLine(bitmap, x + WIDTH, y - HEIGHT / 2,
				x + WIDTH, y + HEIGHT / 2, LineColor, LineWidth);

			Drawer.DrawLine(bitmap, x + WIDTH, y, x += WIDTH + (Width - 
				WIDTH) / 2, y, LineColor, LineWidth);
		}
	}
}
