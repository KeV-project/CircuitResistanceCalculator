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

		public Circuit Circuit { get; set; } = null;
		public Node Node { get; set; } = null;
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

		private void CircuitChanged()
		{
		
		}

		private void CreateNewCircuitButton_Click(object sender, EventArgs e)
		{
			Circuit = new Circuit();
			Circuit.CircuiChanged += CircuitChanged;

			TreeNode root = new TreeNode();
			root.Text = "Root";
			root.Tag = Circuit;
			CircuitTreeView.Nodes.Add(root);
		}

		private void AddConnectionButton_Click(object sender, EventArgs e)
		{
			//if (CircuitTreeView.SelectedNode == null)
			//{
			//	MessageBox.Show("Please select position for adding a new node!");
			//	return;
			//}

			//if (CircuitTreeView.SelectedNode.Tag is Resistor ||
			//	CircuitTreeView.SelectedNode.Tag is Inductor ||
			//	CircuitTreeView.SelectedNode.Tag is Capacitor)
			//{
			//	MessageBox.Show("Operation not possible");
			//	return;
			//}

			//AddConnectionsForm addConnectionsForm = new AddConnectionsForm();
			//addConnectionsForm.ShowDialog();

			//if(addConnectionsForm.DialogResult == DialogResult.OK)
			//{
			//	TreeNode newNode = new TreeNode();
			//	newNode.Tag = Node;
			//	if(Node is ParallelConnection)
			//	{
			//		newNode.Text = "Parallel";
			//	}
			//	else if(Node is SerialConnection)
			//	{
			//		newNode.Text = "Serial";
			//	}
			//	CircuitTreeView.SelectedNode.Nodes.Add(newNode);
			//}

			//Node = null;
		}

		private void AddElementButton_Click(object sender, EventArgs e)
		{
			//if (CircuitTreeView.SelectedNode == null)
			//{
			//	MessageBox.Show("Please select position for adding a new node!");
			//	return;
			//}

			//if (CircuitTreeView.SelectedNode.Tag is Resistor ||
			//	CircuitTreeView.SelectedNode.Tag is Inductor ||
			//	CircuitTreeView.SelectedNode.Tag is Capacitor)
			//{
			//	MessageBox.Show("Operation not possible");
			//	return;
			//}

			//AddElementForm addElementForm = new AddElementForm();
			//addElementForm.ShowDialog();

			//if (addElementForm.DialogResult == DialogResult.OK)
			//{
			//	TreeNode newNode = new TreeNode();
			//	newNode.Tag = Node;
			//	if (Node is Resistor)
			//	{
			//		newNode.Text = "R";
			//	}
			//	else if (Node is Inductor)
			//	{
			//		newNode.Text = "L";
			//	}
			//	else if(Node is Capacitor)
			//	{
			//		newNode.Text = "C";
			//	}
			//	CircuitTreeView.SelectedNode.Nodes.Add(newNode);
			//}

			//Node = null;
		}

		private void EditNodeButton_Click(object sender, EventArgs e)
		{
			if (CircuitTreeView.SelectedNode == null)
			{
				MessageBox.Show("Please, select an element to edit!");
				return;
			}

			Node = (Node)CircuitTreeView.SelectedNode.Tag;
			AddElementForm addElementForm = new AddElementForm(Node);
			addElementForm.ShowDialog();

			if(addElementForm.DialogResult == DialogResult.OK)
			{

			}
		}
	}
}
