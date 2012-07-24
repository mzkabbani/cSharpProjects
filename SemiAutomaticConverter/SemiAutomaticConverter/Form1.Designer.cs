namespace SemiAutomaticConverter
{
    partial class AutomaticConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutomaticConverter));
            this.btnBrowseFrom = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpOverview = new System.Windows.Forms.TabPage();
            this.btnShowResult = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnAddCP = new System.Windows.Forms.Button();
            this.btnAddHA = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHADirectory = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowseHADir = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearFrom = new System.Windows.Forms.Button();
            this.btnClearTo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFromDirectory = new System.Windows.Forms.TextBox();
            this.txtToDirectory = new System.Windows.Forms.TextBox();
            this.btnBrowseTo = new System.Windows.Forms.Button();
            this.tpRules = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkActionTB = new System.Windows.Forms.CheckBox();
            this.chkFilter = new System.Windows.Forms.CheckBox();
            this.chkRegexMode = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.btnDeleteRule = new System.Windows.Forms.Button();
            this.btnSaveRule = new System.Windows.Forms.Button();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewEvent = new System.Windows.Forms.TextBox();
            this.txtOldEvent = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefreshRules = new System.Windows.Forms.Button();
            this.lbSavedRules = new System.Windows.Forms.ListBox();
            this.tpRequestRule = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkRequestActionTB = new System.Windows.Forms.CheckBox();
            this.chkRequestFilterEv = new System.Windows.Forms.CheckBox();
            this.chkRequestRegexM = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRequestRuleName = new System.Windows.Forms.TextBox();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRequestReset = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRequestNewEvent = new System.Windows.Forms.TextBox();
            this.txtRequestOldEvent = new System.Windows.Forms.TextBox();
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
            this.label15 = new System.Windows.Forms.Label();
            this.txtIncidentSearchText = new System.Windows.Forms.TextBox();
            this.dgvIncidents = new System.Windows.Forms.DataGridView();
            this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIncident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSolution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearchIncidents = new System.Windows.Forms.Button();
            this.btnRefreshIncidents = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpOverview.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tpRules.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpRequestRule.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tpIncidents.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowseFrom
            // 
            this.btnBrowseFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseFrom.Location = new System.Drawing.Point(513, 26);
            this.btnBrowseFrom.Name = "btnBrowseFrom";
            this.btnBrowseFrom.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFrom.TabIndex = 1;
            this.btnBrowseFrom.Text = "Browse";
            this.btnBrowseFrom.UseVisualStyleBackColor = true;
            this.btnBrowseFrom.Click += new System.EventHandler(this.btnBrowseFrom_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpOverview);
            this.tabControl1.Controls.Add(this.tpRules);
            this.tabControl1.Controls.Add(this.tpRequestRule);
            this.tabControl1.Controls.Add(this.tpIncidents);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(761, 615);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpOverview
            // 
            this.tpOverview.Controls.Add(this.btnShowResult);
            this.tpOverview.Controls.Add(this.groupBox5);
            this.tpOverview.Controls.Add(this.btnParse);
            this.tpOverview.Controls.Add(this.groupBox4);
            this.tpOverview.Controls.Add(this.groupBox3);
            this.tpOverview.Location = new System.Drawing.Point(4, 22);
            this.tpOverview.Name = "tpOverview";
            this.tpOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tpOverview.Size = new System.Drawing.Size(753, 589);
            this.tpOverview.TabIndex = 0;
            this.tpOverview.Text = "Overview";
            this.tpOverview.UseVisualStyleBackColor = true;
            // 
            // btnShowResult
            // 
            this.btnShowResult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowResult.Enabled = false;
            this.btnShowResult.Location = new System.Drawing.Point(379, 113);
            this.btnShowResult.Name = "btnShowResult";
            this.btnShowResult.Size = new System.Drawing.Size(93, 23);
            this.btnShowResult.TabIndex = 2;
            this.btnShowResult.Text = "Show Result";
            this.btnShowResult.UseVisualStyleBackColor = true;
            this.btnShowResult.Click += new System.EventHandler(this.btnShowResult_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Location = new System.Drawing.Point(6, 142);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(716, 205);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Additional operations";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnAddCP);
            this.groupBox6.Controls.Add(this.btnAddHA);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.txtHADirectory);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.btnBrowseHADir);
            this.groupBox6.Location = new System.Drawing.Point(6, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(704, 100);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Add help about";
            // 
            // btnAddCP
            // 
            this.btnAddCP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddCP.Location = new System.Drawing.Point(355, 53);
            this.btnAddCP.Name = "btnAddCP";
            this.btnAddCP.Size = new System.Drawing.Size(93, 23);
            this.btnAddCP.TabIndex = 5;
            this.btnAddCP.Text = "Add Conn. Par.";
            this.btnAddCP.UseVisualStyleBackColor = true;
            this.btnAddCP.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddHA
            // 
            this.btnAddHA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddHA.Location = new System.Drawing.Point(256, 53);
            this.btnAddHA.Name = "btnAddHA";
            this.btnAddHA.Size = new System.Drawing.Size(93, 23);
            this.btnAddHA.TabIndex = 4;
            this.btnAddHA.Text = "Add H/A";
            this.btnAddHA.UseVisualStyleBackColor = true;
            this.btnAddHA.Click += new System.EventHandler(this.btnAddHA_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Directory:";
            // 
            // txtHADirectory
            // 
            this.txtHADirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHADirectory.Location = new System.Drawing.Point(89, 27);
            this.txtHADirectory.Name = "txtHADirectory";
            this.txtHADirectory.Size = new System.Drawing.Size(450, 20);
            this.txtHADirectory.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-220, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "To Directory:";
            // 
            // btnBrowseHADir
            // 
            this.btnBrowseHADir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBrowseHADir.Location = new System.Drawing.Point(545, 25);
            this.btnBrowseHADir.Name = "btnBrowseHADir";
            this.btnBrowseHADir.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseHADir.TabIndex = 3;
            this.btnBrowseHADir.Text = "Browse";
            this.btnBrowseHADir.UseVisualStyleBackColor = true;
            this.btnBrowseHADir.Click += new System.EventHandler(this.btnBrowseHADir_Click);
            // 
            // btnParse
            // 
            this.btnParse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnParse.Location = new System.Drawing.Point(280, 113);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(93, 23);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtLog);
            this.groupBox4.Location = new System.Drawing.Point(6, 353);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(716, 176);
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
            this.txtLog.Size = new System.Drawing.Size(710, 157);
            this.txtLog.TabIndex = 0;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnClearFrom);
            this.groupBox3.Controls.Add(this.btnClearTo);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtFromDirectory);
            this.groupBox3.Controls.Add(this.txtToDirectory);
            this.groupBox3.Controls.Add(this.btnBrowseFrom);
            this.groupBox3.Controls.Add(this.btnBrowseTo);
            this.groupBox3.Location = new System.Drawing.Point(6, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(716, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setup";
            // 
            // btnClearFrom
            // 
            this.btnClearFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFrom.Location = new System.Drawing.Point(594, 26);
            this.btnClearFrom.Name = "btnClearFrom";
            this.btnClearFrom.Size = new System.Drawing.Size(75, 23);
            this.btnClearFrom.TabIndex = 2;
            this.btnClearFrom.Text = "Clear";
            this.btnClearFrom.UseVisualStyleBackColor = true;
            this.btnClearFrom.Click += new System.EventHandler(this.btnClearFrom_Click);
            // 
            // btnClearTo
            // 
            this.btnClearTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearTo.Location = new System.Drawing.Point(594, 55);
            this.btnClearTo.Name = "btnClearTo";
            this.btnClearTo.Size = new System.Drawing.Size(75, 23);
            this.btnClearTo.TabIndex = 5;
            this.btnClearTo.Text = "Clear";
            this.btnClearTo.UseVisualStyleBackColor = true;
            this.btnClearTo.Click += new System.EventHandler(this.btnClearTo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "To Directory:";
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
            this.txtFromDirectory.Location = new System.Drawing.Point(95, 29);
            this.txtFromDirectory.Name = "txtFromDirectory";
            this.txtFromDirectory.Size = new System.Drawing.Size(412, 20);
            this.txtFromDirectory.TabIndex = 0;
            // 
            // txtToDirectory
            // 
            this.txtToDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToDirectory.Location = new System.Drawing.Point(95, 58);
            this.txtToDirectory.Name = "txtToDirectory";
            this.txtToDirectory.Size = new System.Drawing.Size(412, 20);
            this.txtToDirectory.TabIndex = 3;
            // 
            // btnBrowseTo
            // 
            this.btnBrowseTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseTo.Location = new System.Drawing.Point(513, 55);
            this.btnBrowseTo.Name = "btnBrowseTo";
            this.btnBrowseTo.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTo.TabIndex = 4;
            this.btnBrowseTo.Text = "Browse";
            this.btnBrowseTo.UseVisualStyleBackColor = true;
            this.btnBrowseTo.Click += new System.EventHandler(this.btnBrowseTo_Click);
            // 
            // tpRules
            // 
            this.tpRules.Controls.Add(this.groupBox2);
            this.tpRules.Controls.Add(this.groupBox1);
            this.tpRules.Location = new System.Drawing.Point(4, 22);
            this.tpRules.Name = "tpRules";
            this.tpRules.Padding = new System.Windows.Forms.Padding(3);
            this.tpRules.Size = new System.Drawing.Size(753, 589);
            this.tpRules.TabIndex = 1;
            this.tpRules.Text = "Rules";
            this.tpRules.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkActionTB);
            this.groupBox2.Controls.Add(this.chkFilter);
            this.groupBox2.Controls.Add(this.chkRegexMode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRuleName);
            this.groupBox2.Controls.Add(this.btnDeleteRule);
            this.groupBox2.Controls.Add(this.btnSaveRule);
            this.groupBox2.Controls.Add(this.btnAddRule);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNewEvent);
            this.groupBox2.Controls.Add(this.txtOldEvent);
            this.groupBox2.Location = new System.Drawing.Point(206, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 545);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rules";
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
            this.btnDeleteRule.Location = new System.Drawing.Point(381, 506);
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
            this.btnSaveRule.Location = new System.Drawing.Point(141, 506);
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
            this.btnAddRule.Location = new System.Drawing.Point(21, 506);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(114, 23);
            this.btnAddRule.TabIndex = 6;
            this.btnAddRule.Text = "Add";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "New event:";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReset.Location = new System.Drawing.Point(261, 506);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(114, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Old event:";
            // 
            // txtNewEvent
            // 
            this.txtNewEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewEvent.Location = new System.Drawing.Point(77, 288);
            this.txtNewEvent.Multiline = true;
            this.txtNewEvent.Name = "txtNewEvent";
            this.txtNewEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewEvent.Size = new System.Drawing.Size(433, 203);
            this.txtNewEvent.TabIndex = 5;
            // 
            // txtOldEvent
            // 
            this.txtOldEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOldEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldEvent.Location = new System.Drawing.Point(77, 56);
            this.txtOldEvent.Multiline = true;
            this.txtOldEvent.Name = "txtOldEvent";
            this.txtOldEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOldEvent.Size = new System.Drawing.Size(433, 203);
            this.txtOldEvent.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnRefreshRules);
            this.groupBox1.Controls.Add(this.lbSavedRules);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 546);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saved rules";
            // 
            // btnRefreshRules
            // 
            this.btnRefreshRules.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRefreshRules.Location = new System.Drawing.Point(39, 507);
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
            this.lbSavedRules.Location = new System.Drawing.Point(6, 19);
            this.lbSavedRules.Name = "lbSavedRules";
            this.lbSavedRules.Size = new System.Drawing.Size(181, 472);
            this.lbSavedRules.TabIndex = 0;
            this.lbSavedRules.SelectedIndexChanged += new System.EventHandler(this.lbSavedRules_SelectedIndexChanged);
            // 
            // tpRequestRule
            // 
            this.tpRequestRule.Controls.Add(this.groupBox7);
            this.tpRequestRule.Location = new System.Drawing.Point(4, 22);
            this.tpRequestRule.Name = "tpRequestRule";
            this.tpRequestRule.Size = new System.Drawing.Size(753, 589);
            this.tpRequestRule.TabIndex = 2;
            this.tpRequestRule.Text = "Request Rule";
            this.tpRequestRule.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.chkRequestActionTB);
            this.groupBox7.Controls.Add(this.chkRequestFilterEv);
            this.groupBox7.Controls.Add(this.chkRequestRegexM);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.txtRequestRuleName);
            this.groupBox7.Controls.Add(this.btnSendRequest);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.btnRequestReset);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.txtRequestNewEvent);
            this.groupBox7.Controls.Add(this.txtRequestOldEvent);
            this.groupBox7.Location = new System.Drawing.Point(8, 7);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(737, 545);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Rule Request";
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
            this.btnSendRequest.Location = new System.Drawing.Point(251, 506);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(114, 23);
            this.btnSendRequest.TabIndex = 6;
            this.btnSendRequest.Text = "Send";
            this.btnSendRequest.UseVisualStyleBackColor = true;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "New event:";
            // 
            // btnRequestReset
            // 
            this.btnRequestReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRequestReset.Location = new System.Drawing.Point(371, 506);
            this.btnRequestReset.Name = "btnRequestReset";
            this.btnRequestReset.Size = new System.Drawing.Size(114, 23);
            this.btnRequestReset.TabIndex = 8;
            this.btnRequestReset.Text = "Reset";
            this.btnRequestReset.UseVisualStyleBackColor = true;
            this.btnRequestReset.Click += new System.EventHandler(this.btnRequestReset_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Old event:";
            // 
            // txtRequestNewEvent
            // 
            this.txtRequestNewEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequestNewEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestNewEvent.Location = new System.Drawing.Point(77, 288);
            this.txtRequestNewEvent.Multiline = true;
            this.txtRequestNewEvent.Name = "txtRequestNewEvent";
            this.txtRequestNewEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequestNewEvent.Size = new System.Drawing.Size(654, 203);
            this.txtRequestNewEvent.TabIndex = 5;
            // 
            // txtRequestOldEvent
            // 
            this.txtRequestOldEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequestOldEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestOldEvent.Location = new System.Drawing.Point(77, 56);
            this.txtRequestOldEvent.Multiline = true;
            this.txtRequestOldEvent.Name = "txtRequestOldEvent";
            this.txtRequestOldEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequestOldEvent.Size = new System.Drawing.Size(654, 203);
            this.txtRequestOldEvent.TabIndex = 4;
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
            this.tpIncidents.Size = new System.Drawing.Size(753, 589);
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
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.txtIncidentSearchText);
            this.groupBox8.Controls.Add(this.dgvIncidents);
            this.groupBox8.Controls.Add(this.btnSearchIncidents);
            this.groupBox8.Controls.Add(this.btnRefreshIncidents);
            this.groupBox8.Location = new System.Drawing.Point(9, 297);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(736, 255);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Incidents";
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
            this.txtIncidentSearchText.Size = new System.Drawing.Size(429, 20);
            this.txtIncidentSearchText.TabIndex = 8;
            // 
            // dgvIncidents
            // 
            this.dgvIncidents.AllowUserToAddRows = false;
            this.dgvIncidents.AllowUserToDeleteRows = false;
            this.dgvIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncidents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcName,
            this.dgvcNotes,
            this.dgvcIncident,
            this.dgvcSolution});
            this.dgvIncidents.Location = new System.Drawing.Point(7, 48);
            this.dgvIncidents.Name = "dgvIncidents";
            this.dgvIncidents.RowHeadersVisible = false;
            this.dgvIncidents.RowTemplate.ReadOnly = true;
            this.dgvIncidents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncidents.Size = new System.Drawing.Size(723, 198);
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
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.Location = new System.Drawing.Point(323, 580);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AutomaticConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 615);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutomaticConverter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic Converter - [Ver. 1.1]";
            this.Load += new System.EventHandler(this.AutomaticConverter_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpOverview.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tpRules.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tpRequestRule.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tpIncidents.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncidents)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnBrowseTo;
        private System.Windows.Forms.TextBox txtToDirectory;
        private System.Windows.Forms.TextBox txtFromDirectory;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearFrom;
        private System.Windows.Forms.Button btnClearTo;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.CheckBox chkRegexMode;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnShowResult;
        private System.Windows.Forms.CheckBox chkFilter;
        private System.Windows.Forms.CheckBox chkActionTB;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtHADirectory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowseHADir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddHA;
        private System.Windows.Forms.Button btnRefreshRules;
        private System.Windows.Forms.Button btnAddCP;
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
    }
}

