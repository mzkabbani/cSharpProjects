/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/9/2012
 * Time: 4:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace XmlParsersAndUi.Forms.TpkBuilder
{
	partial class TaskAdditionForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskAdditionForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dgvTaskProperties = new System.Windows.Forms.DataGridView();
			this.propertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.propertyValue = new System.Windows.Forms.DataGridViewButtonColumn();
			this.propObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lblTaskName = new System.Windows.Forms.Label();
			this.btnCancelBuildTask = new System.Windows.Forms.Button();
			this.btnProceedBuildTask = new System.Windows.Forms.Button();
			this.propertyObject = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cmsAddCommonProp = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addCommonPropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtComment = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvTaskProperties)).BeginInit();
			this.cmsAddCommonProp.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.dgvTaskProperties);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(327, 255);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Properties";
			// 
			// dgvTaskProperties
			// 
			this.dgvTaskProperties.AllowUserToAddRows = false;
			this.dgvTaskProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvTaskProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvTaskProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.propertyName,
									this.propertyValue,
									this.propObject});
			this.dgvTaskProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvTaskProperties.Location = new System.Drawing.Point(3, 16);
			this.dgvTaskProperties.Name = "dgvTaskProperties";
			this.dgvTaskProperties.RowHeadersVisible = false;
			this.dgvTaskProperties.Size = new System.Drawing.Size(321, 236);
			this.dgvTaskProperties.TabIndex = 0;
			this.dgvTaskProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTaskPropertiesCellClick);
			// 
			// propertyName
			// 
			this.propertyName.HeaderText = "Name";
			this.propertyName.Name = "propertyName";
			// 
			// propertyValue
			// 
			this.propertyValue.HeaderText = "Value";
			this.propertyValue.Name = "propertyValue";
			this.propertyValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.propertyValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// propObject
			// 
			this.propObject.HeaderText = "propObject";
			this.propObject.Name = "propObject";
			this.propObject.Visible = false;
			// 
			// lblTaskName
			// 
			this.lblTaskName.BackColor = System.Drawing.SystemColors.ControlLight;
			this.lblTaskName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTaskName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblTaskName.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTaskName.Location = new System.Drawing.Point(0, 0);
			this.lblTaskName.Name = "lblTaskName";
			this.lblTaskName.Size = new System.Drawing.Size(351, 44);
			this.lblTaskName.TabIndex = 1;
			this.lblTaskName.Text = "Task Name";
			this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnCancelBuildTask
			// 
			this.btnCancelBuildTask.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancelBuildTask.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelBuildTask.Location = new System.Drawing.Point(97, 370);
			this.btnCancelBuildTask.Name = "btnCancelBuildTask";
			this.btnCancelBuildTask.Size = new System.Drawing.Size(75, 23);
			this.btnCancelBuildTask.TabIndex = 2;
			this.btnCancelBuildTask.Text = "Cancel";
			this.btnCancelBuildTask.UseVisualStyleBackColor = true;
			// 
			// btnProceedBuildTask
			// 
			this.btnProceedBuildTask.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnProceedBuildTask.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnProceedBuildTask.Location = new System.Drawing.Point(178, 370);
			this.btnProceedBuildTask.Name = "btnProceedBuildTask";
			this.btnProceedBuildTask.Size = new System.Drawing.Size(75, 23);
			this.btnProceedBuildTask.TabIndex = 3;
			this.btnProceedBuildTask.Text = "Proceed";
			this.btnProceedBuildTask.UseVisualStyleBackColor = true;
			this.btnProceedBuildTask.Click += new System.EventHandler(this.BtnProceedBuildTaskClick);
			// 
			// propertyObject
			// 
			this.propertyObject.HeaderText = "propertyObject";
			this.propertyObject.Name = "propertyObject";
			this.propertyObject.Visible = false;
			// 
			// cmsAddCommonProp
			// 
			this.cmsAddCommonProp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.addCommonPropertyToolStripMenuItem});
			this.cmsAddCommonProp.Name = "cmsAddCommonProp";
			this.cmsAddCommonProp.Size = new System.Drawing.Size(194, 48);
			// 
			// addCommonPropertyToolStripMenuItem
			// 
			this.addCommonPropertyToolStripMenuItem.Name = "addCommonPropertyToolStripMenuItem";
			this.addCommonPropertyToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.addCommonPropertyToolStripMenuItem.Text = "Add Common Property";
			this.addCommonPropertyToolStripMenuItem.Click += new System.EventHandler(this.AddCommonPropertyToolStripMenuItemClick);
			// 
			// txtComment
			// 
			this.txtComment.Location = new System.Drawing.Point(12, 58);
			this.txtComment.Multiline = true;
			this.txtComment.Name = "txtComment";
			this.txtComment.Size = new System.Drawing.Size(327, 48);
			this.txtComment.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 11);
			this.label1.TabIndex = 5;
			this.label1.Text = "Comment:";
			// 
			// TaskAdditionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(351, 405);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtComment);
			this.Controls.Add(this.btnProceedBuildTask);
			this.Controls.Add(this.btnCancelBuildTask);
			this.Controls.Add(this.lblTaskName);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(461, 599);
			this.Name = "TaskAdditionForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Task Properties";
			this.Load += new System.EventHandler(this.TaskAdditionFormLoad);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvTaskProperties)).EndInit();
			this.cmsAddCommonProp.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtComment;
		private System.Windows.Forms.ToolStripMenuItem addCommonPropertyToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip cmsAddCommonProp;
		private System.Windows.Forms.DataGridViewTextBoxColumn propObject;
		private System.Windows.Forms.DataGridViewButtonColumn propertyValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn propertyName;
		private System.Windows.Forms.DataGridViewTextBoxColumn propValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn propName;
		private System.Windows.Forms.DataGridViewTextBoxColumn propertyObject;
		private System.Windows.Forms.Button btnProceedBuildTask;
		private System.Windows.Forms.Button btnCancelBuildTask;
		private System.Windows.Forms.DataGridView dgvTaskProperties;
		private System.Windows.Forms.Label lblTaskName;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
