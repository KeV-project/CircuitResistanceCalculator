
namespace CircuitResistanceCalculatorUI.EditConnection
{
	partial class EditConnectionsForm
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
			this.ParallelRadioButton = new System.Windows.Forms.RadioButton();
			this.SerialRadioButton = new System.Windows.Forms.RadioButton();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ParallelRadioButton
			// 
			this.ParallelRadioButton.AutoSize = true;
			this.ParallelRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ParallelRadioButton.Location = new System.Drawing.Point(23, 32);
			this.ParallelRadioButton.Name = "ParallelRadioButton";
			this.ParallelRadioButton.Size = new System.Drawing.Size(142, 21);
			this.ParallelRadioButton.TabIndex = 0;
			this.ParallelRadioButton.TabStop = true;
			this.ParallelRadioButton.Text = "Parallel connection";
			this.ParallelRadioButton.UseVisualStyleBackColor = true;
			// 
			// SerialRadioButton
			// 
			this.SerialRadioButton.AutoSize = true;
			this.SerialRadioButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SerialRadioButton.Location = new System.Drawing.Point(23, 59);
			this.SerialRadioButton.Name = "SerialRadioButton";
			this.SerialRadioButton.Size = new System.Drawing.Size(132, 21);
			this.SerialRadioButton.TabIndex = 1;
			this.SerialRadioButton.TabStop = true;
			this.SerialRadioButton.Text = "Serial connection";
			this.SerialRadioButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.OkButton.Location = new System.Drawing.Point(138, 109);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(86, 27);
			this.OkButton.TabIndex = 2;
			this.OkButton.Text = "Ok";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CancelButton.Location = new System.Drawing.Point(46, 109);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(86, 27);
			this.CancelButton.TabIndex = 3;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// EditConnectionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(236, 148);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.SerialRadioButton);
			this.Controls.Add(this.ParallelRadioButton);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(252, 186);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(252, 186);
			this.Name = "EditConnectionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add connection type";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton ParallelRadioButton;
		private System.Windows.Forms.RadioButton SerialRadioButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancelButton;
	}
}