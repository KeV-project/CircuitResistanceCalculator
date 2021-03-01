﻿using System.Drawing;

namespace CircuitVisualization.NodeDrawer
{
	/// <summary>
	/// Класс <see cref="NodeDrawerBase"/> предназначен для
	/// отрисовки узлов макета электрической цепи
	/// </summary>
	public abstract class NodeDrawerBase
	{
		public readonly Color LINE_COLOR = Color.Black;
		public const int LINE_WIDTH = 2;
		/// <summary>
		/// Возвращает высоту узла электрической цепи в пикселях
		/// </summary>
		public abstract int Height { get; }

		/// <summary>
		/// Возвращает ширину узла электрической цепи в пикселях
		/// </summary>
		public abstract int Width { get; }

		/// <summary>
		/// Рисует узел на макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение электрической цепи</param>
		/// <param name="x">Абцисса точки включения узла в цепь</param>
		/// <param name="y">Ордината точки включения узла в цепь</param>
		public abstract void Draw(Bitmap bitmap, int x, int y);
	}
}
