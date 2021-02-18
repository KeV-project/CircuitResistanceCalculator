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
		public override int ConnectionWidth
		{
			get
			{
				int connectionWidth = 0;
				for(int i = 0; i < NodesCount; i++)
				{
					connectionWidth += this[i].ConnectionWidth;
				}
				return connectionWidth;
			}
		}

		public override void Draw(Bitmap bitmap, int x, int y)
		{
			Drawer.DrawLine(bitmap, x, y, x += ElementsDistanceWidth, y, 
				LineColor, LineWidth);
			int connectonWidth = 0;
			for(int i = 0; i < NodesCount; i++)
			{
				connectonWidth += (this[i].ConnectionWidth * ElementDrawerBase.Height +
					(this[i].ConnectionWidth - 1) * ElementsDistanceHeight) * 2;
			}
			int verticalLine = connectonWidth + (NodesCount - 1) * ElementsDistanceHeight;
			Drawer.DrawLine(bitmap, x, y - verticalLine / 2, x, 
				y + verticalLine / 2, LineColor, LineWidth);
			y -= verticalLine / 2;
			for(int i = 0; i < NodesCount; i++)
			{
				this[i].Draw(bitmap, x, y);
				if(i != NodesCount - 1)
				{
					y += this[i].ConnectionWidth * ElementDrawerBase.Height +
					this[i].ConnectionWidth * ElementsDistanceHeight +
					this[i + 1].ConnectionWidth * ElementDrawerBase.Height +
					this[i + 1].ConnectionWidth - 1 * ElementsDistanceHeight;
				}
			}
		}
	}
}
