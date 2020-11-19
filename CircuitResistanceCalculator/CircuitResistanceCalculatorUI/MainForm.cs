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
	}
}
