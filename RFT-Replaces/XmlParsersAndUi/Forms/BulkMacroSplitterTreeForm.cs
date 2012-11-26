using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using Automation.Common;
using Automation.Common.Classes.Monitoring;
using Automation.Common.Forms;
using Automation.Common.Utils;
using XmlParsersAndUi.Forms;

namespace XmlParsersAndUi {
    public partial class BulkMacroSplitterTreeForm : BaseForm {

        #region Constructor

        public BulkMacroSplitterTreeForm() {
            InitializeComponent();
        }

        #endregion

        #region Variables

        string oldEventsFile = string.Empty;
        bool check = true;
        string fsEventsFile = string.Empty;
        string buildFileText = string.Empty;
        string buildFileTextGrouped = string.Empty;
        string buildMacroStep = "<automation.macroplayback eventsfile=\"${datastore}.macros.${OutputFolderName}.eventsfiles.xml\"" +
                                " kernelsteptitle=\"{TestTitle}\" createstep=\"false\" />";
        bool splitPerformed = false;
		bool loadFolderUsed = false;
        #endregion

        #region Methods

        private void StartSplittingFile() {
            if (!Directory.Exists(txtOutputDir.Text)) {
                Directory.CreateDirectory(txtOutputDir.Text);
            }
            string sessionKey = string.Empty;
            sessionKey = txtSessionKey.Text.Trim();
            string fileRead = string.Empty;
            StreamReader reader = new StreamReader(txtDirectory.Text);
            string eventsFile = "<Steps label=\"Automatically Generated\">";
            try {
                fileRead = reader.ReadToEnd();
                MatchCollection collection = Regex.Matches(fileRead, "<Comment.*>(.*)</Comment>");
                List<string> matches = new List<string>();
                for (int i = 0; i < collection.Count; i++) {
                    matches.Add(collection[i].Groups[1].ToString());
                }
                string newFileRead = Regex.Replace(fileRead, "<Comment.*</Comment>", "</Events></MXClientScript><!-- --><MXClientScript><Events>");
                string[] test = new string[] { "<!-- -->" };
                string[] splitArray = newFileRead.Split(test, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < splitArray.Length; j++) {
                    if (j < collection.Count) {
                        StreamWriter writer = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml");
                        StreamWriter guiWriter = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_gui.xml");
                        StreamWriter customsWriter = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_customs.xml");
                        try {
                            guiWriter.Write(" ");
                            customsWriter.Write(@"<Customs></Customs>");
                            writer.Write(splitArray[j]);
                            if (string.IsNullOrEmpty(sessionKey)) {
                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" label=\"" + collection[j].Groups[1].ToString() + "\" events=\"step" + (j + 1) + "_events.xml\" gui=\"step" + (j + 1) + "_gui.xml\" customs=\"step" + (j + 1) + "_customs.xml\"></Step>";
                            } else {
                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"" + collection[j].Groups[1].ToString() + "\" events=\"step" + (j + 1) + "_events.xml\" gui=\"step" + (j + 1) + "_gui.xml\" customs=\"step" + (j + 1) + "_customs.xml\"></Step>";
                            }
                            BulkMacroTreeNode node = new BulkMacroTreeNode();
                            node.filepathEvents = txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml";
                            node.stepName = "step" + (j + 1) + "_events.xml";
                            node.stepTitle = collection[j].Groups[1].ToString();
                            node.stepEvents = splitArray[j];
                            node.Text = node.stepName + " | " + node.stepTitle;
                            tvResults.Nodes.Add(node);
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
                        StreamWriter writer = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml");
                        try {
                            writer.Write(splitArray[j]);
                            if (string.IsNullOrEmpty(sessionKey)) {
                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" label=\"Exit\" events=\"step" + (j + 1) + "_events.xml\"></Step>";
                            } else {
                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"Exit\" events=\"step" + (j + 1) + "_events.xml\"></Step>";
                            }
                            //remove customs and gui for exit step
                            File.Delete(txtOutputDir.Text + @"\step" + (j + 1) + "_gui.xml");
                            File.Delete(txtOutputDir.Text + @"\step" + (j + 1) + "_gui.xml");
                            BulkMacroTreeNode node = new BulkMacroTreeNode();
                            node.filepathEvents = txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml";
                            node.stepName = "step" + (j + 1) + "_events.xml";
                            node.stepTitle = "Exit";
                            node.stepEvents = splitArray[j];
                            node.Text = node.stepName + " | " + "Exit";
                            tvResults.Nodes.Add(node);
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
            eventsFile = WriteEventsFile(eventsFile);
            buildFileText = buildMacroStep.Replace("${OutputFolderName}", Path.GetFileName(txtOutputDir.Text));
        }

        private string WriteEventsFile(string eventsFile) {
            StreamWriter eventsfilesWriter = new StreamWriter(txtOutputDir.Text + @"\eventsfiles.xml");
            try {
                eventsFile = eventsFile + "</Steps>";
                eventsfilesWriter.Write(eventsFile);
                oldEventsFile = eventsFile;
            } finally {
                if (eventsfilesWriter != null) {
                    eventsfilesWriter.Close();
                }
            }
            return eventsFile;
        }

        private string PrepareFsEventsFile(List<checkboxItems> selectedItems, string oldEventsFile) {
            string preparedEventsFile = string.Empty;
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(oldEventsFile);
            for (int i = 0; i < selectedItems.Count; i++) {
                XmlNode requestedNode = GetRespectiveChildNode(selectedItems[i], xDoc);
            }
            return preparedEventsFile;
        }

        private XmlNode GetRespectiveChildNode(checkboxItems selectedItem, XmlDocument xDoc) {
            XmlNode node = null;
            for (int i = 0; i < xDoc.DocumentElement.ChildNodes.Count; i++) {
            }
            return node;
        }

        private static void SetDefaultFormValues(SessionKeyAndTitleForm form) {
            Random random = new Random(DateTime.Now.Millisecond);
            form.Controls["txtSessionKey"].Text = random.Next(8999).ToString();
        }

        private void CleanOutputDir(BulkMacroTreeNode bulkMacroTreeNode) {
            File.Delete(bulkMacroTreeNode.filepathEvents);
            if (File.Exists(Directory.GetParent(bulkMacroTreeNode.filepathEvents)+"/eventsfiles.xml")) {	
            	 File.Delete(Directory.GetParent(bulkMacroTreeNode.filepathEvents)+"/eventsfiles.xml");
            }
            string parentDirectory = Directory.GetParent(bulkMacroTreeNode.filepathEvents).ToString();
            if (string.IsNullOrEmpty(bulkMacroTreeNode.filepathCustoms) && File.Exists(parentDirectory + @"\" + Path.GetFileName(bulkMacroTreeNode.filepathEvents).Replace("events", "customs"))) {
                File.Delete(parentDirectory + @"\" + Path.GetFileName(bulkMacroTreeNode.filepathEvents).Replace("events", "customs"));
            }
            if (string.IsNullOrEmpty(bulkMacroTreeNode.filepathGui) && File.Exists(parentDirectory + @"\" + Path.GetFileName(bulkMacroTreeNode.filepathEvents).Replace("events", "gui"))) {
                File.Delete(parentDirectory + @"\" + Path.GetFileName(bulkMacroTreeNode.filepathEvents).Replace("events", "gui"));
            }
        }

        private void CreateBuildXmlFile(string parentTitle, string outputFolderName) {
            buildFileTextGrouped = buildFileTextGrouped + "\r\n\r\n" + buildMacroStep.Replace("${OutputFolderName}", outputFolderName).Replace("{TestTitle}", parentTitle);
        }

        private void GenerateSplitFile(List<BulkMacroTreeNode> movedNodes, string sessionKey, string folderName, int startIndex) {
            string eventsFileDirectory = Directory.GetParent(movedNodes[0].filepathEvents).ToString();
            Directory.CreateDirectory(eventsFileDirectory);
            string eventsFileText = "<Steps label=\"Automatically Generated\">";
            for (int i = startIndex - 1, j = 0; i < (movedNodes.Count + startIndex - 1); i++, j++) {
                if (!string.Equals(movedNodes[j].stepTitle, "Exit")) {
                    WriteCustomsFile(eventsFileDirectory, i + 1,movedNodes[j]);
                    WriteGuiFile(eventsFileDirectory, i + 1,movedNodes[j]);
                }
                WriteStepEventFile(eventsFileDirectory, i + 1, movedNodes[j]);
                if (string.Equals(movedNodes[j].stepTitle, "Exit")) {
                    if (string.IsNullOrEmpty(sessionKey)) {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" label=\"Exit\" events=\"step" + (i + 1) + "_events.xml\" ></Step>";
                    } else {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"Exit\" events=\"step" + (i + 1) + "_events.xml\" ></Step>";
                    }
                } else {
                    if (!string.IsNullOrEmpty(sessionKey)) {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"" + movedNodes[j].stepTitle + "\" events=\"step" + (i + 1) + "_events.xml\" gui=\"step" + (i + 1) + "_gui.xml\" customs=\"step" + (i + 1) + "_customs.xml\"></Step>";
                    } else {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" label=\"" + movedNodes[j].stepTitle + "\" events=\"step" + (i + 1) + "_events.xml\" gui=\"step" + (i + 1) + "_gui.xml\" customs=\"step" + (i + 1) + "_customs.xml\"></Step>";
                    }
                }
            }
            WriteEventsFile(sessionKey, eventsFileDirectory, eventsFileText);
        }

        private void WriteStepEventFile(string eventsFileDirectory, int stepNumber, BulkMacroTreeNode bulkMacroTreeNode) {
            StreamWriter writer = new StreamWriter(eventsFileDirectory + @"\step" + stepNumber + "_events.xml");
            try {
                writer.Write(bulkMacroTreeNode.stepEvents);
            } finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        private void WriteGuiFile(string eventsFileDirectory, int guiNumber, BulkMacroTreeNode selectedNode) {
            if (!string.IsNullOrEmpty(selectedNode.filepathGui)) {
        		File.Move(selectedNode.filepathGui,eventsFileDirectory + @"\step" + guiNumber + "_gui.xml");
        		//  string readGui = CommonUtils.ReadFile(selectedNode.filepathGui);
              //  CommonUtils.WriteFile(eventsFileDirectory + @"\step" + guiNumber + "_gui.xml",readGui);
            } else {
                CommonUtils.WriteFile(eventsFileDirectory + @"\step" + guiNumber + "_gui.xml","<GuiRoot MXRequest=\"GetFullTree\"></GuiRoot>");
            }
            if (!string.IsNullOrEmpty(selectedNode.filepathGuiGim)) {
        		File.Move(selectedNode.filepathGuiGim,eventsFileDirectory + @"\step" + guiNumber + "_gui_gim.xml");
               // string readGuiGim = CommonUtils.ReadFile(selectedNode.filepathGuiGim);
              //  CommonUtils.WriteFile(eventsFileDirectory + @"\step" + guiNumber + "_gui_gim.xml",readGuiGim);
            }
        }

        private void WriteCustomsFile(string eventsFileDirectory, int customsNumber, BulkMacroTreeNode selectedNode) {
            if (!string.IsNullOrEmpty(selectedNode.filepathCustoms)) {
        		File.Move(selectedNode.filepathCustoms,eventsFileDirectory + @"\step" + customsNumber + "_customs.xml");
               // string readCustoms = CommonUtils.ReadFile(selectedNode.filepathCustoms);
               // CommonUtils.WriteFile(eventsFileDirectory + @"\step" + customsNumber + "_customs.xml",readCustoms);
            } else {
                CommonUtils.WriteFile(eventsFileDirectory + @"\step" + customsNumber + "_customs.xml",@"<Customs></Customs>");
            }
        }

        private void WriteEventsFile(string sessionKey, string eventsFileDirectory, string eventsFileText) {
            StreamWriter eventsfilesWriter = new StreamWriter(eventsFileDirectory + @"\eventsfiles.xml");
            try {
                eventsFileText = eventsFileText + "</Steps>";
                eventsfilesWriter.Write(eventsFileText);
            } finally {
                if (eventsfilesWriter != null) {
                    eventsfilesWriter.Flush();
                    eventsfilesWriter.Close();
                    eventsfilesWriter.Dispose();
                }
            }
        }

        #endregion

        #region Events

        private void btnShowOutput_Click(object sender, EventArgs e) {
            if (Directory.Exists(txtOutputDir.Text)) {
                Process.Start(txtOutputDir.Text);
            } else {
                CommonUtils.ShowError("The output directory does not exist yet", null);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            btnSplitFile.Enabled = true;
            tvResults.Nodes.Clear();
            buildFileText = string.Empty;
            buildFileTextGrouped = string.Empty;
            splitPerformed = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtDirectory.Text = dialog.FileName;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnOutputDir_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtOutputDir.Text = dialog.SelectedPath;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void txtDirectory_TextChanged(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtDirectory.Text)) {
                    string outputDir = Directory.GetParent(txtDirectory.Text) + @"\output";
                    if (!Directory.Exists(outputDir)) {
                        Directory.Exists(outputDir);
                    }
                    txtOutputDir.Text = outputDir;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void BulkMacroSplitterForm_Load(object sender, EventArgs e) {
        	base.LoadForm(this);        	
        }

        private void btnSplitFile_Click(object sender, EventArgs e) {
            try {
                tvResults.Nodes.Clear();
                splitPerformed=true;
                StartSplittingFile();
                btnSplitFile.Enabled = false;
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion


        /// <summary> /// Gets controls for context menu ///
        /// </summary> /// <param name="Sender">Sender object from menu event handler</param> ///
        /// <returns></returns>
        private object GetSourceControl(Object Sender) {
            // ContextMenuStrip sended?
            if (Sender as ContextMenuStrip != null) {
                ContextMenuStrip cms = Sender as ContextMenuStrip;
                return cms.SourceControl;
            }
            var item = Sender as ToolStripItem;
            // move to root item
            while (item.OwnerItem != null) {
                item = item.OwnerItem;
            }
            // we have root item now, so lets take ContextMenuStrip object
            var menuObject = item.Owner as ContextMenuStrip;
            if (menuObject != null) {
                return menuObject.SourceControl;
            }
            return null;
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e) {
            Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
            MWTreeView treeView = control as MWTreeView;

            if (treeView != null) {

                if (treeView.SelNodes.Count > 0) {

                    SessionKeyAndTitleForm form = new SessionKeyAndTitleForm(txtOutputDir.Text);
                    DialogResult result = form.ShowDialog();
                    SetDefaultFormValues(form);
                    if (result == DialogResult.OK) {
                        int startIndex = Convert.ToInt32(((NumericUpDown)form.Controls["nudStartIndex"]).Value);
                        string outputFolderName = form.Controls["txtFolderName"].Text + "-" + form.eventsGroupNameAndID.OperationGeneratedID;
                        string testTitle = form.Controls["txtTestTitle"].Text;

                        object[] selectedKeys = new object[treeView.SelNodes.Count];
                        treeView.SelNodes.Keys.CopyTo(selectedKeys, 0);


                        List<BulkMacroTreeNode> selectedNodes = new List<BulkMacroTreeNode>();

                        bool emptyParentInSelection = false;

                        for (int i = 0; i < selectedKeys.Length; i++) {
                            BulkMacroTreeNode node = (treeView.SelNodes[selectedKeys[i]] as Automation.Common.MWTreeNodeWrapper).Node as BulkMacroTreeNode;
                            if (!node.Text.Contains("|")) {
                                emptyParentInSelection = true;
                            }
                            selectedNodes.Add(node);
                        }

                        if (!emptyParentInSelection) {
                            tvResults.ClearSelNodes();
                            selectedNodes.Sort(BulkMacroTreeNode.stepIndexComparison);


                            List<BulkMacroTreeNode> movedNodes = new List<BulkMacroTreeNode>();
                            for (int i = 0; i < selectedNodes.Count; i++) {

                                BulkMacroTreeNode bulkMacroTreeNode = selectedNodes[i].Clone() as BulkMacroTreeNode;
                                bulkMacroTreeNode.endStepId = selectedNodes[i].endStepId;
                                bulkMacroTreeNode.filepathEvents = selectedNodes[i].filepathEvents;
                                bulkMacroTreeNode.startStepId = selectedNodes[i].startStepId;
                                bulkMacroTreeNode.stepEvents = selectedNodes[i].stepEvents;
								bulkMacroTreeNode.filepathCustoms =  selectedNodes[i].filepathCustoms;
								bulkMacroTreeNode.filepathGui =  selectedNodes[i].filepathGui;
								bulkMacroTreeNode.filepathGuiGim =  selectedNodes[i].filepathGuiGim;
                               
								CleanOutputDir(bulkMacroTreeNode);
								
                                //outputFolderName
                                bulkMacroTreeNode.stepName = Regex.Replace(selectedNodes[i].stepName, "\\d+", ((i) + startIndex).ToString());
                                bulkMacroTreeNode.stepTitle = selectedNodes[i].stepTitle;
                                bulkMacroTreeNode.Text = bulkMacroTreeNode.stepName + " | " + bulkMacroTreeNode.stepTitle;
                                bulkMacroTreeNode.filepathEvents = Directory.GetParent(bulkMacroTreeNode.filepathEvents) + @"\" + outputFolderName + @"\" + bulkMacroTreeNode.stepName;
                                tvResults.DeselectNode(bulkMacroTreeNode, true);
                                selectedNodes[0].Nodes.Add(bulkMacroTreeNode);
                                //outputFolderName
                                selectedNodes[0].isParentNode = true;
                                selectedNodes[0].Tag = outputFolderName;
                                movedNodes.Add(bulkMacroTreeNode);
                                if (i > 0) {
                                    selectedNodes[i].Remove();
                                }
                            }
                            
                            selectedNodes[0].Text = testTitle;
                            selectedNodes[0] = new BulkMacroTreeNode();
                            GenerateSplitFile(movedNodes, form.sessionKey, outputFolderName, startIndex);
                            CreateBuildXmlFile(testTitle, outputFolderName);
                            File.Delete(Directory.GetParent(txtOutputDir.Text) + @"\eventsfiles.xml");
                        }
                    }
                }
                tvResults.ExpandAll();
            }
        }

        private void txtShowBuildFile_Click(object sender, EventArgs e) {
            // show buildFileTextGrouped;
            try {
                BulkMacroBuildXmlForm form = new BulkMacroBuildXmlForm(buildFileTextGrouped);
                form.ShowDialog();

            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void renameSToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
                MWTreeView resutltsTree = control as MWTreeView;
                if (resutltsTree != null) {
                    BulkMacroTreeNode bulkMacroTreeNode = resutltsTree.SelNode as BulkMacroTreeNode;
                    if (bulkMacroTreeNode != null) {
                        if (!bulkMacroTreeNode.isParentNode) {
                            RenameStepForm form = new RenameStepForm(bulkMacroTreeNode.stepTitle);
                            DialogResult dialog = form.ShowDialog();
                            if (dialog == DialogResult.OK) {
                                bulkMacroTreeNode.stepTitle = form.Controls["txtNewStepTitle"].Text;
                                bulkMacroTreeNode.Text = bulkMacroTreeNode.Text.Split(new char[] { '|' })[0]
                                                         + "| " + form.Controls["txtNewStepTitle"].Text;
                                UpdateEventsFileWithNewName(bulkMacroTreeNode);
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void UpdateEventsFileWithNewName(BulkMacroTreeNode bulkMacroTreeNode) {
            string eventsFilePath = Directory.GetParent(bulkMacroTreeNode.filepathEvents) + @"\eventsfiles.xml";
            string renameStepRegex = "(<Step.*?label=\")(.*?)(\" events=\"" + bulkMacroTreeNode.stepName + "\".*?></Step>)";
            string eventsFile = CommonUtils.ReadFile(eventsFilePath);
            eventsFile = Regex.Replace(eventsFile, renameStepRegex, "$1" + bulkMacroTreeNode.stepTitle + "$3");
            CommonUtils.WriteFile(eventsFilePath, eventsFile);
        }

        private void cmsResultsTreeView_Opening(object sender, CancelEventArgs e) {
            try {
                Control control = GetSourceControl(sender) as Control;
                MWTreeView resutltsTree = control as MWTreeView;
                if (resutltsTree != null) {
                    //int leve=  resutltsTree.SelNode.Level;

                    if (resutltsTree.SelNodes.Count > 1) {
                        renameSToolStripMenuItem.Enabled = false;
                        compareExceptionToolStripMenuItem.Enabled = false;
                        compareDialogToolStripMenuItem.Enabled = false;
                        object[] selectedKeys = new object[resutltsTree.SelNodes.Count];
                        resutltsTree.SelNodes.Keys.CopyTo(selectedKeys, 0);


                        List<BulkMacroTreeNode> selectedNodes = new List<BulkMacroTreeNode>();

                        bool foundParentOrLevelTwo = false;
                        for (int i = 0; i < selectedKeys.Length && !foundParentOrLevelTwo; i++) {
                            BulkMacroTreeNode node = (resutltsTree.SelNodes[selectedKeys[i]] as Automation.Common.MWTreeNodeWrapper).Node as BulkMacroTreeNode;
                            if (node.isParentNode || node.Level > 0) {
                                foundParentOrLevelTwo = true;
                            }
                        }
                        if (foundParentOrLevelTwo) {
                            groupToolStripMenuItem.Enabled = false;
                        } else {
                            groupToolStripMenuItem.Enabled = true;
                        }
                    } else if (resutltsTree.SelNode != null) {
                        if (resutltsTree.SelNode.Level > 0 || (resutltsTree.SelNode as BulkMacroTreeNode).isParentNode) {
                            compareExceptionToolStripMenuItem.Enabled = true;
                            renameSToolStripMenuItem.Enabled = true;
                            compareDialogToolStripMenuItem.Enabled = true;
                            if ((resutltsTree.SelNode as BulkMacroTreeNode).isParentNode) {
                                groupToolStripMenuItem.Enabled = false;
                                renameSToolStripMenuItem.Enabled = false;
                                compareDialogToolStripMenuItem.Enabled = false;
                                compareExceptionToolStripMenuItem.Enabled = false;
                            }
                        } else {
                            renameSToolStripMenuItem.Enabled = true;
                            compareExceptionToolStripMenuItem.Enabled = true;
                            compareDialogToolStripMenuItem.Enabled = true;
                            groupToolStripMenuItem.Enabled = true;
                        }
                    } else {
                        groupToolStripMenuItem.Enabled = false;
                        compareExceptionToolStripMenuItem.Enabled = false;
                        compareDialogToolStripMenuItem.Enabled = false;
                        renameSToolStripMenuItem.Enabled = false;
                    }
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void BulkMacroSplitterTreeForm_FormClosing(object sender, FormClosingEventArgs e) {

        }

        private void compareExceptionToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
                MWTreeView resutltsTree = control as MWTreeView;
                if (resutltsTree != null) {
                    BulkMacroTreeNode bulkMacroTreeNode = resutltsTree.SelNode as BulkMacroTreeNode;
                    if (bulkMacroTreeNode != null) {
                        if (!bulkMacroTreeNode.isParentNode) {
                            UpdateEventsFileWithCompareException(bulkMacroTreeNode);
                            if (!bulkMacroTreeNode.Text.Contains("[CE]")) {
                                bulkMacroTreeNode.Text = bulkMacroTreeNode.Text + " [CE]";
                            }

                        }
                    }
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void UpdateEventsFileWithCompareException(BulkMacroTreeNode bulkMacroTreeNode) {
            string eventsFilePath = Directory.GetParent(bulkMacroTreeNode.filepathEvents) + @"\eventsfiles.xml";
            string renameStepRegex = "(<Step.*?(id=\"\\d+\"))(.*?label=\".*?\" events=\"" + bulkMacroTreeNode.stepName + "\".*?></Step>)";
            string eventsFile = CommonUtils.ReadFile(eventsFilePath);
            eventsFile = Regex.Replace(eventsFile, renameStepRegex, "$1" +
                                       " compareExceptions=\"true\" exception=\"" +
                                       bulkMacroTreeNode.stepName.Replace("events", "exception") +
                                       "\" exceptionCustoms=\"" +
                                       bulkMacroTreeNode.stepName.Replace("events.xml", "exception") +
                                       "_customs.xml\" " +
                                       "$3");

            //write step1_exception.xml
            CommonUtils.WriteFile(Directory.GetParent(bulkMacroTreeNode.filepathEvents) +
                                  @"\" + bulkMacroTreeNode.stepName.Replace("events", "exception"), "");
            //write step1_exception_customs.xml
            CommonUtils.WriteFile(Directory.GetParent(bulkMacroTreeNode.filepathEvents) +
                                  @"\" + bulkMacroTreeNode.stepName.Replace("events.xml", "exception") + "_customs.xml", "");




            CommonUtils.WriteFile(eventsFilePath, eventsFile);
        }

        private void compareDialogToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
                MWTreeView resutltsTree = control as MWTreeView;
                if (resutltsTree != null) {
                    BulkMacroTreeNode bulkMacroTreeNode = resutltsTree.SelNode as BulkMacroTreeNode;
                    if (bulkMacroTreeNode != null) {
                        if (!bulkMacroTreeNode.isParentNode) {
                            UpdateEventsFileWithCompareDialogs(bulkMacroTreeNode);
                            if (!bulkMacroTreeNode.Text.Contains("[CD]")) {
                                bulkMacroTreeNode.Text = bulkMacroTreeNode.Text + " [CD]";
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void UpdateEventsFileWithCompareDialogs(BulkMacroTreeNode bulkMacroTreeNode) {
            string eventsFilePath = Directory.GetParent(bulkMacroTreeNode.filepathEvents) + @"\eventsfiles.xml";
            string renameStepRegex = "(<Step.*?(id=\"\\d+\"))(.*?label=\".*?\" events=\"" + bulkMacroTreeNode.stepName + "\".*?></Step>)";
            string eventsFile = CommonUtils.ReadFile(eventsFilePath);
            eventsFile = Regex.Replace(eventsFile, renameStepRegex, "$1" +
                                       " compareDialogs=\"true\" dialog=\"" +
                                       bulkMacroTreeNode.stepName.Replace("events", "dialog") +
                                       "\" " +
                                       "$3");

            //write step1_dialog.xml
            CommonUtils.WriteFile(Directory.GetParent(bulkMacroTreeNode.filepathEvents) +
                                  @"\" + bulkMacroTreeNode.stepName.Replace("events", "dialog"), "");
            CommonUtils.WriteFile(eventsFilePath, eventsFile);
        }

        private void BtnCloseMacroSplitterClick(object sender, EventArgs e) {
            try {
                if (CommonUtils.ShowConfirmation("Are you sure you want to close?") == DialogResult.Yes) {
                    if (splitPerformed) {
                        bool disposing = this.ParentForm.Disposing  ;
                        if (CommonUtils.ShowConfirmation("Do you want to proceed to level one cleanup?") == DialogResult.Yes) {
                            CleanupForm form = new CleanupForm(txtOutputDir.Text);
                            form.MdiParent = this.MdiParent;
                            form.Show();
                        }
                    }
                    this.Close();
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void TxtDirectoryDragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TxtDirectoryDragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                txtDirectory.Text = filePaths[0];
            }
        }

        private void JoinSplitMacro() {
            XDocument xdoc = new XDocument();
            string[] availableFiles = Directory.GetFiles(txtDirectory.Text,"eventsfiles.xml");
            xdoc = XDocument.Parse(CommonUtils.ReadFile(availableFiles[0]));
            var item = from c1 in xdoc.Descendants("Steps").Elements()
                       select new { elements = c1.DescendantNodesAndSelf() };
            string completeFile = "";

            for (int i = 0; i < item.Count(); i++) {
                BulkMacroTreeNode node = new BulkMacroTreeNode();
                XElement eement =  item.ElementAt(i).elements.ElementAt(0) as XElement;
                node.startStepId=Convert.ToInt32(eement.Attribute("id").Value);
                eement.Attribute("sessionKey");
                node.stepTitle = eement.Attribute("label").Value.ToString();
                node.filepathEvents = txtDirectory.Text + "/"+eement.Attribute("events").Value;
                
                node.filepathCustoms = eement.Attribute("customs")!=null? (txtDirectory.Text + "/"+eement.Attribute("customs").Value):"";                
                node.filepathGui  = eement.Attribute("gui") !=null? (txtDirectory.Text + "/"+eement.Attribute("gui").Value):"";
                node.stepEvents = CommonUtils.ReadFile(node.filepathEvents);
				node.stepName = eement.Attribute("events").Value;
                node.Text = eement.Attribute("events").Value + " | " + node.stepTitle;

                tvResults.Nodes.Add(node);

//                string readFile = CommonUtils.ReadFile(node.filepathEvents).Replace("</Events>","").Replace("</MXClientScript>","");
//                if (!readFile.Contains("LoginInfo")) {
//                    completeFile = completeFile + CommonUtils.ReadFile(node.filepathEvents).Replace("</Events>","").Replace("</MXClientScript>","").Replace("<Events>","").Replace("<MXClientScript>","")+"<Comment EventID=\"18\">"+node.stepTitle+"</Comment>";
//                } else {
//                    completeFile = completeFile + CommonUtils.ReadFile(node.filepathEvents).Replace("</Events>","").Replace("</MXClientScript>","");
//                    if (!string.Equals(node.stepTitle,"Exit") ) {
//
//                        completeFile = completeFile +"<Comment EventID=\"18\">"+node.stepTitle+"</Comment>";
//                    }
//                }
            }
      //      completeFile = completeFile +"</Events></MXClientScript>";
      //      string tempPath = Path.GetTempFileName();
      //      CommonUtils.WriteFile(tempPath,completeFile);
      //     txtDirectory.Text = tempPath;

        }

        private void BtnLoadFolderClick(object sender, EventArgs e) {
            try {
        		loadFolderUsed = true;
                JoinSplitMacro();
                //tvResults.Nodes.Clear();
                splitPerformed=true;
                txtOutputDir.Text = txtDirectory.Text;
                // StartSplittingFile();
                // btnSplitFile.Enabled = false;
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }
    
	}
}
