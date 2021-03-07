﻿using System.Drawing;
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
        /// <param name="bitmap">Фоновое изображения для 
        /// отисовки электрической цепи</param>
        public static Bitmap Draw(ConnectionBase circuit)
		{
            ConnectionDrawerBase circuitDrawer = 
                new SerialConnectionDrawer();
            circuitDrawer.AddNode(circuit[0]);
            var initialCircuitDrawer = circuitDrawer[0];
            var bitmap = new Bitmap(initialCircuitDrawer.Width + 1, 
                initialCircuitDrawer.Height + 1);
            int x = 0;
            int y = initialCircuitDrawer.TopHeight;
            initialCircuitDrawer.Draw(bitmap, x, y);

            return bitmap;
		}
    }
}
