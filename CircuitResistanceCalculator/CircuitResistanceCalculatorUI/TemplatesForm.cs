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
	public partial class TemplatesForm : Form
	{
		public TemplatesForm()
		{
			InitializeComponent();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
