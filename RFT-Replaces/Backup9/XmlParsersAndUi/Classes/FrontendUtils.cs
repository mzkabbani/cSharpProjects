using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using XmlParsersAndUi.Forms;

namespace XmlParsersAndUi {
    public static class FrontendUtils {

        static string logFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Logs\app.logs";

        [DllImport("User32.dll")]
        private static extern bool
                GetLastInputInfo(ref LASTINPUTINFO plii);

        //Step 4
        public struct LASTINPUTINFO {
            public uint cbSize;
            public uint dwTime;
        }

        public static void ShowError(string errorText, Exception ex) {
            ExceptionForm form = new ExceptionForm(errorText, ex);
            //form.MdiParent = MainForm.ActiveForm.ParentForm;
            form.ShowDialog();
            LogError(errorText, ex);
        }

        public static void LogError(string errorText, Exception ex) {
            StreamWriter writer = new StreamWriter(logFilePath, true);
            try {
                try {
                    writer.Write("\n\n\n\n\n" + DateTime.Now + "\n\n\n" + errorText + "\n\n\n" + (ex == null ? "" : ex.ToString()));
                } finally {
                    if (writer != null) {
                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                    }
                }
            } catch (Exception exc) {
                // dirty catch
            }
        }

        public static Bitmap GetScreenShot() {
            //to allow the screen to refresh(repaint)
            Application.DoEvents();
            int width = 0;
            int height = 0;
            int smallerX = 99999;
            int smallerY = 99999;
            int totalWidth = 0;
            int totalHeight = 0;
            // Set the bitmap object to the size of the screen
            for (int i = 0; i < Screen.AllScreens.Count(); i++) {
                width = width + Screen.AllScreens[i].Bounds.Width;
                height = Screen.AllScreens[i].Bounds.Height;
                if (smallerX > Screen.AllScreens[i].Bounds.X) {
                    smallerX = Screen.AllScreens[i].Bounds.X;
                }
                if (smallerY > Screen.AllScreens[i].Bounds.Y) {
                    smallerY = Screen.AllScreens[i].Bounds.Y;
                }
                totalWidth = totalWidth + Screen.AllScreens[i].Bounds.Size.Width;
                totalHeight = Screen.AllScreens[i].Bounds.Size.Height;
            }
            var bmpScreenshot = new Bitmap(width
                                          , height
                                           , PixelFormat.Format32bppArgb
                    );
            Size totalSize = new Size(totalWidth, totalHeight);
            // Create a graphics object from the bitmap
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            // Take the screenshot from the upper left corner to the right bottom corner
            try {
                gfxScreenshot.CopyFromScreen(smallerX
                                        , smallerY
                                        , 0
                                        , 0
                                        , totalSize
                                        , CopyPixelOperation.SourceCopy
               );
            } catch (Exception ex) {
            }
            return bmpScreenshot;
        }

        public static void ShowInformation(string infoText) {
            MessageBox.Show(infoText, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void CheckoutPath(string repositoryLocation, string localLocation) {
            try {
                Process p = new Process();
                p.StartInfo.FileName = "svn";
                p.StartInfo.Arguments = "checkout " + repositoryLocation + " " + localLocation;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                string output = p.StartInfo.Arguments + "\r\n";
                output = output + p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "SVN checkout issue");
            }
        }

        public static string ReadFile(string filePath) {
            string readText = string.Empty;
            StreamReader reader = new StreamReader(filePath);
            try {
                readText = reader.ReadToEnd();
            } finally {
                if (reader != null) {
                    reader.Close();
                    reader.Dispose();
                }
            }
            return readText;
        }

        public static DialogResult ShowConformation(string confirmationText) {
            return MessageBox.Show(confirmationText, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void WriteXmlFile(string filePath, string readTextReplaced) {
            XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.Default);
            // StreamWriter writer = new StreamWriter(filePath, false);
            try {
                writer.WriteString(readTextReplaced);
                //writer.WriteLine(readTextReplaced);
            } finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();
                }
            }
        }

        public static void WriteFile(string filePath, string readTextReplaced) {
            StreamWriter writer = new StreamWriter(filePath, false);
            try {
                writer.WriteLine(readTextReplaced);
            } finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        public static void AddSimpleRectoSvn(string inputDir) {
            try {
                Process p = new Process();
                p.StartInfo.FileName = "svn";
                p.StartInfo.Arguments = "add -N " + inputDir + @"\*";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                string output = p.StartInfo.Arguments + "\r\n";
                output = output + p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p = new Process();
                p.StartInfo.FileName = "svn";
                p.StartInfo.Arguments = "commit " + inputDir + "\\* -m\"addedFiles\"";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                p.WaitForExit();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "SVN checkout issue");
            }
        }

        public static void SendEmail(string sender, string recipient, string subject, string body) {
            MailAddress mailfrom = new MailAddress("autoengine@murex.com", sender);
            MailAddress mailto = new MailAddress(recipient);
            MailMessage newmsg = new MailMessage(mailfrom, mailto);
            newmsg.Subject = subject;
            newmsg.Body = body;
            //Attachment att = new Attachment("C:\\...file path");
            //newmsg.Attachments.Add(att);
            SmtpClient smtp = new SmtpClient("Barid.lb.murex.com");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential();
            //smtp.EnableSsl = true;           
            smtp.Send(newmsg);
        }

        internal static void SendUsageNotification(string Title) {
            SendEmail("MET", "mkabbani@murex.com", "MET STAT: " + Title, Title);
        }

        internal static string GetCurrentUser() {
            string currentUserName = string.Empty;
            System.Security.Principal.WindowsIdentity user =
                System.Security.Principal.WindowsIdentity.GetCurrent();
            string[] usernameArray = user.Name.Split('\\');
            currentUserName = usernameArray[1];
            return currentUserName;
        }

        internal static void CreateLogsDirectory() {
            if (!Directory.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Logs")) {
                Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Logs");
            }
        }

        internal static void SendEmailWithAttachement(string exceptionMessage, Exception sentException, string fileName) {
            MailAddress mailfrom = new MailAddress("autoengine@murex.com", "MET");
            MailAddress mailto = new MailAddress("mkabbani@murex.com");
            MailMessage newmsg = new MailMessage(mailfrom, mailto);
            if (sentException != null) {
                newmsg.Subject = "MET Exception: " + sentException.Message;
                newmsg.Body = exceptionMessage + "\n\n\n" + sentException.ToString();
            } else {
                newmsg.Subject = "MET Exception: " + exceptionMessage;
                newmsg.Body = exceptionMessage;
            }
            Attachment att = new Attachment(fileName);
            newmsg.Attachments.Add(att);
            SmtpClient smtp = new SmtpClient("Barid.lb.murex.com");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential();
            //smtp.EnableSsl = true;           
            smtp.Send(newmsg);
        }

        internal static void ShowError(string p, Exception ex, MainForm mainForm) {
            throw new NotImplementedException();
        }
    
    }
}
