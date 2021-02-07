using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Numerics;
using System.ComponentModel;
using CircuitResistanceCalculator.Node;
using CircuitResistanceCalculator.Connections;
using CircuitResistanceCalculator.Elements;
using CircuitResistanceCalculator.Serializer;
using CircuitResistanceCalculatorUI.EditElement;
using CircuitResistanceCalculatorUI.EditConnection;
using CircuitResistanceCalculatorUI.CreateTemplates;
using CircuitResistanceCalculatorUI.CalculatedData;

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

		private BindingList<CircuitResistance> _resistance;

		/// <summary>
		/// Содержит путь к файлу для сохранения цепи по умолчанию
		/// </summary>
		private readonly FileInfo _defaultPath = new FileInfo(
			Environment.GetFolderPath(
			Environment.SpecialFolder.ApplicationData) +
			"\\CircuitResistanceCalculator\\" + "Circuit.notes");

		/// <summary>
		/// Содержит имена элементов управления, отвечающих за
		/// десериализацию шаблонов цепей и путей к файлам,
		/// содержащим соответствующие цепи
		/// </summary>
		private readonly Dictionary<ToolStripMenuItem, FileInfo> _templates =
			new Dictionary<ToolStripMenuItem, FileInfo>();

		/// <summary>
		/// Выполняет инициализацию и настройку 
		/// компонентов стартового окна приложения
		/// </summary>
		public MainForm()
		{
			InitializeComponent();

			_resistance = new BindingList<CircuitResistance>();
			CircuitResistanceGridView.DataSource = _resistance;
		}

		/// <summary>
		/// Создает шаблоны цепей и словарь путей к соответствующим шаблонам
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_Load(object sender, EventArgs e)
		{
			Templates.CreateTemplates();

			_templates.Add(Template1ToolStripMenuItem, Templates.TemplatesPath[0]);
			_templates.Add(Template2ToolStripMenuItem, Templates.TemplatesPath[1]);
			_templates.Add(Template3ToolStripMenuItem, Templates.TemplatesPath[2]);
			_templates.Add(Template4ToolStripMenuItem, Templates.TemplatesPath[3]);
			_templates.Add(Template5ToolStripMenuItem, Templates.TemplatesPath[4]);
		}

		/// <summary>
		/// Заполняет расчетную таблице актуальными данными
		/// </summary>
		private void RecalculateCircuit(object obj, EventArgs e)
		{
			//TODO: Раньше не обратил внимание - с gridView правильнее работать с помощью списков, 
			//TODO: которые оповещают о своём изменении, смотрите тут
			//TODO: https://stackoverflow.com/questions/16695885/binding-listt-to-datagridview-in-winform
			for(int i = 0; i < _resistance.Count; i++)
			{
				Complex z = _circuit.CalculateZ(_resistance[i].Frequency);
				_resistance[i].Resistance = new Complex(Math.Round(z.Real, 3), 
					Math.Round(z.Imaginary, 3));
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

			Complex z = _circuit.CalculateZ(frequency);
			_resistance.Add(new CircuitResistance(frequency, new Complex(
				Math.Round(z.Real, 3), Math.Round(z.Imaginary, 3))));
			EnterFrequencyTextBox.Text = "";
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

			_resistance.RemoveAt(CircuitResistanceGridView.SelectedRows[0].Index);
		}

		/// <summary>
		/// Очищает расчетную таблицу
		/// </summary>
		/// <param name="sender">Элемент управления типа Button</param>
		/// <param name="e">Вспомогательные данные</param>
		private void ClearButton_Click(object sender, EventArgs e)
		{
			_resistance.Clear();
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
				_circuit.NodeAdded += RecalculateCircuit;
				_circuit.NodeChanged += RecalculateCircuit;
				_circuit.NodeRemoved += RecalculateCircuit;


				TreeNode root = new TreeNode("Root");
				root.Tag = _circuit;
				CircuitTreeView.Nodes.Add(root);
				RecalculateCircuit(null, EventArgs.Empty);
			}
			else
			{
				SaveCircuit();
				_circuit.NodeAdded -= RecalculateCircuit;
				_circuit.NodeChanged -= RecalculateCircuit;
				_circuit.NodeRemoved -= RecalculateCircuit;
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
			newTreeNode.Text = newNode.Name;
			parentNode.Nodes.Add(newTreeNode);
		}

		/// <summary>
		/// Создает дерево по модели электрической цепи
		/// </summary>
		/// //TODO: XML комментарии?
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
			CircuitTreeView.SelectedNode.Text = e.Node.Name;
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
				_circuit.NodeAdded -= RecalculateCircuit;
				_circuit.NodeChanged -= RecalculateCircuit;
				_circuit.NodeRemoved -= RecalculateCircuit;
				_circuit = null;
			}
			else
			{
				((NodeBase)CircuitTreeView.SelectedNode.Tag).RemoveNode();
			}
			
			CircuitTreeView.Nodes.Remove(CircuitTreeView.SelectedNode);
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
			_circuit.NodeAdded -= RecalculateCircuit;
			_circuit.NodeChanged -= RecalculateCircuit;
			_circuit.NodeRemoved -= RecalculateCircuit;

			_circuit = Serializer.ReadCircuit(path);
			_circuit.NodeAdded += RecalculateCircuit;
			_circuit.NodeChanged += RecalculateCircuit;
			_circuit.NodeRemoved += RecalculateCircuit;
			_circuit.SubscribeNodesToEvents();

			TreeNode root = new TreeNode("Root");
			root.Tag = _circuit;
			CircuitTreeView.Nodes.Add(root);

			CreateNewCircuitTree(root, _circuit[0]);
			RecalculateCircuit(null, EventArgs.Empty);
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
		/// Выполняет десериализацию выбранного шаблона цепи
		/// </summary>
		/// <param name="sender">Этемент управления типа ToolStripMenuItem</param>
		/// <param name="e">Вспомогательные данные</param>
		private void TemplateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveCircuit();

			FileInfo currentPath = _templates[(ToolStripMenuItem)sender];
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
			_circuit.NodeAdded -= RecalculateCircuit;
			_circuit.NodeChanged -= RecalculateCircuit;
			_circuit.NodeRemoved -= RecalculateCircuit;
			_circuit = null;
			CircuitTreeView.Nodes.Clear();
			RecalculateCircuit(null, EventArgs.Empty);
		}

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
