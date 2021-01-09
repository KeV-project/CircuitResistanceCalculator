using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;

namespace CircuitResistanceCalculatorUI
{
	public partial class MainForm : Form
	{
		private ConnectionBase _circuit;
		private NodeBase _newNode;

		private List<double> _frequencies;
		private List<Complex> _resistance;

		public MainForm()
		{
			InitializeComponent();

			_frequencies = new List<double>();
		}

		public void AddedNode(object obj, AddedNodeArgs e)
		{
			_newNode = e.Node;
		}

		private void RecalculateCircuit()
		{
			CircuitResistanceGridView.Rows.Clear();
			_resistance = new List<Complex>();
			int i = 1;
			foreach(double frequency in _frequencies)
			{
				Complex z = _circuit.CalculateZ(frequency);
				z = new Complex(Math.Round(z.Real, 3), Math.Round(z.Imaginary, 3));
				_resistance.Add(z);
				CircuitResistanceGridView.Rows.Add(i, frequency, _resistance.Last());
				i++;
			}
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

		private void CalculateButton_Click(object sender, EventArgs e)
		{
			if (!double.TryParse(EnterFrequencyTextBox.Text, 
				out double frequency))
			{
				MessageBox.Show(EnterFrequencyTextBox.Text + "isn't a " +
					"real number!");
				return;
			}

			_frequencies.Add(frequency);
			EnterFrequencyTextBox.Text = "";
			RecalculateCircuit();
		}

		private void CircuitTreeView_NodeMouseDoubleClick(object sender, 
			TreeNodeMouseClickEventArgs e)
		{
			if(CircuitTreeView.SelectedNode.Tag is ConnectionBase)
			{

			}
			else if(CircuitTreeView.SelectedNode.Tag is ElementBase)
			{

			}
			else
			{
				return;
			}
		}
	}
}
