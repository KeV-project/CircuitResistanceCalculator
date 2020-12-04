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
	public partial class AddElementForm : Form
	{
		public ElementBase Element { get; private set; } 
		public AddElementForm(ElementBase element)
		{
			InitializeComponent();

			Element = element;
		}

		private void AddElementForm_Load(object sender, EventArgs e)
		{
			if (Element == null)
			{
				this.Text = "Add element";
				ElementsDomainUpDown.SelectedIndex = 2;
				ElementsUnitsLabel.Text = "Ω";
				ElementsDomainUpDown.Enabled = true;
			}
			else
			{
				this.Text = "Edit element";
				if(Element is Resistor)
				{
					ElementsDomainUpDown.SelectedIndex = 2;
					ElementsUnitsLabel.Text = "Ω";
				}
				else if(Element is Inductor)
				{
					ElementsDomainUpDown.SelectedIndex = 0;
					ElementsUnitsLabel.Text = "H";
				}
				else if(Element is Capacitor)
				{
					ElementsDomainUpDown.SelectedIndex = 1;
					ElementsUnitsLabel.Text = "F";
				}
				ElementsDomainUpDown.Enabled = false;
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
			else if (ElementsDomainUpDown.SelectedIndex == 2)
			{
				ElementsUnitsLabel.Text = "Ω";
			}
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			double value = 0.0;
			if(!double.TryParse(ValueTextBox.Text, out value))
			{
				MessageBox.Show( "\"" + ValueTextBox.Text + "\" isn't a real number!");
				return;
			}
			if(Element == null)
			{
				if (ElementsDomainUpDown.SelectedIndex == 0)
				{
					Element = new Inductor(value);
				}
				else if (ElementsDomainUpDown.SelectedIndex == 1)
				{
					Element = new Capacitor(value);
				}
				else if (ElementsDomainUpDown.SelectedIndex == 2)
				{
					Element = new Resistor(value);
				}
			}
			else
			{
				Element.ChangeValue(value);
			}
			
			DialogResult = DialogResult.OK;
		}
	}
}
