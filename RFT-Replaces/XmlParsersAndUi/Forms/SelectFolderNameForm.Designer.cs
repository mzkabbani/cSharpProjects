namespace XmlParsersAndUi.Forms {
    partial class SelectFolderNameForm {
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
            this.tvFolderNames = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvFolderNames
            // 
            this.tvFolderNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFolderNames.Location = new System.Drawing.Point(0, 0);
            this.tvFolderNames.Name = "tvFolderNames";
            this.tvFolderNames.Size = new System.Drawing.Size(195, 267);
            this.tvFolderNames.TabIndex = 0;
            this.tvFolderNames.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolderNames_NodeMouseDoubleClick);
            // 
            // SelectFolderNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 267);
            this.Controls.Add(this.tvFolderNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectFolderNameForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Folder Name";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SelectFolderNameForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvFolderNames;
    }
}