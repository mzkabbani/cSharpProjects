using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XmlParsersAndUi.Classes;

namespace XmlParsersAndUi.Forms {
    public partial class ApplicationPreferencesForm : Form {
        public ApplicationPreferencesForm() {
            InitializeComponent();
        }

        #region Events

        DataSet dataSet;
        private void ApplicationPreferencesForm_Load(object sender, EventArgs e) {
            try {
               //List<ApplicationConfigObject> AppConfigList = BackEndUtils.GetAllApplicationConfigAsList();
               //PopulateAppConfigFromList(AppConfigList);
                txtConnectedDatabase.Text =  BackEndUtils.ConnectionParamter;
                dataSet = BackEndUtils.GetAppPrefsDataset();
                dgvDatabasePrefs.DataSource = dataSet.Tables[0];
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }        
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                BackEndUtils.UpdatePrefs(dataSet);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        //private void PopulateAppConfigFromList(List<ApplicationConfigObject> AppConfigList) {
        //    for (int i = 0; i < AppConfigList.Count; i++) {
        //        Label label = new Label();
        //        label.Text = AppConfigList[i].key;
        //        label.Dock = DockStyle.Left;
        //        TextBox textBox = new TextBox();
        //        textBox.Text = AppConfigList[i].value;
        //        textBox.Dock = DockStyle.Left;


        //    }
        //} 

        #endregion
    }
}
