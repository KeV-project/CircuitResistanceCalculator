using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Node;

namespace CircuitResistanceCalculatorUI
{ 
	public partial class AddConnectionsForm : Form
	{
		public event EventHandler<AddedNodeArgs> AddedNode;
		public AddConnectionsForm()
		{
			InitializeComponent();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if(ParallelRadioButton.Checked)
			{
				AddedNode?.Invoke(this, new AddedNodeArgs(new ParallelConnection()));
			}
			else
			{
				AddedNode?.Invoke(this, new AddedNodeArgs(new SerialConnection()));
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
