using System.Drawing;

namespace CircuitVisualization.ConnectionDrawer
{
	/// <summary>
	/// Класс <see cref="SerialConnectionDrawer"/> предназначен 
	/// для отрисовки последовательного соединения элементов
	/// на макете электрической цепи
	/// </summary>
	public class SerialConnectionDrawer : ConnectionDrawerBase
	{
		/// <summary>
		/// Возвращает количество элементов в последовательном 
		/// соединении и во всех его вложенных цепях
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
		/// Возвращает true, если последовательное соединения не содержит
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
		/// Возвращает ширину последовательного соединения в пикселях
		/// </summary>
		public override int Width
		{
			get
			{
				int width = 0;
				for (int i = 0; i < NodesCount; i++)
				{
					width += this[i].Width;
				}
				return width;
			}
		}

		/// <summary>
		/// Возвращает высоту последовательного соединения в пикселях
		/// </summary>
		public override int Height
		{
			get
			{
				int heigth = 0;
				for (int i = 0; i < NodesCount; i++)
				{
					if (this[i].Height > heigth)
					{
						heigth = this[i].Height;
					}
				}
				return heigth;
			}
		}

		/// <summary>
		/// Возвращает высоту последовательного соединения
		/// выше точки включения
		/// </summary>
		public override int TopHeight
		{
			get
			{
				int height = 0;
				for(int i = 0; i < NodesCount; i++)
				{
					if(this[i].TopHeight > height)
					{
						height = this[i].TopHeight;
					}
				}
				return height;
			}
		}

		/// <summary>
		/// Возвращает высоту последовательного соединения
		/// ниже точки включения
		/// </summary>
		public override int BottomHeight
		{
			get
			{
				int height = 0;
				for (int i = 0; i < NodesCount; i++)
				{
					if (this[i].BottomHeight > height)
					{
						height = this[i].BottomHeight;
					}
				}
				return height;
			}
		}

		/// <summary>
		/// Отрисовывает последовательное соединение на
		/// макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение электрической цепи</param>
		/// <param name="x">Абцисса точки включения соединения в цепь</param>
		/// <param name="y">Ордината точки включения соединения в цепь</param>
		public override void Draw(Bitmap bitmap, int x, int y)
		{
			for(int i = 0; i < NodesCount; i++)
			{
				this[i].Draw(bitmap, x, y);
				x += this[i].Width;
			}
		}
	}
}
