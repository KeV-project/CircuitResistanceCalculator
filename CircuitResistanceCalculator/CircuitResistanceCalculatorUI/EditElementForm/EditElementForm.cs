using System;
using System.Windows.Forms;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculatorUI.EditElement
{
	public partial class EditElementForm : Form
	{
		private ElementBase _editableElement;

		public event EventHandler<AddedNodeArgs> CreatedNewElement;
		public EditElementForm(ElementBase element)
		{
			InitializeComponent();

			if(element == null)
			{
				ElementsDomainUpDown.SelectedIndex = 2;
				ElementsUnitsLabel.Text = "Ω";
			}
			else
			{
				if(element is Resistor)
				{
					ElementsDomainUpDown.SelectedIndex = 2;
					ElementsUnitsLabel.Text = "Ω";
				}
				else if(element is Inductor)
				{
					ElementsDomainUpDown.SelectedIndex = 0;
					ElementsUnitsLabel.Text = "H";
				}
				else
				{
					ElementsDomainUpDown.SelectedIndex = 1;
					ElementsUnitsLabel.Text = "F";
				}

				IndexTextBox.Text = Convert.ToString(element.Index);
				ValueTextBox.Text = Convert.ToString(element.Value);
			}
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
					CreatedNewElement?.Invoke(this, 
						new AddedNodeArgs(new Inductor(value, index)));
				}
				else if (ElementsDomainUpDown.SelectedIndex == 1)
				{
					CreatedNewElement?.Invoke(this, 
						new AddedNodeArgs(new Capacitor(value, index)));
				}
				else
				{
					CreatedNewElement?.Invoke(this, 
						new AddedNodeArgs(new Resistor(value, index)));
				}
			}
			catch(ArgumentException ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			
			Close();
		}
	}
}
