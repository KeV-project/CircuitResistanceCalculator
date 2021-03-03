
namespace CircuitResistanceCalculatorUI.EditingElement
{
	partial class EditElementForm
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
			this.ElementLabel = new System.Windows.Forms.Label();
			this.ValueLabel = new System.Windows.Forms.Label();
			this.UnitsLabel = new System.Windows.Forms.Label();
			this.ElementsUnitsLabel = new System.Windows.Forms.Label();
			this.ValueTextBox = new System.Windows.Forms.TextBox();
			this.ElementsDomainUpDown = new System.Windows.Forms.DomainUpDown();
			this.CancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.IndexLabel = new System.Windows.Forms.Label();
			this.IndexTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// ElementLabel
			// 
			this.ElementLabel.AutoSize = true;
			this.ElementLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ElementLabel.Location = new System.Drawing.Point(23, 21);
			this.ElementLabel.Name = "ElementLabel";
			this.ElementLabel.Size = new System.Drawing.Size(57, 17);
			this.ElementLabel.TabIndex = 0;
			this.ElementLabel.Text = "Element";
			// 
			// ValueLabel
			// 
			this.ValueLabel.AutoSize = true;
			this.ValueLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ValueLabel.Location = new System.Drawing.Point(204, 21);
			this.ValueLabel.Name = "ValueLabel";
			this.ValueLabel.Size = new System.Drawing.Size(42, 17);
			this.ValueLabel.TabIndex = 1;
			this.ValueLabel.Text = "Value";
			// 
			// UnitsLabel
			// 
			this.UnitsLabel.AutoSize = true;
			this.UnitsLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.UnitsLabel.Location = new System.Drawing.Point(283, 21);
			this.UnitsLabel.Name = "UnitsLabel";
			this.UnitsLabel.Size = new System.Drawing.Size(40, 17);
			this.UnitsLabel.TabIndex = 2;
			this.UnitsLabel.Text = "Units";
			// 
			// ElementsUnitsLabel
			// 
			this.ElementsUnitsLabel.AutoSize = true;
			this.ElementsUnitsLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ElementsUnitsLabel.Location = new System.Drawing.Point(283, 50);
			this.ElementsUnitsLabel.Name = "ElementsUnitsLabel";
			this.ElementsUnitsLabel.Size = new System.Drawing.Size(40, 17);
			this.ElementsUnitsLabel.TabIndex = 3;
			this.ElementsUnitsLabel.Text = "Units";
			// 
			// ValueTextBox
			// 
			this.ValueTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ValueTextBox.Location = new System.Drawing.Point(194, 47);
			this.ValueTextBox.Name = "ValueTextBox";
			this.ValueTextBox.Size = new System.Drawing.Size(62, 24);
			this.ValueTextBox.TabIndex = 4;
			// 
			// ElementsDomainUpDown
			// 
			this.ElementsDomainUpDown.Items.Add("L");
			this.ElementsDomainUpDown.Items.Add("C");
			this.ElementsDomainUpDown.Items.Add("R");
			this.ElementsDomainUpDown.Location = new System.Drawing.Point(26, 50);
			this.ElementsDomainUpDown.Name = "ElementsDomainUpDown";
			this.ElementsDomainUpDown.ReadOnly = true;
			this.ElementsDomainUpDown.Size = new System.Drawing.Size(54, 20);
			this.ElementsDomainUpDown.TabIndex = 5;
			this.ElementsDomainUpDown.Wrap = true;
			this.ElementsDomainUpDown.SelectedItemChanged += new System.EventHandler(this.ElementsDomainUpDown_SelectedItemChanged);
			// 
			// CancelButton
			// 
			this.CancelButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CancelButton.Location = new System.Drawing.Point(158, 126);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(84, 28);
			this.CancelButton.TabIndex = 6;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// OkButton
			// 
			this.OkButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.OkButton.Location = new System.Drawing.Point(248, 126);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(84, 28);
			this.OkButton.TabIndex = 7;
			this.OkButton.Text = "Ok";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// IndexLabel
			// 
			this.IndexLabel.AutoSize = true;
			this.IndexLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.IndexLabel.Location = new System.Drawing.Point(115, 21);
			this.IndexLabel.Name = "IndexLabel";
			this.IndexLabel.Size = new System.Drawing.Size(42, 17);
			this.IndexLabel.TabIndex = 8;
			this.IndexLabel.Text = "Index";
			// 
			// IndexTextBox
			// 
			this.IndexTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.IndexTextBox.Location = new System.Drawing.Point(107, 47);
			this.IndexTextBox.Name = "IndexTextBox";
			this.IndexTextBox.Size = new System.Drawing.Size(62, 24);
			this.IndexTextBox.TabIndex = 9;
			// 
			// EditElementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 167);
			this.Controls.Add(this.IndexTextBox);
			this.Controls.Add(this.IndexLabel);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.ElementsDomainUpDown);
			this.Controls.Add(this.ValueTextBox);
			this.Controls.Add(this.ElementsUnitsLabel);
			this.Controls.Add(this.UnitsLabel);
			this.Controls.Add(this.ValueLabel);
			this.Controls.Add(this.ElementLabel);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(360, 205);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(360, 205);
			this.Name = "EditElementForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label ElementLabel;
		private System.Windows.Forms.Label ValueLabel;
		private System.Windows.Forms.Label UnitsLabel;
		private System.Windows.Forms.Label ElementsUnitsLabel;
		private System.Windows.Forms.TextBox ValueTextBox;
		private System.Windows.Forms.DomainUpDown ElementsDomainUpDown;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Label IndexLabel;
		private System.Windows.Forms.TextBox IndexTextBox;
	}
}