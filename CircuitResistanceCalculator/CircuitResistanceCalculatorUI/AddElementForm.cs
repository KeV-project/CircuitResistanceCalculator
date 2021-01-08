using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculatorUI
{
	public partial class AddElementForm : Form
	{
		public event EventHandler<AddedNodeArgs> AddedNode;
		public AddElementForm()
		{
			InitializeComponent();

			ElementsDomainUpDown.SelectedIndex = 2;
			ElementsUnitsLabel.Text = "Ω";
		}

		private void ElementsDomainUpDown_SelectedItemChanged(object sender,
			EventArgs e)
		{
			if (ElementsDomainUpDown.SelectedIndex == 0)
			{
				ElementsUnitsLabel.Text = "H";
			}
			else if (ElementsDomainUpDown.SelectedIndex == 1)
			{
				ElementsUnitsLabel.Text = "F";
			}
			else
			{
				ElementsUnitsLabel.Text = "Ω";
			}
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if(!Int32.TryParse(IndexTextBox.Text, out int index))
			{
				MessageBox.Show("Entered string \"" + IndexTextBox.Text +
					"\" contains non-numeric symbols!");
				return;
			}

			if(!double.TryParse(ValueTextBox.Text, out double value))
			{
				MessageBox.Show("Entered string \"" + ValueTextBox.Text +
					"\" isn't a real number!");
				return;
			}

			try
			{
				if (ElementsDomainUpDown.SelectedIndex == 0)
				{
					AddedNode?.Invoke(this, new AddedNodeArgs(new Inductor(value, index)));
				}
				else if (ElementsDomainUpDown.SelectedIndex == 1)
				{
					AddedNode?.Invoke(this, new AddedNodeArgs(new Capacitor(value, index)));
				}
				else
				{
					AddedNode?.Invoke(this, new AddedNodeArgs(new Resistor(value, index)));
				}
			}
			catch(ArgumentException ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
