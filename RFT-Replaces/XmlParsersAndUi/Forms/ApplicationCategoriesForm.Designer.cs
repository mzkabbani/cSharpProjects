/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/31/2012
 * Time: 4:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Manifest.Forms
{
	partial class ApplicationCategoriesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationCategoriesForm));
			this.btnSaveCategory = new System.Windows.Forms.Button();
			this.btnAddCategory = new System.Windows.Forms.Button();
			this.cboCategoryUsage = new System.Windows.Forms.ComboBox();
			this.lbAvailableCategories = new System.Windows.Forms.ListBox();
			this.btnRemoveCategory = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtCategoryType = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCategoryDesc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nudCategoryIndex = new System.Windows.Forms.NumericUpDown();
			this.txtCategoryName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudCategoryIndex)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSaveCategory
			// 
			this.btnSaveCategory.Location = new System.Drawing.Point(196, 230);
			this.btnSaveCategory.Name = "btnSaveCategory";
			this.btnSaveCategory.Size = new System.Drawing.Size(75, 23);
			this.btnSaveCategory.TabIndex = 0;
			this.btnSaveCategory.Text = "Save";
			this.btnSaveCategory.UseVisualStyleBackColor = true;
			// 
			// btnAddCategory
			// 
			this.btnAddCategory.Location = new System.Drawing.Point(277, 230);
			this.btnAddCategory.Name = "btnAddCategory";
			this.btnAddCategory.Size = new System.Drawing.Size(75, 23);
			this.btnAddCategory.TabIndex = 1;
			this.btnAddCategory.Text = "Add";
			this.btnAddCategory.UseVisualStyleBackColor = true;
			// 
			// cboCategoryUsage
			// 
			this.cboCategoryUsage.FormattingEnabled = true;
			this.cboCategoryUsage.Location = new System.Drawing.Point(6, 19);
			this.cboCategoryUsage.Name = "cboCategoryUsage";
			this.cboCategoryUsage.Size = new System.Drawing.Size(163, 21);
			this.cboCategoryUsage.TabIndex = 2;
			this.cboCategoryUsage.SelectedIndexChanged += new System.EventHandler(this.CboCategoryUsageSelectedIndexChanged);
			// 
			// lbAvailableCategories
			// 
			this.lbAvailableCategories.FormattingEnabled = true;
			this.lbAvailableCategories.Location = new System.Drawing.Point(6, 46);
			this.lbAvailableCategories.Name = "lbAvailableCategories";
			this.lbAvailableCategories.Size = new System.Drawing.Size(163, 186);
			this.lbAvailableCategories.TabIndex = 3;
			// 
			// btnRemoveCategory
			// 
			this.btnRemoveCategory.Location = new System.Drawing.Point(358, 230);
			this.btnRemoveCategory.Name = "btnRemoveCategory";
			this.btnRemoveCategory.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveCategory.TabIndex = 4;
			this.btnRemoveCategory.Text = "Remove";
			this.btnRemoveCategory.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbAvailableCategories);
			this.groupBox1.Controls.Add(this.cboCategoryUsage);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(175, 241);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Available Categories";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.txtCategoryType);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtCategoryDesc);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.nudCategoryIndex);
			this.groupBox2.Controls.Add(this.txtCategoryName);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(193, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(244, 212);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Category";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(4, 188);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Index:";
			// 
			// txtCategoryType
			// 
			this.txtCategoryType.Location = new System.Drawing.Point(54, 46);
			this.txtCategoryType.Name = "txtCategoryType";
			this.txtCategoryType.ReadOnly = true;
			this.txtCategoryType.Size = new System.Drawing.Size(184, 20);
			this.txtCategoryType.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(5, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "Type:";
			// 
			// txtCategoryDesc
			// 
			this.txtCategoryDesc.Location = new System.Drawing.Point(53, 72);
			this.txtCategoryDesc.Multiline = true;
			this.txtCategoryDesc.Name = "txtCategoryDesc";
			this.txtCategoryDesc.Size = new System.Drawing.Size(184, 108);
			this.txtCategoryDesc.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(5, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Desc.:";
			// 
			// nudCategoryIndex
			// 
			this.nudCategoryIndex.Location = new System.Drawing.Point(53, 186);
			this.nudCategoryIndex.Name = "nudCategoryIndex";
			this.nudCategoryIndex.Size = new System.Drawing.Size(55, 20);
			this.nudCategoryIndex.TabIndex = 2;
			// 
			// txtCategoryName
			// 
			this.txtCategoryName.Location = new System.Drawing.Point(54, 19);
			this.txtCategoryName.Name = "txtCategoryName";
			this.txtCategoryName.Size = new System.Drawing.Size(184, 20);
			this.txtCategoryName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			// 
			// ApplicationCategoriesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(449, 261);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnRemoveCategory);
			this.Controls.Add(this.btnAddCategory);
			this.Controls.Add(this.btnSaveCategory);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ApplicationCategoriesForm";
			this.Text = "Application Categories";
			this.Load += new System.EventHandler(this.ApplicationCategoriesFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudCategoryIndex)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCategoryType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCategoryDesc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtCategoryName;
		private System.Windows.Forms.NumericUpDown nudCategoryIndex;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnRemoveCategory;
		private System.Windows.Forms.ListBox lbAvailableCategories;
		private System.Windows.Forms.ComboBox cboCategoryUsage;
		private System.Windows.Forms.Button btnAddCategory;
		private System.Windows.Forms.Button btnSaveCategory;
	}
}
