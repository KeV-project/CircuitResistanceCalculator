using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CircuitDrawer.Drawers;
using CircuitDrawer.ElementDrawer;

namespace CircuitDrawer.ElementDrawer
{
	public class ResistorDrawer : ElementDrawerBase
	{
		private const int WIDTH = 40;
		private const int HEIGHT = 20;

		public override void Draw(Bitmap bitmap, int x, int y)
		{
			Drawer.DrawLine(bitmap, x, y, x += 40, y, LineColor, LineWidth);

			Drawer.DrawLine(bitmap, x, y - HEIGHT / 2, x, y + HEIGHT / 2,
				LineColor, LineWidth);
			Drawer.DrawLine(bitmap, x, y - HEIGHT / 2, x + WIDTH,
				y - HEIGHT / 2, LineColor, LineWidth);
			Drawer.DrawLine(bitmap, x, y + HEIGHT / 2, x + WIDTH,
				y + HEIGHT / 2, LineColor, LineWidth);
			Drawer.DrawLine(bitmap, x + WIDTH, y - HEIGHT / 2,
				x + WIDTH, y + HEIGHT / 2, LineColor, LineWidth);

			Drawer.DrawLine(bitmap, x + WIDTH, y, x + WIDTH + 40,
				y, LineColor, LineWidth);
		}
	}
}
