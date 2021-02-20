using System.Drawing;

namespace CircuitVisualization.Drawers
{
	public static class Drawer
	{
		public static void DrawLine(Bitmap bitmap, int x1, int y1, 
			int x2, int y2, Color lineColor, int lineWidth)
		{
			Pen myPen = new Pen(lineColor, lineWidth);
			Graphics g = Graphics.FromImage(bitmap);

			g.DrawLine(myPen, x1, y1, x2, y2);

			g.Dispose();
			myPen.Dispose();
		}
	}
}
