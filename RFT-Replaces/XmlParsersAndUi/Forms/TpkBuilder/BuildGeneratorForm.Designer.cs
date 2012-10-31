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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildGeneratorForm));
			this.gbAvailableTasks = new System.Windows.Forms.GroupBox();
			this.lvAvailableTasks = new System.Windows.Forms.ListView();
			this.gbDetails = new System.Windows.Forms.GroupBox();
			this.srcTaskRating = new RatingControls.StarRatingControl();
			this.btnAddTask = new System.Windows.Forms.Button();
			this.wbTaskDetails = new System.Windows.Forms.WebBrowser();
			this.gpTasks = new System.Windows.Forms.GroupBox();
			this.scAvailTaskDetailsSplitter = new System.Windows.Forms.SplitContainer();
			this.tcResults = new System.Windows.Forms.TabControl();
			this.tpBuildSequence = new System.Windows.Forms.TabPage();
			this.tvBuildSequence = new System.Windows.Forms.TreeView();
			this.tpBuildTasks = new System.Windows.Forms.TabPage();
			this.dgvBuildTasks = new System.Windows.Forms.DataGridView();
			this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.task = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tpBuildText = new System.Windows.Forms.TabPage();
			this.txtEditorBText = new ICSharpCode.TextEditor.TextEditorControl();
			this.scInputResultHSplit = new System.Windows.Forms.SplitContainer();
			this.msBuildGen = new System.Windows.Forms.MenuStrip();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.targetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.macrodefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbAvailableTasks.SuspendLayout();
			this.gbDetails.SuspendLayout();
			this.gpTasks.SuspendLayout();
			this.scAvailTaskDetailsSplitter.Panel1.SuspendLayout();
			this.scAvailTaskDetailsSplitter.Panel2.SuspendLayout();
			this.scAvailTaskDetailsSplitter.SuspendLayout();
			this.tcResults.SuspendLayout();
			this.tpBuildSequence.SuspendLayout();
			this.tpBuildTasks.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBuildTasks)).BeginInit();
			this.tpBuildText.SuspendLayout();
			this.scInputResultHSplit.Panel1.SuspendLayout();
			this.scInputResultHSplit.Panel2.SuspendLayout();
			this.scInputResultHSplit.SuspendLayout();
			this.msBuildGen.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbAvailableTasks
			// 
			this.gbAvailableTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.gbAvailableTasks.Controls.Add(this.lvAvailableTasks);
			this.gbAvailableTasks.Location = new System.Drawing.Point(3, 0);
			this.gbAvailableTasks.Name = "gbAvailableTasks";
			this.gbAvailableTasks.Size = new System.Drawing.Size(181, 300);
			this.gbAvailableTasks.TabIndex = 0;
			this.gbAvailableTasks.TabStop = false;
			this.gbAvailableTasks.Text = "Available Tasks";
			// 
			// lvAvailableTasks
			// 
			this.lvAvailableTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvAvailableTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvAvailableTasks.Location = new System.Drawing.Point(3, 16);
			this.lvAvailableTasks.Name = "lvAvailableTasks";
			this.lvAvailableTasks.Size = new System.Drawing.Size(175, 281);
			this.lvAvailableTasks.TabIndex = 0;
			this.lvAvailableTasks.UseCompatibleStateImageBehavior = false;
			this.lvAvailableTasks.View = System.Windows.Forms.View.List;
			this.lvAvailableTasks.SelectedIndexChanged += new System.EventHandler(this.LvAvailableTasksSelectedIndexChanged);
			// 
			// gbDetails
			// 
			this.gbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.gbDetails.Controls.Add(this.srcTaskRating);
			this.gbDetails.Controls.Add(this.btnAddTask);
			this.gbDetails.Controls.Add(this.wbTaskDetails);
			this.gbDetails.Location = new System.Drawing.Point(0, 0);
			this.gbDetails.Name = "gbDetails";
			this.gbDetails.Size = new System.Drawing.Size(500, 300);
			this.gbDetails.TabIndex = 2;
			this.gbDetails.TabStop = false;
			this.gbDetails.Text = "Details";
			// 
			// srcTaskRating
			// 
			this.srcTaskRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.srcTaskRating.BottomMargin = 2;
			this.srcTaskRating.Enabled = false;
			this.srcTaskRating.HoverColor = System.Drawing.Color.Gold;
			this.srcTaskRating.LeftMargin = 2;
			this.srcTaskRating.Location = new System.Drawing.Point(374, 19);
			this.srcTaskRating.Name = "srcTaskRating";
			this.srcTaskRating.OutlineColor = System.Drawing.Color.Black;
			this.srcTaskRating.OutlineThickness = 1;
			this.srcTaskRating.RightMargin = 2;
			this.srcTaskRating.SelectedColor = System.Drawing.Color.RoyalBlue;
			this.srcTaskRating.Size = new System.Drawing.Size(120, 18);
			this.srcTaskRating.StarCount = 5;
			this.srcTaskRating.StarSpacing = 8;
			this.srcTaskRating.TabIndex = 6;
			this.srcTaskRating.TabStop = false;
			this.srcTaskRating.TopMargin = 2;
			// 
			// btnAddTask
			// 
			this.btnAddTask.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAddTask.Location = new System.Drawing.Point(213, 271);
			this.btnAddTask.Name = "btnAddTask";
			this.btnAddTask.Size = new System.Drawing.Size(75, 23);
			this.btnAddTask.TabIndex = 5;
			this.btnAddTask.Text = "Add";
			this.btnAddTask.UseVisualStyleBackColor = true;
			this.btnAddTask.Click += new System.EventHandler(this.BtnAddTaskClick);
			// 
			// wbTaskDetails
			// 
			this.wbTaskDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.wbTaskDetails.Location = new System.Drawing.Point(6, 43);
			this.wbTaskDetails.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbTaskDetails.Name = "wbTaskDetails";
			this.wbTaskDetails.Size = new System.Drawing.Size(488, 222);
			this.wbTaskDetails.TabIndex = 1;
			// 
			// gpTasks
			// 
			this.gpTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.gpTasks.Controls.Add(this.scAvailTaskDetailsSplitter);
			this.gpTasks.Location = new System.Drawing.Point(12, 30);
			this.gpTasks.Name = "gpTasks";
			this.gpTasks.Size = new System.Drawing.Size(702, 322);
			this.gpTasks.TabIndex = 5;
			this.gpTasks.TabStop = false;
			this.gpTasks.Text = "Tasks";
			// 
			// scAvailTaskDetailsSplitter
			// 
			this.scAvailTaskDetailsSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scAvailTaskDetailsSplitter.Location = new System.Drawing.Point(3, 16);
			this.scAvailTaskDetailsSplitter.Name = "scAvailTaskDetailsSplitter";
			// 
			// scAvailTaskDetailsSplitter.Panel1
			// 
			this.scAvailTaskDetailsSplitter.Panel1.Controls.Add(this.gbAvailableTasks);
			// 
			// scAvailTaskDetailsSplitter.Panel2
			// 
			this.scAvailTaskDetailsSplitter.Panel2.Controls.Add(this.gbDetails);
			this.scAvailTaskDetailsSplitter.Size = new System.Drawing.Size(696, 303);
			this.scAvailTaskDetailsSplitter.SplitterDistance = 192;
			this.scAvailTaskDetailsSplitter.TabIndex = 3;
			// 
			// tcResults
			// 
			this.tcResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tcResults.Controls.Add(this.tpBuildSequence);
			this.tcResults.Controls.Add(this.tpBuildTasks);
			this.tcResults.Controls.Add(this.tpBuildText);
			this.tcResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tcResults.Location = new System.Drawing.Point(12, 3);
			this.tcResults.Name = "tcResults";
			this.tcResults.SelectedIndex = 0;
			this.tcResults.Size = new System.Drawing.Size(702, 255);
			this.tcResults.TabIndex = 6;
			// 
			// tpBuildSequence
			// 
			this.tpBuildSequence.Controls.Add(this.tvBuildSequence);
			this.tpBuildSequence.Location = new System.Drawing.Point(4, 22);
			this.tpBuildSequence.Name = "tpBuildSequence";
			this.tpBuildSequence.Padding = new System.Windows.Forms.Padding(3);
			this.tpBuildSequence.Size = new System.Drawing.Size(694, 229);
			this.tpBuildSequence.TabIndex = 1;
			this.tpBuildSequence.Text = "Build Sequence";
			this.tpBuildSequence.UseVisualStyleBackColor = true;
			// 
			// tvBuildSequence
			// 
			this.tvBuildSequence.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvBuildSequence.Location = new System.Drawing.Point(3, 3);
			this.tvBuildSequence.Name = "tvBuildSequence";
			this.tvBuildSequence.Size = new System.Drawing.Size(688, 223);
			this.tvBuildSequence.TabIndex = 0;
			// 
			// tpBuildTasks
			// 
			this.tpBuildTasks.Controls.Add(this.dgvBuildTasks);
			this.tpBuildTasks.Location = new System.Drawing.Point(4, 22);
			this.tpBuildTasks.Name = "tpBuildTasks";
			this.tpBuildTasks.Size = new System.Drawing.Size(694, 229);
			this.tpBuildTasks.TabIndex = 2;
			this.tpBuildTasks.Text = "Build Tasks";
			this.tpBuildTasks.UseVisualStyleBackColor = true;
			// 
			// dgvBuildTasks
			// 
			this.dgvBuildTasks.AllowUserToAddRows = false;
			this.dgvBuildTasks.AllowUserToDeleteRows = false;
			this.dgvBuildTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvBuildTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBuildTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.index,
									this.task,
									this.id});
			this.dgvBuildTasks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvBuildTasks.Location = new System.Drawing.Point(0, 0);
			this.dgvBuildTasks.MultiSelect = false;
			this.dgvBuildTasks.Name = "dgvBuildTasks";
			this.dgvBuildTasks.RowHeadersVisible = false;
			this.dgvBuildTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvBuildTasks.Size = new System.Drawing.Size(694, 229);
			this.dgvBuildTasks.TabIndex = 0;
			// 
			// index
			// 
			this.index.FillWeight = 20.30457F;
			this.index.HeaderText = "Index";
			this.index.Name = "index";
			// 
			// task
			// 
			this.task.FillWeight = 179.6954F;
			this.task.HeaderText = "Task";
			this.task.Name = "task";
			// 
			// id
			// 
			this.id.HeaderText = "id";
			this.id.Name = "id";
			this.id.Visible = false;
			// 
			// tpBuildText
			// 
			this.tpBuildText.Controls.Add(this.txtEditorBText);
			this.tpBuildText.Location = new System.Drawing.Point(4, 22);
			this.tpBuildText.Name = "tpBuildText";
			this.tpBuildText.Size = new System.Drawing.Size(694, 229);
			this.tpBuildText.TabIndex = 3;
			this.tpBuildText.Text = "Build Text";
			// 
			// txtEditorBText
			// 
			this.txtEditorBText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtEditorBText.IsReadOnly = false;
			this.txtEditorBText.Location = new System.Drawing.Point(0, 0);
			this.txtEditorBText.Name = "txtEditorBText";
			this.txtEditorBText.Size = new System.Drawing.Size(694, 229);
			this.txtEditorBText.TabIndex = 0;
			// 
			// scInputResultHSplit
			// 
			this.scInputResultHSplit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scInputResultHSplit.Location = new System.Drawing.Point(0, 0);
			this.scInputResultHSplit.Name = "scInputResultHSplit";
			this.scInputResultHSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scInputResultHSplit.Panel1
			// 
			this.scInputResultHSplit.Panel1.Controls.Add(this.gpTasks);
			this.scInputResultHSplit.Panel1.Controls.Add(this.msBuildGen);
			// 
			// scInputResultHSplit.Panel2
			// 
			this.scInputResultHSplit.Panel2.Controls.Add(this.tcResults);
			this.scInputResultHSplit.Size = new System.Drawing.Size(726, 629);
			this.scInputResultHSplit.SplitterDistance = 355;
			this.scInputResultHSplit.TabIndex = 7;
			// 
			// msBuildGen
			// 
			this.msBuildGen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.addToolStripMenuItem});
			this.msBuildGen.Location = new System.Drawing.Point(0, 0);
			this.msBuildGen.Name = "msBuildGen";
			this.msBuildGen.Size = new System.Drawing.Size(726, 24);
			this.msBuildGen.TabIndex = 6;
			this.msBuildGen.Text = "menuStrip1";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.targetToolStripMenuItem,
									this.macrodefToolStripMenuItem});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.addToolStripMenuItem.Text = "Insert";
			// 
			// targetToolStripMenuItem
			// 
			this.targetToolStripMenuItem.Name = "targetToolStripMenuItem";
			this.targetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.targetToolStripMenuItem.Text = "Target";
			this.targetToolStripMenuItem.Click += new System.EventHandler(this.TargetToolStripMenuItemClick);
			// 
			// macrodefToolStripMenuItem
			// 
			this.macrodefToolStripMenuItem.Name = "macrodefToolStripMenuItem";
			this.macrodefToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.macrodefToolStripMenuItem.Text = "Macrodef";
			this.macrodefToolStripMenuItem.Click += new System.EventHandler(this.MacrodefToolStripMenuItemClick);
			// 
			// BuildGeneratorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(726, 629);
			this.Controls.Add(this.scInputResultHSplit);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.msBuildGen;
			this.Name = "BuildGeneratorForm";
			this.Text = "Build Generator";
			this.Load += new System.EventHandler(this.BuildGeneratorFormLoad);
			this.gbAvailableTasks.ResumeLayout(false);
			this.gbDetails.ResumeLayout(false);
			this.gpTasks.ResumeLayout(false);
			this.scAvailTaskDetailsSplitter.Panel1.ResumeLayout(false);
			this.scAvailTaskDetailsSplitter.Panel2.ResumeLayout(false);
			this.scAvailTaskDetailsSplitter.ResumeLayout(false);
			this.tcResults.ResumeLayout(false);
			this.tpBuildSequence.ResumeLayout(false);
			this.tpBuildTasks.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvBuildTasks)).EndInit();
			this.tpBuildText.ResumeLayout(false);
			this.scInputResultHSplit.Panel1.ResumeLayout(false);
			this.scInputResultHSplit.Panel1.PerformLayout();
			this.scInputResultHSplit.Panel2.ResumeLayout(false);
			this.scInputResultHSplit.ResumeLayout(false);
			this.msBuildGen.ResumeLayout(false);
			this.msBuildGen.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripMenuItem macrodefToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem targetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.MenuStrip msBuildGen;
		private ICSharpCode.TextEditor.TextEditorControl txtEditorBText;
		private System.Windows.Forms.SplitContainer scInputResultHSplit;
		private System.Windows.Forms.SplitContainer scAvailTaskDetailsSplitter;
		private RatingControls.StarRatingControl srcTaskRating;
		private System.Windows.Forms.DataGridViewTextBoxColumn id;
		
		private System.Windows.Forms.DataGridViewTextBoxColumn task;
		private System.Windows.Forms.DataGridViewTextBoxColumn index;
		private System.Windows.Forms.DataGridView dgvBuildTasks;
		private System.Windows.Forms.TabPage tpBuildTasks;
		private System.Windows.Forms.TreeView tvBuildSequence;
		private System.Windows.Forms.TabPage tpBuildSequence;
		private System.Windows.Forms.TabPage tpBuildText;
		private System.Windows.Forms.TabControl tcResults;
		private System.Windows.Forms.GroupBox gpTasks;
		private System.Windows.Forms.Button btnAddTask;
		private System.Windows.Forms.WebBrowser wbTaskDetails;
		private System.Windows.Forms.ListView lvAvailableTasks;
		private System.Windows.Forms.GroupBox gbDetails;
		private System.Windows.Forms.GroupBox gbAvailableTasks;
	}
}
