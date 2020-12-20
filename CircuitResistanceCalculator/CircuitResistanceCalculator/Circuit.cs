using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	/// <summary>
	/// Класс  <see cref="Circuit"> представляет 
	/// организацию электрической цепи
	/// </summary>
	public class Circuit
	{
		/// <summary>
		/// Хранит корневое соединение цепи
		/// </summary>
		private ConnectionBase _connection;

		/// <summary>
		/// Задает и возвращает корневое соединение цепи
		/// </summary>
		public ConnectionBase Connection 
		{	
			get
			{
				return _connection;
			}
			private set
			{
				_connection = value;
				_connection.ValueChanged += ValueChanged;
				_connection.NodeChanged += ReplaceConnection;
				_connection.NodeRemoved += RemoveNode;
			}
		}

		/// <summary>
		/// Устанавливает корневое соединение цепи
		/// </summary>
		/// <param name="connection">Соединение</param>
		public void SetConnection(ConnectionBase connection)
		{
			if(_connection == null)
			{
				Connection = connection;
			}
			else
			{
				throw new Exception("Соединение уже задано");
			}
		}

		/// <summary>
		/// Заменяет корневое соединение цепи
		/// </summary>
		/// <param name="obj">Текущее соединение</param>
		/// <param name="e">Хранит новое соединение цепи</param>
		private void ReplaceConnection(object obj, ChangeNodeArgs e)
		{
			if (Connection.GetType() != e.Node.GetType())
			{
				Connection.ValueChanged -= ValueChanged;
				Connection.NodeChanged -= ReplaceConnection;
				Connection = (ConnectionBase)e.Node;
				Connection.ValueChanged += ValueChanged;
				Connection.NodeChanged += ReplaceConnection;
			}
		}

		/// <summary>
		/// Удаляет корневое соединение цепи
		/// </summary>
		/// <param name="obj">Текущее соединение</param>
		/// <param name="e">Прочие данные</param>
		private void RemoveNode(object obj, EventArgs e)
		{
			Connection.ValueChanged -= ValueChanged;
			((NodeBase)obj).NodeChanged -= ReplaceConnection;
			((NodeBase)obj).NodeRemoved -= RemoveNode;
			Connection = null;
		}

		/// <summary>
		/// Вызывает перерасчет цепи
		/// </summary>
		/// <param name="obj">Объект, вызывающий событие</param>
		/// <param name="e">Прочие данные</param>
		private void ValueChanged(object obj, EventArgs e)
		{
			CircuitChanged?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Событие, возникающее для перерасчета цепи
		/// </summary>
		public event EventHandler<EventArgs> CircuitChanged;

		/// <summary>
		/// Рассчитывает импедансы цепи
		/// </summary>
		/// <param name="frequencies">Список частот</param>
		/// <returns>Список импедансов</returns>
		public Complex[] CalculateZ(double[] frequencies)
		{
			Complex[] z = new Complex[frequencies.Length];
			for (int i = 0; i < frequencies.Length; i++)
			{
				z[i] = Connection.CalculateZ(frequencies[i]);
			}
			return z;
		}
	}
}
