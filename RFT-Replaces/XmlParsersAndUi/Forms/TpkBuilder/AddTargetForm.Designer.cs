/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/23/2012
 * Time: 2:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Manifest.Forms.TpkBuilder
{
	partial class AddTargetForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTargetForm));
			this.txtTargetName = new System.Windows.Forms.TextBox();
			this.btnCancelNewTarget = new System.Windows.Forms.Button();
			this.btnProceedNewTarget = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtTargetName
			// 
			this.txtTargetName.Location = new System.Drawing.Point(12, 12);
			this.txtTargetName.Name = "txtTargetName";
			this.txtTargetName.Size = new System.Drawing.Size(266, 20);
			this.txtTargetName.TabIndex = 0;
			this.txtTargetName.Text = "NewTarget";
			// 
			// btnCancelNewTarget
			// 
			this.btnCancelNewTarget.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelNewTarget.Location = new System.Drawing.Point(67, 38);
			this.btnCancelNewTarget.Name = "btnCancelNewTarget";
			this.btnCancelNewTarget.Size = new System.Drawing.Size(75, 23);
			this.btnCancelNewTarget.TabIndex = 1;
			this.btnCancelNewTarget.Text = "Cancel";
			this.btnCancelNewTarget.UseVisualStyleBackColor = true;
			// 
			// btnProceedNewTarget
			// 
			this.btnProceedNewTarget.Location = new System.Drawing.Point(148, 38);
			this.btnProceedNewTarget.Name = "btnProceedNewTarget";
			this.btnProceedNewTarget.Size = new System.Drawing.Size(75, 23);
			this.btnProceedNewTarget.TabIndex = 2;
			this.btnProceedNewTarget.Text = "Proceed";
			this.btnProceedNewTarget.UseVisualStyleBackColor = true;
			this.btnProceedNewTarget.Click += new System.EventHandler(this.BtnProceedNewTargetClick);
			// 
			// AddTargetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(290, 68);
			this.Controls.Add(this.btnProceedNewTarget);
			this.Controls.Add(this.btnCancelNewTarget);
			this.Controls.Add(this.txtTargetName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddTargetForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "New Target";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btnProceedNewTarget;
		private System.Windows.Forms.Button btnCancelNewTarget;
		private System.Windows.Forms.TextBox txtTargetName;
	}
}
