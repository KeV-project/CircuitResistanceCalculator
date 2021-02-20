using System.Drawing;
using CircuitVisualization.NodeDrawer;

namespace CircuitVisualization.ElementDrawer
{
	/// <summary>
	/// Класс <see cref="ElementDrawerBase"/> предназначен для
	/// отрисовки элементов на макете электрической цепи
	/// </summary>
	public abstract class ElementDrawerBase : NodeDrawerBase
	{
		/// <summary>
		/// Возвращает цвет элементов электрической цепи
		/// </summary>
		public override Color LineColor
		{
			get
			{
				return Color.Black;
			}
		}

		/// <summary>
		/// Возвращает ширину линии, которой отрисовываются
		/// элементы электрической цепи
		/// </summary>
		public override int LineWidth
		{
			get
			{
				return 2;
			}
		}

		/// <summary>
		/// Возвращает высоту элементов электрической цепи
		/// </summary>
		public override int Height
		{
			get
			{
				return 40;
			}
		}

		/// <summary>
		/// Возвращает ширину элементов электрической цепи
		/// </summary>
		public override int Width
		{
			get
			{
				return 120;
			}
		}
	}
}
