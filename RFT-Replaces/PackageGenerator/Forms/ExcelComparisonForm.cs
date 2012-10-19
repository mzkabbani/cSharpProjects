using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Common.Utils;
using System.IO;

namespace PackageGenerator.Forms {
    public partial class ExcelComparisonForm : Form {
        public ExcelComparisonForm() {
            InitializeComponent();
        }

        #region Methods

        private bool IsValidToProceedWithComparison(string fileOne, string fileTwo) {
            if (string.IsNullOrEmpty(fileOne)) {
                CommonUtils.ShowInformation("Please input reference customizations excel sheet", true);
                return false;
            } else if (string.IsNullOrEmpty(fileTwo)) {
                CommonUtils.ShowInformation("Please input current customizations excel sheet", true);
                return false;
            } else if (!File.Exists(fileOne)) {
                CommonUtils.ShowInformation("Reference customizations excel sheet does not exist", true);
                return false;
            } else if (!File.Exists(fileTwo)) {
                CommonUtils.ShowInformation("Current customizations excel sheet does not exist", true);
                return false;
            }
            return true;
        }

        #endregion
        

        #region Events

        private void btnProceed_Click(object sender, EventArgs e) {
            try {
                if (IsValidToProceedWithComparison(txtFileOneInput.Text, txtFileTwoInput.Text)) { } else {
                    this.DialogResult = DialogResult.No;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnBrowseFileOne_Click(object sender, EventArgs e) {
            try {
                txtFileOneInput.Text = CommonUtils.GetFileOpenDialog();
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnBrowseFileTwo_Click(object sender, EventArgs e) {
            try {
                txtFileTwoInput.Text = CommonUtils.GetFileOpenDialog();
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion
   
    }
}
