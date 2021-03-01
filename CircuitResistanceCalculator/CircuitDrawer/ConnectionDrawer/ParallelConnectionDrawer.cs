using System.Drawing;
using CircuitVisualization.Drawers;

namespace CircuitVisualization.ConnectionDrawer
{
	/// <summary>
	/// Класс <see cref="ParallelConnectionDrawer"/> предназначен 
	/// для отрисовки параллельного соединения элементов 
	/// на макете электрической цепи
	/// </summary>
	public class ParallelConnectionDrawer : ConnectionDrawerBase
	{
		private const int ROOT_WIDTH = 40;
		private const int ELEMENTS_DISTANCE_HEIGHT = 10;

		/// <summary>
		/// Возвращает высоту параллельного соединения в пикселях
		/// </summary>
		public override int Height
		{
			get
			{
				int heigth = 0;
				for(int i = 0; i < NodesCount; i++)
				{
					heigth += this[i].Height;
				}
				return heigth + (NodesCount - 1) * 
					ELEMENTS_DISTANCE_HEIGHT;
			}
		}

		/// <summary>
		/// Возвращает ширину параллельного соединения в пикселях
		/// </summary>
		public override int Width
		{
			get
			{
				int width = 0;
				for(int i = 0; i < NodesCount; i++)
				{
					if(this[i].Width > width)
					{
						width = this[i].Width;
					}
				}
				return width + ROOT_WIDTH * 2;
			}
		}

		/// <summary>
		/// Возвращает количество элементов в параллельном соединении
		/// и во всех его вложенных цепях
		/// </summary>
		public override int ElementsCount
		{
			get
			{
				int elementsCount = 0;
				for (int i = 0; i < NodesCount; i++)
				{
					if (this[i] is ConnectionDrawerBase connection)
					{
						elementsCount += connection.ElementsCount;
					}
					else
					{
						elementsCount++;
					}
				}
				return elementsCount;
			}
		}

		/// <summary>
		/// Рисует паралелльное соединения элементов
		/// на макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение электрической цепи</param>
		/// <param name="x">Абцисса точки включения соединения в цепь</param>
		/// <param name="y">Ордината точки включения соединения в цепь</param>
		public override void Draw(Bitmap bitmap, int x, int y)
		{
			if(ElementsCount == 0)
			{
				return;
			}

			Drawer.DrawLine(bitmap, x, y, x + ROOT_WIDTH, y, 
				LINE_COLOR, LINE_WIDTH);

			int connectonWidth = 0;
			for(int i = 0; i < NodesCount; i++)
			{
				if (i == 0 || i == NodesCount - 1)
				{
					connectonWidth += this[i].Height / 2;
				}
				else
				{
					connectonWidth += this[i].Height;
				}
			}
			int verticalLine = connectonWidth + (NodesCount - 1) 
				* ELEMENTS_DISTANCE_HEIGHT;
			Drawer.DrawLine(bitmap, x + ROOT_WIDTH, 
				y - verticalLine / 2, x + ROOT_WIDTH, 
				y + verticalLine / 2, LINE_COLOR, LINE_WIDTH);

			int currentY = y - verticalLine / 2;
			for (int i = 0; i < NodesCount; i++)
			{
				this[i].Draw(bitmap, x + ROOT_WIDTH, currentY);

				if (this[i] is ParallelConnectionDrawer)
				{
					if(((ParallelConnectionDrawer)this[i]).ElementsCount != 0)
					{
						Drawer.DrawLine(bitmap, x + this[i].Width,
						currentY, x + Width - ROOT_WIDTH,
						currentY, LINE_COLOR, LINE_WIDTH);
					}
				}
				else 
				{
					Drawer.DrawLine(bitmap, x + ROOT_WIDTH + this[i].Width, 
						currentY, x + Width - ROOT_WIDTH, 
						currentY, LINE_COLOR, LINE_WIDTH);
				}

				if (i != NodesCount - 1)
				{
					currentY += this[i].Height / 2 + ELEMENTS_DISTANCE_HEIGHT +
						this[i + 1].Height / 2;
				}
			}

			Drawer.DrawLine(bitmap, x + Width - ROOT_WIDTH,
				y - verticalLine / 2, x + Width - ROOT_WIDTH,
				y + verticalLine / 2, LINE_COLOR, LINE_WIDTH);
			Drawer.DrawLine(bitmap, x + Width - ROOT_WIDTH,
				y, x + Width, y, LINE_COLOR, LINE_WIDTH);
		}
	}
}
