
namespace CircuitResistanceCalculatorUI
{
	partial class AddNode
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ConnectionTypeLabel = new System.Windows.Forms.Label();
			this.ElementTypeLabel = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.SerialRadioButton = new System.Windows.Forms.RadioButton();
			this.ParallelRadioButton = new System.Windows.Forms.RadioButton();
			this.RRadioButton = new System.Windows.Forms.RadioButton();
			this.LRadioButton = new System.Windows.Forms.RadioButton();
			this.CRadioButton = new System.Windows.Forms.RadioButton();
			this.RValuemaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.LValueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.CValueMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.ValueLabel = new System.Windows.Forms.Label();
			this.UnitLabel = new System.Windows.Forms.Label();
			this.RUnitLabel = new System.Windows.Forms.Label();
			this.LUnitLable = new System.Windows.Forms.Label();
			this.ConnectionGroupBox = new System.Windows.Forms.GroupBox();
			this.ElementsGroupBox = new System.Windows.Forms.GroupBox();
			this.IndexLabel = new System.Windows.Forms.Label();
			this.RIndexMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.LIndexMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.CIndexMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.REquallyLabel = new System.Windows.Forms.Label();
			this.LEquallyLabel = new System.Windows.Forms.Label();
			this.CEquallyLabel = new System.Windows.Forms.Label();
			this.CUnitLabel = new System.Windows.Forms.Label();
			this.ConnectionGroupBox.SuspendLayout();
			this.ElementsGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// ConnectionTypeLabel
			// 
			this.ConnectionTypeLabel.AutoSize = true;
			this.ConnectionTypeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ConnectionTypeLabel.Location = new System.Drawing.Point(6, 16);
			this.ConnectionTypeLabel.Name = "ConnectionTypeLabel";
			this.ConnectionTypeLabel.Size = new System.Drawing.Size(113, 17);
			this.ConnectionTypeLabel.TabIndex = 0;
			this.ConnectionTypeLabel.Text = "Connection type:";
			this.ConnectionTypeLabel.Click += new System.EventHandler(this.ConnectionTypeLabel_Click);
			// 
			// ElementTypeLabel
			// 
			this.ElementTypeLabel.AutoSize = true;
			this.ElementTypeLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ElementTypeLabel.Location = new System.Drawing.Point(6, 20);
			this.ElementTypeLabel.Name = "ElementTypeLabel";
			this.ElementTypeLabel.Size = new System.Drawing.Size(91, 17);
			this.ElementTypeLabel.TabIndex = 1;
			this.ElementTypeLabel.Text = "Element type:";
			this.ElementTypeLabel.Click += new System.EventHandler(this.ElementTypeLabel_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(398, 248);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 27);
			this.button1.TabIndex = 2;
			this.button1.Text = "Ok";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			this.CancelButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CancelButton.Location = new System.Drawing.Point(296, 248);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(96, 27);
			this.CancelButton.TabIndex = 3;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			// 
			// SerialRadioButton
			// 
			this.SerialRadioButton.AutoSize = true;
			this.SerialRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SerialRadioButton.Location = new System.Drawing.Point(205, 14);
			this.SerialRadioButton.Name = "SerialRadioButton";
			this.SerialRadioButton.Size = new System.Drawing.Size(59, 21);
			this.SerialRadioButton.TabIndex = 4;
			this.SerialRadioButton.TabStop = true;
			this.SerialRadioButton.Text = "Serial";
			this.SerialRadioButton.UseVisualStyleBackColor = true;
			this.SerialRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// ParallelRadioButton
			// 
			this.ParallelRadioButton.AutoSize = true;
			this.ParallelRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ParallelRadioButton.Location = new System.Drawing.Point(358, 14);
			this.ParallelRadioButton.Name = "ParallelRadioButton";
			this.ParallelRadioButton.Size = new System.Drawing.Size(69, 21);
			this.ParallelRadioButton.TabIndex = 5;
			this.ParallelRadioButton.TabStop = true;
			this.ParallelRadioButton.Text = "Parallel";
			this.ParallelRadioButton.UseVisualStyleBackColor = true;
			// 
			// RRadioButton
			// 
			this.RRadioButton.AutoSize = true;
			this.RRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RRadioButton.Location = new System.Drawing.Point(9, 45);
			this.RRadioButton.Name = "RRadioButton";
			this.RRadioButton.Size = new System.Drawing.Size(34, 21);
			this.RRadioButton.TabIndex = 6;
			this.RRadioButton.TabStop = true;
			this.RRadioButton.Text = "R";
			this.RRadioButton.UseVisualStyleBackColor = true;
			// 
			// LRadioButton
			// 
			this.LRadioButton.AutoSize = true;
			this.LRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LRadioButton.Location = new System.Drawing.Point(9, 72);
			this.LRadioButton.Name = "LRadioButton";
			this.LRadioButton.Size = new System.Drawing.Size(33, 21);
			this.LRadioButton.TabIndex = 7;
			this.LRadioButton.TabStop = true;
			this.LRadioButton.Text = "L";
			this.LRadioButton.UseVisualStyleBackColor = true;
			// 
			// CRadioButton
			// 
			this.CRadioButton.AutoSize = true;
			this.CRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CRadioButton.Location = new System.Drawing.Point(9, 99);
			this.CRadioButton.Name = "CRadioButton";
			this.CRadioButton.Size = new System.Drawing.Size(35, 21);
			this.CRadioButton.TabIndex = 8;
			this.CRadioButton.TabStop = true;
			this.CRadioButton.Text = "C";
			this.CRadioButton.UseVisualStyleBackColor = true;
			// 
			// RValuemaskedTextBox
			// 
			this.RValuemaskedTextBox.Location = new System.Drawing.Point(298, 44);
			this.RValuemaskedTextBox.Name = "RValuemaskedTextBox";
			this.RValuemaskedTextBox.Size = new System.Drawing.Size(100, 20);
			this.RValuemaskedTextBox.TabIndex = 9;
			this.RValuemaskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
			// 
			// LValueMaskedTextBox
			// 
			this.LValueMaskedTextBox.Location = new System.Drawing.Point(298, 70);
			this.LValueMaskedTextBox.Name = "LValueMaskedTextBox";
			this.LValueMaskedTextBox.Size = new System.Drawing.Size(100, 20);
			this.LValueMaskedTextBox.TabIndex = 10;
			// 
			// CValueMaskedTextBox
			// 
			this.CValueMaskedTextBox.Location = new System.Drawing.Point(298, 99);
			this.CValueMaskedTextBox.Name = "CValueMaskedTextBox";
			this.CValueMaskedTextBox.Size = new System.Drawing.Size(100, 20);
			this.CValueMaskedTextBox.TabIndex = 11;
			// 
			// ValueLabel
			// 
			this.ValueLabel.AutoSize = true;
			this.ValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ValueLabel.Location = new System.Drawing.Point(325, 20);
			this.ValueLabel.Name = "ValueLabel";
			this.ValueLabel.Size = new System.Drawing.Size(45, 17);
			this.ValueLabel.TabIndex = 12;
			this.ValueLabel.Text = "Value:";
			// 
			// UnitLabel
			// 
			this.UnitLabel.AutoSize = true;
			this.UnitLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UnitLabel.Location = new System.Drawing.Point(435, 20);
			this.UnitLabel.Name = "UnitLabel";
			this.UnitLabel.Size = new System.Drawing.Size(37, 17);
			this.UnitLabel.TabIndex = 13;
			this.UnitLabel.Text = "Unit:";
			// 
			// RUnitLabel
			// 
			this.RUnitLabel.AutoSize = true;
			this.RUnitLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.RUnitLabel.Location = new System.Drawing.Point(444, 45);
			this.RUnitLabel.Name = "RUnitLabel";
			this.RUnitLabel.Size = new System.Drawing.Size(19, 17);
			this.RUnitLabel.TabIndex = 14;
			this.RUnitLabel.Text = "Ω";
			// 
			// LUnitLable
			// 
			this.LUnitLable.AutoSize = true;
			this.LUnitLable.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LUnitLable.Location = new System.Drawing.Point(444, 71);
			this.LUnitLable.Name = "LUnitLable";
			this.LUnitLable.Size = new System.Drawing.Size(18, 17);
			this.LUnitLable.TabIndex = 15;
			this.LUnitLable.Text = "H";
			// 
			// ConnectionGroupBox
			// 
			this.ConnectionGroupBox.Controls.Add(this.ConnectionTypeLabel);
			this.ConnectionGroupBox.Controls.Add(this.SerialRadioButton);
			this.ConnectionGroupBox.Controls.Add(this.ParallelRadioButton);
			this.ConnectionGroupBox.Location = new System.Drawing.Point(12, 12);
			this.ConnectionGroupBox.Name = "ConnectionGroupBox";
			this.ConnectionGroupBox.Size = new System.Drawing.Size(482, 46);
			this.ConnectionGroupBox.TabIndex = 17;
			this.ConnectionGroupBox.TabStop = false;
			this.ConnectionGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// ElementsGroupBox
			// 
			this.ElementsGroupBox.Controls.Add(this.CEquallyLabel);
			this.ElementsGroupBox.Controls.Add(this.CIndexMaskedTextBox);
			this.ElementsGroupBox.Controls.Add(this.LUnitLable);
			this.ElementsGroupBox.Controls.Add(this.CUnitLabel);
			this.ElementsGroupBox.Controls.Add(this.LEquallyLabel);
			this.ElementsGroupBox.Controls.Add(this.IndexLabel);
			this.ElementsGroupBox.Controls.Add(this.RUnitLabel);
			this.ElementsGroupBox.Controls.Add(this.REquallyLabel);
			this.ElementsGroupBox.Controls.Add(this.UnitLabel);
			this.ElementsGroupBox.Controls.Add(this.LIndexMaskedTextBox);
			this.ElementsGroupBox.Controls.Add(this.ValueLabel);
			this.ElementsGroupBox.Controls.Add(this.ElementTypeLabel);
			this.ElementsGroupBox.Controls.Add(this.CValueMaskedTextBox);
			this.ElementsGroupBox.Controls.Add(this.RValuemaskedTextBox);
			this.ElementsGroupBox.Controls.Add(this.LValueMaskedTextBox);
			this.ElementsGroupBox.Controls.Add(this.RIndexMaskedTextBox);
			this.ElementsGroupBox.Controls.Add(this.RRadioButton);
			this.ElementsGroupBox.Controls.Add(this.LRadioButton);
			this.ElementsGroupBox.Controls.Add(this.CRadioButton);
			this.ElementsGroupBox.Location = new System.Drawing.Point(12, 69);
			this.ElementsGroupBox.Name = "ElementsGroupBox";
			this.ElementsGroupBox.Size = new System.Drawing.Size(482, 173);
			this.ElementsGroupBox.TabIndex = 18;
			this.ElementsGroupBox.TabStop = false;
			// 
			// IndexLabel
			// 
			this.IndexLabel.AutoSize = true;
			this.IndexLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.IndexLabel.Location = new System.Drawing.Point(138, 20);
			this.IndexLabel.Name = "IndexLabel";
			this.IndexLabel.Size = new System.Drawing.Size(45, 17);
			this.IndexLabel.TabIndex = 9;
			this.IndexLabel.Text = "Index:";
			// 
			// RIndexMaskedTextBox
			// 
			this.RIndexMaskedTextBox.Location = new System.Drawing.Point(112, 46);
			this.RIndexMaskedTextBox.Name = "RIndexMaskedTextBox";
			this.RIndexMaskedTextBox.Size = new System.Drawing.Size(100, 20);
			this.RIndexMaskedTextBox.TabIndex = 19;
			// 
			// LIndexMaskedTextBox
			// 
			this.LIndexMaskedTextBox.Location = new System.Drawing.Point(112, 73);
			this.LIndexMaskedTextBox.Name = "LIndexMaskedTextBox";
			this.LIndexMaskedTextBox.Size = new System.Drawing.Size(100, 20);
			this.LIndexMaskedTextBox.TabIndex = 20;
			// 
			// CIndexMaskedTextBox
			// 
			this.CIndexMaskedTextBox.Location = new System.Drawing.Point(112, 100);
			this.CIndexMaskedTextBox.Name = "CIndexMaskedTextBox";
			this.CIndexMaskedTextBox.Size = new System.Drawing.Size(100, 20);
			this.CIndexMaskedTextBox.TabIndex = 21;
			// 
			// REquallyLabel
			// 
			this.REquallyLabel.AutoSize = true;
			this.REquallyLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.REquallyLabel.Location = new System.Drawing.Point(246, 47);
			this.REquallyLabel.Name = "REquallyLabel";
			this.REquallyLabel.Size = new System.Drawing.Size(18, 17);
			this.REquallyLabel.TabIndex = 19;
			this.REquallyLabel.Text = "=";
			// 
			// LEquallyLabel
			// 
			this.LEquallyLabel.AutoSize = true;
			this.LEquallyLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.LEquallyLabel.Location = new System.Drawing.Point(246, 74);
			this.LEquallyLabel.Name = "LEquallyLabel";
			this.LEquallyLabel.Size = new System.Drawing.Size(18, 17);
			this.LEquallyLabel.TabIndex = 20;
			this.LEquallyLabel.Text = "=";
			// 
			// CEquallyLabel
			// 
			this.CEquallyLabel.AutoSize = true;
			this.CEquallyLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CEquallyLabel.Location = new System.Drawing.Point(246, 101);
			this.CEquallyLabel.Name = "CEquallyLabel";
			this.CEquallyLabel.Size = new System.Drawing.Size(18, 17);
			this.CEquallyLabel.TabIndex = 21;
			this.CEquallyLabel.Text = "=";
			// 
			// CUnitLabel
			// 
			this.CUnitLabel.AutoSize = true;
			this.CUnitLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CUnitLabel.Location = new System.Drawing.Point(444, 101);
			this.CUnitLabel.Name = "CUnitLabel";
			this.CUnitLabel.Size = new System.Drawing.Size(15, 17);
			this.CUnitLabel.TabIndex = 16;
			this.CUnitLabel.Text = "F";
			// 
			// AddNode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 281);
			this.Controls.Add(this.ElementsGroupBox);
			this.Controls.Add(this.ConnectionGroupBox);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.button1);
			this.MaximumSize = new System.Drawing.Size(525, 319);
			this.MinimumSize = new System.Drawing.Size(525, 319);
			this.Name = "AddNode";
			this.Text = "Add node";
			this.ConnectionGroupBox.ResumeLayout(false);
			this.ConnectionGroupBox.PerformLayout();
			this.ElementsGroupBox.ResumeLayout(false);
			this.ElementsGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label ConnectionTypeLabel;
		private System.Windows.Forms.Label ElementTypeLabel;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.RadioButton SerialRadioButton;
		private System.Windows.Forms.RadioButton ParallelRadioButton;
		private System.Windows.Forms.RadioButton RRadioButton;
		private System.Windows.Forms.RadioButton LRadioButton;
		private System.Windows.Forms.RadioButton CRadioButton;
		private System.Windows.Forms.MaskedTextBox RValuemaskedTextBox;
		private System.Windows.Forms.MaskedTextBox LValueMaskedTextBox;
		private System.Windows.Forms.MaskedTextBox CValueMaskedTextBox;
		private System.Windows.Forms.Label ValueLabel;
		private System.Windows.Forms.Label UnitLabel;
		private System.Windows.Forms.Label RUnitLabel;
		private System.Windows.Forms.Label LUnitLable;
		private System.Windows.Forms.GroupBox ConnectionGroupBox;
		private System.Windows.Forms.GroupBox ElementsGroupBox;
		private System.Windows.Forms.Label CEquallyLabel;
		private System.Windows.Forms.MaskedTextBox CIndexMaskedTextBox;
		private System.Windows.Forms.Label LEquallyLabel;
		private System.Windows.Forms.Label IndexLabel;
		private System.Windows.Forms.Label REquallyLabel;
		private System.Windows.Forms.MaskedTextBox LIndexMaskedTextBox;
		private System.Windows.Forms.MaskedTextBox RIndexMaskedTextBox;
		private System.Windows.Forms.Label CUnitLabel;
	}
}