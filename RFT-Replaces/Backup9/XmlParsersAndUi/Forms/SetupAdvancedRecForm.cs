using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;

namespace XmlParsersAndUi {
    public partial class SetupAdvancedRecForm : Form {

        public SetupAdvancedRecForm() {
            InitializeComponent();
        }

        XDocument xmlDocument;
        //this list will contain the capture event
        List<CustomTreeNode> captureEventNodes = new List<CustomTreeNode>();


        #region Methods

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
                FrontendUtils.ShowError(xExc.Message, xExc);
            } catch (Exception ex) //General exception
             {
                FrontendUtils.ShowError(ex.Message,ex);
            } finally {
                this.Cursor = Cursors.Default; //Change the cursor back
            }

        }

        //This function is called recursively until all nodes are loaded
        private void addTreeNodeForSingleEvent(XmlNode xmlNode, TreeNode treeNode) {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) //The current node has children
                {
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
                foreach (CustomizedAttribute attr in node.customizedAttributeCollection) {
                    int rowIndex = dgvAttributes.Rows.Add();
                    dgvAttributes.Rows[rowIndex].Cells[0].Value = attr.isUsed;
                    dgvAttributes.Rows[rowIndex].Cells[1].Value = attr.attribute.Name;
                    dgvAttributes.Rows[rowIndex].Cells[2].Value = attr.attribute.Value;
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

            if (dgvAttributes.Rows.Count > 0) {
                foreach (DataGridViewRow row in dgvAttributes.Rows) {
                    if ((bool)row.Cells[0].Value == true) {
                        (node.customizedAttributeCollection[row.Index]).isUsed = true;
                        node.Attributes[(string)row.Cells[1].Value].Value = row.Cells[2].Value.ToString();
                    } else {
                        (node.customizedAttributeCollection[row.Index]).isUsed = false;
                    }
                }
            }
        }


        void Recur(TreeNodeCollection nodeCollection) {
            if (nodeCollection != null) {
                for (int i = 0; i < nodeCollection.Count; i++) {
                    if (nodeCollection[i].Checked) {
                        (nodeCollection[i] as CustomTreeNode).isNodeUsed = true;
                        captureEventNodes.Add(nodeCollection[i] as CustomTreeNode); //(1)
                        Recur(nodeCollection[i].Nodes);
                    }
                }
            }
        }
        #endregion

        #region Events

        private void tvOutput_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                PopulateDgvWithAttributes();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tvOutput_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            try {
                if (tvOutput.SelectedNode == null) {
                    return;
                }
                SaveUpdatedAttributes();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnParse_Click(object sender, EventArgs e) {
            try {
                ParseEvent(txtEventIn.Text);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnAddCaptureEvent_Click(object sender, EventArgs e) {
            try {
                Recur(tvOutput.Nodes);
                SaveUpdatedAttributes();
                CaptureEvent captureEvent = new CaptureEvent(txtAOName.Text, txtAODescription.Text, txtEventIn.Text, captureEventNodes);
                BackEndUtils.InsertCaptureEvent(captureEvent);
                FrontendUtils.ShowInformation("Capture event inserted successfully!");
                
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

      

        private void SetupAdvancedRecForm_Load(object sender, EventArgs e) {
            try {
                LoadAvailableARtoList();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion

      

        private void LoadAvailableARtoList() {
            List<CaptureEvent> allCaptureEvents = BackEndUtils.GetAllAdvancedRecsAsList();
            for (int i = 0; i < allCaptureEvents.Count; i++) {
                lbAdvancedCE.Items.Add(allCaptureEvents[i]);
            }
        }

        private void lbAdvancedCE_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                //CaptureEvent captureEvent = lbAdvancedCE.SelectedItem as CaptureEvent;
                //txtAOName.Text = captureEvent.CaptureEventName;
                //txtAODescription.Text = captureEvent.CaptureEventDescription;
                //txtEventIn.Text = captureEvent.CaptureEventEventText;
                //InterpretCaptureEvent(captureEvent);

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void InterpretCaptureEvent(CaptureEvent captureEvent) {
            XmlDocument document = new XmlDocument();

            for (int i = 0; i < captureEvent.CaptureEventCapturePointsList.Count; i++) {
                XmlNode node = document.AppendChild(document.CreateElement(captureEvent.CaptureEventCapturePointsList[i].Text));
            }
        }

        private void btnResetAO_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();

            string FileToParse = string.Empty;
            if (dialog.ShowDialog() == DialogResult.OK) {
                FileToParse = dialog.FileName;
            }

            StreamReader reader = new StreamReader(FileToParse);
            string readText = string.Empty;
            try {
                readText = reader.ReadToEnd();
            } finally {
                reader.Close();
            }

            CaptureEvent captureEvent = lbAdvancedCE.SelectedItem as CaptureEvent;
            XDocument xdoc = XDocument.Parse(readText);


            captureEvent = GetCapturePointListType(captureEvent);
            List<string> foundEvents = new List<string>();

            if (captureEvent.capturePointListType == CapturePointListType.SimpleList) {
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

                txtFoundEvents.Text = string.Empty;
                for (int k = 0; k < foundEvents.Count; k++) {
                    txtFoundEvents.Text = txtFoundEvents.Text + (string.IsNullOrEmpty(txtFoundEvents.Text) ? "" : "\r\n") + FormatXml(foundEvents[k]);
                }
            } else {
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
                txtFoundEvents.Text = string.Empty;
                for (int k = 0; k < foundlist.Count; k++) {
                    if (foundlist[k]) {
                        XNode node = test21.ElementAt(k).elements.ElementAt(0);
                        txtFoundEvents.Text = txtFoundEvents.Text + (string.IsNullOrEmpty(txtFoundEvents.Text)?"":"\r\n") + FormatXml(node.ToString());
                    }
                }
            }
        }
        
        private string FormatXml(string sUnformattedXml) {
            //load unformatted xml into a dom
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(sUnformattedXml);
            //will hold formatted xml
            StringBuilder sb = new StringBuilder();
            //pumps the formatted xml into the StringBuilder above
            StringWriter sw = new StringWriter(sb);
            //does the formatting
            XmlTextWriter xtw = null;
            try {
                //point the xtw at the StringWriter
                xtw = new XmlTextWriter(sw);
                //we want the output formatted
                xtw.Formatting = Formatting.Indented;
                //get the dom to dump its contents into the xtw 
                xd.WriteTo(xtw);
            } finally {
                //clean up even if error
                if (xtw != null)
                    xtw.Close();
            }
            //return the formatted xml
            return sb.ToString();
        }

        private bool CheckSiblings(XElement c2, List<CustomTreeNode> list) {
            return false;
        }

        private CaptureEvent GetCapturePointListType(CaptureEvent captureEvent) {
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
    }
}
