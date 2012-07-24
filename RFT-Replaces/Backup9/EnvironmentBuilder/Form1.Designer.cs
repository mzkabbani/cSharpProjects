namespace EnvironmentBuilder {
    partial class EnvironmentBuilder {
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("doc");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ntclient");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("start");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("murex");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("download");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("mxres");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("public", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("conf");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("murex", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("conf");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("public", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("quality", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("fs", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode7,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("apps", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("env", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode14});
            this.tcTabControler = new System.Windows.Forms.TabControl();
            this.tpMainPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvFrontEnd = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lName = new System.Windows.Forms.Label();
            this.txtSelectedNodeName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tpConfiguration = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDirectoryHeirarchy = new System.Windows.Forms.TreeView();
            this.btnParseDTD = new System.Windows.Forms.Button();
            this.tvConfig = new System.Windows.Forms.TreeView();
            this.tcTabControler.SuspendLayout();
            this.tpMainPage.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tpConfiguration.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTabControler
            // 
            this.tcTabControler.Controls.Add(this.tpMainPage);
            this.tcTabControler.Controls.Add(this.tpConfiguration);
            this.tcTabControler.Location = new System.Drawing.Point(12, 12);
            this.tcTabControler.Name = "tcTabControler";
            this.tcTabControler.SelectedIndex = 0;
            this.tcTabControler.Size = new System.Drawing.Size(841, 545);
            this.tcTabControler.TabIndex = 0;
            // 
            // tpMainPage
            // 
            this.tpMainPage.Controls.Add(this.splitContainer2);
            this.tpMainPage.Location = new System.Drawing.Point(4, 22);
            this.tpMainPage.Name = "tpMainPage";
            this.tpMainPage.Padding = new System.Windows.Forms.Padding(3);
            this.tpMainPage.Size = new System.Drawing.Size(833, 519);
            this.tpMainPage.TabIndex = 0;
            this.tpMainPage.Text = "Main";
            this.tpMainPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvFrontEnd);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.textBox1);
            this.splitContainer2.Size = new System.Drawing.Size(827, 513);
            this.splitContainer2.SplitterDistance = 214;
            this.splitContainer2.TabIndex = 3;
            // 
            // tvFrontEnd
            // 
            this.tvFrontEnd.Location = new System.Drawing.Point(4, 4);
            this.tvFrontEnd.Name = "tvFrontEnd";
            this.tvFrontEnd.Size = new System.Drawing.Size(207, 449);
            this.tvFrontEnd.TabIndex = 0;
            this.tvFrontEnd.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFrontEnd_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.lName);
            this.groupBox1.Controls.Add(this.txtSelectedNodeName);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnAddChild);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 89);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Step 1: Tree Configuration";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(87, 54);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(6, 31);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(41, 13);
            this.lName.TabIndex = 3;
            this.lName.Text = "Name: ";
            // 
            // txtSelectedNodeName
            // 
            this.txtSelectedNodeName.Location = new System.Drawing.Point(53, 28);
            this.txtSelectedNodeName.Name = "txtSelectedNodeName";
            this.txtSelectedNodeName.ReadOnly = true;
            this.txtSelectedNodeName.Size = new System.Drawing.Size(190, 20);
            this.txtSelectedNodeName.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(168, 54);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAddChild
            // 
            this.btnAddChild.Enabled = false;
            this.btnAddChild.Location = new System.Drawing.Point(6, 54);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(75, 23);
            this.btnAddChild.TabIndex = 1;
            this.btnAddChild.Text = "Add Child";
            this.btnAddChild.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(349, 404);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tpConfiguration
            // 
            this.tpConfiguration.Controls.Add(this.splitContainer1);
            this.tpConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tpConfiguration.Name = "tpConfiguration";
            this.tpConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tpConfiguration.Size = new System.Drawing.Size(833, 519);
            this.tpConfiguration.TabIndex = 1;
            this.tpConfiguration.Text = "Configuration";
            this.tpConfiguration.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDirectoryHeirarchy);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tvConfig);
            this.splitContainer1.Panel2.Controls.Add(this.btnParseDTD);
            this.splitContainer1.Size = new System.Drawing.Size(827, 513);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvDirectoryHeirarchy
            // 
            this.tvDirectoryHeirarchy.Location = new System.Drawing.Point(4, 4);
            this.tvDirectoryHeirarchy.Name = "tvDirectoryHeirarchy";
            treeNode1.Name = "nDoc";
            treeNode1.Text = "doc";
            treeNode2.Name = "nNtClient";
            treeNode2.Text = "ntclient";
            treeNode3.Name = "nStart";
            treeNode3.Text = "start";
            treeNode4.Name = "nMurex";
            treeNode4.Text = "murex";
            treeNode5.Name = "nDownload";
            treeNode5.Text = "download";
            treeNode6.Name = "nMxres";
            treeNode6.Text = "mxres";
            treeNode7.Name = "nPublic";
            treeNode7.Text = "public";
            treeNode8.Name = "nConfMurex";
            treeNode8.Text = "conf";
            treeNode9.Name = "nMurexCon";
            treeNode9.Text = "murex";
            treeNode10.Name = "nPublicConf";
            treeNode10.Text = "conf";
            treeNode11.Name = "nPublicCon";
            treeNode11.Text = "public";
            treeNode12.Name = "nQuality";
            treeNode12.Text = "quality";
            treeNode13.Name = "nFs";
            treeNode13.Text = "fs";
            treeNode14.Name = "nApps";
            treeNode14.Text = "apps";
            treeNode15.Name = "nEnv";
            treeNode15.Text = "env";
            this.tvDirectoryHeirarchy.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode15});
            this.tvDirectoryHeirarchy.Size = new System.Drawing.Size(207, 459);
            this.tvDirectoryHeirarchy.TabIndex = 0;
            this.tvDirectoryHeirarchy.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDirectoryHeirarchy_AfterSelect);
            // 
            // btnParseDTD
            // 
            this.btnParseDTD.Location = new System.Drawing.Point(30, 19);
            this.btnParseDTD.Name = "btnParseDTD";
            this.btnParseDTD.Size = new System.Drawing.Size(75, 23);
            this.btnParseDTD.TabIndex = 0;
            this.btnParseDTD.Text = "Parse";
            this.btnParseDTD.UseVisualStyleBackColor = true;
            this.btnParseDTD.Click += new System.EventHandler(this.btnParseDTD_Click);
            // 
            // tvConfig
            // 
            this.tvConfig.Location = new System.Drawing.Point(358, 19);
            this.tvConfig.Name = "tvConfig";
            this.tvConfig.Size = new System.Drawing.Size(207, 459);
            this.tvConfig.TabIndex = 1;
            // 
            // EnvironmentBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 569);
            this.Controls.Add(this.tcTabControler);
            this.Name = "EnvironmentBuilder";
            this.Text = "Environment Builder";
            this.Load += new System.EventHandler(this.EnvironmentBuilder_Load);
            this.tcTabControler.ResumeLayout(false);
            this.tpMainPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tpConfiguration.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcTabControler;
        private System.Windows.Forms.TabPage tpMainPage;
        private System.Windows.Forms.TabPage tpConfiguration;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvDirectoryHeirarchy;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvFrontEnd;
        private System.Windows.Forms.TextBox txtSelectedNodeName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnParseDTD;
        private System.Windows.Forms.TreeView tvConfig;
    }
}

