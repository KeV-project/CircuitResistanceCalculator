
namespace CircuitResistanceCalculatorUI.MainForm
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewElectricalCircuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Template1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Template2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Template3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Template4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Template5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.CircuitTreeView = new System.Windows.Forms.TreeView();
			this.ResultTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.CalculateCircuitResistanceGroupBox = new System.Windows.Forms.GroupBox();
			this.CalculateButton = new System.Windows.Forms.Button();
			this.CircuitResistanceGridView = new System.Windows.Forms.DataGridView();
			this.ClearButton = new System.Windows.Forms.Button();
			this.DeleteFrequencyButton = new System.Windows.Forms.Button();
			this.EnterFrequencyTextBox = new System.Windows.Forms.TextBox();
			this.EnterFreguencyLabel = new System.Windows.Forms.Label();
			this.CircuitPanel = new System.Windows.Forms.Panel();
			this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
			this.ClearTreeButton = new System.Windows.Forms.Button();
			this.AddConnectionButton = new System.Windows.Forms.Button();
			this.AddElementButton = new System.Windows.Forms.Button();
			this.RemoveNodeButton = new System.Windows.Forms.Button();
			this.SaveCircuitDialog = new System.Windows.Forms.SaveFileDialog();
			this.OpenCircuitDialog = new System.Windows.Forms.OpenFileDialog();
			this.menuStrip.SuspendLayout();
			this.MainTableLayoutPanel.SuspendLayout();
			this.ResultTableLayoutPanel.SuspendLayout();
			this.CalculateCircuitResistanceGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitResistanceGridView)).BeginInit();
			this.CircuitPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.templatesToolStripMenuItem,
            this.HelpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(1026, 25);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.ExitToolStripMenuItem});
			this.FileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
			this.FileToolStripMenuItem.Text = "File";
			// 
			// CreateToolStripMenuItem
			// 
			this.CreateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewElectricalCircuitToolStripMenuItem});
			this.CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
			this.CreateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.CreateToolStripMenuItem.Text = "Create";
			// 
			// NewElectricalCircuitToolStripMenuItem
			// 
			this.NewElectricalCircuitToolStripMenuItem.Name = "NewElectricalCircuitToolStripMenuItem";
			this.NewElectricalCircuitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.NewElectricalCircuitToolStripMenuItem.Text = "New electrical circuit";
			this.NewElectricalCircuitToolStripMenuItem.Click += new System.EventHandler(this.NewElectricalCircuitToolStripMenuItem_Click);
			// 
			// OpenToolStripMenuItem
			// 
			this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
			this.OpenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.OpenToolStripMenuItem.Text = "Open...";
			this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// SaveToolStripMenuItem
			// 
			this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
			this.SaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.SaveToolStripMenuItem.Text = "Save";
			this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
			// 
			// SaveAsToolStripMenuItem
			// 
			this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
			this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.SaveAsToolStripMenuItem.Text = "Save As...";
			this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
			// 
			// ExitToolStripMenuItem
			// 
			this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.ExitToolStripMenuItem.Text = "Exit (Alt + F4)";
			this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// templatesToolStripMenuItem
			// 
			this.templatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Template1ToolStripMenuItem,
            this.Template2ToolStripMenuItem,
            this.Template3ToolStripMenuItem,
            this.Template4ToolStripMenuItem,
            this.Template5ToolStripMenuItem});
			this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
			this.templatesToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
			this.templatesToolStripMenuItem.Text = "Templates";
			// 
			// Template1ToolStripMenuItem
			// 
			this.Template1ToolStripMenuItem.Name = "Template1ToolStripMenuItem";
			this.Template1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.Template1ToolStripMenuItem.Text = "Circuit №1";
			this.Template1ToolStripMenuItem.Click += new System.EventHandler(this.TemplateToolStripMenuItem_Click);
			// 
			// Template2ToolStripMenuItem
			// 
			this.Template2ToolStripMenuItem.Name = "Template2ToolStripMenuItem";
			this.Template2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.Template2ToolStripMenuItem.Text = "Circuit №2";
			this.Template2ToolStripMenuItem.Click += new System.EventHandler(this.TemplateToolStripMenuItem_Click);
			// 
			// Template3ToolStripMenuItem
			// 
			this.Template3ToolStripMenuItem.Name = "Template3ToolStripMenuItem";
			this.Template3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.Template3ToolStripMenuItem.Text = "Circuit №3";
			this.Template3ToolStripMenuItem.Click += new System.EventHandler(this.TemplateToolStripMenuItem_Click);
			// 
			// Template4ToolStripMenuItem
			// 
			this.Template4ToolStripMenuItem.Name = "Template4ToolStripMenuItem";
			this.Template4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.Template4ToolStripMenuItem.Text = "Circuit №4";
			this.Template4ToolStripMenuItem.Click += new System.EventHandler(this.TemplateToolStripMenuItem_Click);
			// 
			// Template5ToolStripMenuItem
			// 
			this.Template5ToolStripMenuItem.Name = "Template5ToolStripMenuItem";
			this.Template5ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.Template5ToolStripMenuItem.Text = "Circuit №5";
			this.Template5ToolStripMenuItem.Click += new System.EventHandler(this.TemplateToolStripMenuItem_Click);
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
			this.HelpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
			this.HelpToolStripMenuItem.Text = "Help";
			// 
			// AboutToolStripMenuItem
			// 
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			this.AboutToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.AboutToolStripMenuItem.Text = "About (F1)";
			// 
			// MainTableLayoutPanel
			// 
			this.MainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MainTableLayoutPanel.ColumnCount = 2;
			this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.23602F));
			this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.76398F));
			this.MainTableLayoutPanel.Controls.Add(this.CircuitTreeView, 0, 0);
			this.MainTableLayoutPanel.Controls.Add(this.ResultTableLayoutPanel, 1, 0);
			this.MainTableLayoutPanel.Location = new System.Drawing.Point(48, 28);
			this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
			this.MainTableLayoutPanel.RowCount = 1;
			this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.MainTableLayoutPanel.Size = new System.Drawing.Size(966, 585);
			this.MainTableLayoutPanel.TabIndex = 1;
			// 
			// CircuitTreeView
			// 
			this.CircuitTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitTreeView.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CircuitTreeView.ForeColor = System.Drawing.SystemColors.WindowText;
			this.CircuitTreeView.HideSelection = false;
			this.CircuitTreeView.Location = new System.Drawing.Point(3, 3);
			this.CircuitTreeView.Name = "CircuitTreeView";
			this.CircuitTreeView.ShowPlusMinus = false;
			this.CircuitTreeView.Size = new System.Drawing.Size(401, 579);
			this.CircuitTreeView.TabIndex = 0;
			this.CircuitTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.CircuitTreeView_NodeMouseDoubleClick);
			// 
			// ResultTableLayoutPanel
			// 
			this.ResultTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ResultTableLayoutPanel.AutoScroll = true;
			this.ResultTableLayoutPanel.ColumnCount = 1;
			this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.ResultTableLayoutPanel.Controls.Add(this.CalculateCircuitResistanceGroupBox, 0, 1);
			this.ResultTableLayoutPanel.Controls.Add(this.CircuitPanel, 0, 0);
			this.ResultTableLayoutPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.ResultTableLayoutPanel.Location = new System.Drawing.Point(410, 3);
			this.ResultTableLayoutPanel.Name = "ResultTableLayoutPanel";
			this.ResultTableLayoutPanel.RowCount = 2;
			this.ResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.64939F));
			this.ResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.35061F));
			this.ResultTableLayoutPanel.Size = new System.Drawing.Size(553, 579);
			this.ResultTableLayoutPanel.TabIndex = 1;
			// 
			// CalculateCircuitResistanceGroupBox
			// 
			this.CalculateCircuitResistanceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CalculateCircuitResistanceGroupBox.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.CalculateButton);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.CircuitResistanceGridView);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.ClearButton);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.DeleteFrequencyButton);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.EnterFrequencyTextBox);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.EnterFreguencyLabel);
			this.CalculateCircuitResistanceGroupBox.Location = new System.Drawing.Point(3, 330);
			this.CalculateCircuitResistanceGroupBox.Name = "CalculateCircuitResistanceGroupBox";
			this.CalculateCircuitResistanceGroupBox.Size = new System.Drawing.Size(547, 246);
			this.CalculateCircuitResistanceGroupBox.TabIndex = 1;
			this.CalculateCircuitResistanceGroupBox.TabStop = false;
			// 
			// CalculateButton
			// 
			this.CalculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.CalculateButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CalculateButton.Location = new System.Drawing.Point(456, 20);
			this.CalculateButton.Name = "CalculateButton";
			this.CalculateButton.Size = new System.Drawing.Size(85, 25);
			this.CalculateButton.TabIndex = 7;
			this.CalculateButton.Text = "Calculate";
			this.CalculateButton.UseVisualStyleBackColor = true;
			this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
			// 
			// CircuitResistanceGridView
			// 
			this.CircuitResistanceGridView.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CircuitResistanceGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.CircuitResistanceGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitResistanceGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.CircuitResistanceGridView.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.CircuitResistanceGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.CircuitResistanceGridView.ColumnHeadersHeight = 24;
			this.CircuitResistanceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.CircuitResistanceGridView.DefaultCellStyle = dataGridViewCellStyle3;
			this.CircuitResistanceGridView.EnableHeadersVisualStyles = false;
			this.CircuitResistanceGridView.Location = new System.Drawing.Point(6, 48);
			this.CircuitResistanceGridView.Name = "CircuitResistanceGridView";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSlateGray;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.CircuitResistanceGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSlateGray;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
			this.CircuitResistanceGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.CircuitResistanceGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.CircuitResistanceGridView.Size = new System.Drawing.Size(535, 161);
			this.CircuitResistanceGridView.TabIndex = 6;
			// 
			// ClearButton
			// 
			this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ClearButton.Location = new System.Drawing.Point(365, 215);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(85, 25);
			this.ClearButton.TabIndex = 5;
			this.ClearButton.Text = "Clear";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// DeleteFrequencyButton
			// 
			this.DeleteFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DeleteFrequencyButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DeleteFrequencyButton.Location = new System.Drawing.Point(456, 215);
			this.DeleteFrequencyButton.Name = "DeleteFrequencyButton";
			this.DeleteFrequencyButton.Size = new System.Drawing.Size(85, 25);
			this.DeleteFrequencyButton.TabIndex = 3;
			this.DeleteFrequencyButton.Text = "Delete";
			this.DeleteFrequencyButton.UseVisualStyleBackColor = true;
			this.DeleteFrequencyButton.Click += new System.EventHandler(this.DeleteFrequencyButton_Click);
			// 
			// EnterFrequencyTextBox
			// 
			this.EnterFrequencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EnterFrequencyTextBox.Location = new System.Drawing.Point(125, 21);
			this.EnterFrequencyTextBox.Name = "EnterFrequencyTextBox";
			this.EnterFrequencyTextBox.Size = new System.Drawing.Size(325, 21);
			this.EnterFrequencyTextBox.TabIndex = 2;
			// 
			// EnterFreguencyLabel
			// 
			this.EnterFreguencyLabel.AutoSize = true;
			this.EnterFreguencyLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.EnterFreguencyLabel.Location = new System.Drawing.Point(3, 21);
			this.EnterFreguencyLabel.Name = "EnterFreguencyLabel";
			this.EnterFreguencyLabel.Size = new System.Drawing.Size(109, 17);
			this.EnterFreguencyLabel.TabIndex = 1;
			this.EnterFreguencyLabel.Text = "Enter frequency:";
			this.EnterFreguencyLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// CircuitPanel
			// 
			this.CircuitPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitPanel.AutoScroll = true;
			this.CircuitPanel.Controls.Add(this.CircuitPictureBox);
			this.CircuitPanel.Location = new System.Drawing.Point(3, 3);
			this.CircuitPanel.Name = "CircuitPanel";
			this.CircuitPanel.Size = new System.Drawing.Size(547, 321);
			this.CircuitPanel.TabIndex = 2;
			// 
			// CircuitPictureBox
			// 
			this.CircuitPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitPictureBox.BackColor = System.Drawing.SystemColors.Window;
			this.CircuitPictureBox.Location = new System.Drawing.Point(0, 0);
			this.CircuitPictureBox.Name = "CircuitPictureBox";
			this.CircuitPictureBox.Size = new System.Drawing.Size(544, 318);
			this.CircuitPictureBox.TabIndex = 0;
			this.CircuitPictureBox.TabStop = false;
			// 
			// ClearTreeButton
			// 
			this.ClearTreeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ClearTreeButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearTreeButton.Image")));
			this.ClearTreeButton.Location = new System.Drawing.Point(10, 585);
			this.ClearTreeButton.Name = "ClearTreeButton";
			this.ClearTreeButton.Size = new System.Drawing.Size(32, 28);
			this.ClearTreeButton.TabIndex = 5;
			this.ClearTreeButton.UseVisualStyleBackColor = true;
			this.ClearTreeButton.Click += new System.EventHandler(this.ClearTreeButton_Click);
			// 
			// AddConnectionButton
			// 
			this.AddConnectionButton.Image = ((System.Drawing.Image)(resources.GetObject("AddConnectionButton.Image")));
			this.AddConnectionButton.Location = new System.Drawing.Point(10, 31);
			this.AddConnectionButton.Name = "AddConnectionButton";
			this.AddConnectionButton.Size = new System.Drawing.Size(32, 27);
			this.AddConnectionButton.TabIndex = 6;
			this.AddConnectionButton.UseVisualStyleBackColor = true;
			this.AddConnectionButton.Click += new System.EventHandler(this.AddConnectionButton_Click);
			// 
			// AddElementButton
			// 
			this.AddElementButton.Image = ((System.Drawing.Image)(resources.GetObject("AddElementButton.Image")));
			this.AddElementButton.Location = new System.Drawing.Point(10, 64);
			this.AddElementButton.Name = "AddElementButton";
			this.AddElementButton.Size = new System.Drawing.Size(32, 27);
			this.AddElementButton.TabIndex = 7;
			this.AddElementButton.UseVisualStyleBackColor = true;
			this.AddElementButton.Click += new System.EventHandler(this.AddElementButton_Click);
			// 
			// RemoveNodeButton
			// 
			this.RemoveNodeButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveNodeButton.Image")));
			this.RemoveNodeButton.Location = new System.Drawing.Point(10, 97);
			this.RemoveNodeButton.Name = "RemoveNodeButton";
			this.RemoveNodeButton.Size = new System.Drawing.Size(32, 27);
			this.RemoveNodeButton.TabIndex = 8;
			this.RemoveNodeButton.UseVisualStyleBackColor = true;
			this.RemoveNodeButton.Click += new System.EventHandler(this.RemoveNodeButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1026, 627);
			this.Controls.Add(this.RemoveNodeButton);
			this.Controls.Add(this.AddElementButton);
			this.Controls.Add(this.AddConnectionButton);
			this.Controls.Add(this.ClearTreeButton);
			this.Controls.Add(this.MainTableLayoutPanel);
			this.Controls.Add(this.menuStrip);
			this.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new System.Drawing.Size(1042, 665);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Circuit resistance calculator";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.MainTableLayoutPanel.ResumeLayout(false);
			this.ResultTableLayoutPanel.ResumeLayout(false);
			this.CalculateCircuitResistanceGroupBox.ResumeLayout(false);
			this.CalculateCircuitResistanceGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitResistanceGridView)).EndInit();
			this.CircuitPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CreateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewElectricalCircuitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
		private System.Windows.Forms.TreeView CircuitTreeView;
		private System.Windows.Forms.TableLayoutPanel ResultTableLayoutPanel;
		private System.Windows.Forms.GroupBox CalculateCircuitResistanceGroupBox;
		private System.Windows.Forms.TextBox EnterFrequencyTextBox;
		private System.Windows.Forms.Label EnterFreguencyLabel;
		private System.Windows.Forms.Button DeleteFrequencyButton;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.DataGridView CircuitResistanceGridView;
		private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Template1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Template2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Template3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Template4ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Template5ToolStripMenuItem;
		private System.Windows.Forms.Button ClearTreeButton;
		private System.Windows.Forms.Button AddConnectionButton;
		private System.Windows.Forms.Button AddElementButton;
		private System.Windows.Forms.Button CalculateButton;
		private System.Windows.Forms.Button RemoveNodeButton;
		private System.Windows.Forms.SaveFileDialog SaveCircuitDialog;
		private System.Windows.Forms.OpenFileDialog OpenCircuitDialog;
		private System.Windows.Forms.Panel CircuitPanel;
		private System.Windows.Forms.PictureBox CircuitPictureBox;
	}
}

