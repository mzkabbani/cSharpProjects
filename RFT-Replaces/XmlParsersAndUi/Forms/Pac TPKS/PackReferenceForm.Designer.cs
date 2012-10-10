/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/9/2012
 * Time: 6:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace XmlParsersAndUi.Forms.Pac_TPKS
{
	partial class PackReferenceForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtInputTes = new System.Windows.Forms.TextBox();
			this.btnGetResults = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.dgvResults = new System.Windows.Forms.DataGridView();
			this.btnInsertToDB = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtInputTes);
			this.groupBox1.Controls.Add(this.btnGetResults);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(611, 76);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Tests";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Test Executions: ";
			// 
			// txtInputTes
			// 
			this.txtInputTes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.txtInputTes.Location = new System.Drawing.Point(103, 19);
			this.txtInputTes.Name = "txtInputTes";
			this.txtInputTes.Size = new System.Drawing.Size(502, 20);
			this.txtInputTes.TabIndex = 1;
			// 
			// btnGetResults
			// 
			this.btnGetResults.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnGetResults.Location = new System.Drawing.Point(245, 45);
			this.btnGetResults.Name = "btnGetResults";
			this.btnGetResults.Size = new System.Drawing.Size(121, 23);
			this.btnGetResults.TabIndex = 0;
			this.btnGetResults.Text = "Get Results";
			this.btnGetResults.UseVisualStyleBackColor = true;
			this.btnGetResults.Click += new System.EventHandler(this.BtnGetResultsClick);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.dgvResults);
			this.groupBox2.Location = new System.Drawing.Point(12, 94);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(611, 267);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Results";
			// 
			// dgvResults
			// 
			this.dgvResults.AllowUserToAddRows = false;
			this.dgvResults.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.dgvResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvResults.Location = new System.Drawing.Point(3, 16);
			this.dgvResults.Name = "dgvResults";
			this.dgvResults.RowHeadersVisible = false;
			this.dgvResults.Size = new System.Drawing.Size(605, 248);
			this.dgvResults.TabIndex = 0;
			// 
			// btnInsertToDB
			// 
			this.btnInsertToDB.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnInsertToDB.Location = new System.Drawing.Point(320, 367);
			this.btnInsertToDB.Name = "btnInsertToDB";
			this.btnInsertToDB.Size = new System.Drawing.Size(121, 23);
			this.btnInsertToDB.TabIndex = 1;
			this.btnInsertToDB.Text = "Proceed";
			this.btnInsertToDB.UseVisualStyleBackColor = true;
			// 
			// btnReset
			// 
			this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnReset.Location = new System.Drawing.Point(193, 367);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(121, 23);
			this.btnReset.TabIndex = 3;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
			// 
			// PackReferenceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(635, 402);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnInsertToDB);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "PackReferenceForm";
			this.Text = "PackReferenceForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.DataGridView dgvResults;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtInputTes;
		private System.Windows.Forms.Button btnInsertToDB;
		private System.Windows.Forms.Button btnGetResults;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
