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
		public ConnectionBase Connection { get; private set; }
		public AddConnectionsForm()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if (ParallelRadioButton.Checked)
			{
				Connection = new CircuitResistanceCalculator.ParallelConnection();
			}
			else if (SerialRadioButton.Checked)
			{
				Connection = new SerialConnection();
			}
			DialogResult = DialogResult.OK;
		}
	}
}
