
namespace CircuitResistanceCalculatorUI
{
	partial class TemplatesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplatesForm));
			this.TemplatesLabel = new System.Windows.Forms.Label();
			this.Template1Button = new System.Windows.Forms.Button();
			this.Template2Button = new System.Windows.Forms.Button();
			this.Template4Button = new System.Windows.Forms.Button();
			this.Template5Button = new System.Windows.Forms.Button();
			this.Template6Button = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.Template3Button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TemplatesLabel
			// 
			this.TemplatesLabel.AutoSize = true;
			this.TemplatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.TemplatesLabel.Location = new System.Drawing.Point(12, 9);
			this.TemplatesLabel.Name = "TemplatesLabel";
			this.TemplatesLabel.Size = new System.Drawing.Size(397, 18);
			this.TemplatesLabel.TabIndex = 0;
			this.TemplatesLabel.Text = "Выберите шаблон для создания электрической схемы:";
			// 
			// Template1Button
			// 
			this.Template1Button.Image = ((System.Drawing.Image)(resources.GetObject("Template1Button.Image")));
			this.Template1Button.Location = new System.Drawing.Point(15, 46);
			this.Template1Button.MaximumSize = new System.Drawing.Size(259, 158);
			this.Template1Button.MinimumSize = new System.Drawing.Size(259, 158);
			this.Template1Button.Name = "Template1Button";
			this.Template1Button.Size = new System.Drawing.Size(259, 158);
			this.Template1Button.TabIndex = 1;
			this.Template1Button.UseVisualStyleBackColor = true;
			// 
			// Template2Button
			// 
			this.Template2Button.Image = ((System.Drawing.Image)(resources.GetObject("Template2Button.Image")));
			this.Template2Button.Location = new System.Drawing.Point(280, 46);
			this.Template2Button.MaximumSize = new System.Drawing.Size(259, 158);
			this.Template2Button.MinimumSize = new System.Drawing.Size(259, 158);
			this.Template2Button.Name = "Template2Button";
			this.Template2Button.Size = new System.Drawing.Size(259, 158);
			this.Template2Button.TabIndex = 2;
			this.Template2Button.UseVisualStyleBackColor = true;
			// 
			// Template4Button
			// 
			this.Template4Button.Image = ((System.Drawing.Image)(resources.GetObject("Template4Button.Image")));
			this.Template4Button.Location = new System.Drawing.Point(15, 220);
			this.Template4Button.MaximumSize = new System.Drawing.Size(259, 158);
			this.Template4Button.MinimumSize = new System.Drawing.Size(259, 158);
			this.Template4Button.Name = "Template4Button";
			this.Template4Button.Size = new System.Drawing.Size(259, 158);
			this.Template4Button.TabIndex = 4;
			this.Template4Button.UseVisualStyleBackColor = true;
			// 
			// Template5Button
			// 
			this.Template5Button.Image = ((System.Drawing.Image)(resources.GetObject("Template5Button.Image")));
			this.Template5Button.Location = new System.Drawing.Point(280, 220);
			this.Template5Button.MaximumSize = new System.Drawing.Size(259, 158);
			this.Template5Button.MinimumSize = new System.Drawing.Size(259, 158);
			this.Template5Button.Name = "Template5Button";
			this.Template5Button.Size = new System.Drawing.Size(259, 158);
			this.Template5Button.TabIndex = 5;
			this.Template5Button.UseVisualStyleBackColor = true;
			// 
			// Template6Button
			// 
			this.Template6Button.Image = ((System.Drawing.Image)(resources.GetObject("Template6Button.Image")));
			this.Template6Button.Location = new System.Drawing.Point(545, 220);
			this.Template6Button.MaximumSize = new System.Drawing.Size(259, 158);
			this.Template6Button.MinimumSize = new System.Drawing.Size(259, 158);
			this.Template6Button.Name = "Template6Button";
			this.Template6Button.Size = new System.Drawing.Size(259, 158);
			this.Template6Button.TabIndex = 6;
			this.Template6Button.UseVisualStyleBackColor = true;
			// 
			// CancelButton
			// 
			this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.CancelButton.Location = new System.Drawing.Point(692, 401);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(96, 28);
			this.CancelButton.TabIndex = 7;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// Template3Button
			// 
			this.Template3Button.Image = ((System.Drawing.Image)(resources.GetObject("Template3Button.Image")));
			this.Template3Button.Location = new System.Drawing.Point(545, 46);
			this.Template3Button.MaximumSize = new System.Drawing.Size(259, 158);
			this.Template3Button.MinimumSize = new System.Drawing.Size(259, 158);
			this.Template3Button.Name = "Template3Button";
			this.Template3Button.Size = new System.Drawing.Size(259, 158);
			this.Template3Button.TabIndex = 3;
			this.Template3Button.UseVisualStyleBackColor = true;
			// 
			// TemplatesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 450);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.Template6Button);
			this.Controls.Add(this.Template5Button);
			this.Controls.Add(this.Template4Button);
			this.Controls.Add(this.Template3Button);
			this.Controls.Add(this.Template2Button);
			this.Controls.Add(this.Template1Button);
			this.Controls.Add(this.TemplatesLabel);
			this.MaximumSize = new System.Drawing.Size(834, 488);
			this.MinimumSize = new System.Drawing.Size(834, 488);
			this.Name = "TemplatesForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Templates";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label TemplatesLabel;
		private System.Windows.Forms.Button Template1Button;
		private System.Windows.Forms.Button Template2Button;
		private System.Windows.Forms.Button Template4Button;
		private System.Windows.Forms.Button Template5Button;
		private System.Windows.Forms.Button Template6Button;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.Button Template3Button;
	}
}