using System;
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
		/// Ширина соединения узла класса 
		/// <see cref="ParallelConnectionDrawer"/> 
		/// с предшествующим и последующим 
		/// узлом электрической цепи в пикселях
		/// </summary>
		private const int ROOT_WIDTH = 40;

		/// <summary>
		/// Расстояние между параллельными ветвями в пикселях
		/// </summary>
		private const int ELEMENTS_DISTANCE_HEIGHT = 10;


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
		/// Возвращает ширину параллельного соединения в пикселях
		/// </summary>
		public override int Width
		{
			get
			{
				if (ElementsCount == 0)
				{
					return 0;
				}

				int width = 0;
				for (int i = 0; i < NodesCount; i++)
				{
					if (this[i].Width > width)
					{
						width = this[i].Width;
					}
				}
				return width + ROOT_WIDTH * 2;
			}
		}

		/// <summary>
		/// Возвращает высоту параллельного соединения в пикселях
		/// </summary>
		public override int Height
		{
			get
			{
				int heigth = 0;
				if(NodesCount != 0)
				{
					for (int i = 0; i < NodesCount; i++)
					{
						heigth += this[i].Height;
					}
					heigth += (NodesCount - 1) * ELEMENTS_DISTANCE_HEIGHT;
				}
				return heigth;
			}
		}

		/// <summary>
		/// Возвращает высоту параллельного соединения выше
		/// точки включения в цепь
		/// </summary>
		public override int TopHeight
		{
			get
			{
				if(NodesCount == 0)
				{
					return 0;
				}

				if(NodesCount == 1)
				{
					return this[0].TopHeight;
				}

				int nodesCount = Convert.ToInt32(Math.Round(NodesCount / 2.0));

				if(nodesCount == 1)
				{
					return this[0].Height + ELEMENTS_DISTANCE_HEIGHT / 2;
				}

				int height = 0;
				for (int i = 0; i < nodesCount; i++)
				{
					if(NodesCount % 2 != 0 && i == nodesCount - 1)
					{
						height += this[i].TopHeight;
					}
					else
					{
						height += this[i].Height;
					}
				}
				
				if(NodesCount % 2 != 0)
				{
					height += (nodesCount - 1) * ELEMENTS_DISTANCE_HEIGHT;
				}
				else
				{
					height += (nodesCount - 1) * ELEMENTS_DISTANCE_HEIGHT +
						ELEMENTS_DISTANCE_HEIGHT / 2;
				}
				return height;
			}
		}

		/// <summary>
		/// Возвращает высоту параллельного соединения 
		/// ниже точки включения в цепь
		/// </summary>
		public override int BottomHeight
		{
			get
			{
				if (NodesCount == 0)
				{
					return 0;
				}

				if (NodesCount == 1)
				{
					return this[0].BottomHeight;
				}

				int nodesCount = Convert.ToInt32(Math.Round(NodesCount / 2.0));

				if (nodesCount == 1)
				{
					return this[1].Height + ELEMENTS_DISTANCE_HEIGHT / 2;
				}

				int height = 0;
				for(int i = NodesCount / 2; i < NodesCount; i++)
				{
					if(NodesCount % 2 != 0 && i == NodesCount / 2)
					{
						height += this[i].BottomHeight;
					}
					else
					{
						height += this[i].Height;
					}
				}

				if (NodesCount % 2 != 0)
				{
					height += (nodesCount - 1) * ELEMENTS_DISTANCE_HEIGHT;
				}
				else
				{
					height += (nodesCount - 1) * ELEMENTS_DISTANCE_HEIGHT +
						ELEMENTS_DISTANCE_HEIGHT / 2;
				}
				return height;
			}
		}

		/// <summary>
		/// Рисует вертикальную линию параллельного соединения
		/// </summary>
		/// <param name="bitmap">Графическая модель электрической цепи</param>
		/// <param name="x">Абцисса точки включения узла в цепь, 
		/// смещенная на ширину корня соединения</param>
		/// <param name="y">Ордината точки включения узла в цепь</param>
		private void DrawVerticalLine(Bitmap bitmap, int x, int y)
		{
			int topHeight = TopHeight - this[0].TopHeight;
			Drawer.DrawLine(bitmap, x, y - topHeight, x, y, 
				LINE_COLOR, LINE_WIDTH);
			int bottomHeight = BottomHeight - this[NodesCount - 1].BottomHeight;
			Drawer.DrawLine(bitmap, x, y, x, y + bottomHeight, 
				LINE_COLOR, LINE_WIDTH);
		}

		/// <summary>
		/// Выполняет отрисовку дочерних узлов параллельного соединения
		/// </summary>
		/// <param name="bitmap">Изображение макета электрической цепи</param>
		/// <param name="x">Абцисса точки включения нулевого узла</param>
		/// <param name="y">Ордината точки включения нулевого узла</param>
		private void DrawNodes(Bitmap bitmap, int x, int y)
		{
			for (int i = 0; i < NodesCount; i++)
			{
				this[i].Draw(bitmap, x + ROOT_WIDTH, y);

				Drawer.DrawLine(bitmap, x + ROOT_WIDTH + this[i].Width,
						y, x + Width - ROOT_WIDTH, y, LINE_COLOR, LINE_WIDTH);
				

				if (i != NodesCount - 1)
				{
					y += this[i].BottomHeight + this[i + 1].TopHeight +
						ELEMENTS_DISTANCE_HEIGHT;
				}
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

			DrawVerticalLine(bitmap, x + ROOT_WIDTH, y);

			DrawNodes(bitmap, x, y - TopHeight + this[0].TopHeight);

			Drawer.DrawLine(bitmap, x + Width - ROOT_WIDTH,
				y - TopHeight + this[0].TopHeight, x + Width - ROOT_WIDTH,
				y + BottomHeight - this[NodesCount - 1].BottomHeight,
				LINE_COLOR, LINE_WIDTH);
			Drawer.DrawLine(bitmap, x + Width - ROOT_WIDTH,
				y, x + Width, y, LINE_COLOR, LINE_WIDTH);
		}
	}
}
