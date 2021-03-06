using System.Drawing;

namespace CircuitVisualization.NodeDrawer
{
	/// <summary>
	/// Класс <see cref="NodeDrawerBase"/> предназначен для
	/// отрисовки узлов макета электрической цепи
	/// </summary>
	public abstract class NodeDrawerBase
	{
		/// <summary>
		/// Цвет макета электрической цепи
		/// </summary>
		public readonly Color LINE_COLOR = Color.Black;

		/// <summary>
		/// Ширина линии в пикселях для отрисовки 
		/// макета электрической цепи
		/// </summary>
		public const int LINE_WIDTH = 2;

		public abstract bool IsEmpty { get; }

		/// <summary>
		/// Возвращает ширину узла электрической цепи в пикселях
		/// </summary>
		public abstract int Width { get; }

		/// <summary>
		/// Возвращает высоту узла электрической цепи в пикселях
		/// </summary>
		public abstract int Height { get; }

		/// <summary>
		/// Возвращает высоту узла выше точки включения в цепь
		/// </summary>
		public abstract int TopHeight { get; }

		/// <summary>
		/// Возвращает высоту узла ниже точки включения в цепь
		/// </summary>
		public abstract int BottomHeight { get; }

		/// <summary>
		/// Рисует узел на макете электрической цепи
		/// </summary>
		/// <param name="bitmap">Изображение электрической цепи</param>
		/// <param name="x">Абцисса точки включения узла в цепь</param>
		/// <param name="y">Ордината точки включения узла в цепь</param>
		public abstract void Draw(Bitmap bitmap, int x, int y);
	}
}
