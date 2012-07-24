using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XmlParsersAndUi {
    public partial class SessionKeyAndTitleForm : Form {
        
        #region Variables

        public string sessionKey;
        string currentOutputDir;

        #endregion

        #region Constructor
        
        public SessionKeyAndTitleForm(string outputDirectory) {
            InitializeComponent();
            currentOutputDir = outputDirectory;
        }

        #endregion    
        
        #region Events

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e) {
            sessionKey = txtSessionKey.Text;
            if (string.IsNullOrEmpty(txtTitle.Text)) {
                this.DialogResult = DialogResult.No;
                return;
            }
            if (Directory.Exists(currentOutputDir + @"\" + txtTitle.Text)) {
                DialogResult dialogResult = MessageBox.Show("Selected directory already exists, do you want to overrite?", "Directory Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No) {
                    this.DialogResult = DialogResult.Abort;
                    return;
                }
            }

        }

        private void SessionKeyAndTitleForm_Load(object sender, EventArgs e) {
            Random random = new Random(DateTime.Now.Millisecond);
            txtSessionKey.Text = random.Next(8999).ToString();

        }

        #endregion   
    }
}
