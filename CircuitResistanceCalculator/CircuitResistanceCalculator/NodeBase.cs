using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс <see cref="NodeBase"> представляет общий 
	/// функционал для узлов дерева электрической цепи
	/// </summary>
	public abstract class NodeBase
	{
		/// <summary>
		/// Уникальный идентификатор каждого узла
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// Инициализирует общие свойства наследников 
		/// класса <see cref="NodeBase">
		/// </summary>
		public NodeBase()
		{
			Id = 0;
		}

		/// <summary>
		/// Определяет сигнатуру метода для расчета комплексного
		/// сопротивления элементов и подцепей
		/// </summary>
		/// <param name="frequency">Частота сигнала</param>
		/// <returns></returns>
		public abstract Complex CalculateZ(double frequency);

		
		/// <summary>
		/// Определяет сигнатуру события <see cref="ValueChanged">
		/// </summary>
		public virtual event EventHandler<EventArgs> ValueChanged;
	}
}
