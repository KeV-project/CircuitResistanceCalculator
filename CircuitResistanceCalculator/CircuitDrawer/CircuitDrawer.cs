using System.Drawing;
using CircuitVisualization.ConnectionDrawer;
using CircuitResistanceCalculator.Connection;

namespace CircuitVisualization
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
