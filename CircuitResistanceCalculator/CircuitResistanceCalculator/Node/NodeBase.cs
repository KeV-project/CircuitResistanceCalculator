using System;
using System.Numerics;

namespace CircuitResistanceCalculator.Node
{
	/// <summary>
	/// Класс <see cref="NodeBase"/> представляет общий 
	/// функционал для узлов дерева электрической цепи
	/// </summary>
	public abstract class NodeBase
	{
		/// <summary>
		/// Возвращает имя узла
		/// </summary>
		public abstract string Name { get; }

		/// <summary>
		/// Обпределяет сигнатуру метода ChangeNode 
		/// и обязует наследников реализовать данный метод
		/// </summary>
		public abstract void ReplaceNode(NodeBase node);

		/// <summary>
		/// Определяет сигнатуру события <see cref="NodeChanged"/>
		/// и обязует наследников реализовать данное событие
		/// </summary>
		public abstract event EventHandler<AddedNodeArgs> NodeChanged;

		/// <summary>
		/// Обпределяет сигнатуру метода RemoveNode 
		/// и обязует наследников реализовать данный метод
		/// </summary>
		public abstract void RemoveNode();

		/// <summary>
		/// Определяет сигнатуру события <see cref="NodeRemoved"/>
		/// и обязует наследников реализовать данное событие
		/// </summary>
		public abstract event EventHandler<EventArgs> NodeRemoved;

		/// <summary>
		/// Определяет сигнатуру метода для расчета комплексного
		/// сопротивления элементов и подцепей
		/// </summary>
		/// <param name="frequency">Частота сигнала</param>
		/// <returns></returns>
		public abstract Complex CalculateZ(double frequency);

		/// <summary>
		/// Устанавливает идентичность двух узлов
		/// </summary>
		/// <param name="node">Узел для сравнения</param>
		/// <returns>Возвращает 1, если объекты равны.
		/// Возвращает 0, если объекты не равны</returns>
		public abstract int CompareTo(NodeBase node);
	}
}
