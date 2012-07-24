using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FtpLib;

namespace FTP_browser {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        string workingDirectory = Directory.GetCurrentDirectory() + @"\Temp";
        FtpFileInfo[] fileInfos;
        FtpConnection ftp;
        private void btnStart_Click(object sender, EventArgs e) {
            try {
                test();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


        public void test() {
            if (Directory.Exists(workingDirectory)) {
                Directory.Delete(workingDirectory, true);                
                Directory.CreateDirectory(workingDirectory);
            } else {
                Directory.CreateDirectory(workingDirectory);
            }
           

            using (ftp = new FtpConnection(txtServername.Text,21, txtUsername.Text, txtPassword.Text)) {

                
                ftp.Open(); /* Open the FTP connection */
                ftp.Login(); /* Login using previously provided credentials */


                if (ftp.DirectoryExists(txtRootDir.Text)) /* check that a directory exists */ {
                    ftp.SetCurrentDirectory(txtRootDir.Text); /* change current directory */
                }
                
                
               // StreamReader reader = new StreamReader(txtBrowse.Text);
                try {
                    string line = string.Empty;


                    FtpDirectoryInfo info = ftp.GetCurrentDirectoryInfo();
                    fileInfos = info.GetFiles();

                    foreach (FtpFileInfo item in fileInfos) {
                        //ftp.GetFile(item.Name, Directory.GetCurrentDirectory() + @"\Output\" + line + @"\item.Name", false);
                        ListboxItem listBoxItem = new ListboxItem();
                        listBoxItem.fileName = item.Name;
                        listBoxItem.filePath = txtRootDir.Text + item.Name;
                        lstFiles.Items.Add(listBoxItem);
                    }
                    //ftp.SetCurrentDirectory(@"/loth2/itsred/caixa/3.1.22.PROD");
                    ftp.SetLocalDirectory(workingDirectory);
                    ftp.GetFile(fileInfos[1].Name,false);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    
                } finally {

                    ftp.Close(); 
                }
               
           
            }

        }

        private void btnEdit_Click(object sender, EventArgs e) {
            try {
                using (ftp = new FtpConnection(txtServername.Text, 21, txtUsername.Text, txtPassword.Text)) {
                    ftp.Open(); /* Open the FTP connection */
                    ftp.Login();
                    if (ftp.DirectoryExists(txtRootDir.Text)) /* check that a directory exists */ {
                        ftp.SetCurrentDirectory(txtRootDir.Text); /* change current directory */
                    }
                    ListboxItem selectedItem = lstFiles.SelectedItem as ListboxItem;
                    ftp.SetLocalDirectory(workingDirectory);
                    ftp.GetFile(selectedItem.fileName,false);
                   
                    StreamReader reader = new StreamReader(workingDirectory + @"\" + selectedItem.fileName,Encoding.Default);
                    txtFileContent.Text = reader.ReadToEnd().Replace("\n","\r\n");
                    
                }
                ftp.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                ftp.Close();
            }
        }

    }
}
