using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace EnvironmentBuilder {
    public partial class EnvironmentBuilder : Form {
        public EnvironmentBuilder() {
            InitializeComponent();
        }

        private void EnvironmentBuilder_Load(object sender, EventArgs e) {
            try {
                LoadFrontEndTree(Directory.GetCurrentDirectory() + @"\TreeHeirarchy.xml");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadFrontEndTree(string XmlFilePath) {
            XmlDocument document = new XmlDocument();
            document.Load(XmlFilePath);
            TreeNode ParentNode = new TreeNode("Root");
            ParentNode.BackColor = Color.Gainsboro;
            ParentNode.Tag = true;
            tvFrontEnd.Nodes.Add(ParentNode);
            RecurseXmlDocument((XmlNode)document.DocumentElement, ParentNode);
            tvFrontEnd.ExpandAll();
        }

        private void RecurseXmlDocument(XmlNode root, TreeNode node) {
            if (root is XmlElement) {
                TreeNode node1 = new TreeNode(root.Attributes["name"] == null ? root.Name : root.Attributes["name"].Value);
                node1.BackColor = Color.Gainsboro;
                node1.Tag = true;
                Random random = new Random(DateTime.Now.Millisecond);
                if (root.HasChildNodes) {
                    node1.Name = root.Attributes["name"].Value + random.Next();
                    node.Nodes.Add(node1);
                    RecurseXmlDocument(root.FirstChild, node1);
                }
                if (root.NextSibling != null && !node.Nodes.Contains(node1)) {
                    node1.Name = root.Attributes["name"].Value + random.Next();
                    node.Nodes.Add(node1);
                    RecurseXmlDocument(root.NextSibling, node);
                }
                if (root.HasChildNodes == false && !node.Nodes.Contains(node1)) {
                    node1.Name = root.Attributes["name"].Value + random.Next();
                    node.Nodes.Add(node1);
                    if (root.ParentNode.NextSibling == null) {
                        NodeTreePair ParentWithSibling = GetFirstParentWithSibling(root.ParentNode, node.Parent);
                        if (ParentWithSibling == null) {
                            return;
                        } else {
                            RecurseXmlDocument(ParentWithSibling.xmlNode.NextSibling, ParentWithSibling.treeNode.Parent);
                        }
                    } else {
                        RecurseXmlDocument(root.ParentNode.NextSibling, node.Parent);
                    }

                }
            } else if (root is XmlText) {
                string text = ((XmlText)root).Value;
                Console.WriteLine(text);
            } else if (root is XmlComment) {

            }
        }

        private NodeTreePair GetFirstParentWithSibling(XmlNode xmlNode, TreeNode nodeParent) {
            NodeTreePair nodeTreePair = new NodeTreePair();

            while (xmlNode.ParentNode.NextSibling == null) {
                nodeParent = nodeParent.Parent;
                nodeTreePair = GetFirstParentWithSibling(xmlNode.ParentNode, nodeParent);
            }
            nodeTreePair.treeNode = nodeParent;
            nodeTreePair.xmlNode = xmlNode.ParentNode;
            return nodeTreePair;
        }

        private void tvFrontEnd_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                txtSelectedNodeName.Text = tvFrontEnd.SelectedNode.Text;
                if (!(bool)tvFrontEnd.SelectedNode.Tag) {
                    txtSelectedNodeName.ReadOnly = false;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void tvDirectoryHeirarchy_AfterSelect(object sender, TreeViewEventArgs e) {

        }

        private void btnParseDTD_Click(object sender, EventArgs e) {
            try {
                tvConfig.Nodes.Add("AvailableTests", "AvailableTests");

                tvConfig.Nodes["AvailableTests"].Nodes.Add("AvailableTest", "AvailableTest");
               // tvConfig.Nodes["AvailableTest"].Nodes.Add("NickName", "NickName");
                //tvConfig.Nodes["AvailableTest"].Nodes.Add("Import", "Import");
                //tvConfig.Nodes["AvailableTest"].Nodes.Add("Customize", "Customize");
                
                TreeNode node = new TreeNode("NickName");
                TreeNode parentNode = new TreeNode("AvailableTest") ;
                RecursiveTreeAdd(node,parentNode);

                node = new TreeNode("Import");
                parentNode = new TreeNode("AvailableTest");
                RecursiveTreeAdd(node, parentNode);


                StreamReader reader = new StreamReader(@"C:\Documents and Settings\mkabbani\My Documents\Visual Studio 2008\Projects\EnvironmentBuilder\EnvironmentBuilder\bin\Debug\DTD.txt");
                List<string> CustomizeTags = new List<string>();
                List<string> AppendTags = new List<string>();
                while (reader.Read() != null) {
                    string lineRead = reader.ReadLine();
                    if (lineRead.Contains("ELEMENT Customize")) {
                        while (reader.Read() != null) {
                            lineRead = reader.ReadLine();
                            if (!lineRead.Equals(")*>\t")) {
                                CustomizeTags.Add(lineRead.Replace("|", "").Trim());
                            } else {
                                break;
                            }

                        }

                    } else if (lineRead.Contains("ELEMENT Append")) { }
                    while (reader.Read() != null) {
                        lineRead = reader.ReadLine();
                        if (!lineRead.Equals(")*>\t")) {
                            AppendTags.Add(lineRead.Replace("|", "").Trim());
                        } else {
                            break;
                        }

                    }
                }
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void RecursiveTreeAdd(TreeNode nodeToAdd,TreeNode parentNode) {
            TreeNodeCollection nodes = tvConfig.Nodes;
            foreach (TreeNode node in nodes) {
                RecurseOverNodes(node,nodeToAdd,parentNode);
            }
        }

        private void RecurseOverNodes(TreeNode node, TreeNode nodeToAdd, TreeNode parentNode) {
            foreach (TreeNode tn in node.Nodes) {
                // if the text properties match, color the item
                if (tn.Text == parentNode.Text) {
                    tn.Nodes.Add(nodeToAdd);
                }
                RecurseOverNodes(tn,nodeToAdd,parentNode);
            }
        }


    }
}
