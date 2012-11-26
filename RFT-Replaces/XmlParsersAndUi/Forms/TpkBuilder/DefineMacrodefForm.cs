/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/22/2012
 * Time: 11:04 AM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Automation.Common;
using Automation.Common.Classes;
using Automation.Common.Utils;

namespace Manifest.Forms.TpkBuilder {
    /// <summary>
    /// Description of DefineMacrodefForm.
    /// </summary>
    public partial class DefineMacrodefForm : Form {
    	
    	#region Variables
        #endregion
        
        #region Constructor
        #endregion
        
        #region Methods
        #endregion
        
        #region Events
        #endregion
    	

        public BuildTask GeneratedBuildTask = null;

        public DefineMacrodefForm() {
            InitializeComponent();
        }

        private BuildTask ConvertMacrodefToBuildTask(string macrodefName,List<BuildTaskProperty> macrodefAttributes, bool isParallelExec) {
            //FIXME: Handle details link?
            BuildTask task = new BuildTask(macrodefName,"??",(int)ApplicationEnumerations.BuildTaskCat.Macrodef,8,DateTime.Now);
            if (cbParallel.Checked) {
            	task.CategoryId = (int)ApplicationEnumerations.BuildTaskCat.MacrodefParallel;            	
            }            
            task.TaskProperties = macrodefAttributes;
            return task;
        }

        private List<BuildTaskProperty> GetListFromSuppliedAttributes() {
            List<BuildTaskProperty> taskProps= new List<BuildTaskProperty>();
            for (int i = 0; i < lbMacrodefAttributes.Items.Count; i++) {
                taskProps.Add(lbMacrodefAttributes.Items[i] as BuildTaskProperty);
            }
            return taskProps;
        }

        private void BtnProceedMacrodefClick(object sender, EventArgs e) {
            try {
                string macrodefName = txtMacrodefName.Text.Trim();
                if (!string.IsNullOrEmpty(macrodefName)) {
                    List<BuildTaskProperty> attributes = GetListFromSuppliedAttributes();
                    GeneratedBuildTask = ConvertMacrodefToBuildTask(macrodefName,attributes,cbParallel.Checked);
                    this.DialogResult = DialogResult.OK;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

        private bool IsValidToAddAttribute(string name) {
            if (string.IsNullOrEmpty(name)) {
                CommonUtils.ShowInformation("Attribute name cannot be empty!",true);
                return false;
            }
            return true;
        }

        private void BtnAddAttributeClick(object sender, EventArgs e) {
            try {
                string attrName = txtMacrodefAttribName.Text.Trim();
                string attrDefValue = txtMacrodefAttrDefValue.Text.Trim();
                if (IsValidToAddAttribute(attrName)) {                    
                    BuildTaskProperty prop = new BuildTaskProperty(attrName,attrDefValue,(int)ApplicationEnumerations.PropertyType.Default,cbIsMandatory.Checked,CommonUtils.LoggedInUserId,DateTime.Now);
                    lbMacrodefAttributes.Items.Add(prop);
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

       private void BtnRemoveAttributeClick(object sender, EventArgs e) {
            try {
                if (lbMacrodefAttributes.SelectedItem != null) {
                    DialogResult dial = CommonUtils.ShowConfirmation("Are you sure you want to remove ["+lbMacrodefAttributes.SelectedItem.ToString()+"]?");
                    if (dial == DialogResult.Yes) {
                        lbMacrodefAttributes.Items.Remove(lbMacrodefAttributes.SelectedItem);
                    }
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

       private void BtnCancelMacrodefClick(object sender, EventArgs e) {
            try {
                DialogResult dial = CommonUtils.ShowConfirmation("Are you sure you want to cancel updates?");
                if (dial == DialogResult.No) {
                    this.DialogResult = DialogResult.None;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

    }
}
