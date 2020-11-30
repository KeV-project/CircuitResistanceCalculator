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
		public AddConnectionsForm()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			//if(ParallelRadioButton.Checked)
			//{
			//	MainForm.Node = new ParallelConnection();
			//}
			//else if(SerialRadioButton.Checked)
			//{
			//	MainForm.Node = new SerialConnection();
			//}
			//DialogResult = DialogResult.OK;
		}
	}
}
