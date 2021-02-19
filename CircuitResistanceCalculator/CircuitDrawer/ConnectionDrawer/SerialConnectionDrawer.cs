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

namespace CircuitDrawer.ConnectionDrawer
{
	public class SerialConnectionDrawer : ConnectionDrawerBase
	{
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
