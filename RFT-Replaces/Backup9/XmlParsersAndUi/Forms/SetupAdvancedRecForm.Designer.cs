namespace XmlParsersAndUi {
    partial class SetupAdvancedRecForm {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbAdvancedCE = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.grpBoxAttr = new System.Windows.Forms.GroupBox();
            this.dgvAttributes = new System.Windows.Forms.DataGridView();
            this.tvOutput = new System.Windows.Forms.TreeView();
            this.btnAddCaptureEvent = new System.Windows.Forms.Button();
            this.btnResetAO = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAODescription = new System.Windows.Forms.TextBox();
            this.txtEventIn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAOName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtFoundEvents = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbOptions = new System.Windows.Forms.ListBox();
            this.btnReloadOptions = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtOptionReplacement = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOptionDesc = new System.Windows.Forms.TextBox();
            this.txtOptionPattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsRegex = new System.Windows.Forms.CheckBox();
            this.txtOptionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.useAttribute = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpBoxAttr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(949, 556);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(941, 530);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Capture Events";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 518);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option Definition";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbAdvancedCE);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 499);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Options";
            // 
            // lbAdvancedCE
            // 
            this.lbAdvancedCE.FormattingEnabled = true;
            this.lbAdvancedCE.Location = new System.Drawing.Point(7, 15);
            this.lbAdvancedCE.Name = "lbAdvancedCE";
            this.lbAdvancedCE.Size = new System.Drawing.Size(184, 394);
            this.lbAdvancedCE.TabIndex = 22;
            this.lbAdvancedCE.SelectedIndexChanged += new System.EventHandler(this.lbAdvancedCE_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(20, 469);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Reload Options";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnParse);
            this.groupBox5.Controls.Add(this.grpBoxAttr);
            this.groupBox5.Controls.Add(this.tvOutput);
            this.groupBox5.Controls.Add(this.btnAddCaptureEvent);
            this.groupBox5.Controls.Add(this.btnResetAO);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtAODescription);
            this.groupBox5.Controls.Add(this.txtEventIn);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtAOName);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(206, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(723, 493);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Definition";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(9, 230);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(156, 23);
            this.btnParse.TabIndex = 16;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // grpBoxAttr
            // 
            this.grpBoxAttr.Controls.Add(this.dgvAttributes);
            this.grpBoxAttr.Location = new System.Drawing.Point(238, 230);
            this.grpBoxAttr.Name = "grpBoxAttr";
            this.grpBoxAttr.Size = new System.Drawing.Size(479, 228);
            this.grpBoxAttr.TabIndex = 15;
            this.grpBoxAttr.TabStop = false;
            this.grpBoxAttr.Text = "Attributes";
            // 
            // dgvAttributes
            // 
            this.dgvAttributes.AllowUserToAddRows = false;
            this.dgvAttributes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAttributes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvAttributes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.useAttribute,
            this.Attribute,
            this.Value});
            this.dgvAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttributes.Location = new System.Drawing.Point(3, 16);
            this.dgvAttributes.Name = "dgvAttributes";
            this.dgvAttributes.RowHeadersVisible = false;
            this.dgvAttributes.Size = new System.Drawing.Size(473, 209);
            this.dgvAttributes.TabIndex = 0;
            // 
            // tvOutput
            // 
            this.tvOutput.CheckBoxes = true;
            this.tvOutput.Location = new System.Drawing.Point(9, 276);
            this.tvOutput.Name = "tvOutput";
            this.tvOutput.Size = new System.Drawing.Size(223, 177);
            this.tvOutput.TabIndex = 14;
            this.tvOutput.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOutput_AfterSelect);
            this.tvOutput.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvOutput_BeforeSelect);
            // 
            // btnAddCaptureEvent
            // 
            this.btnAddCaptureEvent.Location = new System.Drawing.Point(29, 464);
            this.btnAddCaptureEvent.Name = "btnAddCaptureEvent";
            this.btnAddCaptureEvent.Size = new System.Drawing.Size(156, 23);
            this.btnAddCaptureEvent.TabIndex = 5;
            this.btnAddCaptureEvent.Text = "Add";
            this.btnAddCaptureEvent.UseVisualStyleBackColor = true;
            this.btnAddCaptureEvent.Click += new System.EventHandler(this.btnAddCaptureEvent_Click);
            // 
            // btnResetAO
            // 
            this.btnResetAO.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnResetAO.Location = new System.Drawing.Point(444, 464);
            this.btnResetAO.Name = "btnResetAO";
            this.btnResetAO.Size = new System.Drawing.Size(156, 23);
            this.btnResetAO.TabIndex = 7;
            this.btnResetAO.Text = "Reset";
            this.btnResetAO.UseVisualStyleBackColor = true;
            this.btnResetAO.Click += new System.EventHandler(this.btnResetAO_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(191, 464);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Capture Points:";
            // 
            // txtAODescription
            // 
            this.txtAODescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAODescription.Location = new System.Drawing.Point(9, 58);
            this.txtAODescription.Multiline = true;
            this.txtAODescription.Name = "txtAODescription";
            this.txtAODescription.Size = new System.Drawing.Size(708, 52);
            this.txtAODescription.TabIndex = 1;
            // 
            // txtEventIn
            // 
            this.txtEventIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEventIn.Location = new System.Drawing.Point(9, 141);
            this.txtEventIn.Multiline = true;
            this.txtEventIn.Name = "txtEventIn";
            this.txtEventIn.Size = new System.Drawing.Size(704, 83);
            this.txtEventIn.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Input Event:";
            // 
            // txtAOName
            // 
            this.txtAOName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAOName.Location = new System.Drawing.Point(51, 19);
            this.txtAOName.Name = "txtAOName";
            this.txtAOName.Size = new System.Drawing.Size(254, 20);
            this.txtAOName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtFoundEvents);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(941, 530);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtFoundEvents
            // 
            this.txtFoundEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFoundEvents.Location = new System.Drawing.Point(3, 3);
            this.txtFoundEvents.Multiline = true;
            this.txtFoundEvents.Name = "txtFoundEvents";
            this.txtFoundEvents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFoundEvents.Size = new System.Drawing.Size(935, 524);
            this.txtFoundEvents.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbOptions);
            this.groupBox4.Controls.Add(this.btnReloadOptions);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 445);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Available Options";
            // 
            // lbOptions
            // 
            this.lbOptions.FormattingEnabled = true;
            this.lbOptions.Location = new System.Drawing.Point(7, 15);
            this.lbOptions.Name = "lbOptions";
            this.lbOptions.Size = new System.Drawing.Size(184, 394);
            this.lbOptions.TabIndex = 22;
            // 
            // btnReloadOptions
            // 
            this.btnReloadOptions.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReloadOptions.Location = new System.Drawing.Point(20, 415);
            this.btnReloadOptions.Name = "btnReloadOptions";
            this.btnReloadOptions.Size = new System.Drawing.Size(156, 23);
            this.btnReloadOptions.TabIndex = 0;
            this.btnReloadOptions.Text = "Reload Options";
            this.btnReloadOptions.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnReset);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.txtOptionReplacement);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtOptionDesc);
            this.groupBox3.Controls.Add(this.txtOptionPattern);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.chkIsRegex);
            this.groupBox3.Controls.Add(this.txtOptionName);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(206, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(521, 441);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Definition";
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(21, 412);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReset.Location = new System.Drawing.Point(343, 412);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(156, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(183, 412);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtOptionReplacement
            // 
            this.txtOptionReplacement.Location = new System.Drawing.Point(13, 311);
            this.txtOptionReplacement.Multiline = true;
            this.txtOptionReplacement.Name = "txtOptionReplacement";
            this.txtOptionReplacement.Size = new System.Drawing.Size(498, 83);
            this.txtOptionReplacement.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Replacement:";
            // 
            // txtOptionDesc
            // 
            this.txtOptionDesc.Location = new System.Drawing.Point(13, 75);
            this.txtOptionDesc.Multiline = true;
            this.txtOptionDesc.Name = "txtOptionDesc";
            this.txtOptionDesc.Size = new System.Drawing.Size(498, 83);
            this.txtOptionDesc.TabIndex = 1;
            // 
            // txtOptionPattern
            // 
            this.txtOptionPattern.Location = new System.Drawing.Point(13, 193);
            this.txtOptionPattern.Multiline = true;
            this.txtOptionPattern.Name = "txtOptionPattern";
            this.txtOptionPattern.Size = new System.Drawing.Size(498, 83);
            this.txtOptionPattern.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pattern:";
            // 
            // chkIsRegex
            // 
            this.chkIsRegex.AutoSize = true;
            this.chkIsRegex.Location = new System.Drawing.Point(454, 173);
            this.chkIsRegex.Name = "chkIsRegex";
            this.chkIsRegex.Size = new System.Drawing.Size(57, 17);
            this.chkIsRegex.TabIndex = 2;
            this.chkIsRegex.Text = "Regex";
            this.chkIsRegex.UseVisualStyleBackColor = true;
            // 
            // txtOptionName
            // 
            this.txtOptionName.Location = new System.Drawing.Point(51, 19);
            this.txtOptionName.Name = "txtOptionName";
            this.txtOptionName.Size = new System.Drawing.Size(254, 20);
            this.txtOptionName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // useAttribute
            // 
            this.useAttribute.HeaderText = "Enabled";
            this.useAttribute.Name = "useAttribute";
            this.useAttribute.Width = 52;
            // 
            // Attribute
            // 
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.Name = "Attribute";
            this.Attribute.ReadOnly = true;
            this.Attribute.Width = 71;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Width = 59;
            // 
            // SetupAdvancedRecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 580);
            this.Controls.Add(this.tabControl1);
            this.Name = "SetupAdvancedRecForm";
            this.Text = "SetupAdvancedRecForm";
            this.Load += new System.EventHandler(this.SetupAdvancedRecForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.grpBoxAttr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbAdvancedCE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAddCaptureEvent;
        private System.Windows.Forms.Button btnResetAO;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAODescription;
        private System.Windows.Forms.TextBox txtEventIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAOName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbOptions;
        private System.Windows.Forms.Button btnReloadOptions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtOptionReplacement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOptionDesc;
        private System.Windows.Forms.TextBox txtOptionPattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsRegex;
        private System.Windows.Forms.TextBox txtOptionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBoxAttr;
        private System.Windows.Forms.TreeView tvOutput;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.TextBox txtFoundEvents;
        private System.Windows.Forms.DataGridViewCheckBoxColumn useAttribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}