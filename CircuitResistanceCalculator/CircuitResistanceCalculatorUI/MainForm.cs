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
			GroupBox groupBox = new GroupBox();
			groupBox.Height = CircuitTreeView.Height + 8;
			groupBox.Width = 360;
			groupBox.Location = new Point(CircuitTreeView.Width + 17, CircuitTreeView.Location.Y - 8);
			groupBox.Anchor = (AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
			this.Controls.Add(groupBox);
		}
	}
}
