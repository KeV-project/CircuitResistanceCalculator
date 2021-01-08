using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculatorUI
{
	public partial class MainForm : Form
	{
		private ConnectionBase _circuit;
		private NodeBase _newNode;
		public MainForm()
		{
			InitializeComponent();
		}

		public void AddedNode(object obj, AddedNodeArgs e)
		{
			_newNode = e.Node;
		}

		private void NewElectricalCircuitToolStripMenuItem_Click(object sender,
			EventArgs e)
		{
			_circuit = new SerialConnection();

			TreeNode root = new TreeNode("Root");
			root.Tag = _circuit;
			CircuitTreeView.Nodes.Add(root);
		}

		private void ConnectionButton_Click(object sender, EventArgs e)
		{
			if(CircuitTreeView.SelectedNode == null)
			{
				MessageBox.Show("Please, select a node to add!");
				return;
			}

			if(CircuitTreeView.SelectedNode.Tag == _circuit)
			{
				if(_circuit.NodesCount != 0)
				{
					MessageBox.Show("Root connection already established!");
					return;
				}
			}

			if(CircuitTreeView.SelectedNode.Tag is ElementBase)
			{
				MessageBox.Show("Element cannot have child nodes!");
				return;
			}

			AddConnectionsForm addConnectionsForm = new AddConnectionsForm();
			addConnectionsForm.AddedNode += AddedNode;
			addConnectionsForm.ShowDialog();

			if(addConnectionsForm.DialogResult == DialogResult.OK)
			{
				((ConnectionBase)CircuitTreeView.SelectedNode.Tag).
					AddNode(_newNode);
				TreeNode newConnection = new TreeNode();

				if (_newNode is ParallelConnection)
				{
					newConnection.Text = "Parallel";
				}
				else
				{
					newConnection.Text = "Serial";
				}

				newConnection.Tag = _newNode;
				CircuitTreeView.SelectedNode.Nodes.Add(newConnection);
			}

			CircuitTreeView.ExpandAll();
		}

		private void ElementButton_Click(object sender, EventArgs e)
		{
			if (CircuitTreeView.SelectedNode == null)
			{
				MessageBox.Show("Please, select a node to add!");
				return;
			}

			if (CircuitTreeView.SelectedNode.Tag == _circuit)
			{
				MessageBox.Show("Unable to add item to circuit root!");
				return;
			}

			if (CircuitTreeView.SelectedNode.Tag is ElementBase)
			{
				MessageBox.Show("Element cannot have child nodes!");
				return;
			}

			AddElementForm addElementForm = new AddElementForm();
			addElementForm.AddedNode += AddedNode;
			addElementForm.ShowDialog();

			if(addElementForm.DialogResult == DialogResult.OK)
			{
				((ConnectionBase)CircuitTreeView.SelectedNode.Tag).
					AddNode(_newNode);
				TreeNode newElement = new TreeNode();

				if(_newNode is Resistor)
				{
					newElement.Text = "R" + ((ElementBase)_newNode).Index;
				}
				else if(_newNode is Inductor)
				{
					newElement.Text = "L" + ((ElementBase)_newNode).Index;
				}
				else
				{
					newElement.Text = "C" + ((ElementBase)_newNode).Index;
				}

				newElement.Tag = _newNode;
				CircuitTreeView.SelectedNode.Nodes.Add(newElement);
			}

			CircuitTreeView.ExpandAll();
		}
	}
}
