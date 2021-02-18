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
		public override int ConnectionWidth
		{
			get
			{
				int connectionWidth = 0;
				for(int i = 0; i < NodesCount; i++)
				{
					if(this[i].ConnectionWidth > connectionWidth)
					{
						connectionWidth = this[i].ConnectionWidth;
					}
				}
				return connectionWidth;
			}
		}

		public override void Draw(Bitmap bitmap, int x, int y)
		{

		}
	}
}
