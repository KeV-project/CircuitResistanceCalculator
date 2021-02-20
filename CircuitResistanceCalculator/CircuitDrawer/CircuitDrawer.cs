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
            circuitDrawer[0].Draw(bitmap, 0, bitmap.Height / 2);
		}
    }
}
