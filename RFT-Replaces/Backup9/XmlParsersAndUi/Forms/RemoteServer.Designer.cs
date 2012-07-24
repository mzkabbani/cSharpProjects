namespace XmlParsersAndUi.Forms {
    partial class RemoteServer {
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
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.txtAppdir = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblConnected = new System.Windows.Forms.Label();
            this.btnLauncAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(162, 231);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblConnected);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.txtAppdir);
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 103);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(171, 72);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // txtAppdir
            // 
            this.txtAppdir.Location = new System.Drawing.Point(52, 46);
            this.txtAppdir.Name = "txtAppdir";
            this.txtAppdir.Size = new System.Drawing.Size(368, 20);
            this.txtAppdir.TabIndex = 1;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(52, 19);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(103, 20);
            this.txtHost.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Host:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Appdir:";
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.BackColor = System.Drawing.Color.Red;
            this.lblConnected.Location = new System.Drawing.Point(367, 16);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(59, 13);
            this.lblConnected.TabIndex = 5;
            this.lblConnected.Text = "Connected";
            // 
            // btnLauncAll
            // 
            this.btnLauncAll.Location = new System.Drawing.Point(13, 122);
            this.btnLauncAll.Name = "btnLauncAll";
            this.btnLauncAll.Size = new System.Drawing.Size(75, 23);
            this.btnLauncAll.TabIndex = 6;
            this.btnLauncAll.Text = "launcAll";
            this.btnLauncAll.UseVisualStyleBackColor = true;
            this.btnLauncAll.Click += new System.EventHandler(this.btnLauncAll_Click);
            // 
            // RemoteServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 266);
            this.Controls.Add(this.btnLauncAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTest);
            this.Name = "RemoteServer";
            this.Text = "RemoteServer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.TextBox txtAppdir;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Button btnLauncAll;
    }
}