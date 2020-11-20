using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircuitResistanceCalculator;

namespace CircuitResistanceCalculatorUI
{
	public partial class MainForm : Form
	{
		private List<Data> _data;
		public MainForm()
		{
			InitializeComponent();

			_data = new List<Data>();

			_data.Add(new Data(22.55, 55.33));
			_data.Add(new Data(13.12, 77.14));
			_data.Add(new Data(29.31, 97.05));
			_data.Add(new Data(71.23, 10.17));
			_data.Add(new Data(65.02, 12.15));
			_data.Add(new Data(87.10, 45.62));
			_data.Add(new Data(22.55, 55.33));
			_data.Add(new Data(13.12, 77.14));
			_data.Add(new Data(29.31, 97.05));
			_data.Add(new Data(71.23, 10.17));
			_data.Add(new Data(65.02, 12.15));
			_data.Add(new Data(87.10, 45.62));
			_data.Add(new Data(22.55, 55.33));
			_data.Add(new Data(13.12, 77.14));
			_data.Add(new Data(29.31, 97.05));
			_data.Add(new Data(71.23, 10.17));
			_data.Add(new Data(65.02, 12.15));
			_data.Add(new Data(87.10, 45.62));

			CircuitResistanceGridView.DataSource = _data;
		}
	}
}
