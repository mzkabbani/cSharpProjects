using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OldEventAutomaticConverter {
    public partial class RulesDirectoryForm : Form {

        #region Constructor

        public RulesDirectoryForm() {
            InitializeComponent();
        } 

        #endregion

        #region Methods

        public DialogResult ShowCustomError(string errorText, bool useYesNo) {
            if (!useYesNo) {
                return MessageBox.Show(errorText, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                return MessageBox.Show(errorText, "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        } 

        #endregion

        #region Events

        private void btnBrowsedir_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult == DialogResult.OK) {
                    txtSvnLocation.Text = folderBrowserDialog.SelectedPath;
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnSaveSVN_Click(object sender, EventArgs e) {
            try {

            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }
        
        #endregion
        
    }
}
