using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CircuitDrawer.NodeDrawer;

namespace CircuitDrawer.ElementDrawer
{
	public abstract class ElementDrawerBase : NodeDrawerBase
	{
		public override Color LineColor
		{
			get
			{
				return Color.Black;
			}
		}

		public override int LineWidth
		{
			get
			{
				return 2;
			}
		}

		public override int Height
		{
			get
			{
				return 40;
			}
		}

		public override int Width
		{
			get
			{
				return 120;
			}
		}
	}
}
