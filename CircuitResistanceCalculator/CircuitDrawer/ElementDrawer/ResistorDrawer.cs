using System.Drawing;
using CircuitVisualization.Drawers;

namespace CircuitVisualization.ElementDrawer
{
	/// <summary>
	/// Класс <see cref="ResistorDrawer"/> предназначен для
	/// отрисовки резистора на макете электрической цепи
	/// </summary>
	public class ResistorDrawer : ElementDrawerBase
	{
		/// <summary>
		/// Ширина резистора в пикселях
		/// </summary>
		private const int WIDTH = 40;

		/// <summary>
		/// Высота резистора в пикселях
		/// </summary>
		private const int HEIGHT = 20;

		/// <summary>
		/// Рисует резистор на макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение макета электрической цепи</param>
		/// <param name="x">Абцисса точки включения резистора в цепь</param>
		/// <param name="y">Ордината точки включения резистора в цепь</param>
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
