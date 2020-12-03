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
	public partial class MainForm : Form
	{
		private List<Data> _data;

		public Circuit Circuit { get; private set; } = null;
		public MainForm()
		{
			InitializeComponent();

			_data = new List<Data>();

			_data.Add(new Data(22.55, 55.33));
			_data.Add(new Data(13.12, 77.14));
			_data.Add(new Data(29.31, 97.05));
			_data.Add(new Data(71.23, 10.17));
			_data.Add(new Data(65.02, 12.15));
			_data.Add(new Data(87.10, 45.62));
			_data.Add(new Data(22.55, 55.33));
			_data.Add(new Data(13.12, 77.14));
			_data.Add(new Data(29.31, 97.05));
			_data.Add(new Data(71.23, 10.17));
			_data.Add(new Data(65.02, 12.15));
			_data.Add(new Data(87.10, 45.62));
			_data.Add(new Data(22.55, 55.33));
			_data.Add(new Data(13.12, 77.14));
			_data.Add(new Data(29.31, 97.05));
			_data.Add(new Data(71.23, 10.17));
			_data.Add(new Data(65.02, 12.15));
			_data.Add(new Data(87.10, 45.62));

			CircuitResistanceGridView.DataSource = _data;
		}

		private void CircuitChanged(object sender, EventArgs e)
		{
		
		}

		private void CircuitTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (CircuitTreeView.SelectedNode.Tag is Circuit)
			{
				AddElementButton.Enabled = false;
			}

			if (CircuitTreeView.SelectedNode.Tag is Circuit &&
				((Circuit)CircuitTreeView.SelectedNode.Tag).Connection != null)
			{
				AddConnectionButton.Enabled = false;
			}

			if (CircuitTreeView.SelectedNode.Tag is Resistor ||
				CircuitTreeView.SelectedNode.Tag is Inductor ||
				CircuitTreeView.SelectedNode.Tag is Capacitor)
			{
				AddElementButton.Enabled = false;
				AddConnectionButton.Enabled = false;
			}

			if(CircuitTreeView.SelectedNode.Tag is Connection)
			{
				AddElementButton.Enabled = true;
				AddConnectionButton.Enabled = true;
			}
		}

		private void CreateNewCircuitButton_Click(object sender, EventArgs e)
		{
			Circuit = new Circuit();
			Circuit.CircuitChanged += CircuitChanged;

			TreeNode root = new TreeNode();
			root.Text = "Root";
			root.Tag = Circuit;
			CircuitTreeView.Nodes.Add(root);
		}

		private void AddConnectionButton_Click(object sender, EventArgs e)
		{
			if (CircuitTreeView.SelectedNode == null)
			{
				MessageBox.Show("Please select position for adding a new node!");
				return;
			}

			AddConnectionsForm addConnectionsForm = new AddConnectionsForm();
			addConnectionsForm.ShowDialog();

			if (addConnectionsForm.DialogResult == DialogResult.OK)
			{
				if(CircuitTreeView.SelectedNode.Tag is Circuit)
				{
					Circuit.SetConnection(addConnectionsForm.Connection);
				}
				else if(CircuitTreeView.SelectedNode.Tag is Connection)
				{
					((Connection)CircuitTreeView.SelectedNode.Tag).AddNode(
						addConnectionsForm.Connection);
				}

				TreeNode treeNode = new TreeNode();
				if(addConnectionsForm.Connection is Serial)
				{
					treeNode.Text = "Serial";
				}
				else
				{
					treeNode.Text = "Parallel";
				}
				
				treeNode.Tag = addConnectionsForm.Connection;
				CircuitTreeView.SelectedNode.Nodes.Add(treeNode);
			}

		}

		private void AddElementButton_Click(object sender, EventArgs e)
		{
			if (CircuitTreeView.SelectedNode == null)
			{
				MessageBox.Show("Please select position for adding a new node!");
				return;
			}

			AddElementForm addElementForm = new AddElementForm(null);
			addElementForm.ShowDialog();

			if (addElementForm.DialogResult == DialogResult.OK)
			{
				((Connection)CircuitTreeView.SelectedNode.Tag).AddNode(
					addElementForm.Element);

				TreeNode treeNode = new TreeNode();
				if(addElementForm.Element is Resistor)
				{
					treeNode.Text = "R";
				}
				else if (addElementForm.Element is Inductor)
				{
					treeNode.Text = "L";
				}
				else if (addElementForm.Element is Capacitor)
				{
					treeNode.Text = "C";
				}
				treeNode.Tag = addElementForm.Element;
				CircuitTreeView.SelectedNode.Nodes.Add(treeNode);
			}
		}

		private void EditNodeButton_Click(object sender, EventArgs e)
		{
			if (CircuitTreeView.SelectedNode == null)
			{
				MessageBox.Show("Please, select an element to edit!");
				return;
			}

			if(CircuitTreeView.SelectedNode.Tag is Connection)
			{
				return;
			}
			else if(CircuitTreeView.SelectedNode.Tag is Element)
			{
				AddElementForm addElementForm = new AddElementForm(
					(Element)CircuitTreeView.SelectedNode.Tag);
				addElementForm.ShowDialog();
			}
		}

	}
}
