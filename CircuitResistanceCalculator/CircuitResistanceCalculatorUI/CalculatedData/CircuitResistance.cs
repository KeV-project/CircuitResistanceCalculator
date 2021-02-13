using System;
using System.Numerics;
using System.ComponentModel;

namespace CircuitResistanceCalculatorUI.CalculatedData
{
	public class CircuitResistance : INotifyPropertyChanged
	{
		private double _frequency;

		private Complex _resistance;

		private string _displayedResistance;

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

		[Browsable(false)]
		public Complex Resistance
		{
			get
			{
				return _resistance;
			}
			set
			{
				_resistance = value;
				DisplayedResistance = Math.Round(_resistance.Real, 3) + 
					" + " + Math.Round(_resistance.Imaginary, 3) + "i";
			}
		}

		public string DisplayedResistance
		{
			get
			{
				return _displayedResistance;
			}
			private set
			{
				_displayedResistance = value;
				NotifyPropertyChanged("DisplayedResistance");
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
			DisplayedResistance = Math.Round(resistance.Real, 3) + " + " +
				Math.Round(resistance.Imaginary, 3) + "i";
		}
	}
}
