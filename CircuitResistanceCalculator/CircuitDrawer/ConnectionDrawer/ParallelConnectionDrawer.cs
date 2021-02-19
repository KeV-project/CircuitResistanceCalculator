using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CircuitDrawer.NodeDrawer;
using CircuitDrawer.ConnectionDrawer;
using CircuitDrawer.ElementDrawer;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;
using CircuitDrawer.Drawers;

namespace CircuitDrawer.ConnectionDrawer
{
	public class ParallelConnectionDrawer : ConnectionDrawerBase
	{
		public override int Height
		{
			get
			{
				int heigth = 0;
				for(int i = 0; i < NodesCount; i++)
				{
					heigth += this[i].Height;
				}
				return heigth + (NodesCount - 1) * ElementsDistanceHeight;
			}
		}

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
				return width + ElementsDistanceWidth * 2;
			}
		}


		public override void Draw(Bitmap bitmap, int x, int y)
		{
			Drawer.DrawLine(bitmap, x, y, x + ElementsDistanceWidth, y, 
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
			Drawer.DrawLine(bitmap, x + ElementsDistanceWidth, 
				y - verticalLine / 2, x + ElementsDistanceWidth, 
				y + verticalLine / 2, LineColor, LineWidth);
			int currentY = y - verticalLine / 2;
			for (int i = 0; i < NodesCount; i++)
			{
				this[i].Draw(bitmap, x + ElementsDistanceWidth, currentY);

				if (this[i] is ParallelConnectionDrawer)
				{
					Drawer.DrawLine(bitmap, x + this[i].Width, currentY,
						x + Width - ElementsDistanceWidth, currentY, 
						LineColor, LineWidth);
				}
				else
				{
					Drawer.DrawLine(bitmap, x + this[i].Width, currentY,
						x + Width - ElementsDistanceWidth, currentY,
						LineColor, LineWidth);
				}

				if (i != NodesCount - 1)
				{
					currentY += this[i].Height / 2 + ElementsDistanceHeight +
						this[i + 1].Height / 2;
				}
			}
			Drawer.DrawLine(bitmap, x + Width - ElementsDistanceWidth, 
				y - verticalLine / 2, x + Width - ElementsDistanceWidth, 
				y + verticalLine / 2, LineColor, LineWidth);
			Drawer.DrawLine(bitmap, x + Width - ElementsDistanceWidth, 
				y, x + Width, y, LineColor, LineWidth);
		}
	}
}
