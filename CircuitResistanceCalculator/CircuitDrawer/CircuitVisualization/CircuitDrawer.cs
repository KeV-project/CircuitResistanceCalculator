using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CircuitDrawer.ConnectionDrawer;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

namespace CircuitDrawer.CircuitVisualization
{
    public static class CircuitDrawer
    {
        public static void Draw(ConnectionBase circuit, 
            Bitmap bitmap)
		{
            ConnectionDrawerBase circuitDrawer = 
                new SerialConnectionDrawer();
            circuitDrawer.AddNode(circuit[0]);
            circuitDrawer[0].Draw(bitmap, 0, bitmap.Height / 2);
		}
    }
}
