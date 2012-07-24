namespace XmlParsersAndUi {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.parsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macroSplitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstLevelCleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkCustomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rFTUpdaterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupRecommendationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedRecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testExceptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.nicknameSpecificToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsAppStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsConnectedTo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.remoteServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parsersToolStripMenuItem,
            this.configurationsToolStripMenuItem,
            this.windowsMenu,
            this.testingToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(834, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // parsersToolStripMenuItem
            // 
            this.parsersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleOperationToolStripMenuItem,
            this.advancedOperationToolStripMenuItem,
            this.helpersToolStripMenuItem});
            this.parsersToolStripMenuItem.Name = "parsersToolStripMenuItem";
            this.parsersToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.parsersToolStripMenuItem.Text = "Parsers";
            // 
            // simpleOperationToolStripMenuItem
            // 
            this.simpleOperationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.macroSplitToolStripMenuItem,
            this.firstLevelCleanupToolStripMenuItem});
            this.simpleOperationToolStripMenuItem.Name = "simpleOperationToolStripMenuItem";
            this.simpleOperationToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.simpleOperationToolStripMenuItem.Text = "Simple Operation";
            this.simpleOperationToolStripMenuItem.Click += new System.EventHandler(this.simpleOperationToolStripMenuItem_Click);
            // 
            // macroSplitToolStripMenuItem
            // 
            this.macroSplitToolStripMenuItem.Name = "macroSplitToolStripMenuItem";
            this.macroSplitToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.macroSplitToolStripMenuItem.Text = "Macro Split";
            this.macroSplitToolStripMenuItem.Click += new System.EventHandler(this.macroSplitToolStripMenuItem_Click);
            // 
            // firstLevelCleanupToolStripMenuItem
            // 
            this.firstLevelCleanupToolStripMenuItem.Name = "firstLevelCleanupToolStripMenuItem";
            this.firstLevelCleanupToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.firstLevelCleanupToolStripMenuItem.Text = "First Level Cleanup";
            this.firstLevelCleanupToolStripMenuItem.Click += new System.EventHandler(this.firstLevelCleanupToolStripMenuItem_Click);
            // 
            // advancedOperationToolStripMenuItem
            // 
            this.advancedOperationToolStripMenuItem.Name = "advancedOperationToolStripMenuItem";
            this.advancedOperationToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.advancedOperationToolStripMenuItem.Text = "Advanced Operation";
            this.advancedOperationToolStripMenuItem.Click += new System.EventHandler(this.advancedOperationToolStripMenuItem_Click);
            // 
            // helpersToolStripMenuItem
            // 
            this.helpersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bulkCustomsToolStripMenuItem,
            this.rFTUpdaterToolStripMenuItem});
            this.helpersToolStripMenuItem.Name = "helpersToolStripMenuItem";
            this.helpersToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.helpersToolStripMenuItem.Text = "Helpers";
            // 
            // bulkCustomsToolStripMenuItem
            // 
            this.bulkCustomsToolStripMenuItem.Name = "bulkCustomsToolStripMenuItem";
            this.bulkCustomsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.bulkCustomsToolStripMenuItem.Text = "Bulk Customs";
            this.bulkCustomsToolStripMenuItem.Click += new System.EventHandler(this.bulkCustomsToolStripMenuItem_Click);
            // 
            // rFTUpdaterToolStripMenuItem
            // 
            this.rFTUpdaterToolStripMenuItem.Name = "rFTUpdaterToolStripMenuItem";
            this.rFTUpdaterToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.rFTUpdaterToolStripMenuItem.Text = "RFT Updater";
            this.rFTUpdaterToolStripMenuItem.Click += new System.EventHandler(this.rFTUpdaterToolStripMenuItem_Click);
            // 
            // configurationsToolStripMenuItem
            // 
            this.configurationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupRecommendationsToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.configurationsToolStripMenuItem.Name = "configurationsToolStripMenuItem";
            this.configurationsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.configurationsToolStripMenuItem.Text = "Configuration";
            // 
            // setupRecommendationsToolStripMenuItem
            // 
            this.setupRecommendationsToolStripMenuItem.Name = "setupRecommendationsToolStripMenuItem";
            this.setupRecommendationsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.setupRecommendationsToolStripMenuItem.Text = "Setup Recommendations";
            this.setupRecommendationsToolStripMenuItem.Visible = false;
            this.setupRecommendationsToolStripMenuItem.Click += new System.EventHandler(this.setupRecommendationsToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Visible = false;
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(62, 20);
            this.windowsMenu.Text = "&Windows";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // testingToolStripMenuItem
            // 
            this.testingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanupToolStripMenuItem,
            this.form1ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.advancedRecToolStripMenuItem,
            this.testExceptionToolStripMenuItem,
            this.userStatusToolStripMenuItem,
            this.toolStripMenuItem2,
            this.nicknameSpecificToolStripMenuItem,
            this.form2ToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.remoteServerToolStripMenuItem});
            this.testingToolStripMenuItem.Name = "testingToolStripMenuItem";
            this.testingToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.testingToolStripMenuItem.Text = "Testing";
            this.testingToolStripMenuItem.Visible = false;
            // 
            // cleanupToolStripMenuItem
            // 
            this.cleanupToolStripMenuItem.Name = "cleanupToolStripMenuItem";
            this.cleanupToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cleanupToolStripMenuItem.Text = "Cleanup ";
            this.cleanupToolStripMenuItem.Click += new System.EventHandler(this.cleanupToolStripMenuItem_Click);
            // 
            // form1ToolStripMenuItem
            // 
            this.form1ToolStripMenuItem.Name = "form1ToolStripMenuItem";
            this.form1ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.form1ToolStripMenuItem.Text = "Form1";
            this.form1ToolStripMenuItem.Click += new System.EventHandler(this.form1ToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.toolStripMenuItem1.Text = "Database Viewer";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // advancedRecToolStripMenuItem
            // 
            this.advancedRecToolStripMenuItem.Name = "advancedRecToolStripMenuItem";
            this.advancedRecToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.advancedRecToolStripMenuItem.Text = "Advanced Rec";
            this.advancedRecToolStripMenuItem.Click += new System.EventHandler(this.advancedRecToolStripMenuItem_Click);
            // 
            // testExceptionToolStripMenuItem
            // 
            this.testExceptionToolStripMenuItem.Name = "testExceptionToolStripMenuItem";
            this.testExceptionToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.testExceptionToolStripMenuItem.Text = "TestException";
            this.testExceptionToolStripMenuItem.Click += new System.EventHandler(this.testExceptionToolStripMenuItem_Click);
            // 
            // userStatusToolStripMenuItem
            // 
            this.userStatusToolStripMenuItem.Name = "userStatusToolStripMenuItem";
            this.userStatusToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.userStatusToolStripMenuItem.Text = "UserStatus";
            this.userStatusToolStripMenuItem.Click += new System.EventHandler(this.userStatusToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 22);
            // 
            // nicknameSpecificToolStripMenuItem
            // 
            this.nicknameSpecificToolStripMenuItem.Name = "nicknameSpecificToolStripMenuItem";
            this.nicknameSpecificToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.nicknameSpecificToolStripMenuItem.Text = "NicknameSpecific";
            this.nicknameSpecificToolStripMenuItem.Click += new System.EventHandler(this.nicknameSpecificToolStripMenuItem_Click);
            // 
            // form2ToolStripMenuItem1
            // 
            this.form2ToolStripMenuItem1.Name = "form2ToolStripMenuItem1";
            this.form2ToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.form2ToolStripMenuItem1.Text = "Form2";
            this.form2ToolStripMenuItem1.Click += new System.EventHandler(this.form2ToolStripMenuItem1_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.printToolStripButton,
            this.printPreviewToolStripButton,
            this.toolStripSeparator2,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(834, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            this.toolStrip.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabelStatus,
            this.tsAppStatus,
            this.tsConnectedTo});
            this.statusStrip.Location = new System.Drawing.Point(0, 514);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(834, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // tsLabelStatus
            // 
            this.tsLabelStatus.Name = "tsLabelStatus";
            this.tsLabelStatus.Size = new System.Drawing.Size(38, 17);
            this.tsLabelStatus.Text = "Status";
            // 
            // tsAppStatus
            // 
            this.tsAppStatus.Name = "tsAppStatus";
            this.tsAppStatus.Size = new System.Drawing.Size(109, 17);
            this.tsAppStatus.Text = "toolStripStatusLabel1";
            this.tsAppStatus.Visible = false;
            // 
            // tsConnectedTo
            // 
            this.tsConnectedTo.Name = "tsConnectedTo";
            this.tsConnectedTo.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(166, 22);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Image = global::XmlParsersAndUi.Properties.Resources.Sad_robot_SH;
            this.pictureBox1.Location = new System.Drawing.Point(796, 255);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "New";
            this.newToolStripButton.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenFile);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save";
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "Print";
            // 
            // printPreviewToolStripButton
            // 
            this.printPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printPreviewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripButton.Image")));
            this.printPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            this.printPreviewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printPreviewToolStripButton.Text = "Print Preview";
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "Help";
            // 
            // remoteServerToolStripMenuItem
            // 
            this.remoteServerToolStripMenuItem.Name = "remoteServerToolStripMenuItem";
            this.remoteServerToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.remoteServerToolStripMenuItem.Text = "RemoteServer";
            this.remoteServerToolStripMenuItem.Click += new System.EventHandler(this.remoteServerToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(834, 536);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Maintenance Reduction Set";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel tsLabelStatus;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem configurationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupRecommendationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstLevelCleanupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macroSplitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bulkCustomsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem advancedRecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsAppStatus;
        private System.Windows.Forms.ToolStripMenuItem rFTUpdaterToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem testExceptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem nicknameSpecificToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel tsConnectedTo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem remoteServerToolStripMenuItem;
    }
}



