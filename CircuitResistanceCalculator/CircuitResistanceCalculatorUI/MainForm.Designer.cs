﻿
namespace CircuitResistanceCalculatorUI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewElectricalCircuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ElectricalCircuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ElectricalCircuitTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.branchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.templatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.circuit1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.circuit2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.circuit3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.circuit4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.circuit5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.CircuitTreeView = new System.Windows.Forms.TreeView();
			this.ResultTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.CircuitPictureBox = new System.Windows.Forms.PictureBox();
			this.CalculateCircuitResistanceGroupBox = new System.Windows.Forms.GroupBox();
			this.CircuitResistanceGridView = new System.Windows.Forms.DataGridView();
			this.ClearButton = new System.Windows.Forms.Button();
			this.EditFrequencyButton = new System.Windows.Forms.Button();
			this.DeleteFrequencyButton = new System.Windows.Forms.Button();
			this.EnterFrequencyTextBox = new System.Windows.Forms.TextBox();
			this.EnterFreguencyLabel = new System.Windows.Forms.Label();
			this.ClearTreeButton = new System.Windows.Forms.Button();
			this.ConnectionButton = new System.Windows.Forms.Button();
			this.ElementButton = new System.Windows.Forms.Button();
			this.menuStrip.SuspendLayout();
			this.MainTableLayoutPanel.SuspendLayout();
			this.ResultTableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).BeginInit();
			this.CalculateCircuitResistanceGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitResistanceGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.addToolStripMenuItem,
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
			this.CreateToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
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
			this.OpenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ElectricalCircuitToolStripMenuItem,
            this.ElectricalCircuitTemplateToolStripMenuItem});
			this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
			this.OpenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.OpenToolStripMenuItem.Text = "Open...";
			// 
			// ElectricalCircuitToolStripMenuItem
			// 
			this.ElectricalCircuitToolStripMenuItem.Name = "ElectricalCircuitToolStripMenuItem";
			this.ElectricalCircuitToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.ElectricalCircuitToolStripMenuItem.Text = "Electrical circuit";
			// 
			// ElectricalCircuitTemplateToolStripMenuItem
			// 
			this.ElectricalCircuitTemplateToolStripMenuItem.Name = "ElectricalCircuitTemplateToolStripMenuItem";
			this.ElectricalCircuitTemplateToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
			this.ElectricalCircuitTemplateToolStripMenuItem.Text = "Electrical circuit template";
			// 
			// SaveToolStripMenuItem
			// 
			this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
			this.SaveToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.SaveToolStripMenuItem.Text = "Save";
			// 
			// SaveAsToolStripMenuItem
			// 
			this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
			this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.SaveAsToolStripMenuItem.Text = "Save As";
			// 
			// ExitToolStripMenuItem
			// 
			this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
			this.ExitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.ExitToolStripMenuItem.Text = "Exit (Alt + F4)";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rootToolStripMenuItem,
            this.branchToolStripMenuItem,
            this.editNodeToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.clearToolStripMenuItem});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
			this.addToolStripMenuItem.Text = "Actions";
			// 
			// rootToolStripMenuItem
			// 
			this.rootToolStripMenuItem.Name = "rootToolStripMenuItem";
			this.rootToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.rootToolStripMenuItem.Text = "Add root";
			// 
			// branchToolStripMenuItem
			// 
			this.branchToolStripMenuItem.Name = "branchToolStripMenuItem";
			this.branchToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.branchToolStripMenuItem.Text = "Add branch";
			// 
			// editNodeToolStripMenuItem
			// 
			this.editNodeToolStripMenuItem.Name = "editNodeToolStripMenuItem";
			this.editNodeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.editNodeToolStripMenuItem.Text = "Edit node";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.deleteToolStripMenuItem.Text = "Delete node";
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.clearToolStripMenuItem.Text = "Clear tree";
			// 
			// templatesToolStripMenuItem
			// 
			this.templatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circuit1ToolStripMenuItem,
            this.circuit2ToolStripMenuItem,
            this.circuit3ToolStripMenuItem,
            this.circuit4ToolStripMenuItem,
            this.circuit5ToolStripMenuItem});
			this.templatesToolStripMenuItem.Name = "templatesToolStripMenuItem";
			this.templatesToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
			this.templatesToolStripMenuItem.Text = "Templates";
			// 
			// circuit1ToolStripMenuItem
			// 
			this.circuit1ToolStripMenuItem.Name = "circuit1ToolStripMenuItem";
			this.circuit1ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.circuit1ToolStripMenuItem.Text = "Circuit №1";
			// 
			// circuit2ToolStripMenuItem
			// 
			this.circuit2ToolStripMenuItem.Name = "circuit2ToolStripMenuItem";
			this.circuit2ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.circuit2ToolStripMenuItem.Text = "Circuit №2";
			// 
			// circuit3ToolStripMenuItem
			// 
			this.circuit3ToolStripMenuItem.Name = "circuit3ToolStripMenuItem";
			this.circuit3ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.circuit3ToolStripMenuItem.Text = "Circuit №3";
			// 
			// circuit4ToolStripMenuItem
			// 
			this.circuit4ToolStripMenuItem.Name = "circuit4ToolStripMenuItem";
			this.circuit4ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.circuit4ToolStripMenuItem.Text = "Circuit №4";
			// 
			// circuit5ToolStripMenuItem
			// 
			this.circuit5ToolStripMenuItem.Name = "circuit5ToolStripMenuItem";
			this.circuit5ToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.circuit5ToolStripMenuItem.Text = "Circuit №5";
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
			// 
			// ResultTableLayoutPanel
			// 
			this.ResultTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ResultTableLayoutPanel.ColumnCount = 1;
			this.ResultTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.ResultTableLayoutPanel.Controls.Add(this.CircuitPictureBox, 0, 0);
			this.ResultTableLayoutPanel.Controls.Add(this.CalculateCircuitResistanceGroupBox, 0, 1);
			this.ResultTableLayoutPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.ResultTableLayoutPanel.Location = new System.Drawing.Point(410, 3);
			this.ResultTableLayoutPanel.Name = "ResultTableLayoutPanel";
			this.ResultTableLayoutPanel.RowCount = 2;
			this.ResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.64939F));
			this.ResultTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.35061F));
			this.ResultTableLayoutPanel.Size = new System.Drawing.Size(553, 579);
			this.ResultTableLayoutPanel.TabIndex = 1;
			// 
			// CircuitPictureBox
			// 
			this.CircuitPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitPictureBox.BackColor = System.Drawing.SystemColors.Window;
			this.CircuitPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("CircuitPictureBox.Image")));
			this.CircuitPictureBox.Location = new System.Drawing.Point(3, 3);
			this.CircuitPictureBox.Name = "CircuitPictureBox";
			this.CircuitPictureBox.Size = new System.Drawing.Size(547, 321);
			this.CircuitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.CircuitPictureBox.TabIndex = 0;
			this.CircuitPictureBox.TabStop = false;
			// 
			// CalculateCircuitResistanceGroupBox
			// 
			this.CalculateCircuitResistanceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CalculateCircuitResistanceGroupBox.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.CircuitResistanceGridView);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.ClearButton);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.EditFrequencyButton);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.DeleteFrequencyButton);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.EnterFrequencyTextBox);
			this.CalculateCircuitResistanceGroupBox.Controls.Add(this.EnterFreguencyLabel);
			this.CalculateCircuitResistanceGroupBox.Location = new System.Drawing.Point(3, 330);
			this.CalculateCircuitResistanceGroupBox.Name = "CalculateCircuitResistanceGroupBox";
			this.CalculateCircuitResistanceGroupBox.Size = new System.Drawing.Size(547, 246);
			this.CalculateCircuitResistanceGroupBox.TabIndex = 1;
			this.CalculateCircuitResistanceGroupBox.TabStop = false;
			// 
			// CircuitResistanceGridView
			// 
			dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CircuitResistanceGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
			this.CircuitResistanceGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitResistanceGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.CircuitResistanceGridView.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
			dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
			dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.CircuitResistanceGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
			this.CircuitResistanceGridView.ColumnHeadersHeight = 24;
			this.CircuitResistanceGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.CircuitResistanceGridView.EnableHeadersVisualStyles = false;
			this.CircuitResistanceGridView.Location = new System.Drawing.Point(6, 48);
			this.CircuitResistanceGridView.Name = "CircuitResistanceGridView";
			dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightSlateGray;
			dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.CircuitResistanceGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
			dataGridViewCellStyle16.BackColor = System.Drawing.Color.DarkGray;
			dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.LightSlateGray;
			dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
			this.CircuitResistanceGridView.RowsDefaultCellStyle = dataGridViewCellStyle16;
			this.CircuitResistanceGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.CircuitResistanceGridView.Size = new System.Drawing.Size(535, 161);
			this.CircuitResistanceGridView.TabIndex = 6;
			// 
			// ClearButton
			// 
			this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ClearButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ClearButton.Location = new System.Drawing.Point(274, 215);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(85, 25);
			this.ClearButton.TabIndex = 5;
			this.ClearButton.Text = "Clear";
			this.ClearButton.UseVisualStyleBackColor = true;
			// 
			// EditFrequencyButton
			// 
			this.EditFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.EditFrequencyButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.EditFrequencyButton.Location = new System.Drawing.Point(456, 215);
			this.EditFrequencyButton.Name = "EditFrequencyButton";
			this.EditFrequencyButton.Size = new System.Drawing.Size(85, 25);
			this.EditFrequencyButton.TabIndex = 4;
			this.EditFrequencyButton.Text = "Edit";
			this.EditFrequencyButton.UseVisualStyleBackColor = true;
			// 
			// DeleteFrequencyButton
			// 
			this.DeleteFrequencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DeleteFrequencyButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.DeleteFrequencyButton.Location = new System.Drawing.Point(365, 215);
			this.DeleteFrequencyButton.Name = "DeleteFrequencyButton";
			this.DeleteFrequencyButton.Size = new System.Drawing.Size(85, 25);
			this.DeleteFrequencyButton.TabIndex = 3;
			this.DeleteFrequencyButton.Text = "Delete";
			this.DeleteFrequencyButton.UseVisualStyleBackColor = true;
			// 
			// EnterFrequencyTextBox
			// 
			this.EnterFrequencyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.EnterFrequencyTextBox.Location = new System.Drawing.Point(125, 21);
			this.EnterFrequencyTextBox.Name = "EnterFrequencyTextBox";
			this.EnterFrequencyTextBox.Size = new System.Drawing.Size(416, 21);
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
			// ClearTreeButton
			// 
			this.ClearTreeButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearTreeButton.Image")));
			this.ClearTreeButton.Location = new System.Drawing.Point(10, 585);
			this.ClearTreeButton.Name = "ClearTreeButton";
			this.ClearTreeButton.Size = new System.Drawing.Size(32, 28);
			this.ClearTreeButton.TabIndex = 5;
			this.ClearTreeButton.UseVisualStyleBackColor = true;
			// 
			// ConnectionButton
			// 
			this.ConnectionButton.Image = ((System.Drawing.Image)(resources.GetObject("ConnectionButton.Image")));
			this.ConnectionButton.Location = new System.Drawing.Point(10, 31);
			this.ConnectionButton.Name = "ConnectionButton";
			this.ConnectionButton.Size = new System.Drawing.Size(32, 27);
			this.ConnectionButton.TabIndex = 6;
			this.ConnectionButton.UseVisualStyleBackColor = true;
			this.ConnectionButton.Click += new System.EventHandler(this.ConnectionButton_Click);
			// 
			// ElementButton
			// 
			this.ElementButton.Image = ((System.Drawing.Image)(resources.GetObject("ElementButton.Image")));
			this.ElementButton.Location = new System.Drawing.Point(10, 64);
			this.ElementButton.Name = "ElementButton";
			this.ElementButton.Size = new System.Drawing.Size(32, 27);
			this.ElementButton.TabIndex = 7;
			this.ElementButton.UseVisualStyleBackColor = true;
			this.ElementButton.Click += new System.EventHandler(this.ElementButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1026, 627);
			this.Controls.Add(this.ElementButton);
			this.Controls.Add(this.ConnectionButton);
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
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.MainTableLayoutPanel.ResumeLayout(false);
			this.ResultTableLayoutPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.CircuitPictureBox)).EndInit();
			this.CalculateCircuitResistanceGroupBox.ResumeLayout(false);
			this.CalculateCircuitResistanceGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.CircuitResistanceGridView)).EndInit();
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
		private System.Windows.Forms.ToolStripMenuItem ElectricalCircuitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ElectricalCircuitTemplateToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
		private System.Windows.Forms.TreeView CircuitTreeView;
		private System.Windows.Forms.TableLayoutPanel ResultTableLayoutPanel;
		private System.Windows.Forms.PictureBox CircuitPictureBox;
		private System.Windows.Forms.GroupBox CalculateCircuitResistanceGroupBox;
		private System.Windows.Forms.TextBox EnterFrequencyTextBox;
		private System.Windows.Forms.Label EnterFreguencyLabel;
		private System.Windows.Forms.Button EditFrequencyButton;
		private System.Windows.Forms.Button DeleteFrequencyButton;
		private System.Windows.Forms.Button ClearButton;
		private System.Windows.Forms.DataGridView CircuitResistanceGridView;
		private System.Windows.Forms.ToolStripMenuItem templatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem circuit1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem circuit2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem circuit3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem circuit4ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem circuit5ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rootToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem branchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.Button ClearTreeButton;
		private System.Windows.Forms.ToolStripMenuItem editNodeToolStripMenuItem;
		private System.Windows.Forms.Button ConnectionButton;
		private System.Windows.Forms.Button ElementButton;
	}
}

