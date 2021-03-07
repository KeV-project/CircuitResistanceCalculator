using System.Drawing;
using CircuitVisualization.Drawers;
using CircuitVisualization.NodeDrawer;

namespace CircuitVisualization.ElementDrawer
{
	/// <summary>
	/// Класс <see cref="ResistorDrawer"/> предназначен для
	/// отрисовки резистора на макете электрической цепи
	/// </summary>
	public class ResistorDrawer : NodeDrawerBase
	{
		/// <summary>
		/// Ширина резистора в пикселях
		/// </summary>
		private const int RESISTOR_WIDTH = 40;

		/// <summary>
		/// Высота резистора в пикселях
		/// </summary>
		private const int RESISTOR_HEIGHT = 20;

		/// <summary>
		/// Ширина соединения резистора с предшествующим и 
		/// последующим элементами в пикселях
		/// </summary>
		private const int CONNECTION_WIDTH = 40;

		/// <summary>
		/// Высота отступа от резисотора сверху и снизу в пикселях
		/// </summary>
		private const int VERTICAL_INDENT = 10;

		/// <summary>
		/// Возвращает false, так как узел типа
		/// <see cref="ResistorDrawer"/> - это элемент, 
		/// имеющий ширину и высоту
		/// </summary>
		public override bool IsEmpty
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Возвращает полную ширину элемента в пикселях, 
		/// включающую ширину резистора и ширину его соединения с 
		/// предшествующим и последующим элементами
		/// </summary>
		public override int Width
		{
			get
			{
				return RESISTOR_WIDTH + CONNECTION_WIDTH * 2;
			}
		}

		/// <summary>
		/// Возвращает полную высоту элемента в пикселях, 
		/// включающую высоту резистора и отступы от него сверху 
		/// и снизу
		/// </summary>
		public override int Height
		{
			get
			{
				return RESISTOR_HEIGHT + VERTICAL_INDENT * 2;
			}
		}

		/// <summary>
		/// Возвращает высоту резистора выше точки включения в цепь
		/// </summary>
		public override int TopHeight
		{
			get
			{
				return Height / 2;
			}
		}

		/// <summary>
		/// Возвращает высоту резистора ниже точки включения в цепь
		/// </summary>
		public override int BottomHeight
		{
			get
			{
				return Height / 2;
			}
		}

		/// <summary>
		/// Рисует резистор на макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение макета электрической цепи</param>
		/// <param name="x">Абцисса точки включения резистора в цепь</param>
		/// <param name="y">Ордината точки включения резистора в цепь</param>
		public override void Draw(Bitmap bitmap, int x, int y)
		{
			Drawer.DrawLine(bitmap, x, y, x += CONNECTION_WIDTH, 
				y, LINE_COLOR, LINE_WIDTH);

			Drawer.DrawLine(bitmap, x, y - RESISTOR_HEIGHT / 2, x, 
				y + RESISTOR_HEIGHT / 2, LINE_COLOR, LINE_WIDTH);
			Drawer.DrawLine(bitmap, x, y - RESISTOR_HEIGHT / 2, x + RESISTOR_WIDTH, 
				y - RESISTOR_HEIGHT / 2, LINE_COLOR, LINE_WIDTH);
			Drawer.DrawLine(bitmap, x, y + RESISTOR_HEIGHT / 2, x + RESISTOR_WIDTH, 
				y + RESISTOR_HEIGHT / 2, LINE_COLOR, LINE_WIDTH);
			Drawer.DrawLine(bitmap, x + RESISTOR_WIDTH, y - RESISTOR_HEIGHT / 2, 
				x + RESISTOR_WIDTH, y + RESISTOR_HEIGHT / 2, LINE_COLOR, LINE_WIDTH);

			Drawer.DrawLine(bitmap, x + RESISTOR_WIDTH, y, 
				x += RESISTOR_WIDTH + CONNECTION_WIDTH, y, LINE_COLOR, LINE_WIDTH);
		}
	}
}
