using System.Drawing;

using CircuitVisualization.ElementDrawer;

namespace CircuitVisualization.ConnectionDrawer
{
	public class SerialConnectionDrawer : ConnectionDrawerBase
	{
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

		public override int Height
		{
			get
			{
				int heigth = 0;
				for(int i = 0; i < NodesCount; i++)
				{
					if(this[i].Height > heigth)
					{
						heigth = this[i].Height;
					}
				}
				return heigth;
			}
		}

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
