﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XmlParsersAndUi.Classes;
using Automation.Common.Utils;
using Automation.Backend;

namespace XmlParsersAndUi.Forms {
    public partial class ApplicationPreferencesForm : Form {
        
        #region Constructor
        
        public ApplicationPreferencesForm() {
            InitializeComponent();
        } 

        #endregion

        #region General

        #region Events

        private void ApplicationPreferencesForm_Load(object sender, EventArgs e) {
            try {
                tvPreferenceSections.ExpandAll();
                txtConnectedDatabase.Text = BackEndUtils.ConnectionParamter;
                dataSet = BackEndUtils.GetAppPrefsDataset();
                dgvDatabasePrefs.DataSource = dataSet.Tables[0];
                LoadSavedFolderNames();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion

        #endregion

        #region Application Preferences

        #region Events

        DataSet dataSet;

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                BackEndUtils.UpdatePrefs(dataSet);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion

        #endregion

        #region Folder Names Section

        #region Variables

        List<TreeNode> allTreeNodes = new List<TreeNode>();

        #endregion

        #region Methods

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

        private void LoadSavedFolderNames() {

            DataSet dataSet = BackEndUtils.GetAllFolderNamesAsDataset();
            dataSet.Relations.Add("NodeRelation", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["parentId"]);

            foreach (DataRow dataRow in dataSet.Tables[0].Rows) {
                if (dataRow.IsNull("parentId")) {
                    TreeNode node = CreateNode(dataRow["folderName"].ToString(), true);

                    tvFolderNames.Nodes.Add(node);
                    RecursivelyPopulate(dataRow, node);
                }
            }
            tvFolderNames.ExpandAll();
        }

        private void SaveUpdatedTreeView() {
            LoopOverAllTreeNodes();
            BackEndUtils.UpdateTreeNodesTransaction(allTreeNodes);
        }

        private void LoopOverAllTreeNodes() {
            foreach (TreeNode treeNode in tvFolderNames.Nodes) {
                allTreeNodes.Add(treeNode);
                ParseAllChildren(treeNode);
            }
        }

        private void ParseAllChildren(TreeNode treeNode) {
            foreach (TreeNode childNode in treeNode.Nodes) {
                allTreeNodes.Add(childNode);
                if (childNode.Nodes.Count > 0) {
                    ParseAllChildren(childNode);
                }
            }
        }

        #endregion

        #region Events

        private void addChildToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                EditFolderNameForm form = new EditFolderNameForm();
                DialogResult dialog = form.ShowDialog();
                if (dialog == DialogResult.OK) {
                    tvFolderNames.SelectedNode.Nodes.Add(form.Controls["txtNewName"].Text);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void saveNameToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                EditFolderNameForm form = new EditFolderNameForm(tvFolderNames.SelectedNode.Text);
                DialogResult dialog = form.ShowDialog();
                if (dialog == DialogResult.OK) {
                    tvFolderNames.SelectedNode.Text = form.Controls["txtNewName"].Text;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnSaveFolderNames_Click(object sender, EventArgs e) {
            try {
                SaveUpdatedTreeView();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion

        #endregion

        #region Preference Sections Group

        #region Methods

        private void UpdateUIFromSelectedNode(string selectedNodeText) {
            switch (selectedNodeText) {
                case "Application Settings":
                    SetVisibilityAndDock(gbDatabasePrefs);
                    break;
                case "Folder Naming":
                    SetVisibilityAndDock(gbFolderNaming);
                    break;
                default:
                    SetVisibilityAndDock(gbConnectedDatabase);
                    break;
            }
        }

        private void SetVisibilityAndDock(GroupBox gbGenericBox) {
            foreach (Control control in gbParentPrefs.Controls) {
                if (control is GroupBox) {
                    control.Visible = false;
                }
            }
            gbGenericBox.Dock = DockStyle.Top;
            gbGenericBox.Visible = true;
        } 

        #endregion

        #region Events

        private void tvPreferenceSections_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                UpdateUIFromSelectedNode(tvPreferenceSections.SelectedNode.Text);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        } 

        #endregion


        #endregion
    }
}
