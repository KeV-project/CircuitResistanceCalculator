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
		private int _id;

		/// <summary>
		/// Задает и возвращает уникальный идентификатор 
		/// каждого узла. Id узла должен быть неотрицательным 
		/// числом, длинной не более 15 символов
		/// </summary>
		public int Id 
		{ 
			get
			{
				return _id;
			}
			private set
			{
				const int minId = 0;
				const int maxId = Int32.MaxValue;
				ValueValidator.AssertValueInRange(value, minId, maxId, 
					"идентификатор элемента");

				const int minIdLength = 1;
				const int maxIdLength = 15;
				ValueValidator.AssertLengthInRange(Convert.ToString(value), 
					minIdLength, maxIdLength, "идентификатор элемента");

				_id = value;
			}
		}

		/// <summary>
		/// Инициализирует общие свойства наследников 
		/// класса <see cref="NodeBase">
		/// </summary>
		public NodeBase()
		{
			Id = IdGenerator.GetId();
		}

		/// <summary>
		/// Определяет сигнатуру события <see cref="ValueChanged">
		/// </summary>
		public abstract event EventHandler<EventArgs> ValueChanged;

		public abstract event EventHandler<ChangeNodeArgs> NodeChanged;

		public abstract void RemoveNode();

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
