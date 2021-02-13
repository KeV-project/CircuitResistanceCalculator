using System;
using System.Numerics;
using System.ComponentModel;

namespace CircuitResistanceCalculatorUI.CalculatedData
{
	/// <summary>
	/// Класс <see cref="CircuitResistance"/> предназначен 
	/// для хранения частоты входного сигнала и соответствующего 
	/// ему расчитанного сопротивления цепи
	/// </summary>
	public class CircuitResistance : INotifyPropertyChanged
	{
		/// <summary>
		/// Частота сигнала
		/// </summary>
		private double _frequency;

		/// <summary>
		/// Комплексное сопротивление цепи
		/// </summary>
		private Complex _resistance;

		/// <summary>
		/// Комплексное сопротивление цепи в 
		/// алгебраической форме
		/// </summary>
		private string _displayedResistance;

		/// <summary>
		/// Возвращает и задает частоту входного сигнала
		/// </summary>
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

		/// <summary>
		/// Возвращает и задает расчитанное сопротивление цепи
		/// </summary>
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

		/// <summary>
		/// Возвращает и задает алгебраическую форму
		/// комплексного сопротивления цепи
		/// </summary>
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

		/// <summary>
		/// Событие, созникающее при изменении объекта 
		/// класса <see cref="CircuitResistance"/>
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Сообщает CircuitResistanceGridView об изменении 
		/// отображаемых данных
		/// </summary>
		/// <param name="p">Измененное свойство</param>
		private void NotifyPropertyChanged(string p)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(p));
			}
		}

		/// <summary>
		/// Инициализирует объект класса <see cref="CircuitResistance"/>
		/// </summary>
		/// <param name="frequency"></param>
		/// <param name="resistance"></param>
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
