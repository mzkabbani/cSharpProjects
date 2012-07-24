namespace XmlParsersAndUi.Forms {
    partial class ApplicationPreferencesForm {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblConnectedTo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDatabasePrefs = new System.Windows.Forms.DataGridView();
            this.txtConnectedDatabase = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabasePrefs)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConnectedDatabase);
            this.groupBox1.Controls.Add(this.lblConnectedTo);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 505);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preferences";
            // 
            // lblConnectedTo
            // 
            this.lblConnectedTo.AutoSize = true;
            this.lblConnectedTo.Location = new System.Drawing.Point(7, 20);
            this.lblConnectedTo.Name = "lblConnectedTo";
            this.lblConnectedTo.Size = new System.Drawing.Size(56, 13);
            this.lblConnectedTo.TabIndex = 3;
            this.lblConnectedTo.Text = "Database:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(176, 473);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDatabasePrefs);
            this.groupBox2.Location = new System.Drawing.Point(6, 235);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 235);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Prefs";
            // 
            // dgvDatabasePrefs
            // 
            this.dgvDatabasePrefs.AllowUserToAddRows = false;
            this.dgvDatabasePrefs.AllowUserToDeleteRows = false;
            this.dgvDatabasePrefs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatabasePrefs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatabasePrefs.Location = new System.Drawing.Point(3, 16);
            this.dgvDatabasePrefs.Name = "dgvDatabasePrefs";
            this.dgvDatabasePrefs.RowHeadersVisible = false;
            this.dgvDatabasePrefs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDatabasePrefs.Size = new System.Drawing.Size(469, 216);
            this.dgvDatabasePrefs.TabIndex = 0;
            // 
            // txtConnectedDatabase
            // 
            this.txtConnectedDatabase.Location = new System.Drawing.Point(10, 37);
            this.txtConnectedDatabase.Name = "txtConnectedDatabase";
            this.txtConnectedDatabase.ReadOnly = true;
            this.txtConnectedDatabase.Size = new System.Drawing.Size(468, 20);
            this.txtConnectedDatabase.TabIndex = 4;
            // 
            // ApplicationPreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 530);
            this.Controls.Add(this.groupBox1);
            this.Name = "ApplicationPreferencesForm";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.ApplicationPreferencesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabasePrefs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDatabasePrefs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblConnectedTo;
        private System.Windows.Forms.TextBox txtConnectedDatabase;
    }
}