namespace OldEventAutomaticConverter {
    partial class RulesDirectoryForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesDirectoryForm));
            this.btnSaveSVN = new System.Windows.Forms.Button();
            this.btnCancelSVN = new System.Windows.Forms.Button();
            this.txtSvnLocation = new System.Windows.Forms.TextBox();
            this.btnBrowsedir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSaveSVN
            // 
            this.btnSaveSVN.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveSVN.Location = new System.Drawing.Point(143, 51);
            this.btnSaveSVN.Name = "btnSaveSVN";
            this.btnSaveSVN.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSVN.TabIndex = 0;
            this.btnSaveSVN.Text = "Save";
            this.btnSaveSVN.UseVisualStyleBackColor = true;
            this.btnSaveSVN.Click += new System.EventHandler(this.btnSaveSVN_Click);
            // 
            // btnCancelSVN
            // 
            this.btnCancelSVN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelSVN.Location = new System.Drawing.Point(224, 51);
            this.btnCancelSVN.Name = "btnCancelSVN";
            this.btnCancelSVN.Size = new System.Drawing.Size(75, 23);
            this.btnCancelSVN.TabIndex = 1;
            this.btnCancelSVN.Text = "Close";
            this.btnCancelSVN.UseVisualStyleBackColor = true;
            // 
            // txtSvnLocation
            // 
            this.txtSvnLocation.Location = new System.Drawing.Point(96, 25);
            this.txtSvnLocation.Name = "txtSvnLocation";
            this.txtSvnLocation.Size = new System.Drawing.Size(249, 20);
            this.txtSvnLocation.TabIndex = 2;
            this.txtSvnLocation.Text = "D:\\svn\\PFR0000081\\pfr\\QAA-Activities\\GIM\\Rules";
            // 
            // btnBrowsedir
            // 
            this.btnBrowsedir.Location = new System.Drawing.Point(351, 23);
            this.btnBrowsedir.Name = "btnBrowsedir";
            this.btnBrowsedir.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsedir.TabIndex = 3;
            this.btnBrowsedir.Text = "Browse";
            this.btnBrowsedir.UseVisualStyleBackColor = true;
            this.btnBrowsedir.Click += new System.EventHandler(this.btnBrowsedir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rules Directory:";
            // 
            // RulesDirectoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 99);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowsedir);
            this.Controls.Add(this.txtSvnLocation);
            this.Controls.Add(this.btnCancelSVN);
            this.Controls.Add(this.btnSaveSVN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RulesDirectoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rules Directory";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveSVN;
        private System.Windows.Forms.Button btnCancelSVN;
        private System.Windows.Forms.TextBox txtSvnLocation;
        private System.Windows.Forms.Button btnBrowsedir;
        private System.Windows.Forms.Label label1;
    }
}