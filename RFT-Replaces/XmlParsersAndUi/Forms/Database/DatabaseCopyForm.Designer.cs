/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 11/15/2012
 * Time: 3:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Manifest.Forms
{
	partial class DatabaseCopyForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtSourceDB = new Automation.Common.Controls.AutomationFileBrowserTextBox();
			this.txtDestinationDB = new Automation.Common.Controls.AutomationFileBrowserTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnStart = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtSourceDB
			// 
			this.txtSourceDB.AllowDrop = true;
			this.txtSourceDB.Location = new System.Drawing.Point(77, 23);
			this.txtSourceDB.Name = "txtSourceDB";
			this.txtSourceDB.Size = new System.Drawing.Size(315, 20);
			this.txtSourceDB.TabIndex = 0;
			// 
			// txtDestinationDB
			// 
			this.txtDestinationDB.AllowDrop = true;
			this.txtDestinationDB.Location = new System.Drawing.Point(77, 49);
			this.txtDestinationDB.Name = "txtDestinationDB";
			this.txtDestinationDB.Size = new System.Drawing.Size(315, 20);
			this.txtDestinationDB.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Source: ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Destination: ";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(181, 75);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 4;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.BtnStartClick);
			// 
			// DatabaseCopyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(472, 266);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtDestinationDB);
			this.Controls.Add(this.txtSourceDB);
			this.Name = "DatabaseCopyForm";
			this.Text = "DatabaseCopyForm";
			this.Load += new System.EventHandler(this.DatabaseCopyFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Automation.Common.Controls.AutomationFileBrowserTextBox txtDestinationDB;
		private Automation.Common.Controls.AutomationFileBrowserTextBox txtSourceDB;
	}
}
