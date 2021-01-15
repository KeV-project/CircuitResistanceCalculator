using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Numerics;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;
using CircuitResistanceCalculator.Serializer;
using CircuitResistanceCalculatorUI.EditElement;
using CircuitResistanceCalculatorUI.EditConnection;

namespace CircuitResistanceCalculatorUI.MainForm
{
	public partial class MainForm : Form
	{
		private ConnectionBase _circuit;

		private List<double> _frequencies;
		private List<Complex> _resistance;

		private readonly FileInfo _defaultPath = new FileInfo(
			Environment.GetFolderPath(
			Environment.SpecialFolder.ApplicationData) +
			"\\CircuitResistanceCalculator\\" + "Circuit.notes");

		private FileInfo _currentPath;

		public MainForm()
		{
			InitializeComponent();

			_frequencies = new List<double>();
			_currentPath = _defaultPath;
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
		private void AddNode(TreeNode parentNode, TreeNode newTreeNode,
			NodeBase newNode)
		{
			((ConnectionBase)parentNode.Tag).AddNode(newNode);

			newTreeNode.Tag = newNode;
			if (newNode is ParallelConnection)
			{
				newTreeNode.Text = "Parallel";
			}
			else if (newNode is SerialConnection)
			{
				newTreeNode.Text = "Serial";
			}
			else if (newNode is Resistor)
			{
				newTreeNode.Text = "R" + ((ElementBase)newNode).Index;
			}
			else if (newNode is Inductor)
			{
				newTreeNode.Text = "L" + ((ElementBase)newNode).Index;
			}
			else
			{
				newTreeNode.Text = "C" + ((ElementBase)newNode).Index;
			}
			parentNode.Nodes.Add(newTreeNode);
		}

		// Добавление нового узла в цепь и 
		// перезаполнение расчетной таблицы
		private void AddNode(object obj, AddedNodeArgs e)
		{
			AddNode(CircuitTreeView.SelectedNode, new TreeNode(), e.Node);
			RecalculateCircuit();
		}

		// Создание дерева по готовой цепи
		private void CreateNewCircuit(TreeNode parentNode, NodeBase newNode)
		{
			TreeNode newTreeNode = new TreeNode();

			AddNode(parentNode, newTreeNode, newNode);
		
			if (newNode is ConnectionBase)
			{
				int nodesCount = ((ConnectionBase)newNode).NodesCount;
				for (int i = 0; i < nodesCount; i++)
				{
					CreateNewCircuit(newTreeNode, ((ConnectionBase)newNode)[i]);
				}
			}
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
		private void AddElementButton_Click(object sender, EventArgs e)
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
			if(_circuit == null)
			{
				MessageBox.Show("Please, create a circuit!");
				return;
			}

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

		// Удаление узла из цепи
		private void RemoveNodeButton_Click(object sender, EventArgs e)
		{
			if (CircuitTreeView.SelectedNode == null)
			{
				MessageBox.Show("Please, select a node to remove!");
				return;
			}

			if (CircuitTreeView.SelectedNode.Tag == _circuit)
			{
				_circuit = null;
			}
			else
			{
				((NodeBase)CircuitTreeView.SelectedNode.Tag).RemoveNode();
			}
			
			CircuitTreeView.Nodes.Remove(CircuitTreeView.SelectedNode);
			RecalculateCircuit();
		}

		// Очистить дерево
		private void ClearTreeButton_Click(object sender, EventArgs e)
		{
			_circuit = null;
			CircuitTreeView.Nodes.Clear();
			RecalculateCircuit();
		}

		// Удаление строки из расчетной таблицы
		private void DeleteFrequencyButton_Click(object sender, EventArgs e)
		{
			if(CircuitResistanceGridView.SelectedRows == null)
			{
				MessageBox.Show("Please, select a row!");
				return;
			}

			_frequencies.RemoveAt(CircuitResistanceGridView.SelectedRows[0].Index);
			CircuitResistanceGridView.Rows.RemoveAt(
				CircuitResistanceGridView.SelectedRows[0].Index);
			RecalculateCircuit();
		}

		// Очистить расчетную таблицу
		private void ClearButton_Click(object sender, EventArgs e)
		{
			_frequencies.Clear();
			RecalculateCircuit();
		}

		// Сериализация цепи в файл по умолчанию 
		private void SaveCircuitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Serializer.SaveCircuit(_circuit, _defaultPath);
		}

		// Выбор пути к файлу для сериализации
		private void SaveCircuitAsToolStripMenuItem_Click(object sender,
			EventArgs e)
		{
			SaveCircuitDialog.Filter = "NOTES (*.notes)| *.notes";
			if (SaveCircuitDialog.ShowDialog() == DialogResult.OK)
			{
				_currentPath = new FileInfo(SaveCircuitDialog.FileName);
				Serializer.SaveCircuit(_circuit, _currentPath);
			}
		}

		// Десериализация цепи
		private void DeserializingCircuit(FileInfo path)
		{
			CircuitTreeView.Nodes.Clear();

			_circuit = new SerialConnection();

			TreeNode root = new TreeNode("Root");
			root.Tag = _circuit;
			CircuitTreeView.Nodes.Add(root);

			ConnectionBase circuit1 = Serializer.ReadCircuit(path);

			CreateNewCircuit(root, (ConnectionBase)circuit1[0]);
			CircuitTreeView.ExpandAll();
		}

		// Десериализация первой цепи
		private void Circuit1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileInfo currentPath = new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit1.notes");
			DeserializingCircuit(currentPath);
		}

		// Десериализация второй цепи
		private void Сircuit2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileInfo currentPath = new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit2.notes");
			DeserializingCircuit(currentPath);
		}
	}
}
