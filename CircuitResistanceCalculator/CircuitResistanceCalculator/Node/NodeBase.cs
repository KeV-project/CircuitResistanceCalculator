using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Node
{
	//TODO: Тут и много где ещё не закрываете тег <see... должно быть <see cref=".."/> +
	/// <summary>
	/// Класс <see cref="NodeBase"/> представляет общий 
	/// функционал для узлов дерева электрической цепи
	/// </summary>
	public abstract class NodeBase
	{
        //TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
		/// <summary>
		/// Определяет сигнатуру события <see cref="ValueChanged"/>
		/// и обязует наследников реализовать данное событие
		/// </summary>
		public abstract event EventHandler<EventArgs> ValueChanged;

		//TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
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

		//TODO: Не закрыт тег <see... должно быть <see cref=".."/> +
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
	}
}
