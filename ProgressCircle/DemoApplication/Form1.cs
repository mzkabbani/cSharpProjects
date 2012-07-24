using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Utezduyar.Windows.Forms;

namespace DemoaApplication
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Utezduyar.Windows.Forms.ProgressCircle progressBar1;
		private System.Windows.Forms.Button btnStartStop;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numbericWidth;
		private System.Windows.Forms.NumericUpDown numericNumberOfTail;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericThickness;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Panel pnlForeColor;
		private System.Windows.Forms.Panel pnlRingColor;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkTransparentBackground;
		private System.Windows.Forms.Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );			
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			this.numbericWidth.Value = this.progressBar1.Width;
			this.numericNumberOfTail.Value = this.progressBar1.NumberOfTail;

			foreach (Object obj in this.comboBox1.Items)
			{
				if (obj.ToString () == "8")
					this.comboBox1.SelectedItem = obj;
			}

			this.numericThickness.Value = this.progressBar1.RingThickness;

			this.pnlForeColor.BackColor = this.progressBar1.ForeColor;
			this.pnlRingColor.BackColor = this.progressBar1.RingColor;
			this.numericUpDown1.Value = this.progressBar1.Interval;
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.progressBar1 = new Utezduyar.Windows.Forms.ProgressCircle();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numbericWidth = new System.Windows.Forms.NumericUpDown();
            this.numericNumberOfTail = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericThickness = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pnlForeColor = new System.Windows.Forms.Panel();
            this.pnlRingColor = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chkTransparentBackground = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numbericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfTail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Transparent;
            this.progressBar1.ForeColor = System.Drawing.Color.Gold;
            this.progressBar1.Interval = 100;
            this.progressBar1.Location = new System.Drawing.Point(235, 90);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RingColor = System.Drawing.Color.White;
            this.progressBar1.RingThickness = 30;
            this.progressBar1.Size = new System.Drawing.Size(80, 80);
            this.progressBar1.TabIndex = 1;
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(84, 252);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(92, 23);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "Start / Stop";
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width";
            // 
            // numbericWidth
            // 
            this.numbericWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numbericWidth.Location = new System.Drawing.Point(127, 18);
            this.numbericWidth.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numbericWidth.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numbericWidth.Name = "numbericWidth";
            this.numbericWidth.Size = new System.Drawing.Size(49, 21);
            this.numbericWidth.TabIndex = 4;
            this.numbericWidth.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numbericWidth.ValueChanged += new System.EventHandler(this.numbericWidth_ValueChanged);
            // 
            // numericNumberOfTail
            // 
            this.numericNumberOfTail.Location = new System.Drawing.Point(127, 47);
            this.numericNumberOfTail.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numericNumberOfTail.Name = "numericNumberOfTail";
            this.numericNumberOfTail.Size = new System.Drawing.Size(49, 21);
            this.numericNumberOfTail.TabIndex = 6;
            this.numericNumberOfTail.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericNumberOfTail.ValueChanged += new System.EventHandler(this.numericNumberOfTail_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number Of Tail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Arc Number";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "6",
            "8",
            "9",
            "10",
            "12"});
            this.comboBox1.Location = new System.Drawing.Point(127, 76);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(49, 26);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // numericThickness
            // 
            this.numericThickness.Location = new System.Drawing.Point(127, 110);
            this.numericThickness.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
            this.numericThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericThickness.Name = "numericThickness";
            this.numericThickness.Size = new System.Drawing.Size(49, 21);
            this.numericThickness.TabIndex = 9;
            this.numericThickness.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericThickness.ValueChanged += new System.EventHandler(this.numericThickness_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ring Thickness";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fore Color";
            // 
            // pnlForeColor
            // 
            this.pnlForeColor.Location = new System.Drawing.Point(127, 139);
            this.pnlForeColor.Name = "pnlForeColor";
            this.pnlForeColor.Size = new System.Drawing.Size(49, 21);
            this.pnlForeColor.TabIndex = 11;
            this.pnlForeColor.Click += new System.EventHandler(this.pnlForeColor_Click);
            // 
            // pnlRingColor
            // 
            this.pnlRingColor.Location = new System.Drawing.Point(127, 168);
            this.pnlRingColor.Name = "pnlRingColor";
            this.pnlRingColor.Size = new System.Drawing.Size(49, 21);
            this.pnlRingColor.TabIndex = 11;
            this.pnlRingColor.Click += new System.EventHandler(this.pnlRingColor_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ring Color";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(127, 197);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(49, 21);
            this.numericUpDown1.TabIndex = 9;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "Interval";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Clear";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkTransparentBackground
            // 
            this.chkTransparentBackground.Checked = true;
            this.chkTransparentBackground.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTransparentBackground.Location = new System.Drawing.Point(25, 222);
            this.chkTransparentBackground.Name = "chkTransparentBackground";
            this.chkTransparentBackground.Size = new System.Drawing.Size(155, 24);
            this.chkTransparentBackground.TabIndex = 14;
            this.chkTransparentBackground.Text = "Transparent BackColor";
            this.chkTransparentBackground.CheckedChanged += new System.EventHandler(this.chkTransparentBackground_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(203, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 61);
            this.panel1.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(415, 311);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkTransparentBackground);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlForeColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericThickness);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.numericNumberOfTail);
            this.Controls.Add(this.numbericWidth);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.pnlRingColor);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "Form1";
            this.Text = "Umut Tezduyar http://www.UmutTezduyar.com";
            ((System.ComponentModel.ISupportInitialize)(this.numbericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNumberOfTail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnStartStop_Click(object sender, System.EventArgs e)
		{
			this.progressBar1.Rotate = !this.progressBar1.Rotate;
		}

		private void numbericWidth_ValueChanged(object sender, System.EventArgs e)
		{
			this.progressBar1.Width = (int)this.numbericWidth.Value;
		}

		private void numericNumberOfTail_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.progressBar1.NumberOfTail = (int)this.numericNumberOfTail.Value;
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message);
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.progressBar1.NumberOfArcs =  int.Parse(this.comboBox1.SelectedItem.ToString ());
		}

		private void numericThickness_ValueChanged(object sender, System.EventArgs e)
		{
			try
			{
				this.progressBar1.RingThickness = (int)this.numericThickness.Value;
			}
			catch (Exception ex)
			{
				MessageBox.Show (ex.Message);
			}
		}

		private void pnlForeColor_Click(object sender, System.EventArgs e)
		{
			DialogResult result = this.colorDialog1.ShowDialog ();

			if (result == DialogResult.OK)
			{
				this.pnlForeColor.BackColor = this.colorDialog1.Color;
				this.progressBar1.ForeColor = this.colorDialog1.Color;
			}
		}

		private void pnlRingColor_Click(object sender, System.EventArgs e)
		{
			DialogResult result = this.colorDialog1.ShowDialog ();

			if (result == DialogResult.OK)
			{
				this.pnlRingColor.BackColor = this.colorDialog1.Color;
				this.progressBar1.RingColor = this.colorDialog1.Color;
			}
		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			this.progressBar1.Interval = (int)this.numericUpDown1.Value;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.progressBar1.Rotate = false;
			this.progressBar1.Clear ();
		}

		private void chkTransparentBackground_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.chkTransparentBackground.Checked)
				this.progressBar1.BackColor = Color.Transparent;
			else
				this.progressBar1.BackColor = Color.FromKnownColor(KnownColor.Control);
		}

	}
}
