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
		/// Возвращает цвет линии для отрисовки узла
		/// электрической цепи
		/// </summary>
		public abstract Color LineColor { get; }

		/// <summary>
		/// Возвращает ширину линии в пикселях для 
		/// отрисовки узла электрической цепи
		/// </summary>
		public abstract int LineWidth { get; }

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
