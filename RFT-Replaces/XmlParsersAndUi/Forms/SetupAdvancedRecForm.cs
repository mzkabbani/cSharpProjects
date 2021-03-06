﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using Automation.Backend;
using Automation.Common;
using Automation.Common.Classes.Monitoring;
using Automation.Common.Forms;
using Automation.Common.Utils;
using XmlParsersAndUi.Classes;

namespace XmlParsersAndUi {
    public partial class SetupAdvancedRecForm : BaseForm {

        public SetupAdvancedRecForm() {
            InitializeComponent();
        }
 		
		#region Variables
        #endregion
        
        #region Constructor
        #endregion        
     
        XDocument xmlDocument;
        //this list will contain the capture event
        List<CustomTreeNode> captureEventNodes = new List<CustomTreeNode>();
        bool eventParsed = false;
        bool enabledParentChecking = false;
        bool ConfigureToValidateXml = true;

        #region Methods

        private void ParseEvent(string eventMacro) {
            xmlDocument = XDocument.Parse(eventMacro);
            populateTreeviewSingleEvent(xmlDocument.ToString());
            //IEnumerable<XElement> childred =
            //       object patterns = xmlDocument.XPathEvaluate(@"MXClientScript\Events");
            IEnumerable<XElement> children = xmlDocument.Elements();
        }

        private void ParseEventFromDatabase(AdvancedRecomendation captureEvent) {
            xmlDocument = XDocument.Parse(captureEvent.CaptureEventEventText);
            populateTreeviewSingleEventFromDatabase(xmlDocument.ToString(), captureEvent);
            //IEnumerable<XElement> childred =
            //       object patterns = xmlDocument.XPathEvaluate(@"MXClientScript\Events");
            IEnumerable<XElement> children = xmlDocument.Elements();
        }


        private void populateTreeviewSingleEventFromDatabase(string document, AdvancedRecomendation captureEvent) {
            try {
                //Just a good practice -- change the cursor to a
                //wait cursor while the nodes populate
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(document);
                this.Cursor = Cursors.WaitCursor;
                //First, we'll load the Xml document
                //Now, clear out the treeview,
                //and add the first (root) node
                tvOutput.Nodes.Clear();//captureEvent.CaptureEventCapturePointsList[i]
                CustomTreeNode customRootNode = new CustomTreeNode(xDoc.DocumentElement.Name, xDoc.DocumentElement.Attributes);
                customRootNode.isNodeUsed = true;
                customRootNode.customizedAttributeCollection = captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection;
                tvOutput.Nodes.Add(customRootNode);
                TreeNode tNode = new TreeNode();
                tNode = (TreeNode)tvOutput.Nodes[0];
                //We make a call to addTreeNode,
                //where we'll add all of our nodes
                addTreeNodeForSingleEventFromDatabase(xDoc.DocumentElement, tNode, captureEvent, 1, 0, 0, 0);
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

        private void addTreeNodeForSingleEventFromDatabase(XmlNode xmlNode, TreeNode treeNode, AdvancedRecomendation captureEvent, int level, int index, int parentLevel, int parentIndex) {
            int newParentLevel = 0;
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) { //The current node has children
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0, j = 0; x <= xNodeList.Count - 1; x++, j++)
                    //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    if (xNode.NodeType != XmlNodeType.Text) {
                        CustomTreeNode customTreeNode = new CustomTreeNode(xNode.Name, xNode.Attributes);
                        int currentIndex = j;
                        customTreeNode = GetRespectiveCapturePoint(customTreeNode, captureEvent, xNode, currentIndex, level, parentIndex, parentLevel);
                        treeNode.Nodes.Add(customTreeNode);
                        //nodeIncludedText
                        tNode = treeNode.Nodes[j];
                        newParentLevel = level;
                        int newParentIndex = currentIndex;
                        if (xNode.HasChildNodes) {
                            //addTreeNodeForSingleEventFromDatabase(xNode, tNode, captureEvent, level + 1, 0, newParentIndex, newParentLevel);
                            int indextElementTypeOnly = 0;
                            for (int i = 0; i < xNode.ChildNodes.Count; i++) {
                                XmlNode childNode = xNode.ChildNodes[i];
                                if (childNode.NodeType != XmlNodeType.Text) {

                                    customTreeNode = new CustomTreeNode(childNode.Name, childNode.Attributes);
                                    currentIndex = i;
                                    customTreeNode = GetRespectiveCapturePoint(customTreeNode, captureEvent, childNode, indextElementTypeOnly, level + 1, j, level);
                                    tNode.Nodes.Add(customTreeNode);
                                    indextElementTypeOnly++;
                                }
                            }
                        }
                    } else {
                        j = x - 1;
                    }
                }

            } else { //No children, so add the outer xml (trimming off whitespace)
                // treeNode.Text = xmlNode.Name;
                // treeNode.Text = xmlNode.Attributes["name"].Value;
                treeNode.Text = xmlNode.Attributes["name"] == null ? xmlNode.Name : xmlNode.Attributes["name"].Value;
            }
        }

        List<string> captureNodesSelectedNames = new List<string>();

        private CustomTreeNode GetRespectiveCapturePoint(CustomTreeNode customTreeNode, AdvancedRecomendation captureEvent, XmlNode xNode, int index, int level, int parentIndex, int parentLevel) {
            for (int i = 1; i < captureEvent.CaptureEventCapturePointsList.Count; i++) {
                if (captureEvent.CaptureEventCapturePointsList[i].nodeIndex == index &&
                        captureEvent.CaptureEventCapturePointsList[i].nodeLevel == level &&
                        captureEvent.CaptureEventCapturePointsList[i].parentIndex == parentIndex &&
                        captureEvent.CaptureEventCapturePointsList[i].parentLevel == parentLevel) {
                    if (string.Equals(captureEvent.CaptureEventCapturePointsList[i].Text, xNode.Name)) {
                        if ((captureNodesSelectedNames.Count < captureEvent.CaptureEventCapturePointsList.Count - 1) || (!captureNodesSelectedNames.Contains(xNode.Name))) {
                            customTreeNode.customizedAttributeCollection = captureEvent.CaptureEventCapturePointsList[i].customizedAttributeCollection;
                            customTreeNode.isNodeUsed = captureEvent.CaptureEventCapturePointsList[i].isNodeUsed;
                            if ((level == 2) && (!string.Equals(captureNodesSelectedNames[captureNodesSelectedNames.Count - 1], xNode.Name))) {
                                captureNodesSelectedNames.Add(xNode.Name);
                            } else if (level < 2) {
                                captureNodesSelectedNames.Add(xNode.Name);
                            }
                        }
                    }
                }
            }
            return customTreeNode;
        }

        private bool ValidatdByCheckingParentIndexAndUsage(List<CustomTreeNode> captureEventCapturePointsList, CustomTreeNode customTreeNodeCapturePoint, int parentIndex) {

            for (int i = 0; i < captureEventCapturePointsList.Count; i++) {
                if (!string.IsNullOrEmpty(customTreeNodeCapturePoint.parentNodeText)) {
                    if (string.Equals(customTreeNodeCapturePoint.parentNodeText, captureEventCapturePointsList[i].Text)) {
                        if (!captureEventCapturePointsList[i].isNodeUsed) {
                            return false;
                        } else if (captureEventCapturePointsList[i].Index != parentIndex) {
                            return false;
                        }
                    }
                }

            }

            return true;
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
                tvOutput.Nodes.Add(new CustomTreeNode(xDoc.DocumentElement.Name, xDoc.DocumentElement.Attributes));
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
                for (int x = 0, j = 0; x <= xNodeList.Count - 1; x++, j++)
                    //Loop through the child nodes
                {
                    xNode = xmlNode.ChildNodes[x];
                    if (xNode.NodeType != XmlNodeType.Text) {
                        CustomTreeNode customTreeNode = new CustomTreeNode(xNode.Name, xNode.Attributes);
                        treeNode.Nodes.Add(customTreeNode);
                        //nodeIncludedText
                        tNode = treeNode.Nodes[j];
                        addTreeNodeForSingleEvent(xNode, tNode);
                    } else {
                        j = x - 1;
                    }
                }
            } else //No children, so add the outer xml (trimming off whitespace)
                // treeNode.Text = xmlNode.Name;
                // treeNode.Text = xmlNode.Attributes["name"].Value;
                treeNode.Text = xmlNode.Attributes["name"] == null ? xmlNode.Name : xmlNode.Attributes["name"].Value;
        }

        private void PopulateDgvWithAttributes() {
            dgvAttributes.Rows.Clear();
            CustomTreeNode node = (CustomTreeNode)tvOutput.SelectedNode;
            if (node.Attributes != null) {
                for (int i = 0; i < node.Attributes.Count; i++) {
                    int rowIndex = dgvAttributes.Rows.Add();
                    bool found = false;

                    for (int j = 0; j < node.customizedAttributeCollection.Count; j++) {
                        if (string.Equals(node.customizedAttributeCollection[j].attrName, node.Attributes[i].Name)) {
                            dgvAttributes.Rows[rowIndex].Cells[0].Value = node.customizedAttributeCollection[j].isUsed;
                            dgvAttributes.Rows[rowIndex].Cells[1].Value = node.customizedAttributeCollection[j].attrName;
                            dgvAttributes.Rows[rowIndex].Cells[2].Value = node.customizedAttributeCollection[j].attrValue;
                            found = true;
                        }
                    }
                    if (!found) {
                        dgvAttributes.Rows[rowIndex].Cells[0].Value = false;
                        dgvAttributes.Rows[rowIndex].Cells[1].Value = node.Attributes[i].Name;
                        dgvAttributes.Rows[rowIndex].Cells[2].Value = node.Attributes[i].Value;
                    }
                }
            }
        }

        private static void TestConnections() {
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            sqlConnection1.ConnectionString = "Data Source = D:\\Recommendations.sdf";

            //SqlCeCommand cmd = new SqlCeCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "INSERT [Employee Table] (SSN, FirstName) VALUES ('555-23-4322', 'Tim')";
            //cmd.Connection = sqlConnection1;

            try {
                sqlConnection1.Open();
            } catch (Exception ex) {

                throw;
            }
            //cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        private void SaveUpdatedAttributes() {
            CustomTreeNode node = (tvOutput.SelectedNode as CustomTreeNode);
            for (int i = 0; i < node.customizedAttributeCollection.Count; i++) {
                node.customizedAttributeCollection[i].isUsed = false;
            }
            if (dgvAttributes.Rows.Count > 0) {
                foreach (DataGridViewRow row in dgvAttributes.Rows) {
                    if ((bool)row.Cells[0].Value == true) {
                        int attrIndex = GetCustomizedAttrIndex(node.customizedAttributeCollection, row.Cells[1]);
                        if (attrIndex == -1) {
                            int normalAttrIndex = GetNormalAttrIndex(node.customizedAttributeCollection, row.Cells[1]);
                            if (normalAttrIndex != -1) {
                                node.customizedAttributeCollection[normalAttrIndex].isUsed = true;
                                node.customizedAttributeCollection[normalAttrIndex].attrName = row.Cells[1].Value.ToString();
                                node.customizedAttributeCollection[normalAttrIndex].attrValue = row.Cells[2].Value.ToString().Trim();
                                node.Attributes[(string)row.Cells[1].Value].Value = row.Cells[2].Value.ToString().Trim();
                            } else {
                                CustomizedAttribute attr = new CustomizedAttribute(node.Attributes[row.Cells[1].Value.ToString()], true);
                                row.Cells[0].Value = true;
                                attr.attrName = row.Cells[1].Value.ToString().Trim();
                                attr.attrValue = row.Cells[2].Value.ToString().Trim();
                                node.customizedAttributeCollection.Add(attr);
                            }
                        } else {
                            (node.customizedAttributeCollection[attrIndex]).isUsed = true;
                            (node.customizedAttributeCollection[attrIndex]).attrValue = row.Cells[2].Value.ToString().Trim();
                            node.Attributes[(string)row.Cells[1].Value].Value = row.Cells[2].Value.ToString().Trim();
                        }
                    } else {
                        int attrIndex = GetCustomizedAttrIndex(node.customizedAttributeCollection, row.Cells[1]);
                        if (attrIndex != -1) {
                            (node.customizedAttributeCollection[attrIndex]).isUsed = false;
                        }
                    }
                }
            }
        }

        private int GetRegAttrIndex(List<CustomizedAttribute> list, DataGridViewCell dataGridViewCell) {
            int foundIndex = 0;
            for (int i = 0; i < list.Count; i++) {
                if (list[i].attribute != null) {
                    if (string.Equals(list[i].attribute.Name, dataGridViewCell.Value)) {
                        foundIndex = i;
                        return i;
                    }
                }
            }
            return foundIndex;
        }

        private int GetNormalAttrIndex(List<CustomizedAttribute> xmlAttributeCollection, DataGridViewCell dataGridViewCell) {
            int foundIndex = -1;
            for (int i = 0; i < xmlAttributeCollection.Count; i++) {
                if (xmlAttributeCollection[i].attribute != null) {
                    if (string.Equals(xmlAttributeCollection[i].attribute.Name, dataGridViewCell.Value)) {
                        foundIndex = i;
                        return i;
                    }
                }
            }
            return foundIndex;
        }

        private int GetCustomizedAttrIndex(List<CustomizedAttribute> list, DataGridViewCell dataGridViewCell) {
            int foundIndex = -1;
            for (int i = 0; i < list.Count; i++) {
                if (string.Equals(list[i].attrName, dataGridViewCell.Value)) {
                    foundIndex = i;
                    return i;
                }
            }
            return foundIndex;
        }

        void RecurResetTag(TreeNodeCollection nodeCollection) {
            if (nodeCollection != null) {
                for (int i = 0; i < nodeCollection.Count; i++) {
                    nodeCollection[i].Tag = null;
                    RecurResetTag(nodeCollection[i].Nodes);
                }
            }
        }

        void Recur(TreeNodeCollection nodeCollection) {
            if (nodeCollection != null) {
                for (int i = 0; i < nodeCollection.Count; i++) {
                    if (nodeCollection[i].Checked) {
                        (nodeCollection[i] as CustomTreeNode).isNodeUsed = true;
                        captureEventNodes.Add(nodeCollection[i] as CustomTreeNode); //(1)
                    } else {
                        (nodeCollection[i] as CustomTreeNode).isNodeUsed = false;
                    }
                    Recur(nodeCollection[i].Nodes);
                }
            }
        }
        #endregion

        #region Events

        private void tvOutput_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                PopulateDgvWithAttributes();
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void tvOutput_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            try {
                if (tvOutput.SelectedNode == null) {
                    return;
                }
                SaveUpdatedAttributes();
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnParse_Click(object sender, EventArgs e) {
            try {
                if (IsValidXml(txtAOEventIn.Text)) {
                    ParseEvent(txtAOEventIn.Text);
                    if (!txtAOEventIn.ReadOnly) {
                        btnAddCaptureEvent.Enabled = true;
                    }
                    eventParsed = true;
                } else {
                    CommonUtils.ShowInformation("Event must be a valid xml!",true);
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnAddCaptureEvent_Click(object sender, EventArgs e) {
            try {
                if (eventParsed) {
                    tvOutput.Select();
                    string ruleName = txtAOName.Text;
                    string ruleDescription = txtAODescription.Text;
                    string ruleEventIn = txtAOEventIn.Text;
                    if (IsValidToAddRule(ruleName, ruleDescription, ruleEventIn)) {
                        Recur(tvOutput.Nodes);
                        SaveUpdatedAttributes();
                        AdvancedRecomendation captureEvent = new AdvancedRecomendation(ruleName, ruleDescription, ruleEventIn, captureEventNodes);
                        captureEvent.captureEventCategory = Convert.ToInt32(cboCaptureType.SelectedValue);
                        captureEvent.captureEventUsageCount = 0;
                        Advanced_Recommendations.InsertCaptureEvent(captureEvent);
                        CommonUtils.ShowInformation("Capture event inserted successfully!",false);
                    }
                }
                LoadAvailableARtoList();
                SetAllCombos();
                BindCombos();
                lbAdvancedCE.Select();
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private bool IsValidToAddRule(string ruleName, string ruleDescription, string ruleEventIn) {
            if (string.IsNullOrEmpty(ruleName)) {
                CommonUtils.ShowInformation("Rule name cannot be empty!",true);
                return false;
            } else if (string.IsNullOrEmpty(ruleDescription)) {
                CommonUtils.ShowInformation("Description cannot be empty!",true);
                return false;
            } else if (string.IsNullOrEmpty(ruleEventIn)) {
                CommonUtils.ShowInformation("Event in cannot be empty!",true);
                return false;
            }
            if (!IsValidXml(ruleEventIn)) {
                CommonUtils.ShowInformation("Event must be a valid xml!",true);
                return false;
            }
            return true;
        }

        private void SetupAdvancedRecForm_Load(object sender, EventArgs e) {
            try {
        		base.LoadForm(this);
                LoadAvailableARtoList();
                SetAllCombos();
                BindCombos();
                lbAdvancedCE.SelectedIndex = 0;
                enabledParentChecking = true;
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void BindCombos() {
            string displayMember = "enumerationName";
            string valueMember = "id";
            DataTable replacementDatable = Replacement_Events_Categories.GetAllReplacementCategoriesAsDataTable();
            CommonUtils.BindCombo(cboReplacementType, replacementDatable, displayMember, valueMember);
            DataTable captureDatatable = Advanced_Recommendation_Categories.GetAllCaptureCategoriesAsDataTable(false);
            CommonUtils.BindCombo(cboCaptureType, captureDatatable, displayMember, valueMember);
        }

        private void SetAllCombos() {
            foreach (Control control in Controls) {
                CheckControls(control);
            }
        }

        private void CheckControls(Control control) {
            if (control is ComboBox) {
                if (((ComboBox)control).DropDownStyle == ComboBoxStyle.DropDownList) {
                    ((ComboBox)control).SelectedIndex = 0;
                }
            }
            if (control.HasChildren) {
                foreach (Control childControl in control.Controls) {
                    if (childControl is ComboBox) {
                        if (((ComboBox)childControl).DropDownStyle == ComboBoxStyle.DropDownList) {
                            ((ComboBox)childControl).SelectedIndex = 0;
                        }
                    }
                    CheckControls(childControl);
                }
            }
        }

        #endregion

        private void LoadAvailableARtoList() {
            cboCapturePoint.Items.Clear();
            int savedIndex = 0;
            if (lbAdvancedCE.SelectedIndex!= null) {
                savedIndex=lbAdvancedCE.SelectedIndex;
            }
            lbAdvancedCE.Items.Clear();
            List<AdvancedRecomendation> allCaptureEvents = Advanced_Recommendations.GetAllAdvancedRecsAsList();
            for (int i = 0; i < allCaptureEvents.Count; i++) {
                lbAdvancedCE.Items.Add(allCaptureEvents[i]);
                cboCapturePoint.Items.Add(allCaptureEvents[i]);
            }
            lbAdvancedCE.SelectedIndex = savedIndex;

        }

        private void InterpretCaptureEvent(AdvancedRecomendation captureEvent) {
            ParseEventFromDatabase(captureEvent);
            CustomTreeNode[] customArray = new CustomTreeNode[captureEvent.CaptureEventCapturePointsList.Count];
            captureEvent.CaptureEventCapturePointsList.CopyTo(customArray);
            RestoreSelectedCapturePoints(customArray, tvOutput.Nodes);
        }

        private void RestoreSelectedCapturePoints(CustomTreeNode[] treeNodeNodes, TreeNodeCollection collection) {
            if (collection != null) {
                for (int i = 0; i < collection.Count; i++) {
                    //(collection[i] as CustomTreeNode).che
                    //RestoreSelectedCapturePoints(Array, collection[i].Nodes);
                    OperateOnTreeNode(collection[i] as CustomTreeNode, treeNodeNodes);
                }

            }
        }

        private void OperateOnTreeNode(CustomTreeNode customTreeNode, CustomTreeNode[] treeNodeNodes) {
            if (!customTreeNode.isNodeUsed) {
                customTreeNode.Checked = false;
            } else {
                customTreeNode.Checked = true;
            }

            for (int j = 0; (j < treeNodeNodes.Length) && (treeNodeNodes[j].isNodeUsed); j++) {
                if (string.Equals(treeNodeNodes[j].Text, customTreeNode.Text) && !treeNodeNodes[j].nodeVisited) {
                    //if (treeNodeNodes[j].isNodeUsed) {
                    //    customTreeNode.Checked = true;
                    //}
                    treeNodeNodes[j].nodeVisited = true;
                    for (int k = 0; k < treeNodeNodes[j].customizedAttributeCollection.Count; k++) {
                        CustomizedAttribute customAttrFromDB = treeNodeNodes[j].customizedAttributeCollection[k];
                        for (int l = 0; l < customTreeNode.customizedAttributeCollection.Count; l++) {
                            CustomizedAttribute customAttrFromTree = customTreeNode.customizedAttributeCollection[l];
                            if (customAttrFromDB.attribute == null && customAttrFromTree.attribute != null) {
                                if (string.Equals(customAttrFromTree.attribute.Name, customAttrFromDB.attrName)) {
                                    customAttrFromTree.attrName = customAttrFromDB.attrName;
                                    customAttrFromTree.attrValue = customAttrFromDB.attrValue;
                                }
                            }
                        }
                    }
                }
            }
            if (customTreeNode.Nodes.Count > 0) {
                RestoreSelectedCapturePoints(treeNodeNodes, customTreeNode.Nodes);
            }

        }

        private void RestoreSelectedSiblingCapturePoints(CustomTreeNode[] Array, TreeNodeCollection collection) {
            if (collection != null) {
                for (int i = 0; i < collection.Count; i++) {
                    collection[i].Checked = false;
                    for (int j = 0; (j < Array.Length) && (Array[j].isNodeUsed); j++) {
                        if (string.Equals(Array[j].Text, collection[i].Text) && !Array[j].nodeVisited) {
                            collection[i].Checked = true;
                            Array[j].nodeVisited = true;
                            for (int k = 0; k < Array[j].customizedAttributeCollection.Count; k++) {
                                CustomizedAttribute customAttrFromDB = Array[j].customizedAttributeCollection[k];
                                for (int l = 0; l < (collection[i] as CustomTreeNode).customizedAttributeCollection.Count; l++) {
                                    CustomizedAttribute customAttrFromTree = (collection[i] as CustomTreeNode).customizedAttributeCollection[l];
                                    if (customAttrFromDB.attribute == null && customAttrFromTree.attribute != null) {

                                        if (string.Equals(customAttrFromTree.attribute.Name, customAttrFromDB.attrName)) {
                                            customAttrFromTree.attrName = customAttrFromDB.attrName;
                                            customAttrFromTree.attrValue = customAttrFromDB.attrValue;

                                        }
                                    }
                                    //customAttrFromTree.isUsed = false;
                                    //if (string.Equals(customAttrFromTree.attribute.Name, customAttrFromDB.attrName)) {
                                    //    customAttrFromTree.isUsed = customAttrFromDB.isUsed;
                                    //    customAttrFromTree.attrValue = customAttrFromDB.attrValue;
                                    //    customAttrFromTree.attrName = customAttrFromDB.attrName;
                                    //}
                                }
                            }
                        }
                    }
                    RestoreSelectedSiblingCapturePoints(Array, collection[i].Nodes);
                }
            }
        }

        AdvancedRecomendation CurrentlySelectedCaptureEvent;

        private void lbAdvancedCE_SelectedIndexChanged_1(object sender, EventArgs e) {
            try {
                captureNodesSelectedNames = new List<string>();
                AdvancedRecomendation captureEvent = new AdvancedRecomendation();
                captureEvent = lbAdvancedCE.SelectedItem as AdvancedRecomendation;

                if (captureEvent != null) {
                    btnAddCaptureEvent.Enabled = false;
                    btnSaveCaptureEvent.Enabled = true;
                    txtAOEventIn.ReadOnly = true;
                    tvOutput.Nodes.Clear();
                    dgvAttributes.Rows.Clear();
                    AdvancedRecomendation workingEvent = new AdvancedRecomendation(captureEvent.CaptureEventId,
                            captureEvent.CaptureEventName,
                            captureEvent.CaptureEventDescription,
                            captureEvent.CaptureEventEventText,
                            captureEvent.captureEventCategory,
                            captureEvent.captureEventUsageCount,
                            captureEvent.CaptureEventCapturePointsList,
                            captureEvent.captureEventuserId);
                    CurrentlySelectedCaptureEvent = workingEvent;
                    for (int i = 0; i < captureEvent.CaptureEventCapturePointsList.Count; i++) {
                        captureEvent.CaptureEventCapturePointsList[i].nodeVisited = false;
                    }
                    cboCaptureType.SelectedValue = captureEvent.captureEventCategory;
                    txtAOName.Text = workingEvent.CaptureEventName;
                    txtAODescription.Text = workingEvent.CaptureEventDescription;
                    txtAOEventIn.Text = workingEvent.CaptureEventEventText;
                    InterpretCaptureEvent(workingEvent);

                    RecurResetTag(tvOutput.Nodes);

                    if (captureEvent.captureEventCategory == (int)AdvancedRecomendationCategory.Verbal) {
                        // setup validation and ui for verbal recommendations
                        ConfigureToValidateXml = false;

                    } else {
                        ConfigureToValidateXml = true;
                    }

                }

            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnResetAO_Click(object sender, EventArgs e) {
            try {
                ResetForm();
                eventParsed = false;
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
            //OpenFileDialog dialog = new OpenFileDialog();
            //string FileToParse = string.Empty;
            //if (dialog.ShowDialog() == DialogResult.OK) {
            //    FileToParse = dialog.FileName;
            //}
            //StreamReader reader = new StreamReader(FileToParse);
            //string readText = string.Empty;
            //try {
            //    readText = reader.ReadToEnd();
            //} finally {
            //    reader.Close();
            //}
            //CaptureEvent captureEvent = lbAdvancedCE.SelectedItem as CaptureEvent;
            //XDocument xdoc = XDocument.Parse(readText);


            //captureEvent = GetCapturePointListType(captureEvent);
            //List<string> foundEvents = new List<string>();

            //if (captureEvent.capturePointListType == CapturePointListType.SimpleList) {
            //    ParseUsingSimpleList(captureEvent, xdoc, foundEvents);
            //    txtFoundEvents.Text = string.Empty;
            //    for (int k = 0; k < foundEvents.Count; k++) {
            //        txtFoundEvents.Text = txtFoundEvents.Text + (string.IsNullOrEmpty(txtFoundEvents.Text) ? "" : "\r\n") + FrontendUtils.FormatXml(foundEvents[k]);
            //    }
            //} else {
            //    ParseUsingAdvancedList(captureEvent, xdoc);

            //}
        }

        private void ResetForm() {
            btnAdd.Enabled = false;
            lbAdvancedCE.ClearSelected();
            btnAddCaptureEvent.Enabled = true;
            btnSaveCaptureEvent.Enabled = false;
            txtAOEventIn.ReadOnly = false;
            txtAOName.Focus();
            txtAOName.Clear();
            cboCaptureType.SelectedIndex = 0;
            txtAODescription.Clear();
            txtAOEventIn.Clear();
            tvOutput.Nodes.Clear();
            dgvAttributes.Rows.Clear();
            captureEventNodes.Clear();
        }

        private void ParseUsingAdvancedList(AdvancedRecomendation captureEvent, XDocument xdoc) {
            var test21 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                         where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                         select new {
                elements = c1.DescendantNodesAndSelf()
            };
            List<bool> foundlist = new List<bool>();
            for (int i = 0; i < test21.Count(); i++) {
                bool found = true;
                XNode node = test21.ElementAt(i).elements.ElementAt(0);
                XmlReader Xreader = node.CreateReader();
                Xreader.Read();
                while (Xreader.Read() && found) {
                    if (Xreader.NodeType == XmlNodeType.Element) {
                        for (int listLength = 1; found && listLength < captureEvent.CaptureEventCapturePointsList.Count; listLength++) {//Xreader.Name;
                            if (!captureEvent.CaptureEventCapturePointsList[listLength].nodeVisited && string.Equals(captureEvent.CaptureEventCapturePointsList[listLength].Text, Xreader.Name)) {
                                captureEvent.CaptureEventCapturePointsList[listLength].nodeVisited = true;
                                #region Loop Thru attributes
                                for (int attrCoun = 0; found && attrCoun < captureEvent.CaptureEventCapturePointsList[listLength].customizedAttributeCollection.Count; attrCoun++) {
                                    CustomizedAttribute customizedAttribute = captureEvent.CaptureEventCapturePointsList[listLength].customizedAttributeCollection[attrCoun];
                                    string attributeValueFromXml = Xreader.GetAttribute(customizedAttribute.attrName);
                                    if (string.IsNullOrEmpty(attributeValueFromXml) && !string.IsNullOrEmpty(customizedAttribute.attrName)) {
                                        found = false;
                                    } else if (!string.Equals(attributeValueFromXml, customizedAttribute.attrValue) && !string.IsNullOrEmpty(customizedAttribute.attrName)) {
                                        found = false;
                                    }
                                }
                                listLength = captureEvent.CaptureEventCapturePointsList.Count;
                                #endregion
                            }
                        }
                    }
                }
                foundlist.Add(found);
            }
            //txtFoundEvents.Text = string.Empty;
            //for (int k = 0; k < foundlist.Count; k++) {
            //    if (foundlist[k]) {
            //        XNode node = test21.ElementAt(k).elements.ElementAt(0);
            //        txtFoundEvents.Text = txtFoundEvents.Text + (string.IsNullOrEmpty(txtFoundEvents.Text) ? "" : "\r\n") + FrontendUtils.FormatXml(node.ToString());
            //    }
            //}
        }

        private void ParseUsingSimpleList(AdvancedRecomendation captureEvent, XDocument xdoc, List<string> foundEvents) {
            switch (captureEvent.CaptureEventCapturePointsList.Count) {
            case 1:
                var q1 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                         where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                         select new {
                    elements = c1.DescendantNodesAndSelf()
                };
                for (int i = 0; i < q1.Count(); i++) {
                    foundEvents.Add(q1.ElementAt(i).elements.ElementAt(0).ToString());
                }
                break;
            case 2:
                var q2 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                         where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                         from c2 in c1.Elements(captureEvent.CaptureEventCapturePointsList[1].Text)
                         where AllAttributesAvailable(c2, captureEvent.CaptureEventCapturePointsList[1].customizedAttributeCollection)
                         select new {
                    elements = c1.DescendantNodesAndSelf()
                };
                for (int i = 0; i < q2.Count(); i++) {
                    foundEvents.Add(q2.ElementAt(i).elements.ElementAt(0).ToString());
                }
                break;
            case 3:
                var q3 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                         where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                         from c2 in c1.Elements(captureEvent.CaptureEventCapturePointsList[1].Text)
                         where AllAttributesAvailable(c2, captureEvent.CaptureEventCapturePointsList[1].customizedAttributeCollection)
                         from c3 in c2.Elements(captureEvent.CaptureEventCapturePointsList[2].Text)
                         where AllAttributesAvailable(c3, captureEvent.CaptureEventCapturePointsList[2].customizedAttributeCollection)
                         select new {
                    elements = c1.DescendantNodesAndSelf()
                };
                for (int i = 0; i < q3.Count(); i++) {
                    foundEvents.Add(q3.ElementAt(i).elements.ElementAt(0).ToString());
                }
                break;
            case 4:
                var q4 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                         where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                         from c2 in c1.Elements(captureEvent.CaptureEventCapturePointsList[1].Text)
                         where AllAttributesAvailable(c2, captureEvent.CaptureEventCapturePointsList[1].customizedAttributeCollection)
                         from c3 in c2.Elements(captureEvent.CaptureEventCapturePointsList[2].Text)
                         where AllAttributesAvailable(c3, captureEvent.CaptureEventCapturePointsList[2].customizedAttributeCollection)
                         from c4 in c3.Elements(captureEvent.CaptureEventCapturePointsList[3].Text)
                         where AllAttributesAvailable(c4, captureEvent.CaptureEventCapturePointsList[3].customizedAttributeCollection)
                         select new {
                    elements = c1.DescendantNodesAndSelf()
                };
                for (int i = 0; i < q4.Count(); i++) {
                    foundEvents.Add(q4.ElementAt(i).elements.ElementAt(0).ToString());
                }
                break;
            }
        }

        private bool CheckSiblings(XElement c2, List<CustomTreeNode> list) {
            return false;
        }

        private AdvancedRecomendation GetCapturePointListType(AdvancedRecomendation captureEvent) {
            List<CustomTreeNode> list = captureEvent.CaptureEventCapturePointsList;
            captureEvent.capturePointListType = CapturePointListType.SimpleList;
            for (int listCount = 1; listCount < list.Count; listCount++) {
                if (list[listCount - 1].nodeLevel > list[listCount].nodeLevel) {
                    captureEvent.capturePointListType = CapturePointListType.ListWithMutlipleDesc;
                    return captureEvent;
                }
            }
            return captureEvent;
        }

        private bool AllAttributesAvailable(XElement c1, List<CustomizedAttribute> list) {
            bool found = true;
            for (int i = 0; i < list.Count && found; i++) {
                if (string.IsNullOrEmpty(list[i].attrName)) {
                    return true;
                } else if (c1.Attribute(list[i].attrName) == null) {
                    found = false;
                } else if (!string.Equals(c1.Attribute(list[i].attrName).Value, list[i].attrValue)) {
                    found = false;
                }
            }
            return found;
        }

        private bool CheckAttrValue(XAttribute xAttribute, CustomizedAttribute customizedAttribute) {
            return (string.Equals(xAttribute.Name, customizedAttribute.attrName) && string.Equals(xAttribute.Value, customizedAttribute.attrValue));
        }

        private bool FindElementByAttributes(XElement xElement, List<CustomizedAttribute> cutomizedAttrCollection) {
            bool found = true;
            string foundString = string.Empty;
            IEnumerable<XAttribute> attributes = xElement.Attributes();
            for (int i = 0; i < cutomizedAttrCollection.Count; i++) {
                XAttribute attribute = xElement.Attribute(cutomizedAttrCollection[i].attrName);
                if (attribute == null) {
                    found = false;
                    return false;
                } else {
                    if (!string.Equals(attribute.Value, cutomizedAttrCollection[i].attrValue)) {
                        found = false;
                        return false;
                    }
                }
            }
            return found;
        }

        private void cboCapturePoint_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                AdvancedRecomendation selectedAdvancedRec = ((AdvancedRecomendation)cboCapturePoint.SelectedItem);
                ResetConfigurationValues();
                FillReplacementsListBox(selectedAdvancedRec);
                if (selectedAdvancedRec.captureEventCategory == (int)AdvancedRecomendationCategory.Verbal) {
                    // setup validation and ui for verbal recommendations
                    ConfigureToValidateXml = false;

                } else {
                    ConfigureToValidateXml = true;
                }

            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void FillReplacementsListBox(AdvancedRecomendation selectedAdvancedRec) {
            int savedIndex = 0;

            if (lbAvailableReplacements.SelectedIndex !=null) {
                savedIndex = lbAvailableReplacements.SelectedIndex;
            }
            lbAvailableReplacements.Items.Clear();



            List<ReplacementEvent> availableReplacements = Advanced_Replacements.GetAvailableReplacementsByCaptureId(selectedAdvancedRec.CaptureEventId, BackEndUtils.GetSqlConnection());
            for (int i = 0; i < availableReplacements.Count; i++) {
                lbAvailableReplacements.Items.Add(availableReplacements[i]);
            }

            lbAvailableReplacements.SelectedIndex = savedIndex;
        }

        private void btnAddReplacementEvent_Click(object sender, EventArgs e) {
            try {
                if (IsValidToAddReplacement(txtReplacementName.Text.Trim(), txtReplacementDesc.Text.Trim(), txtReplacementRep.Text.Trim())) {
                    ReplacementEvent replacementEvent = new ReplacementEvent(txtReplacementName.Text.Trim(), txtReplacementDesc.Text.Trim(), txtReplacementRep.Text.Trim(), Convert.ToInt32(cboReplacementType.SelectedValue), ((AdvancedRecomendation)cboCapturePoint.SelectedItem).CaptureEventId, CommonUtils.LoggedInUserId);

                    Advanced_Replacements.InsertNewReplacement(replacementEvent);
                    AdvancedRecomendation selectedAdvancedRec = ((AdvancedRecomendation)cboCapturePoint.SelectedItem);

                    FillReplacementsListBox(selectedAdvancedRec);
                    UpdateUi(CommonUtils.UiPrepareFor.Add);
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private bool IsValidToAddReplacement(string replacementName, string replacementDescription, string replacementValue) {
            if (string.IsNullOrEmpty(replacementName)) {
                CommonUtils.ShowInformation("Replacement name cannot be empty!", true);
                return false;
            }
            if (string.IsNullOrEmpty(replacementDescription)) {
                CommonUtils.ShowInformation("Replacement description cannot be empty!", true);
                return false;
            }
            if (string.IsNullOrEmpty(replacementValue)) {
                CommonUtils.ShowInformation("Replacement value cannot be empty!", true);
                return false;
            }
            if (lbAvailableReplacements.Items.Contains(replacementName)) {
                CommonUtils.ShowInformation("Replacement name is in use!", true);
                return false;
            }
        	if (!IsValidXml(replacementValue) && ConfigureToValidateXml && !string.Equals(replacementValue,"{EmptyString}")) {
                CommonUtils.ShowInformation("Replacement value must be a valid xml!", true);
                return false;
            }
            return true;
        }

        public bool IsValidXml(string xmlText) {
            try {
                XDocument xd1 = new XDocument();
                xd1 = XDocument.Parse(xmlText);
            } catch (XmlException exception) {
                return false;
            }
            return true;
        }

        private List<string> GetReplacementParametersFromValue(string replacementValue) {
            List<string> caughtParameters = new List<string>();
            Regex regex = new Regex("{(.*?)}", RegexOptions.Compiled);
            foreach (Match match in regex.Matches(replacementValue)) {
                caughtParameters.Add(match.Groups[0].Value);
            }
            return caughtParameters;
        }

        private void txtReplacementRep_Leave(object sender, EventArgs e) {
            try {
                List<string> replacementParameters = GetReplacementParametersFromValue(txtReplacementRep.Text.Trim());
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void button1_Click(object sender, EventArgs e) {

            LoadAvailableARtoList();

            SetAllCombos();
            BindCombos();
        }

        private void btnRefreshReplacements_Click(object sender, EventArgs e) {
            try {
                AdvancedRecomendation selectedAdvancedRec = ((AdvancedRecomendation)cboCapturePoint.SelectedItem);

                FillReplacementsListBox(selectedAdvancedRec);
                FillReplacementsListBox(selectedAdvancedRec);
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void lbAvailableReplacements_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                ReplacementEvent replacementEvent = ((sender as ListBox).SelectedItem as ReplacementEvent);
                if (replacementEvent != null) {
                    PopulateUiWithReplacementValues(replacementEvent);
                    UpdateUi(CommonUtils.UiPrepareFor.Save);
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void UpdateUi(CommonUtils.UiPrepareFor uiPrepareFor) {
            switch (uiPrepareFor) {
            case CommonUtils.UiPrepareFor.Add:
                btnSaveReplacement.Enabled = false;
                btnAddReplacementEvent.Enabled = true;
                break;
            case CommonUtils.UiPrepareFor.Reset:
                btnSaveReplacement.Enabled = false;
                btnAddReplacementEvent.Enabled = true;
                break;
            case CommonUtils.UiPrepareFor.Save:
                btnSaveReplacement.Enabled = true;
                btnAddReplacementEvent.Enabled = false;
                break;
            }
        }

        private void ResetConfigurationValues() {
            txtReplacementName.Text = string.Empty;
            txtReplacementDesc.Text = string.Empty;
            txtReplacementRep.Text = string.Empty;
            cboReplacementType.SelectedIndex = 0;
            btnAddReplacementEvent.Enabled = true;
            btnSaveReplacement.Enabled = false;
        }

        private void PopulateUiWithReplacementValues(ReplacementEvent selectedReplacementEvent) {
            txtReplacementName.Text = selectedReplacementEvent.name;
            txtReplacementDesc.Text = selectedReplacementEvent.description;
            txtReplacementRep.Text = selectedReplacementEvent.Value;
            cboReplacementType.SelectedValue = selectedReplacementEvent.typeId;
        }

        private void btnSaveReplacement_Click(object sender, EventArgs e) {
            try {
                ReplacementEvent selectedReplacementEvent = lbAvailableReplacements.SelectedItem as ReplacementEvent;
                selectedReplacementEvent.name = txtReplacementName.Text;
                selectedReplacementEvent.description = txtReplacementDesc.Text;
                selectedReplacementEvent.Value = txtReplacementRep.Text;
                selectedReplacementEvent.typeId = Convert.ToInt32(cboReplacementType.SelectedValue);
                Advanced_Replacements.SaveReplacementEvent(selectedReplacementEvent);

                AdvancedRecomendation selectedAdvancedRec = ((AdvancedRecomendation)cboCapturePoint.SelectedItem);

                FillReplacementsListBox(selectedAdvancedRec);

                CommonUtils.ShowInformation("Replacement ["+selectedReplacementEvent.name+"] has been updated.",false);

            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnValidate_Click(object sender, EventArgs e) {
            try {
                FillInReplacementVariables(txtReplacementRep.Text);
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void FillInReplacementVariables(string replacementValue) {
            List<string> foundPatterns = GetReplacementParametersFromValue(replacementValue);
            string output = string.Empty;
            if (foundPatterns.Count > 0) {
                foreach (string pattern in foundPatterns) {
                    output = output + pattern + "\n";
                }
                CommonUtils.ShowInformation("Found the following variables:\n" + output,false);
            } else {
                CommonUtils.ShowInformation("No variables found!",false);
            }
        }

        private void btnResetReplacement_Click(object sender, EventArgs e) {
            //UpdateUi(FrontendUtils.UiPrepareFor.Save);
            try {
                UpdateUi(CommonUtils.UiPrepareFor.Reset);
                txtReplacementName.Text = string.Empty;
                txtReplacementDesc.Text = string.Empty;
                txtReplacementRep.Text = string.Empty;
                SetAllCombos();
                BindCombos();
                lbAvailableReplacements.ClearSelected();
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnSaveCaptureEvent_Click(object sender, EventArgs e) {
            try {
                tvOutput.Select();
                Recur(tvOutput.Nodes);
                SaveUpdatedAttributes();
                AdvancedRecomendation captureEvent = new AdvancedRecomendation(txtAOName.Text, txtAODescription.Text, txtAOEventIn.Text, captureEventNodes);
                captureEvent.captureEventCategory = Convert.ToInt32(cboCaptureType.SelectedValue);
                captureEvent.captureEventUsageCount = CurrentlySelectedCaptureEvent.captureEventUsageCount;
                Advanced_Recommendations.SaveAdvancedRecomendationById(CurrentlySelectedCaptureEvent.CaptureEventId, captureEvent);
                LoadAvailableARtoList();
                SetAllCombos();
                BindCombos();
                ResetForm();
                CommonUtils.ShowInformation("Recommendation ["+captureEvent.CaptureEventName+"] saved.",false);
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void cboCaptureType_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                //FIXME: check what to do here
                //switch ((int)cboCaptureType.SelectedValue) {
                //    case (int)FrontendUtils.AdvancedRecCategory.SpecificConf:
                //        SetupUiForSpecificRecommendation();
                //        break;
                //    case (int)FrontendUtils.AdvancedRecCategory.Verbal:
                //        SetupUiForVerbalRecommendation();
                //        break;
                //    case (int)FrontendUtils.AdvancedRecCategory.Xpath:
                //        SetupUiForXpathRecommendation();
                //        break;
                //}
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }


        private void HideAllGroupBoxesUnderParent(Control.ControlCollection controlCollection) {
            foreach (Control control in controlCollection) {
                if (control is GroupBox) {
                    control.Visible = false;
                }
            }
        }

        private void SetupUiForXpathRecommendation() {
            HideAllGroupBoxesUnderParent(gbRuleDefinition.Controls);
        }

        private void SetupUiForVerbalRecommendation() {
            HideAllGroupBoxesUnderParent(gbRuleDefinition.Controls);

        }

        private void SetupUiForSpecificRecommendation() {
            HideAllGroupBoxesUnderParent(gbRuleDefinition.Controls);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if(string.Equals(tabControl1.SelectedTab.Text,"Replacement")) {
                    cboCapturePoint.SelectedItem = lbAdvancedCE.SelectedItem;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        /// <summary>
        /// Recursively checks or unchecks all child nodes for a given TreeNode.
        /// </summary>
        /// <param name="node">TreeNode to check or uncheck.</param>
        /// <param name="check">Desired value of TreeNode.Checked.</param>
        private void ChangeCheckedChildren(TreeNode node, bool check) {

            try {
                // "Queue" up child nodes to be checked or unchecked.
                if (node.Nodes.Count > 0) {
                    for (int i = 0; i < node.Nodes.Count; i++)
                        ChangeCheckedChildren(node.Nodes[i], check);
                }
                node.Checked = check;
            }


            catch (Exception ex) {

            }

        }

        /// <summary>
        /// Recursively checks or unchecks all parent nodes for a given TreeNode.
        /// </summary>
        /// <param name="node">TreeNode to check or uncheck.</param>
        /// <param name="check">Desired value of TreeNode.Checked.</param>
        private void ChangeCheckedParents(TreeNode node, bool check) {
            try {

                if (node.Parent == null) { // if we are at the root node
                    if (node.Nodes.Count > 0) {
                        for (int i = 0; i < node.Nodes.Count; i++) {
                            if (node.Nodes[i].Checked == true) {
                                node.Checked = true;
                                return;
                            }
                        }
                        node.Checked = false;
                    } else {
                        node.Checked = check;
                    }

                } else {
                    // Check all parents if the user is checking
                    if (check == true) {
                        node.Checked = check;
                        ChangeCheckedParents(node.Parent, check);
                    }

                    else {
                        // Do not uncheck a parent if any of its other children or their children are checked
                        if (node.Nodes.Count > 0) {
                            // Default to not check and check if required
                            node.Checked = false;
                            for (int i = 0; i < node.Nodes.Count; i++) {
                                if (node.Nodes[i].Checked == true) {
                                    node.Checked = true;
                                }
                            }
                            ChangeCheckedParents(node.Parent, check);
                        } else {
                            node.Checked = check;
                            ChangeCheckedParents(node.Parent, check);
                        }
                    }
                }
            }

            catch (Exception ex) {


            }



        }

//
        //        void TvOutputAfterCheck(object sender, TreeViewEventArgs e) {
        //            try {
        //                if (enabledParentChecking ) {
        //                  if (e.Node.Parent == null) {
        //                      ChangeCheckedChildren(e.Node,e.Node.Checked);
//
        //                  }else{
        //                      if (e.Node.Checked) {
        //                          ChangeCheckedChildren(e.Node,e.Node.Checked);
        //                          ChangeCheckedParents(e.Node,e.Node.Checked);
        //                      }else{
        //                          ChangeCheckedChildren(e.Node,e.Node.Checked);
        //                      }
        //                  }
        //              }
        //            } catch (Exception ex) {
        //                FrontendUtils.ShowError(ex.Message,ex);
        //            }
        //        }

        private void CheckChildren(TreeNode rootNode, bool isChecked) {
            foreach (TreeNode node in rootNode.Nodes) {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }


    }
}
