using System.Numerics;
using System.ComponentModel;

namespace CircuitResistanceCalculatorUI.CalculatedData
{
	public class CircuitResistance : INotifyPropertyChanged
	{
		private double _frequency;

		private Complex _resistance;

		public double Frequency 
		{ 
			get
			{
				return _frequency;
			}
			private set
			{
				_frequency = value;
				NotifyPropertyChanged("Frequency");
			}
		}

		public Complex Resistance 
		{ 
			get
			{
				return _resistance;
			}
			set
			{
				_resistance = value;
				NotifyPropertyChanged("Resistance");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string p)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(p));
			}
		}

		public CircuitResistance(double frequency, 
			Complex resistance)
		{
			Frequency = frequency;
			Resistance = resistance;
		}
	}
}
