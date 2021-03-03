using System;
using System.Drawing;
using CircuitVisualization.Drawers;
using CircuitVisualization.NodeDrawer;

namespace CircuitVisualization.ElementDrawer
{
	/// <summary>
	/// Класс <see cref="InductorDrawer"/> предназначен для
	/// отрисовки индуктора на макете электрической цепи
	/// </summary>
	public class InductorDrawer : NodeDrawerBase
	{
		/// <summary>
		/// Ширина индуктора в пикселях
		/// </summary>
		private const int INDUCTOR_WIDTH = 80;

		/// <summary>
		/// Ширина соединения индуктора с предшествующим и 
		/// последующим элементами в пикселях
		/// </summary>
		private const int CONNECTION_WIDTH = 20;

		/// <summary>
		/// Высота индуктора в пикселях
		/// </summary>
		private const int INDUCTOR_HEIGHT = 10;

		/// <summary>
		/// Высота отступа от индуктора сверху и снизу в пикселях
		/// </summary>
		private const int VERTICAL_INDENT = 15;

		/// <summary>
		/// Возвращает полную ширину элемента, включающую 
		/// ширину индуктора и ширину его соединения 
		/// с предшествующим и последующим элементами
		/// </summary>
		public override int Width
		{
			get
			{
				return INDUCTOR_WIDTH + CONNECTION_WIDTH * 2;
			}
		}

		/// <summary>
		/// Возвращает полную высоту элемента в пикселях, 
		/// включающую высоту индуктора и отступы от него сверху 
		/// и снизу
		/// </summary>
		public override int Height
		{
			get
			{
				return INDUCTOR_HEIGHT + VERTICAL_INDENT * 2;
			}
		}

		/// <summary>
		/// Возвращает высоту индуктора выше точки включения в цепь
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
		/// Рисует индуктор на макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение макета электрической цепи</param>
		/// <param name="x">Абцисса точки включения индуктора в цепь</param>
		/// <param name="y">Ордината точки вклюцения индуктора в цепь</param>
		public override void Draw(Bitmap bitmap, int x, int y)
		{
			Drawer.DrawLine(bitmap, x, y, x += CONNECTION_WIDTH, y, 
				LINE_COLOR, LINE_WIDTH);
			const int semicircleCount = 4;
			const int semicircleDiameter = INDUCTOR_HEIGHT * 2;
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

					Drawer.DrawLine(bitmap, x1, y1, x2, y2, LINE_COLOR, LINE_WIDTH);
				}
				x += semicircleDiameter;
			}
			Drawer.DrawLine(bitmap, x, y, x += CONNECTION_WIDTH, 
				y, LINE_COLOR, LINE_WIDTH);
		}
	}
}
