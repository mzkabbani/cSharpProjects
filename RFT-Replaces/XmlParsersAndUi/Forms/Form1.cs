﻿using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using Automation.Common;
using Automation.Common.Utils;
using Sybase.Data.AseClient;


namespace XmlParsersAndUi {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        #region Events




        private void txtOutput_DragDrop(object sender, DragEventArgs e) {
            try {
                sender.ToString();
                IDataObject listItemData = e.Data;
            } catch (Exception) {

                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            try {
                DtdElement element = new DtdElement();
                //element.selectByAttribute = "name";
                //element.selectByVAlue = "AvailableTest";
                cmbMain.Items.Add(element);

                this.AllowDrop = true;
                //   this.lvItems.AllowDragDrop = true;
                customListViewItem item = new customListViewItem();
                item.DisplayName = "Testing Item";
                item.Content = "This is the Testing Item Content here";
                lvItems.Items.Add(item.ToString());

            } catch (Exception) {

                throw;
            }
        }

        #endregion

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void lvItems_DragLeave(object sender, EventArgs e) {
            //          DoDragDrop(e, DragDropEffects.Link);
            //          e.ToString();
        }

        private void lvItems_DragOver(object sender, DragEventArgs e) {
            //          DoDragDrop(e.Data,DragDropEffects.Link);
        }

        private void lvItems_ItemDrag(object sender, ItemDragEventArgs e) {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void txtOutput_DragEnter(object sender, DragEventArgs e) {
            sender.ToString();
            IDataObject listItemData = e.Data;
            DoDragDrop(e.Data, DragDropEffects.Move);
        }


        string readText = string.Empty;
        private void btnParse_Click(object sender, EventArgs e) {

        }

        private void FindChildren() {
            XDocument newXDocument = XDocument.Parse(readText);
            IEnumerable<XElement> items = newXDocument.Descendants("element");

            var selectedElementsFirstRun = from c in newXDocument.Descendants("element")
                                           where string.Equals(c.Attribute("name").Value, cmbMain.Text)
                                           select new {
                s1 = c
            };
            if (selectedElementsFirstRun.ElementAt(0).s1.HasElements) {

                var selectedElements = from c in newXDocument.Descendants("element")
                                       where string.Equals(c.Attribute("name").Value, cmbMain.Text)
                                       select new {
                    s1 = c.Descendants("element")
                };

                IEnumerable<XElement> sElements = selectedElements.ElementAt(0).s1;
                ComboBox cmbNew = new ComboBox();
                cmbNew.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbNew.Parent = gbChildren;
                cmbNew.Dock = DockStyle.Left;
                for (int i = 0; i < sElements.Count(); i++) {
                    cmbNew.Items.Add(sElements.ElementAt(i).Attributes("ref").ElementAt(0).Value);

                }
                gbChildren.Controls.Add(cmbNew);
            } else {
                CommonUtils.ShowError(selectedElementsFirstRun.ElementAt(0).s1.Attribute("name").Value + " has no children elements", null);

            }
        }

        private void populateTreeview() {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open XML Document";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            dlg.FileName = Application.StartupPath + "\\..\\..\\example.xml";
            if (dlg.ShowDialog() == DialogResult.OK) {
                try {
                    //Just a good practice -- change the cursor to a
                    //wait cursor while the nodes populate
                    this.Cursor = Cursors.WaitCursor;
                    //First, we'll load the Xml document
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(dlg.FileName);
                    //Now, clear out the treeview,
                    //and add the first (root) node
                    tvOutput.Nodes.Clear();
                    tvOutput.Nodes.Add(new
                                       TreeNode(xDoc.DocumentElement.Name));
                    TreeNode tNode = new TreeNode();
                    tNode = (TreeNode)tvOutput.Nodes[0];
                    //We make a call to addTreeNode,
                    //where we'll add all of our nodes
                    addTreeNode(xDoc.DocumentElement, tNode);
                    //Expand the treeview to show all nodes
                    tvOutput.ExpandAll();
                } catch (XmlException xExc)
                    //Exception is thrown is there is an error in the Xml
                {
                    CommonUtils.ShowError(xExc.Message, xExc);
                } catch (Exception ex) { //General exception
                    CommonUtils.ShowError(ex.Message, ex);
                } finally {
                    this.Cursor = Cursors.Default; //Change the cursor back
                }
            }
        }

        //This function is called recursively until all nodes are loaded
        private void addTreeNode(XmlNode xmlNode, TreeNode treeNode) {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) { //The current node has children
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                    //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    //treeNode.Nodes.Add(new TreeNode(xNode.Name));
                    treeNode.Nodes.Add(new CustomTreeNode(xNode.Name, xNode.Attributes));
                    tNode = treeNode.Nodes[x];
                    addTreeNode(xNode, tNode);
                }
            } else //No children, so add the outer xml (trimming off whitespace)
                treeNode.Text = xmlNode.OuterXml.Trim();
        }

        private void btnPopulateTV_Click(object sender, EventArgs e) {
            populateTreeview();
        }

        private void tvOutput_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                grpBoxAttr.Controls.Clear();

                CustomTreeNode node = (CustomTreeNode)tvOutput.SelectedNode;
                int count = 0;
                if (node.Attributes != null) {
                    foreach (XmlAttribute attr in node.Attributes) {
                        Label label = new Label();
                        label.Text = attr.Name + ": ";

                        TextBox textbox = new TextBox();
                        textbox.Text = attr.Value;

                        Point point = new Point(grpBoxAttr.Location.X, grpBoxAttr.Location.Y + (5 * count));
                        label.Location = point;
                        label.Parent = grpBoxAttr;
                        label.Dock = DockStyle.Top;

                        textbox.Location = new Point(grpBoxAttr.Location.X + label.Location.X, grpBoxAttr.Location.Y + (5 * count));
                        textbox.Parent = grpBoxAttr;
                        textbox.Dock = DockStyle.Top;

                        grpBoxAttr.Controls.Add(textbox);
                        grpBoxAttr.Controls.Add(label);
                        count++;
                    }
                }

            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnParseEvent_Click(object sender, EventArgs e) {
            try {
                ParseEvent(txtEventIn.Text);

            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }


        XDocument xmlDocument;
        private void ParseEvent(string eventMacro) {

            xmlDocument = XDocument.Parse(eventMacro);
            populateTreeviewSingleEvent(xmlDocument.ToString());
            //IEnumerable<XElement> childred =
            //       object patterns = xmlDocument.XPathEvaluate(@"MXClientScript\Events");
            IEnumerable<XElement> children = xmlDocument.Elements();

        }



        private void populateTreeviewSingleEvent(string document) {
            try {
                //Just a good practice -- change the cursor to a
                //wait cursor while the nodes populate
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(document);
                this.Cursor = Cursors.WaitCursor;
                //First, we'll load the Xml document
                //Now, clear out the treeview,
                //and add the first (root) node
                tvOutput.Nodes.Clear();
                tvOutput.Nodes.Add(new
                                   CustomTreeNode(xDoc.DocumentElement.Name, xDoc.DocumentElement.Attributes));

                TreeNode tNode = new TreeNode();
                tNode = (TreeNode)tvOutput.Nodes[0];
                //We make a call to addTreeNode,
                //where we'll add all of our nodes
                addTreeNodeForSingleEvent(xDoc.DocumentElement, tNode);
                //Expand the treeview to show all nodes
                tvOutput.ExpandAll();
            } catch (XmlException xExc)
                //Exception is thrown is there is an error in the Xml
            {
                CommonUtils.ShowError(xExc.Message, xExc);
            } catch (Exception ex) { //General exception
                CommonUtils.ShowError(ex.Message, ex);
            } finally {
                this.Cursor = Cursors.Default; //Change the cursor back
            }

        }

        //This function is called recursively until all nodes are loaded
        private void addTreeNodeForSingleEvent(XmlNode xmlNode, TreeNode treeNode) {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) { //The current node has children
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0; x <= xNodeList.Count - 1; x++)
                    //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    //treeNode.Nodes.Add(new TreeNode(xNode.Name));
                    treeNode.Nodes.Add(new CustomTreeNode(xNode.Name, xNode.Attributes));

                    tNode = treeNode.Nodes[x];
                    addTreeNodeForSingleEvent(xNode, tNode);
                }
            } else //No children, so add the outer xml (trimming off whitespace)
                // treeNode.Text = xmlNode.Name;
                // treeNode.Text = xmlNode.Attributes["name"].Value;
                treeNode.Text = xmlNode.Attributes["name"] == null ? xmlNode.Name : xmlNode.Attributes["name"].Value;
        }

        private void cmbMain_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                //  SpawnNewCmb(cmbMain.SelectedItem.ToString());
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void SpawnNewCmb(string SelectedText) {
            ComboBox cmbNewChild = new ComboBox();
            IEnumerable<XElement> items = xmlDocument.Descendants("element");
            string s1 = string.Empty;
            var q1 = from c in xmlDocument.Descendants("element")
                     where string.Equals(c.Attribute("name").Value, SelectedText)
                     select new {
                s1 = (string)c.Value
            };

        }

        private void button1_Click(object sender, EventArgs e) {
            FindChildren();
        }

        private void button2_Click(object sender, EventArgs e) {


            //XDocument xdoc = XDocument.Parse(txtEventIn.Text);
            //string s1 = string.Empty;
            //var q1 = from c in xdoc.Descendants("AvailableTest")
            //         select new {
            //             s1 = (string)c.Element("NickName")
            //         };

            string[] fileList = Directory.GetFiles(txtInputFile.Text, "utils.xml", SearchOption.AllDirectories);


            Regex regex = new Regex("wait.after.start=\"\\d+\"");
            for (int i = 0; i < fileList.Length; i++) {
                StreamReader reader = new StreamReader(fileList[i]);
                string readText = string.Empty;
                try {
                    readText = reader.ReadToEnd();

                } finally {
                    if (reader != null) {
                        reader.Close();
                        reader.Dispose();

                    }

                    readText = regex.Replace(readText, "wait.after.start=\"10\"");

                    StreamWriter writer = new StreamWriter(fileList[i]);
                    try {
                        writer.Write(readText);
                    } finally {
                        if (writer != null) {
                            writer.Flush();
                            writer.Close();
                            writer.Dispose();
                        }
                    }
                }

            }

            MessageBox.Show("Done");

            //Regex regex1 = new Regex("<Path Tolerance=\"0\">.*[\r\n].*[\r\n].*[\r\n].*[\r\n].*[\r\n].*[\r\n].*[\r\n].*[\r\n].*</Path>");
            //string matchedText = string.Empty;
            //for (int i = 0; i < fileList.Length; i++) {
            //    matchedText = string.Empty;
            //    StreamReader reader = new StreamReader(fileList[i]);
            //    string readText = string.Empty;
            //    try {
            //        readText = reader.ReadToEnd();

            //    } finally {
            //        if (reader != null) {
            //            reader.Close();
            //            reader.Dispose();
            //        }
            //    }
            //}

            //try {
            //    string[] fileList = Directory.GetFiles(txtInputFile.Text,"*.xml.merge-left.*",SearchOption.AllDirectories);
            //    Regex regex1 = new Regex("<Path Tolerance=\"0\">.*[\r\n].*[\r\n].*[\r\n].*[\r\n].*[\r\n].*[\r\n].*[\r\n].*[\r\n].*</Path>");
            //    string matchedText = string.Empty;
            //    for (int i = 0; i < fileList.Length; i++) {
            //        matchedText = string.Empty;
            //        StreamReader reader = new StreamReader(fileList[i]);
            //        string readText = string.Empty;
            //        try {
            //            readText = reader.ReadToEnd();

            //        } finally {
            //            if (reader != null) {
            //                reader.Close();
            //                reader.Dispose();
            //            }
            //          MatchCollection colelction =   regex1.Matches(readText);
            //          for (int j = 0; j < colelction.Count; j++) {
            //              matchedText = matchedText + colelction[j].Value;
            //          }
            //        }

            //        StreamReader reader2 = new StreamReader(fileList[i].Replace("left", "right").Replace("12372", "12373"));
            //        string readText2 = string.Empty;
            //        try {
            //            readText2 = reader2.ReadToEnd();

            //        } finally {
            //            if (reader2 != null) {
            //                reader2.Close();
            //                reader2.Dispose();
            //            }
            //            MatchCollection colelction = regex1.Matches(readText2);
            //            for (int j = 0; j < colelction.Count; j++) {
            //                matchedText = matchedText + colelction[j].Value;
            //            }
            //        }

            //        StreamReader reader3 = new StreamReader(fileList[i].Replace("merge-left.r12372", "working"));
            //        string readText3 = string.Empty;
            //        try {
            //            readText3 = reader3.ReadToEnd();

            //        } finally {
            //            if (reader3 != null) {
            //                reader3.Close();
            //                reader3.Dispose();
            //            }
            //        }


            //        readText3 = readText3.Replace("<Customs>","<Customs>"+ matchedText);
            //        StreamWriter writer = new StreamWriter(fileList[i].Replace("merge-left.r12372","working"));

            //        try {
            //            writer.Write(readText3);
            //        } finally {
            //            writer.Flush();
            //            writer.Close();
            //            writer.Dispose();
            //        }
            //    }

            //    MessageBox.Show("Done");
            //   // Regex regex = new Regex("wait.after.start=\"\\d+\"");
            //    //for (int i = 0; i < fileList.Length; i++) {
            //        //StreamReader reader = new StreamReader(fileList[i]);
            //        //string readText = string.Empty;
            //        //try {
            //        //    readText = reader.ReadToEnd();

            //        //} finally {
            //        //    if(reader != null){
            //        //        reader.Close();
            //        //        reader.Dispose();

            //        //    }

            //        //    readText = regex.Replace(readText, "sync=\"true\"");

            //        //    StreamWriter writer = new StreamWriter(fileList[i]);
            //        //    try {
            //        //        writer.Write(readText);
            //        //    } finally {
            //        //        if(writer!=null){
            //        //            writer.Flush();
            //        //            writer.Close();
            //        //            writer.Dispose();
            //        //        }
            //        //    }
            //        //}

            //   // }
            //} catch (Exception ex) {
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void lvItems_MouseDown(object sender, MouseEventArgs e) {
            //Clipboard.SetDataObject(textBox1.Text);
            System.Collections.Specialized.StringCollection filePath = new
            System.Collections.Specialized.StringCollection();
            if (lvItems.SelectedItems.Count > 0) {
                filePath.Add(lvItems.SelectedItems[0].Text);
                DataObject dataObject = new DataObject();
                //dataObject.SetFileDropList(filePath);
                dataObject.SetText("testtesttest");
                dataObject.SetData("test");
                //dataObject.SetData("testtesttest");
                lvItems.DoDragDrop("test1111233", DragDropEffects.Move | DragDropEffects.Copy);
            }
        }

        private void btnAdd32Customs_Click(object sender, EventArgs e) {
            try {
                string[] fileList = Directory.GetFiles(txtInputFile.Text, "*customs.xml", SearchOption.AllDirectories);
                foreach (string filename in fileList) {
                    string newFileName = Directory.GetParent(filename)+@"\"+Path.GetFileNameWithoutExtension(filename).Split(new char[] { '_' })[0] + "_32_" + Path.GetFileNameWithoutExtension(filename).Split(new char[] { '_' })[1]+".xml";
                    File.Copy(filename, newFileName);
                }
            } catch (Exception ex) {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            try {

                string[] files =  Directory.GetFiles(txtInputFile.Text,"*.cs",SearchOption.AllDirectories);
                string replacement ="/*This file is part of XML-Parser-Engine.\r\n\r\nXML-Parser-Engine is free software: you can redistribute it and/or modify\r\nit under the terms of the GNU General Public License as published by\r\nthe Free Software Foundation, either version 3 of the License, or\r\n(at your option) any later version.\r\n\r\nXML-Parser-Engine is distributed in the hope that it will be useful,\r\nbut WITHOUT ANY WARRANTY; without even the implied warranty of\r\nMERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the\r\nGNU General Public License for more details.\r\n\r\nYou should have received a copy of the GNU General Public License\r\nalong with XML-Parser-Engine.  If not, see <http://www.gnu.org/licenses/>.*/\r\n";

                for (int i = 0; i < files.Length; i++) {
                    string read = CommonUtils.ReadFile(files[i]);
                    read = replacement + read;
                    CommonUtils.WriteFile(files[i],read);
                }


                string filePath = txtInputFile.Text;
                string readFile = CommonUtils.ReadFile(filePath);

                Regex reg = new Regex("http.*.xml");

                MatchCollection matches = reg.Matches(readFile);

                string exportScript = string.Empty;

                foreach (Match match in matches) {
                    exportScript = exportScript + "svn export " + match.Value+"\r\n";
                }

                CommonUtils.WriteFile("D:\\outputExportScript.cmd", exportScript);

            } catch (Exception ex) {

            }
        }

        private void btnUpdateConfig_Click(object sender, EventArgs e) {
            try {
             //   string configTPKS = CommonUtils.ReadFile(txtConfi.Text);

              //  string[] split = configTPKS.Split(new string[] { "\r\n" },StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, List<string>> tpkNickname = new Dictionary<string, List<string>>();

//                for (int i = 0; i < split.Length; i++) {
//                    if (tpkNickname.Count > 0) {
//                        if (tpkNickname.Keys.Contains(split[i].Split(new char[] { '\t' })[0])) {
//                            tpkNickname[split[i].Split(new char[] { '\t' })[0]].Add(split[i].Split(new char[] { '\t' })[1]);
//                        }
//                        else {
//                            List<string> values = new List<string>() {
//                                split[i].Split(new char[] { '\t' })[1]
//                            };
//                            tpkNickname.Add(split[i].Split(new char[] { '\t' })[0], values);
//
//                        }
//                    } else {
//
//                        List<string> values = new List<string>() {
//                            split[i].Split(new char[] { '\t' })[1]
//                        };
//                        tpkNickname.Add(split[i].Split(new char[] { '\t' })[0], values);
//
//                    }
//                }


                string[] configFiles =  Directory.GetFiles(txtInputFile.Text, "config.xml",SearchOption.AllDirectories);
                tpkNickname.Add("0000847",new List<string>() {"DEFAULT_2","DEFAULT"
                });
                tpkNickname.Add("0001729",new List<string>() {"DEFAULT"
                });
                tpkNickname.Add("0000982",new List<string>() {"DEFAULT_SRULE_GUI"
                });
                tpkNickname.Add("0000337",new List<string>() {"COMPAREXML","EXPORT","EXPORTHIGHLEVEL","EXPORTORACLE","IMPORTHIGHLEVEL","IMPORTORACLE","IMPORT"
                });
                tpkNickname.Add("0000593",new List<string>() {"TEST_beta_V31_PF","TEST_beta_V31_PAC"
                });
                tpkNickname.Add("0000682",new List<string>() {"TEST_154_V31"
                });
                tpkNickname.Add("0000775",new List<string>() {"210_CONVERSION"
                });

                tpkNickname.Add("0000806",new List<string>() {"DEFAULT_BIG_TO_SMALL"
                });

                tpkNickname.Add("0000832",new List<string>() {"DEFAULT"
                });
                tpkNickname.Add("0001526",new List<string>() {"DEFAULT_3_2"
                });

                tpkNickname.Add("0001000",new List<string>() {"DEFAULT","DEFAULT_2","DEFAULT_3","DEFAULT_5","EXPORTFS","RESILIENT","SPACE"
                });
                tpkNickname.Add("0001284",new List<string>() {"DEFAULT"
                });

                tpkNickname.Add("0001354",new List<string>() {"FIN-PAR_STATICS_MXML"
                });
                tpkNickname.Add("0001361",new List<string>() {"MIGRATION"
                });
                tpkNickname.Add("0001560",new List<string>() {"DEFAULT"
                });

string doneFiles="";
                for (int i = 0; i < configFiles.Length; i++) {
                    string tpkNumber = "";
                    XDocument xdoc = new XDocument();
                    try {
                        tpkNumber = Directory.GetParent(configFiles[i]).Name;

                        xdoc = XDocument.Parse(CommonUtils.ReadFile(configFiles[i]));
                    } catch (Exception ex) {
                        CommonUtils.ShowError(ex.Message, ex);
                    }


                    if (tpkNickname.Keys.Contains(tpkNumber)) {


                        for (int j = 0; j < tpkNickname[tpkNumber].Count; j++) {
                            var item = from c1 in xdoc.Descendants("AvailableTests").Descendants("AvailableTest")
                                       where string.Equals(c1.Descendants("NickName").ElementAt(0).Value, tpkNickname[tpkNumber][j])
                                       select new { elements = c1.DescendantsAndSelf() };

                            //from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                            //         where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                            //         select new {
                            //             elements = c1.DescendantNodesAndSelf()
                            //         };


                            try {
                                if (item.ElementAt(0).elements.ElementAt(0).Nodes().Count() > 0) {
                            	string testparams= 	item.ElementAt(0).elements.ElementAt(0).Element("Customize").Element("TestParameters").Value;
                            	
                            	if (testparams.Contains("do.log.check=false")) {
                            		doneFiles = doneFiles +"contains logcheckfalse "+tpkNumber+" nickname "+tpkNickname[tpkNumber][j];
                            	}
                            	
                            	
                            	
                            	testparams = Regex.Replace(testparams,"-Dexpected.log.check=\\d+","");
                            	if (Regex.IsMatch(testparams,"-Dexpected.log.check=\\d+")) {
                            			doneFiles = doneFiles +"contains logcheckNumber "+tpkNumber+" nickname "+tpkNickname[tpkNumber][j];
                            
                            	}
                            //	testparams = testparams.Replace("-D do.log.check=false","");
                            testparams = testparams.Replace("-D ","");
                            testparams = testparams.Replace(" -D-D= ","");
                            
                            	item.ElementAt(0).elements.ElementAt(0).Element("Customize").Element("TestParameters").SetValue(testparams);
                            	
                            	//                                    if (item.ElementAt(0).elements.ElementAt(0).Element("Customize") != null) {
//                                        item.ElementAt(0).elements.ElementAt(0).Element("Customize").Add(
//                                            new XElement("MxGen"));
//                                        item.ElementAt(0).elements.ElementAt(0).Element("Customize").Element("MxGen").Add(
//                                            new XElement("FullRightsUser", "USER_FULLRIGHTS"));
//                                    } else {
//                                        item.ElementAt(0).elements.ElementAt(0).Add(new XElement("Customize"));
//                                        item.ElementAt(0).elements.ElementAt(0).Element("Customize").Add(
//                                            new XElement("MxGen"));
//                                        item.ElementAt(0).elements.ElementAt(0).Element("Customize").Element("MxGen").Add(
//                                            new XElement("FullRightsUser", "USER_FULLRIGHTS"));
//                                    }

                                }
                            } catch (Exception ex) {
                                CommonUtils.ShowError(tpkNumber+" nickname "+tpkNickname[tpkNumber][j]+ ex.Message, ex);
                            }

                        }

                        xdoc.Save(configFiles[i]);
                    }

                }


            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void button5_Click(object sender, EventArgs e) {
            try {

                string[] configFiles = Directory.GetFiles(txtInputFile.Text, "config.xml");

                for (int i = 0; i < configFiles.Length; i++) {
                    XDocument xdoc = XDocument.Parse(CommonUtils.ReadFile(configFiles[i]));

                    xdoc.Descendants("AvailableTests").Descendants("AvailableTest");
                    var item = from c1 in xdoc.Descendants("AvailableTests").Descendants("AvailableTest")
                               where string.Equals(c1.Descendants("NickName").ElementAt(0).Value, "DEFAULT_CONFIG")
                               select new { elements = c1.DescendantsAndSelf() };

                    //from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                    //         where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                    //         select new {
                    //             elements = c1.DescendantNodesAndSelf()
                    //         };
                }
            } catch (Exception ex) {
            }
        }

        void Button6Click(object sender, EventArgs e) {
            string path = string.Empty;
            try {
                string[] folders = Directory.GetDirectories("D:\\sites-Stream","*sites",SearchOption.AllDirectories);
                string fileRead = CommonUtils.ReadFile("D:\\sites-Stream\\goodsites.txt");
                for (int i = 0; i < folders.Length; i++) {
                    path = path+"\r\n"+folders[i];
                    //if (folders[i].Contains("sites")) {
                    //FrontendUtils.WriteFile(folders[i]+"\\sites.mxres",fileRead);
                    //  }
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

        void BtnUtilsParserClick(object sender, EventArgs e) {
            string[] fileList = Directory.GetFiles(txtInputFile.Text, "utils.xml", SearchOption.AllDirectories);
            string operatedFiles = "";
            Regex regex = new Regex("wait.after.start=\"\\d+\"");
            for (int i = 0; i < fileList.Length; i++) {
                StreamReader reader = new StreamReader(fileList[i]);
                operatedFiles = operatedFiles +"\r\n"+fileList[i];
                string readText = string.Empty;
                try {
                    readText = reader.ReadToEnd();
                } finally {
                    if (reader != null) {
                        reader.Close();
                        reader.Dispose();
                    }
                    readText = regex.Replace(readText, "wait.after.start=\"10\"");
                    StreamWriter writer = new StreamWriter(fileList[i]);
                    try {
                        writer.Write(readText);
                    } finally {
                        if (writer != null) {
                            writer.Flush();
                            writer.Close();
                            writer.Dispose();
                        }
                    }
                }
            }
            operatedFiles = operatedFiles +"";
            MessageBox.Show("Done");
        }

        void BtnTestConnClick(object sender, EventArgs e) {
            string connectionString = txtConnx.Text;
            //   OleDbConnection conn = new OleDbConnection(connectionString);
            AseConnection conn = new AseConnection(connectionString);

            try {
                conn.Open();

                AseCommand command = new AseCommand("select max(ID) from QA_PAC_TIMING where TEST_PACKAGE='PAR.TPK.0000949'",conn);
                command.CommandTimeout = 99999;
                object scale = command.ExecuteScalar();
                AseDataReader  data=  command.ExecuteReader();
                string result =    data.GetString(0);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message+"\r\n\r\n"+ex.StackTrace);
            } finally {
                conn.Close();
            }
        }
        
        void Button7Click(object sender, EventArgs e)
        {
        	  string[] fileList = Directory.GetFiles(txtInputFile.Text, "config.xml", SearchOption.AllDirectories);
            string operatedFiles = "";
            Regex regex = new Regex("<File>(.*)</File>");
            string foundFiles = "";
            string foundFiles2 = "";
            for (int i = 0; i < fileList.Length; i++) {
                StreamReader reader = new StreamReader(fileList[i]);               
                string readText = string.Empty;
                try {
                    readText = reader.ReadToEnd();
                } finally {
                    if (reader != null) {
                        reader.Close();
                        reader.Dispose();
                    }
                	
                	foreach (Match match in Regex.Matches(readText,"<File>(.*)</File>")){
                		foundFiles = foundFiles+"\r\n" +match.Groups[1].Value.ToString();
                	    foundFiles2 = foundFiles2 +"\r\n TPK:"+Directory.GetParent(Directory.GetParent(fileList[i]).FullName)+" - "+Directory.GetParent(fileList[i])+" fileName: " +match.Groups[1].Value.ToString();
                	      	
                	}
                	
                 
                 
                }
            }
            
            
            CommonUtils.WriteFile("D:/AddopNames/fileNames.txt",foundFiles);
             CommonUtils.WriteFile("D:/AddopNames/fileNamesOrg.txt",foundFiles2);
            MessageBox.Show("Done");
        }
    }
}
