namespace FastExcelExportingDemoCs
{
	partial class MainForm
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.Button startDemoButton;
			this.demoResultListBox = new System.Windows.Forms.ListBox();
			startDemoButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// startDemoButton
			// 
			startDemoButton.Location = new System.Drawing.Point(12, 12);
			startDemoButton.Name = "startDemoButton";
			startDemoButton.Size = new System.Drawing.Size(422, 23);
			startDemoButton.TabIndex = 1;
			startDemoButton.Text = "Start DEMO";
			startDemoButton.UseVisualStyleBackColor = true;
			startDemoButton.Click += new System.EventHandler(this.startDemoButton_Click);
			// 
			// demoResultListBox
			// 
			this.demoResultListBox.FormattingEnabled = true;
			this.demoResultListBox.Location = new System.Drawing.Point(12, 41);
			this.demoResultListBox.Name = "demoResultListBox";
			this.demoResultListBox.Size = new System.Drawing.Size(422, 251);
			this.demoResultListBox.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 303);
			this.Controls.Add(this.demoResultListBox);
			this.Controls.Add(startDemoButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "FastExcelExport DEMO C#";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox demoResultListBox;
	}
}

