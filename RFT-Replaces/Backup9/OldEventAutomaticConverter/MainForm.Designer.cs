namespace OldEventAutomaticConverter {
    partial class MainForm {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnBrowseFrom = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpOverview = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudNumberOfWorkers = new System.Windows.Forms.NumericUpDown();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnClearFrom = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFromDirectory = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblGlobalStatus = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tpRules = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefreshRules = new System.Windows.Forms.Button();
            this.lbSavedRules = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtOldEvent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewEvent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkActionTB = new System.Windows.Forms.CheckBox();
            this.chkFilter = new System.Windows.Forms.CheckBox();
            this.chkRegexMode = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.btnDeleteRule = new System.Windows.Forms.Button();
            this.btnSaveRule = new System.Windows.Forms.Button();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tpRequestRule = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtRequestOldEvent = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRequestNewEvent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkRequestActionTB = new System.Windows.Forms.CheckBox();
            this.chkRequestFilterEv = new System.Windows.Forms.CheckBox();
            this.chkRequestRegexM = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRequestRuleName = new System.Windows.Forms.TextBox();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.btnRequestReset = new System.Windows.Forms.Button();
            this.tpIncidents = new System.Windows.Forms.TabPage();
            this.btnResetIncident = new System.Windows.Forms.Button();
            this.btnSaveIncident = new System.Windows.Forms.Button();
            this.btnAddIncident = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtIncidentNotes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIncidentSolution = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIncident = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtIncidentName = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkCaseSensitive = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtIncidentSearchText = new System.Windows.Forms.TextBox();
            this.dgvIncidents = new System.Windows.Forms.DataGridView();
            this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearchIncidents = new System.Windows.Forms.Button();
            this.btnRefreshIncidents = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.bWGetFiles = new System.ComponentModel.BackgroundWorker();
            this.txtTotalReplacements = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpOverview.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfWorkers)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tpRules.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tpRequestRule.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tpIncidents.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseFrom
            // 
            this.btnBrowseFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFrom.Location = new System.Drawing.Point(535, 26);
            this.btnBrowseFrom.Name = "btnBrowseFrom";
            this.btnBrowseFrom.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFrom.TabIndex = 1;
            this.btnBrowseFrom.Text = "Browse";
            this.btnBrowseFrom.UseVisualStyleBackColor = true;
            this.btnBrowseFrom.Click += new System.EventHandler(this.btnBrowseFrom_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpOverview);
            this.tabControl1.Controls.Add(this.tpRules);
            this.tabControl1.Controls.Add(this.tpRequestRule);
            this.tabControl1.Controls.Add(this.tpIncidents);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(761, 579);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpOverview
            // 
            this.tpOverview.Controls.Add(this.splitContainer3);
            this.tpOverview.Controls.Add(this.btnClose);
            this.tpOverview.Location = new System.Drawing.Point(4, 22);
            this.tpOverview.Name = "tpOverview";
            this.tpOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tpOverview.Size = new System.Drawing.Size(753, 553);
            this.tpOverview.TabIndex = 0;
            this.tpOverview.Text = "Overview";
            this.tpOverview.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer3.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer3.Size = new System.Drawing.Size(747, 547);
            this.splitContainer3.SplitterDistance = 122;
            this.splitContainer3.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.nudNumberOfWorkers);
            this.groupBox3.Controls.Add(this.btnParse);
            this.groupBox3.Controls.Add(this.btnClearFrom);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtFromDirectory);
            this.groupBox3.Controls.Add(this.btnBrowseFrom);
            this.groupBox3.Location = new System.Drawing.Point(4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(738, 116);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setup";
            // 
            // btnShowResult
            // 
            this.btnShowResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowResult.Enabled = false;
            this.btnShowResult.Location = new System.Drawing.Point(197, 95);
            this.btnShowResult.Name = "btnShowResult";
            this.btnShowResult.Size = new System.Drawing.Size(93, 23);
            this.btnShowResult.TabIndex = 2;
            this.btnShowResult.Text = "Show Result";
            this.btnShowResult.UseVisualStyleBackColor = true;
            this.btnShowResult.Visible = false;
            this.btnShowResult.Click += new System.EventHandler(this.btnShowResult_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Number of Workers:";
            // 
            // nudNumberOfWorkers
            // 
            this.nudNumberOfWorkers.Location = new System.Drawing.Point(119, 58);
            this.nudNumberOfWorkers.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudNumberOfWorkers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfWorkers.Name = "nudNumberOfWorkers";
            this.nudNumberOfWorkers.ReadOnly = true;
            this.nudNumberOfWorkers.Size = new System.Drawing.Size(120, 20);
            this.nudNumberOfWorkers.TabIndex = 0;
            this.nudNumberOfWorkers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnParse
            // 
            this.btnParse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnParse.Location = new System.Drawing.Point(323, 87);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(93, 23);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnClearFrom
            // 
            this.btnClearFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFrom.Location = new System.Drawing.Point(616, 26);
            this.btnClearFrom.Name = "btnClearFrom";
            this.btnClearFrom.Size = new System.Drawing.Size(75, 23);
            this.btnClearFrom.TabIndex = 2;
            this.btnClearFrom.Text = "Clear";
            this.btnClearFrom.UseVisualStyleBackColor = true;
            this.btnClearFrom.Click += new System.EventHandler(this.btnClearFrom_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "From Directory:";
            // 
            // txtFromDirectory
            // 
            this.txtFromDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromDirectory.Location = new System.Drawing.Point(119, 29);
            this.txtFromDirectory.Name = "txtFromDirectory";
            this.txtFromDirectory.Size = new System.Drawing.Size(410, 20);
            this.txtFromDirectory.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtTotalReplacements);
            this.groupBox5.Controls.Add(this.lblGlobalStatus);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(738, 108);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Status";
            // 
            // lblGlobalStatus
            // 
            this.lblGlobalStatus.AutoSize = true;
            this.lblGlobalStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblGlobalStatus.Location = new System.Drawing.Point(281, 41);
            this.lblGlobalStatus.Name = "lblGlobalStatus";
            this.lblGlobalStatus.Size = new System.Drawing.Size(205, 13);
            this.lblGlobalStatus.TabIndex = 7;
            this.lblGlobalStatus.Text = "Please select a directory to parse !";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtLog);
            this.groupBox4.Controls.Add(this.btnShowResult);
            this.groupBox4.Location = new System.Drawing.Point(3, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(741, 301);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Logs";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(735, 282);
            this.txtLog.TabIndex = 0;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Location = new System.Drawing.Point(319, 524);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tpRules
            // 
            this.tpRules.Controls.Add(this.groupBox1);
            this.tpRules.Controls.Add(this.groupBox2);
            this.tpRules.Location = new System.Drawing.Point(4, 22);
            this.tpRules.Name = "tpRules";
            this.tpRules.Padding = new System.Windows.Forms.Padding(3);
            this.tpRules.Size = new System.Drawing.Size(753, 553);
            this.tpRules.TabIndex = 1;
            this.tpRules.Text = "Rules";
            this.tpRules.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnRefreshRules);
            this.groupBox1.Controls.Add(this.lbSavedRules);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 510);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saved rules";
            // 
            // btnRefreshRules
            // 
            this.btnRefreshRules.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRefreshRules.Location = new System.Drawing.Point(39, 471);
            this.btnRefreshRules.Name = "btnRefreshRules";
            this.btnRefreshRules.Size = new System.Drawing.Size(114, 23);
            this.btnRefreshRules.TabIndex = 1;
            this.btnRefreshRules.Text = "Refresh";
            this.btnRefreshRules.UseVisualStyleBackColor = true;
            this.btnRefreshRules.Click += new System.EventHandler(this.btnRefreshRules_Click);
            // 
            // lbSavedRules
            // 
            this.lbSavedRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSavedRules.FormattingEnabled = true;
            this.lbSavedRules.Location = new System.Drawing.Point(4, 18);
            this.lbSavedRules.Name = "lbSavedRules";
            this.lbSavedRules.Size = new System.Drawing.Size(183, 420);
            this.lbSavedRules.TabIndex = 0;
            this.lbSavedRules.SelectedIndexChanged += new System.EventHandler(this.lbSavedRules_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.splitContainer2);
            this.groupBox2.Controls.Add(this.chkActionTB);
            this.groupBox2.Controls.Add(this.chkFilter);
            this.groupBox2.Controls.Add(this.chkRegexMode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRuleName);
            this.groupBox2.Controls.Add(this.btnDeleteRule);
            this.groupBox2.Controls.Add(this.btnSaveRule);
            this.groupBox2.Controls.Add(this.btnAddRule);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Location = new System.Drawing.Point(206, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 509);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rules";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(6, 56);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtOldEvent);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtNewEvent);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(504, 408);
            this.splitContainer2.SplitterDistance = 204;
            this.splitContainer2.TabIndex = 10;
            // 
            // txtOldEvent
            // 
            this.txtOldEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldEvent.Location = new System.Drawing.Point(71, 3);
            this.txtOldEvent.Multiline = true;
            this.txtOldEvent.Name = "txtOldEvent";
            this.txtOldEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOldEvent.Size = new System.Drawing.Size(430, 178);
            this.txtOldEvent.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Old event:";
            // 
            // txtNewEvent
            // 
            this.txtNewEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewEvent.Location = new System.Drawing.Point(71, 3);
            this.txtNewEvent.Multiline = true;
            this.txtNewEvent.Name = "txtNewEvent";
            this.txtNewEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewEvent.Size = new System.Drawing.Size(430, 170);
            this.txtNewEvent.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "New event:";
            // 
            // chkActionTB
            // 
            this.chkActionTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActionTB.AutoSize = true;
            this.chkActionTB.Location = new System.Drawing.Point(439, 32);
            this.chkActionTB.Name = "chkActionTB";
            this.chkActionTB.Size = new System.Drawing.Size(73, 17);
            this.chkActionTB.TabIndex = 3;
            this.chkActionTB.Text = "Action TB";
            this.chkActionTB.UseVisualStyleBackColor = true;
            this.chkActionTB.CheckedChanged += new System.EventHandler(this.chkActionTB_CheckedChanged);
            // 
            // chkFilter
            // 
            this.chkFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFilter.AutoSize = true;
            this.chkFilter.Location = new System.Drawing.Point(354, 32);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(79, 17);
            this.chkFilter.TabIndex = 2;
            this.chkFilter.Text = "Filter Event";
            this.chkFilter.UseVisualStyleBackColor = true;
            this.chkFilter.CheckedChanged += new System.EventHandler(this.chkFilter_CheckedChanged);
            // 
            // chkRegexMode
            // 
            this.chkRegexMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRegexMode.AutoSize = true;
            this.chkRegexMode.Location = new System.Drawing.Point(261, 32);
            this.chkRegexMode.Name = "chkRegexMode";
            this.chkRegexMode.Size = new System.Drawing.Size(87, 17);
            this.chkRegexMode.TabIndex = 1;
            this.chkRegexMode.Text = "Regex Mode";
            this.chkRegexMode.UseVisualStyleBackColor = true;
            this.chkRegexMode.CheckedChanged += new System.EventHandler(this.chkRegexMode_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Rule name:";
            // 
            // txtRuleName
            // 
            this.txtRuleName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRuleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuleName.Location = new System.Drawing.Point(77, 30);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(178, 20);
            this.txtRuleName.TabIndex = 0;
            // 
            // btnDeleteRule
            // 
            this.btnDeleteRule.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDeleteRule.Location = new System.Drawing.Point(381, 470);
            this.btnDeleteRule.Name = "btnDeleteRule";
            this.btnDeleteRule.Size = new System.Drawing.Size(114, 23);
            this.btnDeleteRule.TabIndex = 9;
            this.btnDeleteRule.Text = "Delete";
            this.btnDeleteRule.UseVisualStyleBackColor = true;
            this.btnDeleteRule.Click += new System.EventHandler(this.btnDeleteRule_Click);
            // 
            // btnSaveRule
            // 
            this.btnSaveRule.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSaveRule.Enabled = false;
            this.btnSaveRule.Location = new System.Drawing.Point(141, 470);
            this.btnSaveRule.Name = "btnSaveRule";
            this.btnSaveRule.Size = new System.Drawing.Size(114, 23);
            this.btnSaveRule.TabIndex = 7;
            this.btnSaveRule.Text = "Save";
            this.btnSaveRule.UseVisualStyleBackColor = true;
            this.btnSaveRule.Click += new System.EventHandler(this.btnSaveRule_Click);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddRule.Location = new System.Drawing.Point(24, 470);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(114, 23);
            this.btnAddRule.TabIndex = 6;
            this.btnAddRule.Text = "Add";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReset.Location = new System.Drawing.Point(261, 470);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(114, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tpRequestRule
            // 
            this.tpRequestRule.Controls.Add(this.groupBox7);
            this.tpRequestRule.Location = new System.Drawing.Point(4, 22);
            this.tpRequestRule.Name = "tpRequestRule";
            this.tpRequestRule.Size = new System.Drawing.Size(753, 553);
            this.tpRequestRule.TabIndex = 2;
            this.tpRequestRule.Text = "Request Rule";
            this.tpRequestRule.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.splitContainer1);
            this.groupBox7.Controls.Add(this.chkRequestActionTB);
            this.groupBox7.Controls.Add(this.chkRequestFilterEv);
            this.groupBox7.Controls.Add(this.chkRequestRegexM);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.txtRequestRuleName);
            this.groupBox7.Controls.Add(this.btnSendRequest);
            this.groupBox7.Controls.Add(this.btnRequestReset);
            this.groupBox7.Location = new System.Drawing.Point(8, 7);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(737, 509);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Rule Request";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 56);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtRequestOldEvent);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtRequestNewEvent);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Size = new System.Drawing.Size(725, 418);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtRequestOldEvent
            // 
            this.txtRequestOldEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequestOldEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestOldEvent.Location = new System.Drawing.Point(71, 3);
            this.txtRequestOldEvent.Multiline = true;
            this.txtRequestOldEvent.Name = "txtRequestOldEvent";
            this.txtRequestOldEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequestOldEvent.Size = new System.Drawing.Size(651, 185);
            this.txtRequestOldEvent.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Old event:";
            // 
            // txtRequestNewEvent
            // 
            this.txtRequestNewEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequestNewEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestNewEvent.Location = new System.Drawing.Point(71, 3);
            this.txtRequestNewEvent.Multiline = true;
            this.txtRequestNewEvent.Name = "txtRequestNewEvent";
            this.txtRequestNewEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequestNewEvent.Size = new System.Drawing.Size(651, 185);
            this.txtRequestNewEvent.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "New event:";
            // 
            // chkRequestActionTB
            // 
            this.chkRequestActionTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRequestActionTB.AutoSize = true;
            this.chkRequestActionTB.Location = new System.Drawing.Point(660, 32);
            this.chkRequestActionTB.Name = "chkRequestActionTB";
            this.chkRequestActionTB.Size = new System.Drawing.Size(73, 17);
            this.chkRequestActionTB.TabIndex = 3;
            this.chkRequestActionTB.Text = "Action TB";
            this.chkRequestActionTB.UseVisualStyleBackColor = true;
            // 
            // chkRequestFilterEv
            // 
            this.chkRequestFilterEv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRequestFilterEv.AutoSize = true;
            this.chkRequestFilterEv.Location = new System.Drawing.Point(575, 32);
            this.chkRequestFilterEv.Name = "chkRequestFilterEv";
            this.chkRequestFilterEv.Size = new System.Drawing.Size(79, 17);
            this.chkRequestFilterEv.TabIndex = 2;
            this.chkRequestFilterEv.Text = "Filter Event";
            this.chkRequestFilterEv.UseVisualStyleBackColor = true;
            // 
            // chkRequestRegexM
            // 
            this.chkRequestRegexM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRequestRegexM.AutoSize = true;
            this.chkRequestRegexM.Location = new System.Drawing.Point(482, 32);
            this.chkRequestRegexM.Name = "chkRequestRegexM";
            this.chkRequestRegexM.Size = new System.Drawing.Size(87, 17);
            this.chkRequestRegexM.TabIndex = 1;
            this.chkRequestRegexM.Text = "Regex Mode";
            this.chkRequestRegexM.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Rule name:";
            // 
            // txtRequestRuleName
            // 
            this.txtRequestRuleName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequestRuleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestRuleName.Location = new System.Drawing.Point(77, 30);
            this.txtRequestRuleName.Name = "txtRequestRuleName";
            this.txtRequestRuleName.Size = new System.Drawing.Size(399, 20);
            this.txtRequestRuleName.TabIndex = 0;
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSendRequest.Location = new System.Drawing.Point(251, 480);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(114, 23);
            this.btnSendRequest.TabIndex = 6;
            this.btnSendRequest.Text = "Send";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // btnRequestReset
            // 
            this.btnRequestReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRequestReset.Location = new System.Drawing.Point(371, 480);
            this.btnRequestReset.Name = "btnRequestReset";
            this.btnRequestReset.Size = new System.Drawing.Size(114, 23);
            this.btnRequestReset.TabIndex = 8;
            this.btnRequestReset.Text = "Reset";
            this.btnRequestReset.UseVisualStyleBackColor = true;
            this.btnRequestReset.Click += new System.EventHandler(this.btnRequestReset_Click);
            // 
            // tpIncidents
            // 
            this.tpIncidents.Controls.Add(this.btnResetIncident);
            this.tpIncidents.Controls.Add(this.btnSaveIncident);
            this.tpIncidents.Controls.Add(this.btnAddIncident);
            this.tpIncidents.Controls.Add(this.groupBox9);
            this.tpIncidents.Controls.Add(this.groupBox8);
            this.tpIncidents.Location = new System.Drawing.Point(4, 22);
            this.tpIncidents.Name = "tpIncidents";
            this.tpIncidents.Size = new System.Drawing.Size(753, 553);
            this.tpIncidents.TabIndex = 3;
            this.tpIncidents.Text = "Incidents";
            this.tpIncidents.UseVisualStyleBackColor = true;
            // 
            // btnResetIncident
            // 
            this.btnResetIncident.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetIncident.Location = new System.Drawing.Point(647, 74);
            this.btnResetIncident.Name = "btnResetIncident";
            this.btnResetIncident.Size = new System.Drawing.Size(98, 23);
            this.btnResetIncident.TabIndex = 4;
            this.btnResetIncident.Text = "Reset";
            this.btnResetIncident.UseVisualStyleBackColor = true;
            this.btnResetIncident.Click += new System.EventHandler(this.btnResetIncident_Click);
            // 
            // btnSaveIncident
            // 
            this.btnSaveIncident.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveIncident.Enabled = false;
            this.btnSaveIncident.Location = new System.Drawing.Point(647, 45);
            this.btnSaveIncident.Name = "btnSaveIncident";
            this.btnSaveIncident.Size = new System.Drawing.Size(98, 23);
            this.btnSaveIncident.TabIndex = 3;
            this.btnSaveIncident.Text = "Save";
            this.btnSaveIncident.UseVisualStyleBackColor = true;
            this.btnSaveIncident.Click += new System.EventHandler(this.btnSaveIncident_Click);
            // 
            // btnAddIncident
            // 
            this.btnAddIncident.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddIncident.Location = new System.Drawing.Point(647, 16);
            this.btnAddIncident.Name = "btnAddIncident";
            this.btnAddIncident.Size = new System.Drawing.Size(98, 23);
            this.btnAddIncident.TabIndex = 2;
            this.btnAddIncident.Text = "Add";
            this.btnAddIncident.UseVisualStyleBackColor = true;
            this.btnAddIncident.Click += new System.EventHandler(this.btnAddIncident_Click_1);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Controls.Add(this.txtIncidentNotes);
            this.groupBox9.Controls.Add(this.label13);
            this.groupBox9.Controls.Add(this.txtIncidentSolution);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.txtIncident);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.txtIncidentName);
            this.groupBox9.Location = new System.Drawing.Point(9, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(632, 288);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Add Incidents";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 229);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Notes:";
            // 
            // txtIncidentNotes
            // 
            this.txtIncidentNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncidentNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtIncidentNotes.Location = new System.Drawing.Point(60, 226);
            this.txtIncidentNotes.Multiline = true;
            this.txtIncidentNotes.Name = "txtIncidentNotes";
            this.txtIncidentNotes.Size = new System.Drawing.Size(566, 56);
            this.txtIncidentNotes.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Solution:";
            // 
            // txtIncidentSolution
            // 
            this.txtIncidentSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncidentSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtIncidentSolution.Location = new System.Drawing.Point(60, 134);
            this.txtIncidentSolution.Multiline = true;
            this.txtIncidentSolution.Name = "txtIncidentSolution";
            this.txtIncidentSolution.Size = new System.Drawing.Size(566, 73);
            this.txtIncidentSolution.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Incident:";
            // 
            // txtIncident
            // 
            this.txtIncident.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtIncident.Location = new System.Drawing.Point(60, 45);
            this.txtIncident.Multiline = true;
            this.txtIncident.Name = "txtIncident";
            this.txtIncident.Size = new System.Drawing.Size(566, 73);
            this.txtIncident.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Name:";
            // 
            // txtIncidentName
            // 
            this.txtIncidentName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncidentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtIncidentName.Location = new System.Drawing.Point(60, 19);
            this.txtIncidentName.Name = "txtIncidentName";
            this.txtIncidentName.Size = new System.Drawing.Size(251, 20);
            this.txtIncidentName.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.Controls.Add(this.chkCaseSensitive);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.txtIncidentSearchText);
            this.groupBox8.Controls.Add(this.dgvIncidents);
            this.groupBox8.Controls.Add(this.btnSearchIncidents);
            this.groupBox8.Controls.Add(this.btnRefreshIncidents);
            this.groupBox8.Location = new System.Drawing.Point(9, 297);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(736, 253);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Incidents";
            // 
            // chkCaseSensitive
            // 
            this.chkCaseSensitive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCaseSensitive.AutoSize = true;
            this.chkCaseSensitive.Location = new System.Drawing.Point(413, 23);
            this.chkCaseSensitive.Name = "chkCaseSensitive";
            this.chkCaseSensitive.Size = new System.Drawing.Size(96, 17);
            this.chkCaseSensitive.TabIndex = 10;
            this.chkCaseSensitive.Text = "Case Sensitive";
            this.chkCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Search Text:";
            // 
            // txtIncidentSearchText
            // 
            this.txtIncidentSearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncidentSearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtIncidentSearchText.Location = new System.Drawing.Point(80, 21);
            this.txtIncidentSearchText.Name = "txtIncidentSearchText";
            this.txtIncidentSearchText.Size = new System.Drawing.Size(327, 20);
            this.txtIncidentSearchText.TabIndex = 8;
            this.txtIncidentSearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIncidentSearchText_KeyDown);
            // 
            // dgvIncidents
            // 
            this.dgvIncidents.AllowUserToAddRows = false;
            this.dgvIncidents.AllowUserToDeleteRows = false;
            this.dgvIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIncidents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcName,
            this.dgvcNotes,
            this.dgvcIncident,
            this.dgvcSolution});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIncidents.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIncidents.Location = new System.Drawing.Point(7, 48);
            this.dgvIncidents.Name = "dgvIncidents";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIncidents.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIncidents.RowHeadersVisible = false;
            this.dgvIncidents.RowTemplate.ReadOnly = true;
            this.dgvIncidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidents.Size = new System.Drawing.Size(723, 196);
            this.dgvIncidents.TabIndex = 7;
            this.dgvIncidents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncidents_CellClick);
            // 
            // dgvcName
            // 
            this.dgvcName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcName.HeaderText = "Name";
            this.dgvcName.Name = "dgvcName";
            this.dgvcName.ReadOnly = true;
            // 
            // dgvcNotes
            // 
            this.dgvcNotes.HeaderText = "Notes";
            this.dgvcNotes.Name = "dgvcNotes";
            this.dgvcNotes.ReadOnly = true;
            this.dgvcNotes.Visible = false;
            // 
            // dgvcIncident
            // 
            this.dgvcIncident.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcIncident.HeaderText = "Incident";
            this.dgvcIncident.Name = "dgvcIncident";
            this.dgvcIncident.ReadOnly = true;
            // 
            // dgvcSolution
            // 
            this.dgvcSolution.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvcSolution.HeaderText = "Solution";
            this.dgvcSolution.Name = "dgvcSolution";
            this.dgvcSolution.ReadOnly = true;
            // 
            // btnSearchIncidents
            // 
            this.btnSearchIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchIncidents.Location = new System.Drawing.Point(515, 19);
            this.btnSearchIncidents.Name = "btnSearchIncidents";
            this.btnSearchIncidents.Size = new System.Drawing.Size(98, 23);
            this.btnSearchIncidents.TabIndex = 6;
            this.btnSearchIncidents.Text = "Find Next";
            this.btnSearchIncidents.UseVisualStyleBackColor = true;
            this.btnSearchIncidents.Click += new System.EventHandler(this.btnSearchIncidents_Click);
            // 
            // btnRefreshIncidents
            // 
            this.btnRefreshIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshIncidents.Location = new System.Drawing.Point(617, 19);
            this.btnRefreshIncidents.Name = "btnRefreshIncidents";
            this.btnRefreshIncidents.Size = new System.Drawing.Size(98, 23);
            this.btnRefreshIncidents.TabIndex = 5;
            this.btnRefreshIncidents.Text = "Refresh";
            this.btnRefreshIncidents.UseVisualStyleBackColor = true;
            this.btnRefreshIncidents.Click += new System.EventHandler(this.btnRefreshIncidents_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbProgress,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 585);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(761, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspbProgress
            // 
            this.tspbProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tspbProgress.Size = new System.Drawing.Size(200, 16);
            this.tspbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(63, 17);
            this.toolStripStatusLabel1.Text = "Status: Idle";
            this.toolStripStatusLabel1.TextChanged += new System.EventHandler(this.toolStripStatusLabel1_TextChanged);
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            // 
            // bWGetFiles
            // 
            this.bWGetFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bWGetFiles_DoWork);
            this.bWGetFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bWGetFiles_RunWorkerCompleted);
            // 
            // txtTotalReplacements
            // 
            this.txtTotalReplacements.AutoSize = true;
            this.txtTotalReplacements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalReplacements.Location = new System.Drawing.Point(6, 92);
            this.txtTotalReplacements.Name = "txtTotalReplacements";
            this.txtTotalReplacements.Size = new System.Drawing.Size(14, 13);
            this.txtTotalReplacements.TabIndex = 8;
            this.txtTotalReplacements.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 607);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic Converter - [Ver. 2.0]";
            this.Load += new System.EventHandler(this.AutomaticConverter_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpOverview.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfWorkers)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tpRules.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.tpRequestRule.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.tpIncidents.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFrom;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpOverview;
        private System.Windows.Forms.TabPage tpRules;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lbSavedRules;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNewEvent;
        private System.Windows.Forms.TextBox txtOldEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDeleteRule;
        private System.Windows.Forms.Button btnSaveRule;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtFromDirectory;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearFrom;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.CheckBox chkRegexMode;
        private System.Windows.Forms.Button btnShowResult;
        private System.Windows.Forms.CheckBox chkFilter;
        private System.Windows.Forms.CheckBox chkActionTB;
        private System.Windows.Forms.Button btnRefreshRules;
        private System.Windows.Forms.TabPage tpRequestRule;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox chkRequestActionTB;
        private System.Windows.Forms.CheckBox chkRequestFilterEv;
        private System.Windows.Forms.CheckBox chkRequestRegexM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRequestRuleName;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRequestReset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRequestNewEvent;
        private System.Windows.Forms.TextBox txtRequestOldEvent;
        private System.Windows.Forms.TabPage tpIncidents;
        private System.Windows.Forms.Button btnRefreshIncidents;
        private System.Windows.Forms.Button btnResetIncident;
        private System.Windows.Forms.Button btnSaveIncident;
        private System.Windows.Forms.Button btnAddIncident;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnSearchIncidents;
        private System.Windows.Forms.DataGridView dgvIncidents;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtIncidentNotes;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIncidentSolution;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIncident;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtIncidentName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtIncidentSearchText;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIncident;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSolution;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.CheckBox chkCaseSensitive;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudNumberOfWorkers;
        private System.Windows.Forms.Label lblGlobalStatus;
        private System.ComponentModel.BackgroundWorker bWGetFiles;
        private System.Windows.Forms.Label txtTotalReplacements;
    }
}

