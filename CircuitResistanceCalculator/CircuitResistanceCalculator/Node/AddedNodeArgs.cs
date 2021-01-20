﻿using System;

//TODO: Если класс вложен в папку, namespace долен быть составным +
namespace CircuitResistanceCalculator.Node
{
	//TODO: XML комментарии? +
	/// <summary>
	/// Класс <see cref="AddedNodeArgs"/> предназначен для
	/// хранения нового узла электрической цепи
	/// </summary>
	public class AddedNodeArgs : EventArgs
	{
		/// <summary>
		/// Устанавливает и возвращает новый узел электрической цепи
		/// </summary>
		public NodeBase Node { get; private set; }

		/// <summary>
		/// Инициализирует свойство <see cref="Node"/> объекта
		/// класса <see cref="AddedNodeArgs"/>
		/// </summary>
		/// <param name="node">Новый узел</param>
		public AddedNodeArgs(NodeBase node)
		{
			Node = node;
		}
	}
}
