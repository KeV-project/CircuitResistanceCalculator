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

		private List<double> _frequencies;
		private List<Complex> _resistance;

		public MainForm()
		{
			InitializeComponent();

			_frequencies = new List<double>();
		}

		// Создание новой цепи
		private void NewElectricalCircuitToolStripMenuItem_Click(object sender,
			EventArgs e)
		{
			_circuit = new SerialConnection();

			TreeNode root = new TreeNode("Root");
			root.Tag = _circuit;
			CircuitTreeView.Nodes.Add(root);
		}

		// Добавление нового узла в цепь
		private void AddNode(object obj, AddedNodeArgs e)
		{
			((ConnectionBase)CircuitTreeView.SelectedNode.Tag).AddNode(e.Node);
			
			TreeNode newNode = new TreeNode();
			newNode.Tag = e.Node;
			if (e.Node is ParallelConnection)
			{
				newNode.Text = "Parallel";
			}
			else if(e.Node is SerialConnection)
			{
				newNode.Text = "Serial";
			}
			else if(e.Node is Resistor)
			{
				newNode.Text = "R" + ((ElementBase)e.Node).Index;
			}
			else if (e.Node is Inductor)
			{
				newNode.Text = "L" + ((ElementBase)e.Node).Index;
			}
			else 
			{
				newNode.Text = "C" + ((ElementBase)e.Node).Index;
			}
			CircuitTreeView.SelectedNode.Nodes.Add(newNode);
			RecalculateCircuit();
		}

		// Замена выбранного узла цепи
		private void ReplaceNode(object obj, AddedNodeArgs e)
		{
			((NodeBase)CircuitTreeView.SelectedNode.Tag).ReplaceNode(e.Node);
			CircuitTreeView.SelectedNode.Tag = e.Node;
			if(e.Node is ParallelConnection)
			{
				CircuitTreeView.SelectedNode.Text = "Parallel";
			}
			else if(e.Node is SerialConnection)
			{
				CircuitTreeView.SelectedNode.Text = "Serial";
			}
			else if (e.Node is Resistor)
			{
				CircuitTreeView.SelectedNode.Text = "R" + ((ElementBase)e.Node).Index;
			}
			else if (e.Node is Inductor)
			{
				CircuitTreeView.SelectedNode.Text = "L" + ((ElementBase)e.Node).Index;
			}
			else
			{
				CircuitTreeView.SelectedNode.Text = "C" + ((ElementBase)e.Node).Index;
			}
			RecalculateCircuit();
		}

		// Перерасчет цепи и выведение актуальных данных пользователю
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

		// Добавление в цепь нового узла типа соединение
		private void AddConnectionButton_Click(object sender, EventArgs e)
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

			EditConnectionsForm addConnectionsForm = new EditConnectionsForm(null);
			addConnectionsForm.CreatedNewConnection += AddNode;
			addConnectionsForm.ShowDialog();

			CircuitTreeView.ExpandAll();
		}

		// Добавление в цепь нового узла типа элемент
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

			EditElementForm addElementForm = new EditElementForm(null);
			addElementForm.CreatedNewElement += AddNode;
			addElementForm.ShowDialog();

			CircuitTreeView.ExpandAll();
		}

		// Добавление новой частоты сигнала и перерасчет цепи
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

		// Редактирование выбранного узла
		private void CircuitTreeView_NodeMouseDoubleClick(object sender, 
			TreeNodeMouseClickEventArgs e)
		{
			if(CircuitTreeView.SelectedNode.Tag == _circuit)
			{
				return;
			}

			if(CircuitTreeView.SelectedNode.Tag is ConnectionBase)
			{
				EditConnectionsForm editConnectionsForm = new EditConnectionsForm(
					(ConnectionBase)CircuitTreeView.SelectedNode.Tag);
				editConnectionsForm.CreatedNewConnection += ReplaceNode;
				editConnectionsForm.ShowDialog();
			}
			else
			{
				EditElementForm editElementForm = new EditElementForm(
					(ElementBase)CircuitTreeView.SelectedNode.Tag);
				editElementForm.CreatedNewElement += ReplaceNode;
				editElementForm.ShowDialog();
			}

			CircuitTreeView.ExpandAll();
		}
	}
}
