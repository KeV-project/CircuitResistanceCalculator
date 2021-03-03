using System.Drawing;
using CircuitVisualization.Drawers;
using CircuitVisualization.NodeDrawer;

namespace CircuitVisualization.ElementDrawer
{
	/// <summary>
	/// Класс <see cref="CapacitorDrawer"/> предназначен для
	/// отрисовки конденсатора на макете электрической цепи
	/// </summary>
	public class CapacitorDrawer : NodeDrawerBase
	{
		/// <summary>
		/// Ширина конденсатора в пикселях
		/// </summary>
		private const int CAPACITOR_WIDTH = 20;

		/// <summary>
		/// Ширина соединения конденсатора с предшествующим и 
		/// последующим элементами в пикселях
		/// </summary>
		private const int CONNECTION_WIDTH = 50;

		/// <summary>
		/// Высота конденсатора в пикселях
		/// </summary>
		private const int CAPACITOR_HEIGHT = 40;

		/// <summary>
		/// Высота отступа от конденсатора сверху и снизу в пикселях
		/// </summary>
		private const int VERTICAL_INDENT = 0;

		/// <summary>
		/// Возвращает полную ширину элемента, включающую 
		/// ширину конденсатора и ширину его соединения 
		/// с предшествующим и последующим элементами
		/// </summary>
		public override int Width
		{
			get
			{
				return CAPACITOR_WIDTH + CONNECTION_WIDTH * 2;
			}
		}

		/// <summary>
		/// Возвращает полную высоту элемента в пикселях, 
		/// включающую высоту конденсатора и отступы 
		/// от него сверху и снизу
		/// </summary>
		public override int Height
		{
			get
			{
				return CAPACITOR_HEIGHT + VERTICAL_INDENT * 2;
			}
		}

		public override int TopHeight
		{
			get
			{
				return Height / 2;
			}
		}

		public override int BottomHeight
		{
			get
			{
				return Height / 2;
			}
		}

		/// <summary>
		/// Рисует конденсатор на макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение электрической цепи</param>
		/// <param name="x">Абцисса точки включения конденсатора в цепь</param>
		/// <param name="y">Ордината точки включения конденсатора в цепь</param>
		public override void Draw(Bitmap bitmap, int x, int y)
		{
			Drawer.DrawLine(bitmap, x, y, x += CONNECTION_WIDTH, y,
				LINE_COLOR, LINE_WIDTH);

			Drawer.DrawLine(bitmap, x, y - CAPACITOR_HEIGHT / 2, x, 
				y + CAPACITOR_HEIGHT / 2, LINE_COLOR, LINE_WIDTH);
			Drawer.DrawLine(bitmap, x + CAPACITOR_WIDTH, y - CAPACITOR_HEIGHT / 2,
				x + CAPACITOR_WIDTH, y + CAPACITOR_HEIGHT / 2, LINE_COLOR, LINE_WIDTH);

			Drawer.DrawLine(bitmap, x + CAPACITOR_WIDTH, y, x += CAPACITOR_WIDTH + 
				CONNECTION_WIDTH, y, LINE_COLOR, LINE_WIDTH);
		}
	}
}
