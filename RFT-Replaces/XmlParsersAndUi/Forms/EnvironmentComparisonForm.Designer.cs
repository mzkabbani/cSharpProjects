namespace XmlParsersAndUi.Forms {
    partial class EnvironmentComparisonForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnvironmentComparisonForm));
            this.tcComparisonTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pcProgress = new Utezduyar.Windows.Forms.ProgressCircle();
            this.label11 = new System.Windows.Forms.Label();
            this.lblProgess = new System.Windows.Forms.Label();
            this.gbCustomFilters = new System.Windows.Forms.GroupBox();
            this.cboCustomFilter = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnApplyCustomFilter = new System.Windows.Forms.Button();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnReloadFilters = new System.Windows.Forms.Button();
            this.clbAvailableFilters = new System.Windows.Forms.CheckedListBox();
            this.btnApplyFilters = new System.Windows.Forms.Button();
            this.gbResultsGrid = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.btnExportGrid = new System.Windows.Forms.Button();
            this.btnResetGrid = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbConfiguration = new System.Windows.Forms.GroupBox();
            this.btnValidateVersion = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblInputVersionBid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputEnv = new System.Windows.Forms.TextBox();
            this.txtInpHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblReferenceVersionBid = new System.Windows.Forms.Label();
            this.txtRefEnv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnSaveCategories = new System.Windows.Forms.Button();
            this.tvResultsCategories = new System.Windows.Forms.TreeView();
            this.cmsResutlsCategories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRootNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboFilterType = new System.Windows.Forms.ComboBox();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.btnSaveFilter = new System.Windows.Forms.Button();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.txtFilterPattern = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFilterDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilterName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.lbFilters = new System.Windows.Forms.ListBox();
            this.dgvContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoLastDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgDoServerWork = new System.ComponentModel.BackgroundWorker();
            this.bgwExportToExcel = new System.ComponentModel.BackgroundWorker();
            this.tcComparisonTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbCustomFilters.SuspendLayout();
            this.gbFilters.SuspendLayout();
            this.gbResultsGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.gbConfiguration.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.cmsResutlsCategories.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.dgvContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcComparisonTabs
            // 
            this.tcComparisonTabs.AccessibleRole = System.Windows.Forms.AccessibleRole.Document;
            this.tcComparisonTabs.Controls.Add(this.tabPage1);
            this.tcComparisonTabs.Controls.Add(this.tabPage2);
            this.tcComparisonTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcComparisonTabs.Location = new System.Drawing.Point(0, 0);
            this.tcComparisonTabs.Name = "tcComparisonTabs";
            this.tcComparisonTabs.SelectedIndex = 0;
            this.tcComparisonTabs.Size = new System.Drawing.Size(841, 619);
            this.tcComparisonTabs.TabIndex = 0;
            this.tcComparisonTabs.SelectedIndexChanged += new System.EventHandler(this.tcComparisonTabs_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.gbConfiguration);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(833, 593);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Comparison";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pcProgress);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblProgess);
            this.groupBox2.Controls.Add(this.gbCustomFilters);
            this.groupBox2.Controls.Add(this.gbFilters);
            this.groupBox2.Controls.Add(this.gbResultsGrid);
            this.groupBox2.Location = new System.Drawing.Point(6, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(819, 359);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // pcProgress
            // 
            this.pcProgress.Location = new System.Drawing.Point(334, 104);
            this.pcProgress.Name = "pcProgress";
            this.pcProgress.RingColor = System.Drawing.Color.White;
            this.pcProgress.RingThickness = 10;
            this.pcProgress.Size = new System.Drawing.Size(150, 150);
            this.pcProgress.TabIndex = 0;
            this.pcProgress.Visible = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(329, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 18;
            this.label11.Visible = false;
            // 
            // lblProgess
            // 
            this.lblProgess.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProgess.AutoSize = true;
            this.lblProgess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgess.ForeColor = System.Drawing.Color.Black;
            this.lblProgess.Location = new System.Drawing.Point(359, 16);
            this.lblProgess.Name = "lblProgess";
            this.lblProgess.Size = new System.Drawing.Size(0, 13);
            this.lblProgess.TabIndex = 18;
            this.lblProgess.Visible = false;
            // 
            // gbCustomFilters
            // 
            this.gbCustomFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCustomFilters.Controls.Add(this.cboCustomFilter);
            this.gbCustomFilters.Controls.Add(this.label8);
            this.gbCustomFilters.Controls.Add(this.btnApplyCustomFilter);
            this.gbCustomFilters.Location = new System.Drawing.Point(7, 237);
            this.gbCustomFilters.Name = "gbCustomFilters";
            this.gbCustomFilters.Size = new System.Drawing.Size(172, 116);
            this.gbCustomFilters.TabIndex = 13;
            this.gbCustomFilters.TabStop = false;
            this.gbCustomFilters.Text = "Custom Filters";
            this.gbCustomFilters.Visible = false;
            // 
            // cboCustomFilter
            // 
            this.cboCustomFilter.FormattingEnabled = true;
            this.cboCustomFilter.Location = new System.Drawing.Point(9, 31);
            this.cboCustomFilter.Name = "cboCustomFilter";
            this.cboCustomFilter.Size = new System.Drawing.Size(154, 21);
            this.cboCustomFilter.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Wildcards Filter";
            // 
            // btnApplyCustomFilter
            // 
            this.btnApplyCustomFilter.Location = new System.Drawing.Point(6, 58);
            this.btnApplyCustomFilter.Name = "btnApplyCustomFilter";
            this.btnApplyCustomFilter.Size = new System.Drawing.Size(160, 23);
            this.btnApplyCustomFilter.TabIndex = 2;
            this.btnApplyCustomFilter.Text = "Apply";
            this.btnApplyCustomFilter.UseVisualStyleBackColor = true;
            this.btnApplyCustomFilter.Click += new System.EventHandler(this.btnApplyCustomFilter_Click);
            // 
            // gbFilters
            // 
            this.gbFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbFilters.Controls.Add(this.btnSelectAll);
            this.gbFilters.Controls.Add(this.btnReloadFilters);
            this.gbFilters.Controls.Add(this.clbAvailableFilters);
            this.gbFilters.Controls.Add(this.btnApplyFilters);
            this.gbFilters.Enabled = false;
            this.gbFilters.Location = new System.Drawing.Point(7, 20);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(172, 189);
            this.gbFilters.TabIndex = 0;
            this.gbFilters.TabStop = false;
            this.gbFilters.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSelectAll.Location = new System.Drawing.Point(3, 102);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(160, 23);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnReloadFilters
            // 
            this.btnReloadFilters.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReloadFilters.Location = new System.Drawing.Point(3, 160);
            this.btnReloadFilters.Name = "btnReloadFilters";
            this.btnReloadFilters.Size = new System.Drawing.Size(160, 23);
            this.btnReloadFilters.TabIndex = 2;
            this.btnReloadFilters.Text = "Refresh List";
            this.btnReloadFilters.UseVisualStyleBackColor = true;
            this.btnReloadFilters.Click += new System.EventHandler(this.btnReloadFilters_Click);
            // 
            // clbAvailableFilters
            // 
            this.clbAvailableFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbAvailableFilters.FormattingEnabled = true;
            this.clbAvailableFilters.Location = new System.Drawing.Point(6, 19);
            this.clbAvailableFilters.Name = "clbAvailableFilters";
            this.clbAvailableFilters.Size = new System.Drawing.Size(160, 64);
            this.clbAvailableFilters.TabIndex = 0;
            this.clbAvailableFilters.ThreeDCheckBoxes = true;
            // 
            // btnApplyFilters
            // 
            this.btnApplyFilters.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnApplyFilters.Location = new System.Drawing.Point(3, 131);
            this.btnApplyFilters.Name = "btnApplyFilters";
            this.btnApplyFilters.Size = new System.Drawing.Size(160, 23);
            this.btnApplyFilters.TabIndex = 1;
            this.btnApplyFilters.Text = "Apply";
            this.btnApplyFilters.UseVisualStyleBackColor = true;
            this.btnApplyFilters.Click += new System.EventHandler(this.btnApplyFilters_Click);
            // 
            // gbResultsGrid
            // 
            this.gbResultsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultsGrid.Controls.Add(this.label13);
            this.gbResultsGrid.Controls.Add(this.lblTotalFiles);
            this.gbResultsGrid.Controls.Add(this.btnExportGrid);
            this.gbResultsGrid.Controls.Add(this.btnResetGrid);
            this.gbResultsGrid.Controls.Add(this.dgvResults);
            this.gbResultsGrid.Location = new System.Drawing.Point(185, 20);
            this.gbResultsGrid.Name = "gbResultsGrid";
            this.gbResultsGrid.Size = new System.Drawing.Size(628, 333);
            this.gbResultsGrid.TabIndex = 14;
            this.gbResultsGrid.TabStop = false;
            this.gbResultsGrid.Text = "Result Grid";
            this.gbResultsGrid.Visible = false;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(174, -4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 18;
            this.label13.Visible = false;
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFiles.ForeColor = System.Drawing.Color.Red;
            this.lblTotalFiles.Location = new System.Drawing.Point(7, 296);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(101, 13);
            this.lblTotalFiles.TabIndex = 10;
            this.lblTotalFiles.Text = "Remaining files: ";
            // 
            // btnExportGrid
            // 
            this.btnExportGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExportGrid.Location = new System.Drawing.Point(317, 299);
            this.btnExportGrid.Name = "btnExportGrid";
            this.btnExportGrid.Size = new System.Drawing.Size(75, 23);
            this.btnExportGrid.TabIndex = 17;
            this.btnExportGrid.Text = "Export";
            this.btnExportGrid.UseVisualStyleBackColor = true;
            this.btnExportGrid.Click += new System.EventHandler(this.btnExportGrid_Click);
            // 
            // btnResetGrid
            // 
            this.btnResetGrid.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnResetGrid.Location = new System.Drawing.Point(236, 299);
            this.btnResetGrid.Name = "btnResetGrid";
            this.btnResetGrid.Size = new System.Drawing.Size(75, 23);
            this.btnResetGrid.TabIndex = 16;
            this.btnResetGrid.Text = "Reset Grid";
            this.btnResetGrid.UseVisualStyleBackColor = true;
            this.btnResetGrid.Click += new System.EventHandler(this.btnResetGrid_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.FileSize,
            this.FileModifyDate,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResults.Location = new System.Drawing.Point(12, 19);
            this.dgvResults.Name = "dgvResults";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(616, 274);
            this.dgvResults.TabIndex = 15;
            this.dgvResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvResults_KeyPress);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 30.45685F;
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.FillWeight = 50.45473F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Operation";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "File Size (KB)";
            this.FileSize.Name = "FileSize";
            this.FileSize.ReadOnly = true;
            // 
            // FileModifyDate
            // 
            this.FileModifyDate.HeaderText = "Modify Date";
            this.FileModifyDate.Name = "FileModifyDate";
            this.FileModifyDate.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.FillWeight = 60.17286F;
            this.dataGridViewTextBoxColumn3.HeaderText = "FileType";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.FillWeight = 258F;
            this.dataGridViewTextBoxColumn4.HeaderText = "File Path";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // gbConfiguration
            // 
            this.gbConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConfiguration.Controls.Add(this.btnValidateVersion);
            this.gbConfiguration.Controls.Add(this.groupBox7);
            this.gbConfiguration.Controls.Add(this.groupBox6);
            this.gbConfiguration.Controls.Add(this.btnStart);
            this.gbConfiguration.Controls.Add(this.btnReset);
            this.gbConfiguration.Location = new System.Drawing.Point(6, 6);
            this.gbConfiguration.Name = "gbConfiguration";
            this.gbConfiguration.Size = new System.Drawing.Size(819, 214);
            this.gbConfiguration.TabIndex = 2;
            this.gbConfiguration.TabStop = false;
            this.gbConfiguration.Text = "Configuration";
            // 
            // btnValidateVersion
            // 
            this.btnValidateVersion.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnValidateVersion.Location = new System.Drawing.Point(355, 185);
            this.btnValidateVersion.Name = "btnValidateVersion";
            this.btnValidateVersion.Size = new System.Drawing.Size(109, 23);
            this.btnValidateVersion.TabIndex = 11;
            this.btnValidateVersion.Text = "Validate Version";
            this.btnValidateVersion.UseVisualStyleBackColor = true;
            this.btnValidateVersion.Click += new System.EventHandler(this.btnValidateVersion_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblInputVersionBid);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.txtInputEnv);
            this.groupBox7.Controls.Add(this.txtInpHost);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Location = new System.Drawing.Point(6, 101);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(807, 80);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Input Environment";
            // 
            // lblInputVersionBid
            // 
            this.lblInputVersionBid.AutoSize = true;
            this.lblInputVersionBid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputVersionBid.ForeColor = System.Drawing.Color.Maroon;
            this.lblInputVersionBid.Location = new System.Drawing.Point(232, 52);
            this.lblInputVersionBid.Name = "lblInputVersionBid";
            this.lblInputVersionBid.Size = new System.Drawing.Size(53, 13);
            this.lblInputVersionBid.TabIndex = 9;
            this.lblInputVersionBid.Text = "Version:";
            this.lblInputVersionBid.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input Environment:";
            // 
            // txtInputEnv
            // 
            this.txtInputEnv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputEnv.Location = new System.Drawing.Point(108, 23);
            this.txtInputEnv.Name = "txtInputEnv";
            this.txtInputEnv.Size = new System.Drawing.Size(693, 20);
            this.txtInputEnv.TabIndex = 1;
            this.txtInputEnv.TextChanged += new System.EventHandler(this.txtInputEnv_TextChanged);
            // 
            // txtInpHost
            // 
            this.txtInpHost.Location = new System.Drawing.Point(108, 49);
            this.txtInpHost.Name = "txtInpHost";
            this.txtInpHost.Size = new System.Drawing.Size(60, 20);
            this.txtInpHost.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Inp. Host:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblReferenceVersionBid);
            this.groupBox6.Controls.Add(this.txtRefEnv);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.txtRefHost);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Location = new System.Drawing.Point(6, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(801, 76);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Reference Environment";
            // 
            // lblReferenceVersionBid
            // 
            this.lblReferenceVersionBid.AutoSize = true;
            this.lblReferenceVersionBid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceVersionBid.ForeColor = System.Drawing.Color.Maroon;
            this.lblReferenceVersionBid.Location = new System.Drawing.Point(232, 48);
            this.lblReferenceVersionBid.Name = "lblReferenceVersionBid";
            this.lblReferenceVersionBid.Size = new System.Drawing.Size(53, 13);
            this.lblReferenceVersionBid.TabIndex = 7;
            this.lblReferenceVersionBid.Text = "Version:";
            this.lblReferenceVersionBid.Visible = false;
            // 
            // txtRefEnv
            // 
            this.txtRefEnv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefEnv.Location = new System.Drawing.Point(112, 19);
            this.txtRefEnv.Name = "txtRefEnv";
            this.txtRefEnv.Size = new System.Drawing.Size(683, 20);
            this.txtRefEnv.TabIndex = 0;
            this.txtRefEnv.TextChanged += new System.EventHandler(this.txtRefEnv_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ref. Environment:";
            // 
            // txtRefHost
            // 
            this.txtRefHost.Location = new System.Drawing.Point(112, 45);
            this.txtRefHost.Name = "txtRefHost";
            this.txtRefHost.Size = new System.Drawing.Size(60, 20);
            this.txtRefHost.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ref. Host:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(470, 185);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReset.Location = new System.Drawing.Point(240, 185);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(109, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(833, 593);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.btnSaveCategories);
            this.groupBox8.Controls.Add(this.tvResultsCategories);
            this.groupBox8.Location = new System.Drawing.Point(9, 311);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(830, 274);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Results Categories";
            // 
            // btnSaveCategories
            // 
            this.btnSaveCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveCategories.Location = new System.Drawing.Point(61, 245);
            this.btnSaveCategories.Name = "btnSaveCategories";
            this.btnSaveCategories.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCategories.TabIndex = 11;
            this.btnSaveCategories.Text = "Save";
            this.btnSaveCategories.UseVisualStyleBackColor = true;
            this.btnSaveCategories.Click += new System.EventHandler(this.btnSaveCategories_Click);
            // 
            // tvResultsCategories
            // 
            this.tvResultsCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tvResultsCategories.ContextMenuStrip = this.cmsResutlsCategories;
            this.tvResultsCategories.Location = new System.Drawing.Point(6, 19);
            this.tvResultsCategories.Name = "tvResultsCategories";
            this.tvResultsCategories.Size = new System.Drawing.Size(186, 220);
            this.tvResultsCategories.TabIndex = 0;
            this.tvResultsCategories.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvResultsCategories_NodeMouseDoubleClick);
            // 
            // cmsResutlsCategories
            // 
            this.cmsResutlsCategories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChildToolStripMenuItem,
            this.editNodeToolStripMenuItem,
            this.addRootNodeToolStripMenuItem,
            this.deleteToolStripMenuItem1});
            this.cmsResutlsCategories.Name = "cmsResutlsCategories";
            this.cmsResutlsCategories.Size = new System.Drawing.Size(159, 92);
            // 
            // addChildToolStripMenuItem
            // 
            this.addChildToolStripMenuItem.Name = "addChildToolStripMenuItem";
            this.addChildToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addChildToolStripMenuItem.Text = "Add Child";
            this.addChildToolStripMenuItem.Click += new System.EventHandler(this.addChildToolStripMenuItem_Click);
            // 
            // editNodeToolStripMenuItem
            // 
            this.editNodeToolStripMenuItem.Name = "editNodeToolStripMenuItem";
            this.editNodeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editNodeToolStripMenuItem.Text = "Edit Node";
            this.editNodeToolStripMenuItem.Click += new System.EventHandler(this.editNodeToolStripMenuItem_Click);
            // 
            // addRootNodeToolStripMenuItem
            // 
            this.addRootNodeToolStripMenuItem.Name = "addRootNodeToolStripMenuItem";
            this.addRootNodeToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addRootNodeToolStripMenuItem.Text = "Add Root Node";
            this.addRootNodeToolStripMenuItem.Click += new System.EventHandler(this.addRootNodeToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.btnReload);
            this.groupBox3.Controls.Add(this.lbFilters);
            this.groupBox3.Location = new System.Drawing.Point(7, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(832, 298);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filters";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.cboFilterType);
            this.groupBox4.Controls.Add(this.btnResetFilter);
            this.groupBox4.Controls.Add(this.btnSaveFilter);
            this.groupBox4.Controls.Add(this.btnAddFilter);
            this.groupBox4.Controls.Add(this.txtFilterPattern);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtFilterDescription);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtFilterName);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(209, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(617, 273);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Details";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(398, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Type:";
            // 
            // cboFilterType
            // 
            this.cboFilterType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterType.FormattingEnabled = true;
            this.cboFilterType.Location = new System.Drawing.Point(438, 18);
            this.cboFilterType.Name = "cboFilterType";
            this.cboFilterType.Size = new System.Drawing.Size(151, 21);
            this.cboFilterType.TabIndex = 9;
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnResetFilter.Location = new System.Drawing.Point(363, 244);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(75, 23);
            this.btnResetFilter.TabIndex = 8;
            this.btnResetFilter.Text = "Reset";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // btnSaveFilter
            // 
            this.btnSaveFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSaveFilter.Location = new System.Drawing.Point(282, 244);
            this.btnSaveFilter.Name = "btnSaveFilter";
            this.btnSaveFilter.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFilter.TabIndex = 7;
            this.btnSaveFilter.Text = "Save";
            this.btnSaveFilter.UseVisualStyleBackColor = true;
            this.btnSaveFilter.Click += new System.EventHandler(this.btnSaveFilter_Click);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddFilter.Location = new System.Drawing.Point(201, 244);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAddFilter.TabIndex = 6;
            this.btnAddFilter.Text = "Add";
            this.btnAddFilter.UseVisualStyleBackColor = true;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // txtFilterPattern
            // 
            this.txtFilterPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterPattern.Location = new System.Drawing.Point(78, 155);
            this.txtFilterPattern.Multiline = true;
            this.txtFilterPattern.Name = "txtFilterPattern";
            this.txtFilterPattern.Size = new System.Drawing.Size(511, 81);
            this.txtFilterPattern.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Pattern:";
            // 
            // txtFilterDescription
            // 
            this.txtFilterDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterDescription.Location = new System.Drawing.Point(78, 60);
            this.txtFilterDescription.Multiline = true;
            this.txtFilterDescription.Name = "txtFilterDescription";
            this.txtFilterDescription.Size = new System.Drawing.Size(511, 81);
            this.txtFilterDescription.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Description:";
            // 
            // txtFilterName
            // 
            this.txtFilterName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterName.Location = new System.Drawing.Point(78, 19);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(184, 20);
            this.txtFilterName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Name:";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(51, 263);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 9;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lbFilters
            // 
            this.lbFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFilters.FormattingEnabled = true;
            this.lbFilters.Location = new System.Drawing.Point(7, 20);
            this.lbFilters.Name = "lbFilters";
            this.lbFilters.Size = new System.Drawing.Size(187, 225);
            this.lbFilters.TabIndex = 0;
            this.lbFilters.SelectedIndexChanged += new System.EventHandler(this.lbFilters_SelectedIndexChanged);
            // 
            // dgvContextMenu
            // 
            this.dgvContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.undoLastDeleteToolStripMenuItem});
            this.dgvContextMenu.Name = "dgvContextMenu";
            this.dgvContextMenu.Size = new System.Drawing.Size(168, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // undoLastDeleteToolStripMenuItem
            // 
            this.undoLastDeleteToolStripMenuItem.Name = "undoLastDeleteToolStripMenuItem";
            this.undoLastDeleteToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.undoLastDeleteToolStripMenuItem.Text = "Undo Last Delete";
            this.undoLastDeleteToolStripMenuItem.Click += new System.EventHandler(this.undoLastDeleteToolStripMenuItem_Click);
            // 
            // bgDoServerWork
            // 
            this.bgDoServerWork.WorkerReportsProgress = true;
            this.bgDoServerWork.WorkerSupportsCancellation = true;
            this.bgDoServerWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgDoServerWork_DoWork);
            this.bgDoServerWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgDoServerWork_RunWorkerCompleted);
            this.bgDoServerWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgDoServerWork_ProgressChanged);
            // 
            // bgwExportToExcel
            // 
            this.bgwExportToExcel.WorkerSupportsCancellation = true;
            this.bgwExportToExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwExportToExcel_DoWork);
            this.bgwExportToExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwExportToExcel_RunWorkerCompleted);
            // 
            // EnvironmentComparisonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 619);
            this.Controls.Add(this.tcComparisonTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnvironmentComparisonForm";
            this.Text = "Environment Comparison";
            this.Load += new System.EventHandler(this.EnvironmentComparisonForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EnvironmentComparisonForm_FormClosing);
            this.tcComparisonTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbCustomFilters.ResumeLayout(false);
            this.gbCustomFilters.PerformLayout();
            this.gbFilters.ResumeLayout(false);
            this.gbResultsGrid.ResumeLayout(false);
            this.gbResultsGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.gbConfiguration.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.cmsResutlsCategories.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.dgvContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcComparisonTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbConfiguration;
        private System.Windows.Forms.TextBox txtInpHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRefHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInputEnv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRefEnv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TabPage tabPage2;
        private System.ComponentModel.BackgroundWorker bgDoServerWork;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbFilters;
        private System.Windows.Forms.TextBox txtFilterPattern;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFilterDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFilterName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.Button btnSaveFilter;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbResultsGrid;
        private Utezduyar.Windows.Forms.ProgressCircle pcProgress;
        private System.Windows.Forms.Button btnExportGrid;
        private System.Windows.Forms.Button btnResetGrid;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.GroupBox gbCustomFilters;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnApplyCustomFilter;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.CheckedListBox clbAvailableFilters;
        private System.Windows.Forms.Button btnApplyFilters;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Label lblProgess;
        private System.Windows.Forms.Button btnReloadFilters;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboCustomFilter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ContextMenuStrip dgvContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblReferenceVersionBid;
        private System.Windows.Forms.Label lblInputVersionBid;
        private System.Windows.Forms.Button btnValidateVersion;
        private System.ComponentModel.BackgroundWorker bgwExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem undoLastDeleteToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TreeView tvResultsCategories;
        private System.Windows.Forms.ContextMenuStrip cmsResutlsCategories;
        private System.Windows.Forms.ToolStripMenuItem addChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRootNodeToolStripMenuItem;
        private System.Windows.Forms.Button btnSaveCategories;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileModifyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

    }
}