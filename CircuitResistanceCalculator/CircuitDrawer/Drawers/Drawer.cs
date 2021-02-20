using System.Drawing;

namespace CircuitVisualization.Drawers
{
	/// <summary>
	/// Класс <see cref="Drawer"/> предназначен отрисовки фигур на изображении
	/// </summary>
	public static class Drawer
	{
		/// <summary>
		/// Рисует линию на изображении
		/// </summary>
		/// <param name="bitmap">Изображение</param>
		/// <param name="x1">Начальная абцисса линии</param>
		/// <param name="y1">Начальная ордината линии</param>
		/// <param name="x2">Конечная абцисса линии</param>
		/// <param name="y2">Конечная ордината линии</param>
		/// <param name="lineColor">Цвет линии</param>
		/// <param name="lineWidth">Ширина линии</param>
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
