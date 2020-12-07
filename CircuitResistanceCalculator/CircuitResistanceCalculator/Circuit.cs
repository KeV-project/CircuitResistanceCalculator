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
		private ConnectionBase Connection { get; set; }

		public void SetConnection(ConnectionBase connection)
		{
			connection.ValueChanged += ValueChanged;
			connection.NodeChanged += ReplaceConnection;
			Connection.SetId();
			Connection = connection;
		}

		public Complex[] CalculateZ(double[] frequencies)
		{
			Complex[] z = new Complex[frequencies.Length];
			for (int i = 0; i < frequencies.Length; i++)
			{
				z[i] = Connection.CalculateZ(frequencies[i]);
			}
			return z;
		}

		public void ReplaceConnection(object obj, ChangeNodeArgs e)
		{
			if(Connection.GetType() != e.Node.GetType())
			{
				Connection.ValueChanged -= ValueChanged;
				Connection.NodeChanged -= ReplaceConnection;
				Connection = (ConnectionBase)e.Node;
				Connection.ValueChanged += ValueChanged;
				Connection.NodeChanged += ReplaceConnection;

			}
		}

		public void ValueChanged(object obj, EventArgs e)
		{
			CircuitChanged?.Invoke(this, EventArgs.Empty);
		}

		public event EventHandler<EventArgs> CircuitChanged;
	}
}
