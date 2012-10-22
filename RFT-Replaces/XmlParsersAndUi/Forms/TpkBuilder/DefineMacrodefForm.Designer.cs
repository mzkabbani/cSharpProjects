/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/22/2012
 * Time: 11:04 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Manifest.Forms.TpkBuilder
{
	partial class DefineMacrodefForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefineMacrodefForm));
			this.btnAddAttribute = new System.Windows.Forms.Button();
			this.lbMacrodefAttributes = new System.Windows.Forms.ListBox();
			this.gbMacrodef = new System.Windows.Forms.GroupBox();
			this.cbParallel = new System.Windows.Forms.CheckBox();
			this.btnCancelMacrodef = new System.Windows.Forms.Button();
			this.btnProceedMacrodef = new System.Windows.Forms.Button();
			this.gbAttributes = new System.Windows.Forms.GroupBox();
			this.cbIsMandatory = new System.Windows.Forms.CheckBox();
			this.btnRemoveAttribute = new System.Windows.Forms.Button();
			this.txtMacrodefAttrDefValue = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMacrodefAttribName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMacrodefName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.gbMacrodef.SuspendLayout();
			this.gbAttributes.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAddAttribute
			// 
			this.btnAddAttribute.Location = new System.Drawing.Point(140, 80);
			this.btnAddAttribute.Name = "btnAddAttribute";
			this.btnAddAttribute.Size = new System.Drawing.Size(60, 23);
			this.btnAddAttribute.TabIndex = 0;
			this.btnAddAttribute.Text = "Add";
			this.btnAddAttribute.UseVisualStyleBackColor = true;
			this.btnAddAttribute.Click += new System.EventHandler(this.BtnAddAttributeClick);
			// 
			// lbMacrodefAttributes
			// 
			this.lbMacrodefAttributes.FormattingEnabled = true;
			this.lbMacrodefAttributes.Location = new System.Drawing.Point(6, 109);
			this.lbMacrodefAttributes.Name = "lbMacrodefAttributes";
			this.lbMacrodefAttributes.Size = new System.Drawing.Size(263, 173);
			this.lbMacrodefAttributes.TabIndex = 3;
			// 
			// gbMacrodef
			// 
			this.gbMacrodef.Controls.Add(this.cbParallel);
			this.gbMacrodef.Controls.Add(this.btnCancelMacrodef);
			this.gbMacrodef.Controls.Add(this.btnProceedMacrodef);
			this.gbMacrodef.Controls.Add(this.gbAttributes);
			this.gbMacrodef.Controls.Add(this.txtMacrodefName);
			this.gbMacrodef.Controls.Add(this.label1);
			this.gbMacrodef.Location = new System.Drawing.Point(12, 12);
			this.gbMacrodef.Name = "gbMacrodef";
			this.gbMacrodef.Size = new System.Drawing.Size(287, 383);
			this.gbMacrodef.TabIndex = 4;
			this.gbMacrodef.TabStop = false;
			this.gbMacrodef.Text = "Macrodef";
			// 
			// cbParallel
			// 
			this.cbParallel.Location = new System.Drawing.Point(53, 39);
			this.cbParallel.Name = "cbParallel";
			this.cbParallel.Size = new System.Drawing.Size(138, 15);
			this.cbParallel.TabIndex = 11;
			this.cbParallel.Text = "Parallel Execution";
			this.cbParallel.UseVisualStyleBackColor = true;
			// 
			// btnCancelMacrodef
			// 
			this.btnCancelMacrodef.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelMacrodef.Location = new System.Drawing.Point(20, 354);
			this.btnCancelMacrodef.Name = "btnCancelMacrodef";
			this.btnCancelMacrodef.Size = new System.Drawing.Size(120, 23);
			this.btnCancelMacrodef.TabIndex = 10;
			this.btnCancelMacrodef.Text = "Cancel";
			this.btnCancelMacrodef.UseVisualStyleBackColor = true;
			this.btnCancelMacrodef.Click += new System.EventHandler(this.BtnCancelMacrodefClick);
			// 
			// btnProceedMacrodef
			// 
			this.btnProceedMacrodef.Location = new System.Drawing.Point(146, 354);
			this.btnProceedMacrodef.Name = "btnProceedMacrodef";
			this.btnProceedMacrodef.Size = new System.Drawing.Size(120, 23);
			this.btnProceedMacrodef.TabIndex = 9;
			this.btnProceedMacrodef.Text = "Proceed";
			this.btnProceedMacrodef.UseVisualStyleBackColor = true;
			this.btnProceedMacrodef.Click += new System.EventHandler(this.BtnProceedMacrodefClick);
			// 
			// gbAttributes
			// 
			this.gbAttributes.Controls.Add(this.cbIsMandatory);
			this.gbAttributes.Controls.Add(this.btnRemoveAttribute);
			this.gbAttributes.Controls.Add(this.txtMacrodefAttrDefValue);
			this.gbAttributes.Controls.Add(this.label3);
			this.gbAttributes.Controls.Add(this.txtMacrodefAttribName);
			this.gbAttributes.Controls.Add(this.label2);
			this.gbAttributes.Controls.Add(this.lbMacrodefAttributes);
			this.gbAttributes.Controls.Add(this.btnAddAttribute);
			this.gbAttributes.Location = new System.Drawing.Point(6, 60);
			this.gbAttributes.Name = "gbAttributes";
			this.gbAttributes.Size = new System.Drawing.Size(275, 288);
			this.gbAttributes.TabIndex = 3;
			this.gbAttributes.TabStop = false;
			this.gbAttributes.Text = "Attributes";
			// 
			// cbIsMandatory
			// 
			this.cbIsMandatory.Checked = true;
			this.cbIsMandatory.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbIsMandatory.Location = new System.Drawing.Point(84, 59);
			this.cbIsMandatory.Name = "cbIsMandatory";
			this.cbIsMandatory.Size = new System.Drawing.Size(138, 17);
			this.cbIsMandatory.TabIndex = 12;
			this.cbIsMandatory.Text = "Mandatory";
			this.cbIsMandatory.UseVisualStyleBackColor = true;
			// 
			// btnRemoveAttribute
			// 
			this.btnRemoveAttribute.Location = new System.Drawing.Point(74, 80);
			this.btnRemoveAttribute.Name = "btnRemoveAttribute";
			this.btnRemoveAttribute.Size = new System.Drawing.Size(60, 23);
			this.btnRemoveAttribute.TabIndex = 8;
			this.btnRemoveAttribute.Text = "Remove";
			this.btnRemoveAttribute.UseVisualStyleBackColor = true;
			this.btnRemoveAttribute.Click += new System.EventHandler(this.BtnRemoveAttributeClick);
			// 
			// txtMacrodefAttrDefValue
			// 
			this.txtMacrodefAttrDefValue.Location = new System.Drawing.Point(84, 36);
			this.txtMacrodefAttrDefValue.Name = "txtMacrodefAttrDefValue";
			this.txtMacrodefAttrDefValue.Size = new System.Drawing.Size(185, 20);
			this.txtMacrodefAttrDefValue.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(3, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Default Value:";
			// 
			// txtMacrodefAttribName
			// 
			this.txtMacrodefAttribName.Location = new System.Drawing.Point(84, 13);
			this.txtMacrodefAttribName.Name = "txtMacrodefAttribName";
			this.txtMacrodefAttribName.Size = new System.Drawing.Size(185, 20);
			this.txtMacrodefAttribName.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Attr. Name:";
			// 
			// txtMacrodefName
			// 
			this.txtMacrodefName.Location = new System.Drawing.Point(53, 13);
			this.txtMacrodefName.Name = "txtMacrodefName";
			this.txtMacrodefName.Size = new System.Drawing.Size(219, 20);
			this.txtMacrodefName.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name:";
			// 
			// DefineMacrodefForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(310, 407);
			this.Controls.Add(this.gbMacrodef);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "DefineMacrodefForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Macrodef Definition";
			this.TopMost = true;
			this.gbMacrodef.ResumeLayout(false);
			this.gbMacrodef.PerformLayout();
			this.gbAttributes.ResumeLayout(false);
			this.gbAttributes.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox cbIsMandatory;
		private System.Windows.Forms.CheckBox cbParallel;
		private System.Windows.Forms.Button btnProceedMacrodef;
		private System.Windows.Forms.Button btnCancelMacrodef;
		private System.Windows.Forms.Button btnRemoveAttribute;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMacrodefAttribName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtMacrodefAttrDefValue;
		private System.Windows.Forms.GroupBox gbAttributes;
		private System.Windows.Forms.GroupBox gbMacrodef;
		private System.Windows.Forms.ListBox lbMacrodefAttributes;
		private System.Windows.Forms.TextBox txtMacrodefName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAddAttribute;
	}
}
