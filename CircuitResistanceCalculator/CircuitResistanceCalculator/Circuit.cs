using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitResistanceCalculator
{
	public class Circuit
	{
		private ConnectionBase _connection;
		public ConnectionBase Connection 
		{	
			get
			{
				return _connection;
			}
			set
			{
				if(_connection == null)
				{
					_connection = value;
					_connection.ValueChanged += ValueChanged;
					_connection.NodeChanged += ReplaceConnection;
				}
				else
				{
					throw new Exception("Соединение уже задано");
				}
			}
		}

		public void ReplaceConnection(object obj, ChangeNodeArgs e)
		{
			//if(Connection.GetType() != e.Node.GetType())
			//{
			//	Connection.ValueChanged -= ValueChanged;
			//	Connection.NodeChanged -= ReplaceConnection;
			//	Connection = (ConnectionBase)e.Node;
			//	Connection.ValueChanged += ValueChanged;
			//	Connection.NodeChanged += ReplaceConnection;

			//}
		}

		public void ValueChanged(object obj, EventArgs e)
		{
			CircuitChanged?.Invoke(this, EventArgs.Empty);
		}

		public event EventHandler<EventArgs> CircuitChanged;

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
