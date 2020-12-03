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
	public partial class AddConnectionsForm : Form
	{
		public Connection Connection { get; private set; }
		public AddConnectionsForm()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if (ParallelRadioButton.Checked)
			{
				Connection = new CircuitResistanceCalculator.Parallel();
			}
			else if (SerialRadioButton.Checked)
			{
				Connection = new Serial();
			}
			DialogResult = DialogResult.OK;
		}
	}
}
