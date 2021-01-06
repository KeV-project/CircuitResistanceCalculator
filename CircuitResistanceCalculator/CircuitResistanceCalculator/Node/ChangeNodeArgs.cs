using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Node
{
	//TODO: XML комментарии? +
	/// <summary>
	/// Класс <see cref="ChangeNodeArgs"/> предназначен для
	/// хранения нового узла электрической цепи
	/// </summary>
	public class ChangeNodeArgs : EventArgs
	{
		/// <summary>
		/// Устанавливает и возвращает новый узел электрической цепи
		/// </summary>
		public NodeBase Node { get; private set; }

		/// <summary>
		/// Инициализирует свойство <see cref="Node"/> объекта
		/// класса <see cref="ChangeNodeArgs"/>
		/// </summary>
		/// <param name="node">Новый узел</param>
		public ChangeNodeArgs(NodeBase node)
		{
			Node = node;
		}
	}
}
