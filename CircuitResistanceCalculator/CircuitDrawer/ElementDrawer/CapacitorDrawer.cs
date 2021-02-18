using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CircuitDrawer.ElementDrawer;

namespace CircuitDrawer.ElementDrawer
{
	public class CapacitorDrawer : ElementDrawerBase
	{
		private const int WIDTH = 20;
		private const int HEIGHT = 40;

		public override int ConnectionWidth
		{
			get
			{
				return 1;
			}
		}

		public override void Draw(Bitmap bitmap, int x, int y)
		{

		}
	}
}
