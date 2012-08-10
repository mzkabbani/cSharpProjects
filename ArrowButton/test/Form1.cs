#region Using

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

#endregion

namespace test
{
	public class Form1 : System.Windows.Forms.Form
	{
		#region  Members

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox2;
		private ArrowButton.ArrowButton arrowButton6;
		private ArrowButton.ArrowButton arrowButton5;
		private ArrowButton.ArrowButton arrowButton4;
		private ArrowButton.ArrowButton arrowButton1;
		private ArrowButton.ArrowButton arrowButton3;
		private ArrowButton.ArrowButton arrowButton2;
		private System.Windows.Forms.GroupBox groupBox1;
		private ArrowButton.ArrowButton arrowButton7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private ArrowButton.ArrowButton arrowButton8;
		private ArrowButton.ArrowButton arrowButton9;
		private ArrowButton.ArrowButton arrowButton10;
		private System.Windows.Forms.PictureBox pictureBox1;

		private int m_X = 0;
		private int m_Y = 0;
		private int m_Z = 0;

		#endregion

		#region Constrctors

		public Form1()
		{
			InitializeComponent();
			DisplayVari ();
		}

		#endregion

		#region Disposing 

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
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

		#endregion

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.arrowButton6 = new ArrowButton.ArrowButton();
			this.arrowButton5 = new ArrowButton.ArrowButton();
			this.arrowButton4 = new ArrowButton.ArrowButton();
			this.arrowButton1 = new ArrowButton.ArrowButton();
			this.arrowButton3 = new ArrowButton.ArrowButton();
			this.arrowButton2 = new ArrowButton.ArrowButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.arrowButton10 = new ArrowButton.ArrowButton();
			this.arrowButton9 = new ArrowButton.ArrowButton();
			this.arrowButton8 = new ArrowButton.ArrowButton();
			this.arrowButton7 = new ArrowButton.ArrowButton();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.LightSeaGreen;
			this.groupBox2.Controls.Add(this.pictureBox1);
			this.groupBox2.Controls.Add(this.arrowButton6);
			this.groupBox2.Controls.Add(this.arrowButton5);
			this.groupBox2.Controls.Add(this.arrowButton4);
			this.groupBox2.Controls.Add(this.arrowButton1);
			this.groupBox2.Controls.Add(this.arrowButton3);
			this.groupBox2.Controls.Add(this.arrowButton2);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(336, 360);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = " Direction ";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(8, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(120, 128);
			this.pictureBox1.TabIndex = 19;
			this.pictureBox1.TabStop = false;
			// 
			// arrowButton6
			// 
			this.arrowButton6.ArrowEnabled = true;
			this.arrowButton6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.arrowButton6.HoverEndColor = System.Drawing.Color.DarkOrchid;
			this.arrowButton6.HoverStartColor = System.Drawing.Color.LightSkyBlue;
			this.arrowButton6.Location = new System.Drawing.Point(216, 160);
			this.arrowButton6.Name = "arrowButton6";
			this.arrowButton6.NormalEndColor = System.Drawing.Color.Gray;
			this.arrowButton6.NormalStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton6.Rotation = 90;
			this.arrowButton6.Size = new System.Drawing.Size(96, 96);
			this.arrowButton6.TabIndex = 18;
			this.arrowButton6.Text = "X+";
			this.arrowButton6.OnClickEvent += new ArrowButton.ArrowButton.ArrowButtonClickDelegate(this.arrowButton6_OnClickEvent);
			// 
			// arrowButton5
			// 
			this.arrowButton5.ArrowEnabled = true;
			this.arrowButton5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.arrowButton5.HoverEndColor = System.Drawing.Color.DarkOliveGreen;
			this.arrowButton5.HoverStartColor = System.Drawing.Color.GreenYellow;
			this.arrowButton5.Location = new System.Drawing.Point(56, 160);
			this.arrowButton5.Name = "arrowButton5";
			this.arrowButton5.NormalEndColor = System.Drawing.Color.Gray;
			this.arrowButton5.NormalStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton5.Rotation = 270;
			this.arrowButton5.Size = new System.Drawing.Size(96, 96);
			this.arrowButton5.TabIndex = 17;
			this.arrowButton5.Text = "X-";
			this.arrowButton5.OnClickEvent += new ArrowButton.ArrowButton.ArrowButtonClickDelegate(this.arrowButton5_OnClickEvent);
			// 
			// arrowButton4
			// 
			this.arrowButton4.ArrowEnabled = true;
			this.arrowButton4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.arrowButton4.HoverEndColor = System.Drawing.Color.Tomato;
			this.arrowButton4.HoverStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton4.Location = new System.Drawing.Point(136, 240);
			this.arrowButton4.Name = "arrowButton4";
			this.arrowButton4.NormalEndColor = System.Drawing.Color.Gray;
			this.arrowButton4.NormalStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton4.Rotation = 180;
			this.arrowButton4.Size = new System.Drawing.Size(96, 96);
			this.arrowButton4.TabIndex = 16;
			this.arrowButton4.Text = "Z-";
			// 
			// arrowButton1
			// 
			this.arrowButton1.ArrowEnabled = true;
			this.arrowButton1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.arrowButton1.HoverEndColor = System.Drawing.Color.DarkRed;
			this.arrowButton1.HoverStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton1.Location = new System.Drawing.Point(136, 80);
			this.arrowButton1.Name = "arrowButton1";
			this.arrowButton1.NormalEndColor = System.Drawing.Color.Gray;
			this.arrowButton1.NormalStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton1.Rotation = 0;
			this.arrowButton1.Size = new System.Drawing.Size(96, 96);
			this.arrowButton1.TabIndex = 15;
			this.arrowButton1.Text = "Z+";
			// 
			// arrowButton3
			// 
			this.arrowButton3.ArrowEnabled = true;
			this.arrowButton3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.arrowButton3.HoverEndColor = System.Drawing.Color.CadetBlue;
			this.arrowButton3.HoverStartColor = System.Drawing.Color.LightSkyBlue;
			this.arrowButton3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.arrowButton3.Location = new System.Drawing.Point(40, 264);
			this.arrowButton3.Name = "arrowButton3";
			this.arrowButton3.NormalEndColor = System.Drawing.Color.Gray;
			this.arrowButton3.NormalStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton3.Rotation = 225;
			this.arrowButton3.Size = new System.Drawing.Size(96, 96);
			this.arrowButton3.TabIndex = 14;
			this.arrowButton3.Text = "Y-";
			// 
			// arrowButton2
			// 
			this.arrowButton2.ArrowEnabled = true;
			this.arrowButton2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.arrowButton2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.arrowButton2.HoverEndColor = System.Drawing.Color.ForestGreen;
			this.arrowButton2.HoverStartColor = System.Drawing.Color.Cornsilk;
			this.arrowButton2.Location = new System.Drawing.Point(240, 64);
			this.arrowButton2.Name = "arrowButton2";
			this.arrowButton2.NormalEndColor = System.Drawing.Color.Gray;
			this.arrowButton2.NormalStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.arrowButton2.Rotation = 45;
			this.arrowButton2.Size = new System.Drawing.Size(96, 96);
			this.arrowButton2.TabIndex = 11;
			this.arrowButton2.Text = "Y+";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Aquamarine;
			this.groupBox1.Controls.Add(this.arrowButton10);
			this.groupBox1.Controls.Add(this.arrowButton9);
			this.groupBox1.Controls.Add(this.arrowButton8);
			this.groupBox1.Controls.Add(this.arrowButton7);
			this.groupBox1.Location = new System.Drawing.Point(352, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(112, 240);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = " Other ";
			// 
			// arrowButton10
			// 
			this.arrowButton10.ArrowEnabled = true;
			this.arrowButton10.HoverEndColor = System.Drawing.Color.DarkRed;
			this.arrowButton10.HoverStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton10.Location = new System.Drawing.Point(32, 160);
			this.arrowButton10.Name = "arrowButton10";
			this.arrowButton10.NormalEndColor = System.Drawing.Color.HotPink;
			this.arrowButton10.NormalStartColor = System.Drawing.Color.Cyan;
			this.arrowButton10.Rotation = 145;
			this.arrowButton10.Size = new System.Drawing.Size(48, 48);
			this.arrowButton10.TabIndex = 3;
			this.arrowButton10.Text = "txt";
			// 
			// arrowButton9
			// 
			this.arrowButton9.ArrowEnabled = false;
			this.arrowButton9.HoverEndColor = System.Drawing.Color.DarkRed;
			this.arrowButton9.HoverStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton9.Location = new System.Drawing.Point(16, 72);
			this.arrowButton9.Name = "arrowButton9";
			this.arrowButton9.NormalEndColor = System.Drawing.Color.Goldenrod;
			this.arrowButton9.NormalStartColor = System.Drawing.Color.Wheat;
			this.arrowButton9.Rotation = 0;
			this.arrowButton9.Size = new System.Drawing.Size(64, 64);
			this.arrowButton9.TabIndex = 2;
			this.arrowButton9.Text = "disabled";
			// 
			// arrowButton8
			// 
			this.arrowButton8.ArrowEnabled = true;
			this.arrowButton8.HoverEndColor = System.Drawing.Color.OrangeRed;
			this.arrowButton8.HoverStartColor = System.Drawing.Color.OrangeRed;
			this.arrowButton8.Location = new System.Drawing.Point(8, 24);
			this.arrowButton8.Name = "arrowButton8";
			this.arrowButton8.NormalEndColor = System.Drawing.Color.DarkGray;
			this.arrowButton8.NormalStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton8.Rotation = 66;
			this.arrowButton8.Size = new System.Drawing.Size(24, 24);
			this.arrowButton8.TabIndex = 1;
			// 
			// arrowButton7
			// 
			this.arrowButton7.ArrowEnabled = true;
			this.arrowButton7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.arrowButton7.HoverEndColor = System.Drawing.Color.Yellow;
			this.arrowButton7.HoverStartColor = System.Drawing.Color.WhiteSmoke;
			this.arrowButton7.Location = new System.Drawing.Point(56, 8);
			this.arrowButton7.Name = "arrowButton7";
			this.arrowButton7.NormalEndColor = System.Drawing.Color.CadetBlue;
			this.arrowButton7.NormalStartColor = System.Drawing.Color.LightCoral;
			this.arrowButton7.Rotation = 325;
			this.arrowButton7.Size = new System.Drawing.Size(40, 40);
			this.arrowButton7.TabIndex = 0;
			this.arrowButton7.Text = "small";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(352, 288);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 19;
			this.label4.Text = "Position";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(416, 320);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(48, 20);
			this.textBox1.TabIndex = 14;
			this.textBox1.Text = "";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.MediumTurquoise;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(352, 320);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 13;
			this.label1.Text = "X - Axis";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.MediumTurquoise;
			this.ClientSize = new System.Drawing.Size(472, 373);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Text = "ArrowButton Test";
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Main

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		#endregion

		#region Methods

		private void DisplayVari ()
		{
			textBox1.Text = Convert.ToString( m_X );
		}

		private void arrowButton6_OnClickEvent(object sender, EventArgs e)
		{
			m_X += 5;
			CheckRange ();
			DisplayVari ();
		}
		private void arrowButton5_OnClickEvent(object sender, EventArgs e)
		{
			m_X -= 5;
			CheckRange ();
			DisplayVari ();
		}

		private void CheckRange ()
		{
			if ( m_X > 50 )
			{
				arrowButton6.HoverStartColor = Color.LightPink;
				arrowButton6.HoverEndColor = Color.DarkRed;
			}
			else
			{
				this.arrowButton6.HoverEndColor = System.Drawing.Color.DarkOrchid;
				this.arrowButton6.HoverStartColor = System.Drawing.Color.LightSkyBlue;
			}

			if ( m_X < 0 )
			{
				arrowButton5.HoverStartColor = Color.LightPink;
				arrowButton5.HoverEndColor = Color.DarkRed;
			}
			else
			{
				this.arrowButton5.HoverEndColor = System.Drawing.Color.DarkOliveGreen;
				this.arrowButton5.HoverStartColor = System.Drawing.Color.GreenYellow;
			}
		}

		#endregion
	}
}
