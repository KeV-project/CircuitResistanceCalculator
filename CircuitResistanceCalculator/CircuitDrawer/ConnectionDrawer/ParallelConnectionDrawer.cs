using System;
using System.Drawing;
using CircuitVisualization.Drawers;
using CircuitVisualization.NodeDrawer;

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
		/// Возвращает true, если паралелльное соединение не содержит
		/// ни одного элемента. В противном случае возвращает false
		/// </summary>
		public override bool IsEmpty
		{
			get
			{
				if(ElementsCount != 0)
				{
					return false;
				}
				return true;
			}
		}

		/// <summary>
		/// Возвращает количество непустых узлов паралелльного соединения
		/// </summary>
		private int NotEmptyNodesCount
		{
			get
			{
				int notEmptyNodesCount = 0;
				for(int i = 0; i < NodesCount; i++)
				{
					if(!this[i].IsEmpty)
					{
						notEmptyNodesCount++;
					}
				}
				return notEmptyNodesCount;
			}
		}

		/// <summary>
		/// Возвращает верхний непустой узел паралелльного соединения
		/// </summary>
		public NodeDrawerBase TopNode
		{
			get
			{
				for(int i = 0; i < NodesCount; i++)
				{
					if(!this[i].IsEmpty)
					{
						return this[i];
					}
				}
				return null;
			}
		}

		/// <summary>
		/// Возвращает нижний непустой узел паралелльного соединения
		/// </summary>
		public NodeDrawerBase BottomNode
		{
			get
			{
				for(int i = NodesCount - 1; i >= 0; i--)
				{
					if(!this[i].IsEmpty)
					{
						return this[i];
					}
				}
				return null;
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

				if(NotEmptyNodesCount > 1)
				{
					width += ROOT_WIDTH * 2;
				}

				return width;
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
				if(NotEmptyNodesCount != 0)
				{
					for (int i = 0; i < NodesCount; i++)
					{
						heigth += this[i].Height;
					}
					heigth += (NotEmptyNodesCount - 1) * ELEMENTS_DISTANCE_HEIGHT;
				}
				return heigth;
			}
		}

		/// <summary>
		/// Возвращает суммарное промежуточное расстояние между 
		/// узлами верхней или нижней части паралелльного соединения
		/// </summary>
		private int HalfElementsDistance
		{
			get
			{
				if(NotEmptyNodesCount != 0)
				{
					int notEmptyNodesCount = Convert.ToInt32(Math.Ceiling(
						NotEmptyNodesCount / 2.0));
					if (NotEmptyNodesCount % 2 != 0)
					{
						if (NotEmptyNodesCount != 1)
						{
							return (notEmptyNodesCount - 1)
								* ELEMENTS_DISTANCE_HEIGHT;
						}
					}
					else
					{
						return (notEmptyNodesCount - 1)
							* ELEMENTS_DISTANCE_HEIGHT
							+ ELEMENTS_DISTANCE_HEIGHT / 2;
					}
				}
				return 0;
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
				int height = 0;

				if (NotEmptyNodesCount != 0)
				{
					int notEmptyNodesCount = Convert.ToInt32(Math.Ceiling(
						NotEmptyNodesCount / 2.0));
					int notEmptyNodeNumber = 0;
					for (int i = 0; i < NodesCount; i++)
					{
						if(!this[i].IsEmpty)
						{
							notEmptyNodeNumber++;
							if (notEmptyNodeNumber <= notEmptyNodesCount)
							{
								if (NotEmptyNodesCount % 2 != 0 && 
									notEmptyNodeNumber == notEmptyNodesCount)
								{
									height += this[i].TopHeight;
								}
								else
								{
									height += this[i].Height;
								}
							}
						}
					}
				}

				return height += HalfElementsDistance;
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
				int height = 0;

				if (NotEmptyNodesCount != 0)
				{
					int notEmptyNodesCount = Convert.ToInt32(Math.Ceiling(
						NotEmptyNodesCount / 2.0));
					int notEmptyNodeNumber = 0;
					for (int i = 0; i < NodesCount; i++)
					{
						if (!this[i].IsEmpty)
						{
							notEmptyNodeNumber++;
							if (NotEmptyNodesCount % 2 != 0 && 
								notEmptyNodeNumber >= notEmptyNodesCount || 
								NotEmptyNodesCount % 2 == 0 && 
								notEmptyNodeNumber > notEmptyNodesCount)
							{
								if (NotEmptyNodesCount % 2 != 0 &&
									notEmptyNodeNumber == Convert.ToInt32(
									Math.Ceiling(NotEmptyNodesCount / 2.0)))
								{
									height += this[i].BottomHeight;
								}
								else
								{
									height += this[i].Height;
								}
							}
						}
					}
				}

				return height += HalfElementsDistance;
			}
		}

		/// <summary>
		/// Высолняет отрисовку соединения узла типа 
		/// <see cref="ParallelConnectionDrawer"/> 
		/// c предшествующим и последующим узлами
		/// </summary>
		/// <param name="bitmap">Изображение электрической цепи</param>
		/// <param name="x">Абцисса точки начала отрисовки вертикальной 
		/// линии паралелльного соединения</param>
		/// <param name="y">Ордината точки начала отрисовки вертикальной 
		/// линии параллельного соединения</param>
		/// <param name="rootWidth">Ширина корня соединения с 
		/// соответствующим знаком. Если корень соединяет текущий узел 
		/// с предшествующим узлом, ширина передается с отрицательным
		/// знаком. Если корень соединяет текущий узел с последующим узлом,
		/// ширина передается с положительным знаком</param>
		private void DrawConnection(Bitmap bitmap, int x, int y, int rootWidth)
		{
			if(ElementsCount != 0)
			{
				int topHeight = TopHeight - TopNode.TopHeight;
				int bottomHeight = BottomHeight - BottomNode.BottomHeight;
				Drawer.DrawLine(bitmap, x, y - topHeight, x, 
					y + bottomHeight, LINE_COLOR, LINE_WIDTH);
				if(NotEmptyNodesCount > 1)
				{
					Drawer.DrawLine(bitmap, x, y, x + rootWidth, y, 
						LINE_COLOR, LINE_WIDTH);
				}
			}
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
				y += this[i].TopHeight;

				this[i].Draw(bitmap, x, y);

				if(!(this[i] is ConnectionDrawerBase connectionDrawer 
					&& connectionDrawer.ElementsCount == 0))
				{
					if(NotEmptyNodesCount > 1)
					{
						Drawer.DrawLine(bitmap, x + this[i].Width, y,
						x + Width - ROOT_WIDTH * 2, y, LINE_COLOR, LINE_WIDTH);
					}
					else
					{
						Drawer.DrawLine(bitmap, x + this[i].Width, y,
							x + Width, y, LINE_COLOR, LINE_WIDTH);
					}
				}

				if (this[i].BottomHeight != 0)
				{
					y += this[i].BottomHeight + ELEMENTS_DISTANCE_HEIGHT;
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
			if(ElementsCount != 0)
			{
				if(NotEmptyNodesCount > 1)
				{
					x += ROOT_WIDTH;
				}
				DrawConnection(bitmap, x, y, -ROOT_WIDTH);

				DrawNodes(bitmap, x, y - TopHeight);

				if (NotEmptyNodesCount > 1)
				{
					x -= ROOT_WIDTH * 2;
				}
				DrawConnection(bitmap, x + Width, y, ROOT_WIDTH);
			}
		}
	}
}
