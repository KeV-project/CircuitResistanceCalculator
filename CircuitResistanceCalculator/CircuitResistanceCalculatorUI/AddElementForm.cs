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
		private Node Node { get; set; }
		public int SelectedElementIndex { get; private set; } = 2;
		public AddElementForm(Node node)
		{
			InitializeComponent();

			Node = node;
		}

		private void AddElementForm_Load(object sender, EventArgs e)
		{
			this.Text = "Edit element";
			ElementsDomainUpDown.Enabled = false;
			if (Node is Resistor)
			{
				ElementsDomainUpDown.SelectedIndex = 2;
				ElementsUnitsLabel.Text = "Ω";
			}
			if (Node is Inductor)
			{
				ElementsDomainUpDown.SelectedIndex = 0;
				ElementsUnitsLabel.Text = "H";
			}
			if (Node is Capacitor)
			{
				ElementsDomainUpDown.SelectedIndex = 1;
				ElementsUnitsLabel.Text = "F";
			}

		}

		private void ElementsDomainUpDown_SelectedItemChanged(object sender,
			EventArgs e)
		{
			//SelectedElementIndex = ElementsDomainUpDown.SelectedIndex;

			//if (SelectedElementIndex == 0)
			//{
			//	ElementsUnitsLabel.Text = "H";

			//}
			//else if (SelectedElementIndex == 1)
			//{
			//	ElementsUnitsLabel.Text = "F";
			//}
			//else if (SelectedElementIndex == 2)
			//{
			//	ElementsUnitsLabel.Text = "Ω";
			//}
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if (!double.TryParse(ValueTextBox.Text, out double value))
			{
				MessageBox.Show("Invalid value");
				return;
			}

			//if (SelectedElementIndex == 0)
			//{
			//	MainForm.Node = new Inductor(value);
			//}
			//else if (SelectedElementIndex == 1)
			//{
			//	MainForm.Node = new Capacitor(value);
			//}
			//else if (SelectedElementIndex == 2)
			//{
			//	MainForm.Node = new Resistor(value);
			//}

			if (Node is Resistor)
			{
				((Resistor)Node).Value = value;
			}
			if (Node is Inductor)
			{
				((Inductor)Node).Value = value;
			}
			if (Node is Capacitor)
			{
				((Capacitor)Node).Value = value;
			}

			DialogResult = DialogResult.OK;
		}
	}
}
