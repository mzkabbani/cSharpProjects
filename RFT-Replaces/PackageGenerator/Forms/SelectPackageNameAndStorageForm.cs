using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Common.Utils;

namespace PackageGenerator.Forms {
    public partial class SelectPackageNameAndStorageForm : Form {
        public SelectPackageNameAndStorageForm() {
            InitializeComponent();
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            txtOutputPath.Text = folderBrowserDialog.SelectedPath;

        }

        private void btnProceed_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txtOutputPath.Text.Trim()) || string.IsNullOrEmpty(txtPackageName.Text.Trim())) {
                    FrontendUtils.ShowInformation("[Output Path] and [Package Name] are mandatory fields!");
                    this.DialogResult = DialogResult.Cancel;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }


    }
}
