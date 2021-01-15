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

namespace CircuitResistanceCalculatorUI.EditConnection
{ 
	public partial class EditConnectionsForm : Form
	{
		private ConnectionBase _editableConnection;

		public event EventHandler<AddedNodeArgs> CreatedNewConnection;

		public EditConnectionsForm(ConnectionBase connection)
		{
			InitializeComponent();

			if(connection != null)
			{
				_editableConnection = connection;
				if(_editableConnection is ParallelConnection)
				{
					ParallelRadioButton.Checked = true;
				}
				else
				{
					SerialRadioButton.Checked = true;
				}
			}
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if(ParallelRadioButton.Checked)
			{
				CreatedNewConnection?.Invoke(this, 
					new AddedNodeArgs(new ParallelConnection()));
			}
			else
			{
				CreatedNewConnection?.Invoke(this, 
					new AddedNodeArgs(new SerialConnection()));
			}

			Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
