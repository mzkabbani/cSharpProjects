namespace OldEventAutomaticConverter {
    partial class customs {
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
            this.txtinput = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTolerance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnex = new System.Windows.Forms.Button();
            this.chkCol = new System.Windows.Forms.CheckBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtinput
            // 
            this.txtinput.Location = new System.Drawing.Point(12, 38);
            this.txtinput.MaxLength = 999999999;
            this.txtinput.Multiline = true;
            this.txtinput.Name = "txtinput";
            this.txtinput.Size = new System.Drawing.Size(754, 450);
            this.txtinput.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(334, 495);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTolerance
            // 
            this.txtTolerance.Location = new System.Drawing.Point(61, 12);
            this.txtTolerance.Name = "txtTolerance";
            this.txtTolerance.Size = new System.Drawing.Size(100, 20);
            this.txtTolerance.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tole:";
            // 
            // btnex
            // 
            this.btnex.Location = new System.Drawing.Point(456, 494);
            this.btnex.Name = "btnex";
            this.btnex.Size = new System.Drawing.Size(75, 23);
            this.btnex.TabIndex = 4;
            this.btnex.Text = "ex";
            this.btnex.UseVisualStyleBackColor = true;
            this.btnex.Click += new System.EventHandler(this.btnex_Click);
            // 
            // chkCol
            // 
            this.chkCol.AutoSize = true;
            this.chkCol.Location = new System.Drawing.Point(594, 499);
            this.chkCol.Name = "chkCol";
            this.chkCol.Size = new System.Drawing.Size(40, 17);
            this.chkCol.TabIndex = 5;
            this.chkCol.Text = "col";
            this.chkCol.UseVisualStyleBackColor = true;
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(216, 494);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 23);
            this.btnclear.TabIndex = 6;
            this.btnclear.Text = "button1";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // customs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 543);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.chkCol);
            this.Controls.Add(this.btnex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTolerance);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtinput);
            this.Name = "customs";
            this.Text = "customs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtinput;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTolerance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnex;
        private System.Windows.Forms.CheckBox chkCol;
        private System.Windows.Forms.Button btnclear;
    }
}