using System;
using System.Drawing;
using CircuitVisualization.Drawers;

namespace CircuitVisualization.ElementDrawer
{
	/// <summary>
	/// Класс <see cref="InductorDrawer"/> предназначен для
	/// отрисовки индуктора на макете электрической цепи
	/// </summary>
	public class InductorDrawer : ElementDrawerBase
	{
		/// <summary>
		/// Ширина индуктора в пикселях
		/// </summary>
		private const int WIDTH = 80;

		/// <summary>
		/// Высота индуктора в пикселях
		/// </summary>
		private const int HEIGHT = 10;

		/// <summary>
		/// Рисует индуктор на макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение макета электрической цепи</param>
		/// <param name="x">Абцисса точки включения индуктора в цепь</param>
		/// <param name="y">Ордината точки вклюцения индуктора в цепь</param>
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
