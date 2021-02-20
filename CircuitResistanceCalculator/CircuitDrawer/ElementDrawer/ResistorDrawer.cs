using System.Drawing;
using CircuitVisualization.Drawers;

namespace CircuitVisualization.ElementDrawer
{
	public class ResistorDrawer : ElementDrawerBase
	{
		private const int WIDTH = 40;
		private const int HEIGHT = 20;

		public override void Draw(Bitmap bitmap, int x, int y)
		{
			Drawer.DrawLine(bitmap, x, y, x += (Width - WIDTH) / 2, 
				y, LineColor, LineWidth);

			Drawer.DrawLine(bitmap, x, y - HEIGHT / 2, x, y + HEIGHT / 2,
				LineColor, LineWidth);
			Drawer.DrawLine(bitmap, x, y - HEIGHT / 2, x + WIDTH,
				y - HEIGHT / 2, LineColor, LineWidth);
			Drawer.DrawLine(bitmap, x, y + HEIGHT / 2, x + WIDTH,
				y + HEIGHT / 2, LineColor, LineWidth);
			Drawer.DrawLine(bitmap, x + WIDTH, y - HEIGHT / 2,
				x + WIDTH, y + HEIGHT / 2, LineColor, LineWidth);

			Drawer.DrawLine(bitmap, x + WIDTH, y, x += WIDTH + (Width - 
				WIDTH) / 2, y, LineColor, LineWidth);
		}
	}
}
