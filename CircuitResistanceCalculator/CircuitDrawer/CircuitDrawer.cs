using System.Drawing;
using CircuitVisualization.ConnectionDrawer;
using CircuitResistanceCalculator.Connection;

namespace CircuitVisualization
{
    /// <summary>
    /// Класс <see cref="CircuitDrawer"/> предназначен для
    /// отрисовки электрической цепи
    /// </summary>
    public static class CircuitDrawer
    {
        /// <summary>
        /// Отрисовывает электрическую цепь на изображении
        /// </summary>
        /// <param name="circuit">Макет электрической цепи</param>
        /// <param name="bitmap">Изображения</param>
        public static void Draw(ConnectionBase circuit, 
            Bitmap bitmap)
		{
            ConnectionDrawerBase circuitDrawer = 
                new SerialConnectionDrawer();
            circuitDrawer.AddNode(circuit[0]);
            int x = (bitmap.Width - circuitDrawer[0].Width) / 2;
            int y = (bitmap.Height - circuitDrawer[0].Height) / 2 + 
                circuitDrawer[0].TopHeight;
            circuitDrawer[0].Draw(bitmap, x, y);
		}
    }
}
