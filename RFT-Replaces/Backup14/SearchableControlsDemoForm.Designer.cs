namespace SearchableControlsDemo
{
    partial class SearchableControlsDemoForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAgainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.searchableTreeView1 = new SearchableControls.SearchableTreeView();
            this.searchableListView1 = new SearchableControls.SearchableListView();
            this.searchableRichTextBox1 = new SearchableControls.SearchableRichTextBox();
            this.searchableTextBox1 = new SearchableControls.SearchableTextBox();
            this.readOnlyCheckBox1 = new System.Windows.Forms.CheckBox();
            this.readOnlyCheckBox2 = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Example SearchableTextBox";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Example SearchableTreeView";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Example SearchableRichTextBox";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt-F4";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.findAgainToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl-F";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.findToolStripMenuItem.Text = "&Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // findAgainToolStripMenuItem
            // 
            this.findAgainToolStripMenuItem.Name = "findAgainToolStripMenuItem";
            this.findAgainToolStripMenuItem.ShortcutKeyDisplayString = "F3";
            this.findAgainToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.findAgainToolStripMenuItem.Text = "Find &again";
            this.findAgainToolStripMenuItem.Click += new System.EventHandler(this.findAgainToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 487);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Example SearchableListView";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(399, 474);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // searchableTreeView1
            // 
            this.searchableTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchableTreeView1.Location = new System.Drawing.Point(12, 358);
            this.searchableTreeView1.Name = "searchableTreeView1";
            this.searchableTreeView1.Size = new System.Drawing.Size(511, 110);
            this.searchableTreeView1.TabIndex = 3;
            // 
            // searchableListView1
            // 
            this.searchableListView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchableListView1.Location = new System.Drawing.Point(12, 503);
            this.searchableListView1.Name = "searchableListView1";
            this.searchableListView1.Size = new System.Drawing.Size(511, 124);
            this.searchableListView1.TabIndex = 4;
            this.searchableListView1.UseCompatibleStateImageBehavior = false;
            this.searchableListView1.View = System.Windows.Forms.View.List;
            // 
            // searchableRichTextBox1
            // 
            this.searchableRichTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchableRichTextBox1.Location = new System.Drawing.Point(14, 216);
            this.searchableRichTextBox1.Name = "searchableRichTextBox1";
            this.searchableRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.searchableRichTextBox1.Size = new System.Drawing.Size(509, 104);
            this.searchableRichTextBox1.TabIndex = 2;
            this.searchableRichTextBox1.Text = "";
            // 
            // searchableTextBox1
            // 
            this.searchableTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchableTextBox1.Location = new System.Drawing.Point(12, 59);
            this.searchableTextBox1.Multiline = true;
            this.searchableTextBox1.Name = "searchableTextBox1";
            this.searchableTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.searchableTextBox1.Size = new System.Drawing.Size(511, 122);
            this.searchableTextBox1.TabIndex = 0;
            // 
            // readOnlyCheckBox1
            // 
            this.readOnlyCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readOnlyCheckBox1.AutoSize = true;
            this.readOnlyCheckBox1.Location = new System.Drawing.Point(449, 36);
            this.readOnlyCheckBox1.Name = "readOnlyCheckBox1";
            this.readOnlyCheckBox1.Size = new System.Drawing.Size(74, 17);
            this.readOnlyCheckBox1.TabIndex = 7;
            this.readOnlyCheckBox1.Text = "Read only";
            this.readOnlyCheckBox1.UseVisualStyleBackColor = true;
            this.readOnlyCheckBox1.CheckedChanged += new System.EventHandler(this.readOnlyCheckBox1_CheckedChanged);
            // 
            // readOnlyCheckBox2
            // 
            this.readOnlyCheckBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readOnlyCheckBox2.AutoSize = true;
            this.readOnlyCheckBox2.Location = new System.Drawing.Point(446, 193);
            this.readOnlyCheckBox2.Name = "readOnlyCheckBox2";
            this.readOnlyCheckBox2.Size = new System.Drawing.Size(74, 17);
            this.readOnlyCheckBox2.TabIndex = 7;
            this.readOnlyCheckBox2.Text = "Read only";
            this.readOnlyCheckBox2.UseVisualStyleBackColor = true;
            this.readOnlyCheckBox2.CheckedChanged += new System.EventHandler(this.readOnlyCheckBox2_CheckedChanged);
            // 
            // SearchableControlsDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 641);
            this.Controls.Add(this.readOnlyCheckBox2);
            this.Controls.Add(this.readOnlyCheckBox1);
            this.Controls.Add(this.searchableTreeView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.searchableListView1);
            this.Controls.Add(this.searchableRichTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchableTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SearchableControlsDemoForm";
            this.Text = "SearchableControls demo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SearchableControls.SearchableTextBox searchableTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private SearchableControls.SearchableRichTextBox searchableRichTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAgainToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private SearchableControls.SearchableListView searchableListView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private SearchableControls.SearchableTreeView searchableTreeView1;
        private System.Windows.Forms.CheckBox readOnlyCheckBox1;
        private System.Windows.Forms.CheckBox readOnlyCheckBox2;
    }
}

