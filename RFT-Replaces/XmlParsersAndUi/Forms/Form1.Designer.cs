﻿namespace XmlParsersAndUi {
    partial class Form1 {
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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("item1");
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lvItems = new System.Windows.Forms.ListView();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.tvOutput = new System.Windows.Forms.TreeView();
            this.btnPopulateTV = new System.Windows.Forms.Button();
            this.grpBoxAttr = new System.Windows.Forms.GroupBox();
            this.txtEventIn = new System.Windows.Forms.TextBox();
            this.btnParseEvent = new System.Windows.Forms.Button();
            this.gbChildren = new System.Windows.Forms.GroupBox();
            this.cmbMain = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAdd32Customs = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.grpBoxAttr.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.AllowDrop = true;
            this.txtOutput.Location = new System.Drawing.Point(728, 244);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(65, 306);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtOutput_DragDrop);
            this.txtOutput.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtOutput_DragEnter);
            // 
            // lvItems
            // 
            this.lvItems.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvItems.AllowColumnReorder = true;
            this.lvItems.AllowDrop = true;
            this.lvItems.FullRowSelect = true;
            this.lvItems.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6});
            this.lvItems.Location = new System.Drawing.Point(605, 262);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(107, 288);
            this.lvItems.TabIndex = 1;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.List;
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            this.lvItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvItems_MouseDown);
            this.lvItems.DragLeave += new System.EventHandler(this.lvItems_DragLeave);
            this.lvItems.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvItems_ItemDrag);
            this.lvItems.DragOver += new System.Windows.Forms.DragEventHandler(this.lvItems_DragOver);
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(12, 12);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(334, 20);
            this.txtInputFile.TabIndex = 2;
            this.txtInputFile.Text = "D:\\output.txt";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(352, 9);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 3;
            this.btnParse.Text = "Parse File";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.button3_Click);
            // 
            // tvOutput
            // 
            this.tvOutput.CheckBoxes = true;
            this.tvOutput.Location = new System.Drawing.Point(12, 155);
            this.tvOutput.Name = "tvOutput";
            this.tvOutput.Size = new System.Drawing.Size(230, 356);
            this.tvOutput.TabIndex = 4;
            this.tvOutput.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOutput_AfterSelect);
            // 
            // btnPopulateTV
            // 
            this.btnPopulateTV.Location = new System.Drawing.Point(13, 38);
            this.btnPopulateTV.Name = "btnPopulateTV";
            this.btnPopulateTV.Size = new System.Drawing.Size(75, 26);
            this.btnPopulateTV.TabIndex = 5;
            this.btnPopulateTV.Text = "Populate";
            this.btnPopulateTV.UseVisualStyleBackColor = true;
            this.btnPopulateTV.Click += new System.EventHandler(this.btnPopulateTV_Click);
            // 
            // grpBoxAttr
            // 
            this.grpBoxAttr.Controls.Add(this.button3);
            this.grpBoxAttr.Location = new System.Drawing.Point(248, 70);
            this.grpBoxAttr.Name = "grpBoxAttr";
            this.grpBoxAttr.Size = new System.Drawing.Size(276, 441);
            this.grpBoxAttr.TabIndex = 6;
            this.grpBoxAttr.TabStop = false;
            this.grpBoxAttr.Text = "Attributes";
            // 
            // txtEventIn
            // 
            this.txtEventIn.Location = new System.Drawing.Point(561, 109);
            this.txtEventIn.Multiline = true;
            this.txtEventIn.Name = "txtEventIn";
            this.txtEventIn.Size = new System.Drawing.Size(215, 112);
            this.txtEventIn.TabIndex = 7;
            // 
            // btnParseEvent
            // 
            this.btnParseEvent.Location = new System.Drawing.Point(591, 227);
            this.btnParseEvent.Name = "btnParseEvent";
            this.btnParseEvent.Size = new System.Drawing.Size(75, 23);
            this.btnParseEvent.TabIndex = 8;
            this.btnParseEvent.Text = "P Event";
            this.btnParseEvent.UseVisualStyleBackColor = true;
            this.btnParseEvent.Click += new System.EventHandler(this.btnParseEvent_Click);
            // 
            // gbChildren
            // 
            this.gbChildren.Location = new System.Drawing.Point(13, 517);
            this.gbChildren.Name = "gbChildren";
            this.gbChildren.Size = new System.Drawing.Size(636, 144);
            this.gbChildren.TabIndex = 9;
            this.gbChildren.TabStop = false;
            this.gbChildren.Text = "Children";
            // 
            // cmbMain
            // 
            this.cmbMain.FormattingEnabled = true;
            this.cmbMain.Items.AddRange(new object[] {
            "AvailableTests"});
            this.cmbMain.Location = new System.Drawing.Point(338, 41);
            this.cmbMain.Name = "cmbMain";
            this.cmbMain.Size = new System.Drawing.Size(121, 21);
            this.cmbMain.TabIndex = 0;
            this.cmbMain.SelectedIndexChanged += new System.EventHandler(this.cmbMain_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Find Children";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(94, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 11;
            this.button2.Text = "Parse Dir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdd32Customs
            // 
            this.btnAdd32Customs.Location = new System.Drawing.Point(449, 9);
            this.btnAdd32Customs.Name = "btnAdd32Customs";
            this.btnAdd32Customs.Size = new System.Drawing.Size(137, 23);
            this.btnAdd32Customs.TabIndex = 12;
            this.btnAdd32Customs.Text = "Add 32 Customs";
            this.btnAdd32Customs.UseVisualStyleBackColor = true;
            this.btnAdd32Customs.Click += new System.EventHandler(this.btnAdd32Customs_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Extract Addops";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 89);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 673);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnAdd32Customs);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbMain);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbChildren);
            this.Controls.Add(this.btnParseEvent);
            this.Controls.Add(this.txtEventIn);
            this.Controls.Add(this.grpBoxAttr);
            this.Controls.Add(this.btnPopulateTV);
            this.Controls.Add(this.tvOutput);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.txtInputFile);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.txtOutput);
            this.Name = "Form1";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpBoxAttr.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TreeView tvOutput;
        private System.Windows.Forms.Button btnPopulateTV;
        private System.Windows.Forms.GroupBox grpBoxAttr;
        private System.Windows.Forms.TextBox txtEventIn;
        private System.Windows.Forms.Button btnParseEvent;
        private System.Windows.Forms.GroupBox gbChildren;
        private System.Windows.Forms.ComboBox cmbMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAdd32Customs;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

