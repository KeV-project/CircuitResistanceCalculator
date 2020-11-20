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
			this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сalculatingCircuitResistanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CircuitTreeView = new System.Windows.Forms.TreeView();
			this.CalculateCircuitResistanceButton = new System.Windows.Forms.Button();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.HelpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			this.menuStrip.Size = new System.Drawing.Size(1275, 25);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			this.menuStrip.UseWaitCursor = true;
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
			this.ElectricalCircuitTemplateToolStripMenuItem.Click += new System.EventHandler(this.ElectricalCircuitTemplateToolStripMenuItem_Click);
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
			// actionsToolStripMenuItem
			// 
			this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сalculatingCircuitResistanceToolStripMenuItem});
			this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
			this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
			this.actionsToolStripMenuItem.Text = "Actions";
			// 
			// сalculatingCircuitResistanceToolStripMenuItem
			// 
			this.сalculatingCircuitResistanceToolStripMenuItem.Name = "сalculatingCircuitResistanceToolStripMenuItem";
			this.сalculatingCircuitResistanceToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
			this.сalculatingCircuitResistanceToolStripMenuItem.Text = "Сalculating circuit resistance";
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
			// CircuitTreeView
			// 
			this.CircuitTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CircuitTreeView.Location = new System.Drawing.Point(12, 64);
			this.CircuitTreeView.Name = "CircuitTreeView";
			this.CircuitTreeView.Size = new System.Drawing.Size(1251, 608);
			this.CircuitTreeView.TabIndex = 1;
			this.CircuitTreeView.UseWaitCursor = true;
			// 
			// CalculateCircuitResistanceButton
			// 
			this.CalculateCircuitResistanceButton.Image = ((System.Drawing.Image)(resources.GetObject("CalculateCircuitResistanceButton.Image")));
			this.CalculateCircuitResistanceButton.Location = new System.Drawing.Point(12, 28);
			this.CalculateCircuitResistanceButton.Name = "CalculateCircuitResistanceButton";
			this.CalculateCircuitResistanceButton.Size = new System.Drawing.Size(31, 30);
			this.CalculateCircuitResistanceButton.TabIndex = 2;
			this.CalculateCircuitResistanceButton.UseVisualStyleBackColor = true;
			this.CalculateCircuitResistanceButton.UseWaitCursor = true;
			this.CalculateCircuitResistanceButton.Click += new System.EventHandler(this.CalculateCircuitResistanceButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1275, 684);
			this.Controls.Add(this.CalculateCircuitResistanceButton);
			this.Controls.Add(this.CircuitTreeView);
			this.Controls.Add(this.menuStrip);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MainMenuStrip = this.menuStrip;
			this.MinimumSize = new System.Drawing.Size(1042, 665);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Circuit resistance calculator";
			this.UseWaitCursor = true;
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
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
		private System.Windows.Forms.TreeView CircuitTreeView;
		private System.Windows.Forms.ToolStripMenuItem ElectricalCircuitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ElectricalCircuitTemplateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сalculatingCircuitResistanceToolStripMenuItem;
		private System.Windows.Forms.Button CalculateCircuitResistanceButton;
	}
}

