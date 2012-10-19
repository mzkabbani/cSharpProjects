/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/17/2012
 * Time: 11:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace XmlParsersAndUi.Forms.TpkBuilder
{
	partial class ConfigFileTemplateForm
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
			this.txtConfigTemplate = new System.Windows.Forms.TextBox();
			this.btnCancelConfigFile = new System.Windows.Forms.Button();
			this.btnProceedConfigFile = new System.Windows.Forms.Button();
			this.txtConfigFilePath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtConfigTemplate
			// 
			this.txtConfigTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtConfigTemplate.Location = new System.Drawing.Point(12, 42);
			this.txtConfigTemplate.Multiline = true;
			this.txtConfigTemplate.Name = "txtConfigTemplate";
			this.txtConfigTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtConfigTemplate.Size = new System.Drawing.Size(553, 380);
			this.txtConfigTemplate.TabIndex = 0;
			// 
			// btnCancelConfigFile
			// 
			this.btnCancelConfigFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancelConfigFile.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelConfigFile.Location = new System.Drawing.Point(210, 428);
			this.btnCancelConfigFile.Name = "btnCancelConfigFile";
			this.btnCancelConfigFile.Size = new System.Drawing.Size(75, 23);
			this.btnCancelConfigFile.TabIndex = 1;
			this.btnCancelConfigFile.Text = "Cancel";
			this.btnCancelConfigFile.UseVisualStyleBackColor = true;
			// 
			// btnProceedConfigFile
			// 
			this.btnProceedConfigFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnProceedConfigFile.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnProceedConfigFile.Location = new System.Drawing.Point(291, 428);
			this.btnProceedConfigFile.Name = "btnProceedConfigFile";
			this.btnProceedConfigFile.Size = new System.Drawing.Size(75, 23);
			this.btnProceedConfigFile.TabIndex = 2;
			this.btnProceedConfigFile.Text = "Proceed";
			this.btnProceedConfigFile.UseVisualStyleBackColor = true;
			this.btnProceedConfigFile.Click += new System.EventHandler(this.BtnProceedConfigFileClick);
			// 
			// txtConfigFilePath
			// 
			this.txtConfigFilePath.Location = new System.Drawing.Point(55, 16);
			this.txtConfigFilePath.Name = "txtConfigFilePath";
			this.txtConfigFilePath.Size = new System.Drawing.Size(510, 20);
			this.txtConfigFilePath.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Path:";
			// 
			// ConfigFileTemplateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(577, 463);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtConfigFilePath);
			this.Controls.Add(this.btnProceedConfigFile);
			this.Controls.Add(this.btnCancelConfigFile);
			this.Controls.Add(this.txtConfigTemplate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ConfigFileTemplateForm";
			this.Text = "Config File Template";
			
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtConfigFilePath;
		private System.Windows.Forms.Button btnProceedConfigFile;
		private System.Windows.Forms.Button btnCancelConfigFile;
		private System.Windows.Forms.TextBox txtConfigTemplate;
	}
}
