using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircuitResistanceCalculatorUI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void ElectricalCircuitTemplateToolStripMenuItem_Click(
			object sender, EventArgs e)
		{
			TemplatesForm templatesForm = new TemplatesForm();
			templatesForm.ShowDialog();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void CalculateCircuitResistanceButton_Click(object sender, EventArgs e)
		{
			CircuitTreeView.Width = this.Width - 400;

			GroupBox CalculateCircuitResistanceGroupBox = new GroupBox();
			CalculateCircuitResistanceGroupBox.Height = CircuitTreeView.Height + 8;
			CalculateCircuitResistanceGroupBox.Width = 360;
			CalculateCircuitResistanceGroupBox.Location = new Point(
				CircuitTreeView.Width + 17, CircuitTreeView.Location.Y - 8);
			CalculateCircuitResistanceGroupBox.Anchor = (AnchorStyles.Right
				| AnchorStyles.Top | AnchorStyles.Bottom);

			GroupBox buttonGroupBox = new GroupBox();
			buttonGroupBox.Height = 40;
			buttonGroupBox.Width = 200;
			buttonGroupBox.Location = new Point(150, 
				CalculateCircuitResistanceGroupBox.Height - 50);
			buttonGroupBox.Anchor = (AnchorStyles.Right |  AnchorStyles.Bottom);
			CalculateCircuitResistanceGroupBox.Controls.Add(buttonGroupBox);

			Button calculateButton = new Button();
			calculateButton.Text = "Calculate";
			calculateButton.Width = 96;
			calculateButton.Height = 28;
			calculateButton.Location = new Point(0, 5);
			calculateButton.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom);
			buttonGroupBox.Controls.Add(calculateButton);

			Button okButton = new Button();
			okButton.Text = "Cancel";
			okButton.Width = 96;
			okButton.Height = 28;
			okButton.Location = new Point(100, 5);
			okButton.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
			buttonGroupBox.Controls.Add(okButton);

			this.Controls.Add(CalculateCircuitResistanceGroupBox);
		}
	}
}
