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
					ElementsDistanceHeight;
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
				return width + RootWidth * 2;
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

			Drawer.DrawLine(bitmap, x, y, x + RootWidth, y, 
				LineColor, LineWidth);

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
				* ElementsDistanceHeight;
			Drawer.DrawLine(bitmap, x + RootWidth, 
				y - verticalLine / 2, x + RootWidth, 
				y + verticalLine / 2, LineColor, LineWidth);

			int currentY = y - verticalLine / 2;
			for (int i = 0; i < NodesCount; i++)
			{
				this[i].Draw(bitmap, x + RootWidth, currentY);

				if (this[i] is ParallelConnectionDrawer)
				{
					if(((ParallelConnectionDrawer)this[i]).ElementsCount != 0)
					{
						Drawer.DrawLine(bitmap, x + this[i].Width,
						currentY, x + Width - RootWidth,
						currentY, LineColor, LineWidth);
					}
				}
				else
				{
					Drawer.DrawLine(bitmap, x + RootWidth + this[i].Width, 
						currentY, x + Width - RootWidth, 
						currentY, LineColor, LineWidth);
				}

				if (i != NodesCount - 1)
				{
					currentY += this[i].Height / 2 + ElementsDistanceHeight +
						this[i + 1].Height / 2;
				}
			}

			Drawer.DrawLine(bitmap, x + Width - RootWidth,
				y - verticalLine / 2, x + Width - RootWidth,
				y + verticalLine / 2, LineColor, LineWidth);
			Drawer.DrawLine(bitmap, x + Width - RootWidth,
				y, x + Width, y, LineColor, LineWidth);
		}
	}
}
