/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/22/2012
 * Time: 10:08 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Manifest.Forms.TpkBuilder
{
	partial class AddCommonPropertyForm
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
			this.lbCommonProperties = new System.Windows.Forms.ListBox();
			this.btnCancelCommonProp = new System.Windows.Forms.Button();
			this.btnProceedComProp = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbCommonProperties
			// 
			this.lbCommonProperties.FormattingEnabled = true;
			this.lbCommonProperties.Location = new System.Drawing.Point(12, 12);
			this.lbCommonProperties.Name = "lbCommonProperties";
			this.lbCommonProperties.Size = new System.Drawing.Size(176, 212);
			this.lbCommonProperties.TabIndex = 0;
			// 
			// btnCancelCommonProp
			// 
			this.btnCancelCommonProp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelCommonProp.Location = new System.Drawing.Point(22, 231);
			this.btnCancelCommonProp.Name = "btnCancelCommonProp";
			this.btnCancelCommonProp.Size = new System.Drawing.Size(75, 23);
			this.btnCancelCommonProp.TabIndex = 1;
			this.btnCancelCommonProp.Text = "Cancel";
			this.btnCancelCommonProp.UseVisualStyleBackColor = true;
			// 
			// btnProceedComProp
			// 
			this.btnProceedComProp.Location = new System.Drawing.Point(103, 231);
			this.btnProceedComProp.Name = "btnProceedComProp";
			this.btnProceedComProp.Size = new System.Drawing.Size(75, 23);
			this.btnProceedComProp.TabIndex = 2;
			this.btnProceedComProp.Text = "Proceed";
			this.btnProceedComProp.UseVisualStyleBackColor = true;
			this.btnProceedComProp.Click += new System.EventHandler(this.BtnProceedComPropClick);
			// 
			// AddCommonPropertyForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(200, 266);
			this.Controls.Add(this.btnProceedComProp);
			this.Controls.Add(this.btnCancelCommonProp);
			this.Controls.Add(this.lbCommonProperties);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AddCommonPropertyForm";
			this.Text = "Common Properties";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnProceedComProp;
		private System.Windows.Forms.Button btnCancelCommonProp;
		private System.Windows.Forms.ListBox lbCommonProperties;
	}
}
