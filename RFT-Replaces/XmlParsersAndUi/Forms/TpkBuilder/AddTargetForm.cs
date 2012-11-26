/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/23/2012
 * Time: 2:49 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Automation.Common.Classes.TPKBuilder;
using Automation.Common.Utils;

namespace Manifest.Forms.TpkBuilder {
    /// <summary>
    /// Description of AddTargetForm.
    /// </summary>
    public partial class AddTargetForm : Form {

        #region variables
        List<BuildTargetObject> availableTargets  = new List<BuildTargetObject>();
        public string buildTargetName = string.Empty;
        #endregion

        
        #region Constructor
        #endregion
        
        #region Methods
        #endregion
        
        #region Events
        #endregion
        
        public AddTargetForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }


        public AddTargetForm(List<BuildTargetObject> buildTargets) {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            availableTargets = buildTargets;
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }


        bool IsValidToAddTarget(string newTargetName) {
            bool targetAlreadyDefined = false;
            if (string.IsNullOrEmpty(newTargetName)) {
                CommonUtils.ShowInformation("New target name cannot be empty!",true);
                return false;
            }
            foreach (BuildTargetObject buildTarget in availableTargets) {
                if (string.Equals(buildTarget.Name,newTargetName)) {
                    targetAlreadyDefined = true;
                }
            }
            if (targetAlreadyDefined) {
            	  CommonUtils.ShowInformation("A target named ["+newTargetName+"] already exists!",true);
            	return false;
            }
            return true;
        }

        void BtnProceedNewTargetClick(object sender, EventArgs e) {
            try {
                if (IsValidToAddTarget(txtTargetName.Text.Trim())) {
        			buildTargetName = txtTargetName.Text.Trim();
        			this.DialogResult = DialogResult.OK;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }
    }
}
