using System;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SemiAutomaticConverter {
    public partial class SearchAndReplace : Form {
        public SearchAndReplace() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string[] file = Directory.GetFiles(txtDirectory.Text, "description.xml", SearchOption.AllDirectories);
            for (int i = 0; i < file.Length; i++) {
                StreamReader reader = new StreamReader(file[i]);
                string fileRead = string.Empty;
                try {
                    fileRead = reader.ReadToEnd();
                } finally {
                    reader.Close();
                }
                fileRead = fileRead.Replace("<Technical>" + txtOldTechCon.Text + "</Technical>", "<Technical>" + txtNewtechCon.Text + "</Technical>");
                StreamWriter writer = new StreamWriter(file[i]);
                try {
                    writer.Write(fileRead);
                } finally {
                    writer.Close();
                }

            }
            MessageBox.Show("Done");
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult == DialogResult.OK) {
                    txtDirectory.Text = folderBrowserDialog.SelectedPath;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnique_Click(object sender, EventArgs e) {
            StreamReader reader = new StreamReader(txtDirectory.Text);
            List<string> uniques = new List<string>();
            try {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null) {
                    if (!uniques.Contains(line)) {
                        uniques.Add(line);
                    }
                }

            } finally {
                if (reader != null) {
                    reader.Close();
                }
            }
            StreamWriter writer = new StreamWriter(@"C:\Documents and Settings\mkabbani\Desktop\out.txt");
            try {
                for (int i = 0; i < uniques.Count; i++) {
                    writer.WriteLine(uniques[i]);
                }
            } finally {
                if (writer != null) {
                    writer.Close();
                }
            }
        }

        private void btnFindPath_Click(object sender, EventArgs e) {


            DirectoryInfo info = new DirectoryInfo(txtDirectory.Text);
            FileInfo[] finfo = info.GetFiles();
            List<string> list = new List<string>();

            for (int i = 0; i < finfo.Length; i++) {

                StreamReader reader = new StreamReader(finfo[i].FullName);
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null) {
                    if (!string.IsNullOrEmpty(line)) {

                        if (line.Contains("ApplicationDirectoryPath")) {

                            if (!list.Contains(line)) {
                                list.Add(line);

                            }


                        }

                    }
                }


            }

            StreamWriter writer = new StreamWriter(@"C:\Documents and Settings\mkabbani\Desktop\fileList.txt");
            for (int i = 0; i < list.Count; i++) {
                writer.WriteLine(list[i]);


            }


        }

        private void button2_Click(object sender, EventArgs e) {
            try {
                if(!Directory.Exists(Directory.GetCurrentDirectory() +@"\output")){
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() +@"\output");
                }
                string sessionKey = string.Empty;
                if (string.IsNullOrEmpty(txtSessionKey.Text.Trim())) {
                    Random random = new Random(10);
                    sessionKey = random.Next(8999).ToString();
                } else {
                    sessionKey = txtSessionKey.Text.Trim();                
                }

                txtOutput.Text = string.Empty;
                string fileRead = string.Empty;
                StreamReader reader = new StreamReader(txtDirectory.Text);
                string eventsFile = "<Steps label=\"Automatically Generated\">";
                try {
                    fileRead = reader.ReadToEnd();
                    MatchCollection collection = Regex.Matches(fileRead, "<Comment.*>(.*)</Comment>");
                    List<string> matches = new List<string>();
                    for (int i = 0; i < collection.Count; i++) {
                        matches.Add(collection[i].Groups[1].ToString());
                        txtOutput.Text = txtOutput.Text + "\r\n" + collection[i].Groups[1].ToString();
                    }


                    string newFileRead = Regex.Replace(fileRead, "<Comment.*</Comment>", "</Events></MXClientScript><!-- --><MXClientScript><Events>");
                    string[] test = new string[] { "<!-- -->" };
                    string[] splitArray = newFileRead.Split(test, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < splitArray.Length; j++) {
                        if (j < collection.Count) {
                            StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() +@"\output\step" + (j + 1) + "_events.xml");
                            StreamWriter guiWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\output\step" + (j + 1) + "_gui.xml");
                            StreamWriter customsWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\output\step" + (j + 1) + "_customs.xml");
                            try {
                                guiWriter.Write(" ");
                                customsWriter.Write(@"<Customs></Customs>");
                                writer.Write(splitArray[j]);
                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" sessionKey=\""+ sessionKey +"\" label=\"" + collection[j].Groups[1].ToString() + "\" events=\"step" + (j + 1) + "_events.xml\" gui=\"step" + (j + 1) + "_gui.xml\" customs=\"step" + (j + 1) + "_customs.xml\"></Step>";
                            } finally {
                                if (writer != null) {
                                    writer.Close();
                                }
                                if (guiWriter != null) {
                                    guiWriter.Close();
                                }
                                if (customsWriter != null) {
                                    customsWriter.Close();
                                }
                            }
                        } else {
                            StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\output\step" + (j + 1) + "_events.xml");
                                                    try {
                            
                                writer.Write(splitArray[j]);
                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"Exit\" events=\"step" + (j + 1) + "_events.xml\"></Step>";
                            } finally {
                                if (writer != null) {
                                    writer.Close();
                                }                              
                            }

                        }

                    }
                } finally {
                    if (reader != null) {
                        reader.Close();
                    }
                }


                StreamWriter eventsfilesWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\output\eventsfiles.xml");
                try {
                    eventsFile = eventsFile + "</Steps>";
                    eventsfilesWriter.Write(eventsFile);
                } finally {
                    if (eventsfilesWriter != null) {
                        eventsfilesWriter.Close();
                    }
                }

                MessageBox.Show("Done!");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) {
            try {
                string directoryLocation = txtDirectory.Text;
                List<string> parentDirectories = new List<string>();
                string[] files = Directory.GetFiles(directoryLocation, "*gui.xml", SearchOption.AllDirectories);
                string[] filesgim = Directory.GetFiles(directoryLocation, "*gim.xml", SearchOption.AllDirectories);

                for (int i = 0; i < files.Length; i++) {
                    DirectoryInfo parentDirectory = Directory.GetParent(files[i]);
                    if (!parentDirectories.Contains(parentDirectory.FullName)) {
                        parentDirectories.Add(parentDirectory.FullName);
                    }
                }
                for (int i = 0; i < filesgim.Length; i++) {
                    DirectoryInfo parentDirectory = Directory.GetParent(filesgim[i]);
                    if (!parentDirectories.Contains(parentDirectory.FullName)) {
                        parentDirectories.Add(parentDirectory.FullName);
                    }
                }
                for (int i = 0; i < parentDirectories.Count; i++) {
                    string[] guiFilesInDir = Directory.GetFiles(parentDirectories[i],"*gui.xml");
                    string[] guiGimFilesInDir = Directory.GetFiles(parentDirectories[i], "*gim.xml");

                    Directory.CreateDirectory(parentDirectories[i] + @"\__" + txtNewNickname.Text+ "__");

                    for (int j = 0; j < guiFilesInDir.Length; j++) {

                        File.Copy(guiFilesInDir[j], parentDirectories[i] + @"\__" + txtNewNickname.Text + @"__\" + Path.GetFileName(guiFilesInDir[j]));
                    }

                    for (int k = 0; k < guiGimFilesInDir.Length; k++) {
                        File.Copy(guiGimFilesInDir[k], parentDirectories[i] + @"\__" + txtNewNickname.Text + @"__\" + Path.GetFileName(guiGimFilesInDir[k]));
                    }

                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Done");
        }

        private void button5_Click(object sender, EventArgs e) {
            Process.Start(Directory.GetCurrentDirectory() + @"\output");
        }
    }
}
