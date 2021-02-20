using System.Drawing;
using CircuitVisualization.Drawers;

namespace CircuitVisualization.ElementDrawer
{
	/// <summary>
	/// Класс <see cref="CapacitorDrawer"/> предназначен для
	/// отрисовки конденсатора на макете электрической цепи
	/// </summary>
	public class CapacitorDrawer : ElementDrawerBase
	{
		/// <summary>
		/// Ширина конденсатора в пикселях
		/// </summary>
		private const int WIDTH = 20;

		/// <summary>
		/// Высота конденсатора в пикселях
		/// </summary>
		private const int HEIGHT = 40;

		/// <summary>
		/// Рисует конденсатор на макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение электрической цепи</param>
		/// <param name="x">Абцисса точки включения конденсатора в цепь</param>
		/// <param name="y">Ордината точки включения конденсатора в цепь</param>
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
