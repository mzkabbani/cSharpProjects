using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Common.Utils;
using Automation.Backend;

namespace XmlParsersAndUi.Forms {
    public partial class SelectFolderNameForm : Form {
        public SelectFolderNameForm() {
            InitializeComponent();
        }

        private TreeNode CreateNode(string text, bool expanded) {
            TreeNode node = new TreeNode(text);
            node.Expand();
            return node;
        }

        private void RecursivelyPopulate(DataRow dbRow, TreeNode node) {
            foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation")) {
                TreeNode childNode = CreateNode(childRow["folderName"].ToString(), true);
                node.Nodes.Add(childNode);
                RecursivelyPopulate(childRow, childNode);
            }
        }

        private void SelectFolderNameForm_Load(object sender, EventArgs e) {
            try {
                DataSet dataSet = Folder_Names.GetAllFolderNamesAsDataset();
                dataSet.Relations.Add("NodeRelation", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["parentId"]);

                foreach (DataRow dataRow in dataSet.Tables[0].Rows) {
                    if(dataRow.IsNull("parentId")){
                        TreeNode node = CreateNode(dataRow["folderName"].ToString(),true);
                        
                        tvFolderNames.Nodes.Add(node);
                        RecursivelyPopulate(dataRow, node);
                    }
                }
                tvFolderNames.ExpandAll();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        public string SelectedString;

        private void tvFolderNames_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            SelectedString = tvFolderNames.SelectedNode.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
