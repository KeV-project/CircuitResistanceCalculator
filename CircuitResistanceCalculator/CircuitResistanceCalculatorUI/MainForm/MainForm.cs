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
	/// <summary>
	/// Класс <see cref="MainForm"/> отвечает за
	/// работу стартового окна приложения
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Содержит текущую модель электрической цепи
		/// </summary>
		private ConnectionBase _circuit = null;

		/// <summary>
		/// Содержит список частот для расчета импеданса
		/// текущей электрической цепи
		/// </summary>
		private List<double> _frequencies;

		/// <summary>
		/// Содержит список расчитанных для указанных частот
		/// импедансов текущей электрической цепи
		/// </summary>
		private List<Complex> _resistance;

		/// <summary>
		/// Содержит путь к файлу для сохранения цепи по умолчанию
		/// </summary>
		private readonly FileInfo _defaultPath = new FileInfo(
			Environment.GetFolderPath(
			Environment.SpecialFolder.ApplicationData) +
			"\\CircuitResistanceCalculator\\" + "Circuit.notes");

		/// <summary>
		/// Выполняет инициализацию и настройку 
		/// компонентов стартового окна приложения
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			_frequencies = new List<double>();
		}

		/// <summary>
		/// Заполняет расчетную таблице актуальными данными
		/// </summary>
		private void RecalculateCircuit()
		{
			CircuitResistanceGridView.Rows.Clear();
			_resistance = new List<Complex>();
			int i = 1;
			foreach (double frequency in _frequencies)
			{
				Complex z = _circuit.CalculateZ(frequency);
				z = new Complex(Math.Round(z.Real, 3), Math.Round(z.Imaginary, 3));
				_resistance.Add(z);
				CircuitResistanceGridView.Rows.Add(i, frequency, _resistance.Last());
				i++;
			}
		}

		/// <summary>
		/// Добавляет новую частоту в список для расчета импеданса цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
		private void CalculateButton_Click(object sender, EventArgs e)
		{
			if (_circuit == null)
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

		/// <summary>
		/// Удаления частоты из списка для расчета импеданса цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
		private void DeleteFrequencyButton_Click(object sender, EventArgs e)
		{
			if (CircuitResistanceGridView.SelectedRows == null)
			{
				MessageBox.Show("Please, select a row!");
				return;
			}

			_frequencies.RemoveAt(CircuitResistanceGridView.SelectedRows[0].Index);
			CircuitResistanceGridView.Rows.RemoveAt(
				CircuitResistanceGridView.SelectedRows[0].Index);
			RecalculateCircuit();
		}

		/// <summary>
		/// Очищает расчетную таблицу
		/// </summary>
		/// <param name="sender">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
		private void ClearButton_Click(object sender, EventArgs e)
		{
			_frequencies.Clear();
			RecalculateCircuit();
		}

		/// <summary>
		/// Создает пустую модель электрической цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void NewElectricalCircuitToolStripMenuItem_Click(object sender,
			EventArgs e)
		{
			if (_circuit == null)
			{
				_circuit = new SerialConnection();

				TreeNode root = new TreeNode("Root");
				root.Tag = _circuit;
				CircuitTreeView.Nodes.Add(root);
			}
			else
			{
				SaveCircuit();
				_circuit = null;
				NewElectricalCircuitToolStripMenuItem_Click(
				NewElectricalCircuitToolStripMenuItem, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Добавляет новый узел в дерево цепи
		/// </summary>
		/// <param name="parentNode">Родительский элемент</param>
		/// <param name="newTreeNode">Новый узел дерева цепи</param>
		/// <param name="newNode">Новый узел электрической цепи</param>
		private void AddCircuitTreeNode(TreeNode parentNode, TreeNode newTreeNode,
			NodeBase newNode)
		{
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

		/// <summary>
		/// Создает дерево по модели электрической цепи
		/// </summary>
		/// <param name="parentNode">Родительский узел дерева цепи</param>
		/// <param name="newNode">Узел для добавления в дерево цепи</param>
		private void CreateNewCircuitTree(TreeNode parentTreeNode, NodeBase node)
		{
			TreeNode newTreeNode = new TreeNode();

			AddCircuitTreeNode(parentTreeNode, newTreeNode, node);

			if (node is ConnectionBase)
			{
				int nodesCount = ((ConnectionBase)node).NodesCount;
				for (int i = 0; i < nodesCount; i++)
				{
					CreateNewCircuitTree(newTreeNode, ((ConnectionBase)node)[i]);
				}
			}
		}

		/// <summary>
		/// Добавляет новый узел в цепь
		/// </summary>
		/// <param name="obj">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
		private void AddNode(object obj, AddedNodeArgs e)
		{
			((ConnectionBase)CircuitTreeView.SelectedNode.Tag).AddNode(e.Node);
			AddCircuitTreeNode(CircuitTreeView.SelectedNode, new TreeNode(), e.Node);
			RecalculateCircuit();
		}

		/// <summary>
		/// Добавляет в цепь узел типа <see cref="ConnectionBase"/>
		/// </summary>
		/// <param name="sender">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
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

		/// <summary>
		/// Добавляет в цепь узел типы <see cref="ElementBase"/>
		/// </summary>
		/// <param name="sender">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
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
		
		/// <summary>
		/// Производит замену выбранного узла цепи
		/// </summary>
		/// <param name="obj">Элемент класса Form</param>
		/// <param name="e">Содержит новый узел цепи</param>
		private void ReplaceNode(object obj, AddedNodeArgs e)
		{
			((NodeBase)CircuitTreeView.SelectedNode.Tag).ReplaceNode(e.Node);
			CircuitTreeView.SelectedNode.Tag = e.Node;
			if (e.Node is ParallelConnection)
			{
				CircuitTreeView.SelectedNode.Text = "Parallel";
			}
			else if (e.Node is SerialConnection)
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

		/// <summary>
		/// Открывает окно для редактирования выбранного узла
		/// </summary>
		/// <param name="sender">Элемент управления типа DataTreeView</param>
		/// <param name="e">Вспомогательные данные</param>
		private void CircuitTreeView_NodeMouseDoubleClick(object sender, 
			TreeNodeMouseClickEventArgs e)
		{
			ConnectionBase circuit = _circuit;
			if (CircuitTreeView.SelectedNode == null)
			{
				return;
			}

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
			ConnectionBase circuit1 = _circuit;
			CircuitTreeView.ExpandAll();
		}

		
		/// <summary>
		/// Удаляет выбранные узел цепи
		/// </summary>
		/// <param name="sender">Эдемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
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

		/// <summary>
		/// Выполняет сериализацию цепи в файл по умолчанию
		/// </summary>
		/// <param name="sender">Элемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Serializer.SaveCircuit(_circuit, _defaultPath);
		}

		/// <summary>
		/// Выполняет сериализацию цепи в предварительно выбранный файл
		/// </summary>
		/// <param name="sender">Элемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{ 
			SaveCircuitDialog.Filter = "NOTES (*.notes)| *.notes";
			if (SaveCircuitDialog.ShowDialog() == DialogResult.OK)
			{
				FileInfo currentPath = new FileInfo(SaveCircuitDialog.FileName);
				Serializer.SaveCircuit(_circuit, currentPath);
			}
		}

		/// <summary>
		/// Выполняет сохранение цепи в файл перед закрытием
		/// </summary>
		private void SaveCircuit()
		{
			if (_circuit != null)
			{
				DialogResult dialogResult = MessageBox.Show("Save changes?",
					"Circuit resistance calculator",
					MessageBoxButtons.YesNoCancel);

				if (dialogResult == DialogResult.Cancel)
				{
					return;
				}
				else if (dialogResult == DialogResult.Yes)
				{
					SaveCircuitDialog.Filter = "NOTES (*.notes)| *.notes";
					if (SaveCircuitDialog.ShowDialog() == DialogResult.OK)
					{
						FileInfo currentPath = new FileInfo(SaveCircuitDialog.FileName);
						Serializer.SaveCircuit(_circuit, currentPath);
					}
					else
					{
						return;
					}
				}
			}

			CircuitTreeView.Nodes.Clear();
			OpenCircuitDialog.FileName = "";
		}

		/// <summary>
		/// Выполняет десериализацию цепи из указанного файла
		/// </summary>
		/// <param name="path">Путь к файлу</param>
		private void DeserializingCircuit(FileInfo path)
		{
			_circuit = Serializer.ReadCircuit(path);

			TreeNode root = new TreeNode("Root");
			root.Tag = _circuit;
			CircuitTreeView.Nodes.Add(root);

			CreateNewCircuitTree(root, _circuit[0]);
			CircuitTreeView.ExpandAll();
		}

		/// <summary>
		/// Позволяет выбрать файл для десериализации
		/// </summary>
		/// <param name="sender">Этемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveCircuit();

			OpenCircuitDialog.Filter = "NOTES (*.notes)| *.notes";
			if (OpenCircuitDialog.ShowDialog() == DialogResult.OK)
			{
				FileInfo currentPath = new FileInfo(OpenCircuitDialog.FileName);
				DeserializingCircuit(currentPath);
			}
		}

		/// <summary>
		/// Выполняет десериализацию первой шаблонной цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void Circuit1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveCircuit();

			FileInfo currentPath = new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit1.notes");
			DeserializingCircuit(currentPath);
		}

		/// <summary>
		/// Выполняет десериализацию второй шаблонной цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void Сircuit2ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveCircuit();

			FileInfo currentPath = new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit2.notes");
			DeserializingCircuit(currentPath);
		}

		/// <summary>
		/// Выполняет десериализацию третьей шаблонной цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void Сircuit3ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveCircuit();

			FileInfo currentPath = new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit3.notes");
			DeserializingCircuit(currentPath);
		}

		/// <summary>
		/// Выполняет десериализацию четвертой шаблонной цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void Сircuit4ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveCircuit();

			FileInfo currentPath = new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit4.notes");
			DeserializingCircuit(currentPath);
		}

		/// <summary>
		/// Выполняет десериализацию пятой шаблонной цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void Сircuit5ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveCircuit();

			FileInfo currentPath = new FileInfo(Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData) +
				"\\CircuitResistanceCalculator\\" + "Circuit5.notes");
			DeserializingCircuit(currentPath);
		}

		/// <summary>
		/// Удаляет цепь и очищает дерево цепи
		/// </summary>
		/// <param name="sender">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
		private void ClearTreeButton_Click(object sender, EventArgs e)
		{
			SaveCircuit();
			_circuit = null;
			CircuitTreeView.Nodes.Clear();
			RecalculateCircuit();
		}

		// Выход
		/// <summary>
		/// Осуществляет безопасный выход из приложения
		/// </summary>
		/// <param name="sender">Элемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveCircuit();
			this.Close();
		}
	}
}
