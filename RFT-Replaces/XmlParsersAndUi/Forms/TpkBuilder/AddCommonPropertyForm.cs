/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/22/2012
 * Time: 10:08 AM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Automation.Common;
using Automation.Common.Utils;

namespace Manifest.Forms.TpkBuilder {
    /// <summary>
    /// Description of AddCommonPropertyForm.
    /// </summary>
    public partial class AddCommonPropertyForm : Form {
    	
    	 #region Variables
        #endregion
        
        #region Constructor
        #endregion
        
        #region Methods
        #endregion
        
        #region Events
        #endregion
    	
        public List<BuildTaskProperty> selectedCommonProperties = null;

        public AddCommonPropertyForm(List<BuildTaskProperty> commonProperties) {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            for (int i = 0; i < commonProperties.Count; i++) {
                lbCommonProperties.Items.Add(commonProperties[i]);
            }
            if (lbCommonProperties.Items.Count >0) {
                lbCommonProperties.SelectedIndex=0;
            }
        }

        void BtnProceedComPropClick(object sender, EventArgs e) {
            try {
                if (lbCommonProperties.SelectedItems.Count > 0 ) {
        			for (int i = 0; i < lbCommonProperties.SelectedItems.Count; i++) {
        				selectedCommonProperties.Add(lbCommonProperties.SelectedItems[i] as BuildTaskProperty);
        			}
                    this.DialogResult = DialogResult.OK;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

    }
}
