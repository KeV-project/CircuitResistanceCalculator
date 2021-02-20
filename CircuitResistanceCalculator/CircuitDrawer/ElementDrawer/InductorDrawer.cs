using System;
using System.Drawing;
using CircuitVisualization.Drawers;

namespace CircuitVisualization.ElementDrawer
{
	public class InductorDrawer : ElementDrawerBase
	{
		private const int WIDTH = 80;
		private const int HEIGHT = 10;

		public override void Draw(Bitmap bitmap, int x, int y)
		{
			Drawer.DrawLine(bitmap, x, y, x += (Width - WIDTH) / 2, y, 
				LineColor, LineWidth);
			const int semicircleCount = 4;
			const int semicircleDiameter = HEIGHT * 2;
			for (int i = 0; i < semicircleCount; i++)
			{
				for (int j = x; j < x + semicircleDiameter; j++)
				{
					int x1 = j;
					int y1 = Convert.ToInt32(-1 * Math.Sqrt(Math.Pow(
						semicircleDiameter / 2, 2) - Math.Pow(
						j - (x + semicircleDiameter / 2), 2)) + y);

					int x2 = j + 1;
					int y2 = Convert.ToInt32(-1 * Math.Sqrt(Math.Pow(
						semicircleDiameter / 2, 2) - Math.Pow(
						j + 1 - (x + semicircleDiameter / 2), 2)) + y);

					Drawer.DrawLine(bitmap, x1, y1, x2, y2, LineColor, LineWidth);
				}
				x += semicircleDiameter;
			}
			Drawer.DrawLine(bitmap, x, y, x += (Width - WIDTH) / 2, y, 
				LineColor, LineWidth);
		}
	}
}
