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
		public ConnectionBase Connection { get; private set; }

		public void SetConnection(ConnectionBase connection)
		{
			connection.ValueChanged += ValueChanged;
			Connection = connection;
		}

		public Complex[] CalculateZ(double[] frequencies)
		{
			return null;
		}

		public void ValueChanged(object obj, EventArgs e)
		{
			CircuitChanged?.Invoke(this, EventArgs.Empty);
		}

		public virtual event EventHandler<EventArgs> CircuitChanged;
	}
}
