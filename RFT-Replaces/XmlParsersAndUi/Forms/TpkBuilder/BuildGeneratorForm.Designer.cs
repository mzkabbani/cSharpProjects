/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/9/2012
 * Time: 3:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace XmlParsersAndUi.Forms.TpkBuilder
{
	partial class BuildGeneratorForm
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
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("automation.comparisonguixml");
			System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("automation.sqloperations");
			System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Task 1");
			System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Task 2");
			System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Task 3");
			System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Task 4");
			System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Sequence 1", new System.Windows.Forms.TreeNode[] {
									treeNode24,
									treeNode25});
			System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Task 5");
			System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Test-Main", new System.Windows.Forms.TreeNode[] {
									treeNode22,
									treeNode23,
									treeNode26,
									treeNode27});
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lvAvailableTasks = new System.Windows.Forms.ListView();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.wbTaskDetails = new System.Windows.Forms.WebBrowser();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.btnAddTask = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lvAvailableTasks);
			this.groupBox1.Location = new System.Drawing.Point(6, 19);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(178, 358);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Available Tasks";
			// 
			// lvAvailableTasks
			// 
			this.lvAvailableTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			listViewItem7.Tag = "http://globalqa/qa/infrastructure/doc/runtime/v2.3/AutoAntTasks/AutoAntComparison" +
			"GuiXml.html";
			listViewItem8.Tag = "http://globalqa/qa/infrastructure/doc/runtime/v2.3/AutoAntTasks/AutoAntSqlOperati" +
			"ons.html";
			this.lvAvailableTasks.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
									listViewItem7,
									listViewItem8});
			this.lvAvailableTasks.Location = new System.Drawing.Point(3, 16);
			this.lvAvailableTasks.Name = "lvAvailableTasks";
			this.lvAvailableTasks.Size = new System.Drawing.Size(172, 336);
			this.lvAvailableTasks.TabIndex = 0;
			this.lvAvailableTasks.UseCompatibleStateImageBehavior = false;
			this.lvAvailableTasks.View = System.Windows.Forms.View.List;
			this.lvAvailableTasks.SelectedIndexChanged += new System.EventHandler(this.LvAvailableTasksSelectedIndexChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.btnAddTask);
			this.groupBox3.Controls.Add(this.wbTaskDetails);
			this.groupBox3.Location = new System.Drawing.Point(190, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(508, 358);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Details";
			// 
			// wbTaskDetails
			// 
			this.wbTaskDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.wbTaskDetails.Location = new System.Drawing.Point(3, 16);
			this.wbTaskDetails.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbTaskDetails.Name = "wbTaskDetails";
			this.wbTaskDetails.Size = new System.Drawing.Size(499, 307);
			this.wbTaskDetails.TabIndex = 1;
			// 
			// groupBox4
			// 
			this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox4.Controls.Add(this.groupBox1);
			this.groupBox4.Controls.Add(this.groupBox3);
			this.groupBox4.Location = new System.Drawing.Point(12, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(704, 383);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Tasks";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabControl1.Location = new System.Drawing.Point(12, 401);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(704, 216);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(696, 190);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Build Text";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(6, 6);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(682, 176);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "<project default=\"run\">\r\n<target name=\"run\">\r\n</target>\r\n</project>";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.treeView1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(710, 165);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Build Sequence";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(3, 3);
			this.treeView1.Name = "treeView1";
			treeNode22.Name = "Node1";
			treeNode22.Text = "Task 1";
			treeNode23.Name = "Node2";
			treeNode23.Text = "Task 2";
			treeNode24.Name = "Node6";
			treeNode24.Text = "Task 3";
			treeNode25.Name = "Node7";
			treeNode25.Text = "Task 4";
			treeNode26.Name = "Node3";
			treeNode26.Text = "Sequence 1";
			treeNode27.Name = "Node4";
			treeNode27.Text = "Task 5";
			treeNode28.Name = "Node0";
			treeNode28.Text = "Test-Main";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
									treeNode28});
			this.treeView1.Size = new System.Drawing.Size(704, 159);
			this.treeView1.TabIndex = 0;
			// 
			// btnAddTask
			// 
			this.btnAddTask.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnAddTask.Location = new System.Drawing.Point(217, 329);
			this.btnAddTask.Name = "btnAddTask";
			this.btnAddTask.Size = new System.Drawing.Size(75, 23);
			this.btnAddTask.TabIndex = 5;
			this.btnAddTask.Text = "Add";
			this.btnAddTask.UseVisualStyleBackColor = true;
			this.btnAddTask.Click += new System.EventHandler(this.BtnAddTaskClick);
			// 
			// BuildGeneratorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(726, 629);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox4);
			this.Name = "BuildGeneratorForm";
			this.Text = "BuildGeneratorForm";
			this.Load += new System.EventHandler(this.BuildGeneratorFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnAddTask;
		private System.Windows.Forms.WebBrowser wbTaskDetails;
		private System.Windows.Forms.ListView lvAvailableTasks;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
