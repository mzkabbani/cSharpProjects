namespace XmlParsersAndUi {
    partial class CleanupForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CleanupForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("RecommendationGroup 1", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("RecommendationGroup 2", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("RecommendationGroup 3", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("RecommendationGroup 4", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Recommendation",
            "",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Recommendation");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Recommendation");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Recommendation");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Recommendation");
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tvFilesAffected = new System.Windows.Forms.TreeView();
            this.ilImageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblOptionDetails = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputDir = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnReloadOptions = new System.Windows.Forms.Button();
            this.clbSelectedoptions = new System.Windows.Forms.CheckedListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 560);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnReset);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.btnStart);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(790, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Simple";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReset.Location = new System.Drawing.Point(575, 505);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(156, 23);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(413, 505);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show Backup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.tvFilesAffected);
            this.groupBox5.Location = new System.Drawing.Point(209, 280);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(572, 222);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Altered Files";
            // 
            // tvFilesAffected
            // 
            this.tvFilesAffected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFilesAffected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvFilesAffected.ImageIndex = 0;
            this.tvFilesAffected.ImageList = this.ilImageList;
            this.tvFilesAffected.Location = new System.Drawing.Point(3, 16);
            this.tvFilesAffected.Name = "tvFilesAffected";
            this.tvFilesAffected.SelectedImageIndex = 0;
            this.tvFilesAffected.Size = new System.Drawing.Size(566, 203);
            this.tvFilesAffected.TabIndex = 0;
            this.tvFilesAffected.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFilesAffected_NodeMouseDoubleClick);
            // 
            // ilImageList
            // 
            this.ilImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilImageList.ImageStream")));
            this.ilImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ilImageList.Images.SetKeyName(0, "folder_32.png");
            this.ilImageList.Images.SetKeyName(1, "file_icon.png");
            this.ilImageList.Images.SetKeyName(2, "circle_red_M1.jpg");
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.lblOptionDetails);
            this.groupBox7.Location = new System.Drawing.Point(209, 98);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(572, 176);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Option Details";
            // 
            // lblOptionDetails
            // 
            this.lblOptionDetails.AutoSize = true;
            this.lblOptionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOptionDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionDetails.Location = new System.Drawing.Point(3, 16);
            this.lblOptionDetails.Name = "lblOptionDetails";
            this.lblOptionDetails.Size = new System.Drawing.Size(41, 13);
            this.lblOptionDetails.TabIndex = 0;
            this.lblOptionDetails.Text = "label3";
            this.lblOptionDetails.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtInputDir);
            this.groupBox4.Controls.Add(this.btnBrowse);
            this.groupBox4.Location = new System.Drawing.Point(206, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(575, 86);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "I/O";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Input Directory:";
            // 
            // txtInputDir
            // 
            this.txtInputDir.Location = new System.Drawing.Point(91, 26);
            this.txtInputDir.Name = "txtInputDir";
            this.txtInputDir.Size = new System.Drawing.Size(444, 20);
            this.txtInputDir.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(541, 24);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnReloadOptions);
            this.groupBox3.Controls.Add(this.clbSelectedoptions);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 528);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // btnReloadOptions
            // 
            this.btnReloadOptions.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReloadOptions.Location = new System.Drawing.Point(20, 499);
            this.btnReloadOptions.Name = "btnReloadOptions";
            this.btnReloadOptions.Size = new System.Drawing.Size(156, 23);
            this.btnReloadOptions.TabIndex = 0;
            this.btnReloadOptions.Text = "Reload Options";
            this.btnReloadOptions.UseVisualStyleBackColor = true;
            this.btnReloadOptions.Click += new System.EventHandler(this.btnReloadOptions_Click);
            // 
            // clbSelectedoptions
            // 
            this.clbSelectedoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbSelectedoptions.FormattingEnabled = true;
            this.clbSelectedoptions.Location = new System.Drawing.Point(7, 20);
            this.clbSelectedoptions.Name = "clbSelectedoptions";
            this.clbSelectedoptions.Size = new System.Drawing.Size(175, 469);
            this.clbSelectedoptions.TabIndex = 0;
            this.clbSelectedoptions.SelectedIndexChanged += new System.EventHandler(this.clbSelectedoptions_SelectedIndexChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.Location = new System.Drawing.Point(251, 505);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(156, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(790, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Advanced";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            this.splitContainer1.Panel1.Enabled = false;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Size = new System.Drawing.Size(784, 528);
            this.splitContainer1.SplitterDistance = 174;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Applicable Recommendations By Category";
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            listViewGroup1.Header = "RecommendationGroup 1";
            listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup1.Name = "RecommendationGroup1";
            listViewGroup2.Header = "RecommendationGroup 2";
            listViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "RecommendationGroup 3";
            listViewGroup3.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup3.Name = "listViewGroup3";
            listViewGroup4.Header = "RecommendationGroup 4";
            listViewGroup4.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup4.Name = "listViewGroup4";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup2;
            listViewItem3.Group = listViewGroup3;
            listViewItem4.Group = listViewGroup4;
            listViewItem5.Group = listViewGroup1;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listView1.Location = new System.Drawing.Point(3, 38);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(235, 467);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.checkedListBox2);
            this.groupBox2.Location = new System.Drawing.Point(13, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(834, 385);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "After";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(161, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Before";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(488, 49);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(318, 301);
            this.textBox4.TabIndex = 15;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(164, 49);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(318, 301);
            this.textBox3.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Targeted Files";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(362, 356);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(164, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Perform Selected";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "Event File 1",
            "Event File 2",
            "Event File 3",
            "Event File 4",
            "Event File 5",
            "Event File 6",
            "Event File 7",
            "Event File 8",
            "Event File 9",
            "Event File 10"});
            this.checkedListBox2.Location = new System.Drawing.Point(6, 49);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(143, 229);
            this.checkedListBox2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(13, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(834, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recommendation Details";
            // 
            // CleanupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 560);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CleanupForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "First Level Cleanup";
            this.Load += new System.EventHandler(this.CleanupForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInputDir;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clbSelectedoptions;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TreeView tvFilesAffected;
        private System.Windows.Forms.Label lblOptionDetails;
        private System.Windows.Forms.ImageList ilImageList;
        private System.Windows.Forms.Button btnReloadOptions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReset;

    }
}