/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/9/2012
 * Time: 4:03 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

using Automation.Common;
using Automation.Common.Classes.TPKBuilder;
using Automation.Common.Utils;

namespace XmlParsersAndUi.Forms.TpkBuilder {
    /// <summary>
    /// Description of TaskAdditionForm.
    /// </summary>
    public partial class TaskAdditionForm : Form {

        #region Variables
        TpkBuildTask currentlySelectedTask;
        List<FilledBuildTaskProperty> suppliedProperties = new List<FilledBuildTaskProperty>();
        public string createdFinalBuildTask = string.Empty;
        #endregion

        public TaskAdditionForm( TpkBuildTask tpkBuildTask) {
            InitializeComponent();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            currentlySelectedTask = tpkBuildTask;
        }

        public TaskAdditionForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        void UpdateUIFromSelectedTask(TpkBuildTask buildTask) {
            lblTaskName.Text = buildTask.Name;

            FillDatagridFromPropertyList(buildTask.TaskProperties);

        }

        void FillDatagridFromPropertyList(List<BuildTaskProperty> taskProperties) {
            foreach (BuildTaskProperty property in taskProperties) {
                //add name, value, propertyObject
                //property with no config files
                //TODO: change this when we add prop types
                if (string.IsNullOrEmpty(property.ConfigFileTemplate)) {
                    int rowIndex = -1;
                    if (string.IsNullOrEmpty(property.DefaultValue) ) {
                        rowIndex = dgvTaskProperties.Rows.Add(property.Name, "",property);
                        dgvTaskProperties.Rows[rowIndex].Cells["propertyValue"] = new DataGridViewTextBoxCell();
                        dgvTaskProperties.Rows[rowIndex].Cells["propertyValue"].Value = "";
                    } else {
                        rowIndex = dgvTaskProperties.Rows.Add(property.Name, property.DefaultValue,property);
                        dgvTaskProperties.Rows[rowIndex].Cells["propertyValue"] = new DataGridViewTextBoxCell();
                        dgvTaskProperties.Rows[rowIndex].Cells["propertyValue"].Value = property.DefaultValue;
                    }
                } else {
                    //property with config file                    
                    property.SuppliedConfigFile = string.Empty;
                    int rowIndex = dgvTaskProperties.Rows.Add(property.Name, "Config",property);
                    //((DataGridViewButtonCell)dgvTaskProperties.Rows[rowIndex].Cells["propertyValue"]).va
                }
            }
        }

        void TaskAdditionFormLoad(object sender, EventArgs e) {
            try {
                UpdateUIFromSelectedTask(currentlySelectedTask);
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

        bool ValidateGrid() {
            bool validProperties = true;
            suppliedProperties = new List<FilledBuildTaskProperty>();
            //check if default value, check if mandatory, check propertyTypeID
            foreach (DataGridViewRow row in dgvTaskProperties.Rows) {
                BuildTaskProperty property = row.Cells["propObject"].Value as BuildTaskProperty;
                if (property != null) {
                    string propertySuppliedValue= row.Cells["propertyValue"].Value.ToString();
                    //TODO: Add validation for different types of properties
                    //TODO: change this when we add prop types
                    if (property.IsMandatory) {
                    	if (!string.IsNullOrEmpty(property.ConfigFileTemplate)) {
	                        if (string.IsNullOrEmpty(property.SuppliedConfigFile) ) {
	                            row.DefaultCellStyle.BackColor = Color.Salmon;
	                            validProperties = false;
	                        }
	                    } else if (string.IsNullOrEmpty(propertySuppliedValue)) {
	                        row.DefaultCellStyle.BackColor = Color.Salmon;
	                        validProperties = false;
	                    }
                    }
                    
                    //TODO: change this when we add prop types
                    if (!string.IsNullOrEmpty(property.ConfigFileTemplate) && !string.IsNullOrEmpty(property.SuppliedConfigFile)) {
                        suppliedProperties.Add(new FilledBuildTaskProperty(property.Name,true,property.SuppliedConfigFilePath,property.SuppliedConfigFile,property.PropertyTypeId));
                    } else if( !string.IsNullOrEmpty(propertySuppliedValue)){
                        suppliedProperties.Add(new FilledBuildTaskProperty(property.Name,propertySuppliedValue,property.PropertyTypeId));
                    }
                }
            }
            
            if (!validProperties) {
                CommonUtils.ShowInformation("Some mandatory properties, highlighted in red, where not supplied",true);
            }            
            return validProperties;
        }

        void BtnProceedBuildTaskClick(object sender, EventArgs e) {
            try {
                if (ValidateGrid()) {
                    createdFinalBuildTask = string.Empty;
                    createdFinalBuildTask =  CreateBuildTask();
                    this.DialogResult = DialogResult.OK;
                } else {
                    this.DialogResult = DialogResult.None;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

        string CreateBuildTask() {
            string createdBuildTask = "<"+currentlySelectedTask.Name+" ";
            foreach (FilledBuildTaskProperty property in suppliedProperties) {
                createdBuildTask =  string.Concat(createdBuildTask,property.PropertyName,"=\"",property.PropertyValue+property.PropertyConfigFilePath+"\" ");
                if (property.HasConfigFile) {
            		//TODO: write config file
            		WriteSuppliedConfigFile(property.PropertyConfigFilePath,property.PropertyConfigFileValue);
            	}
            }
            createdBuildTask = createdBuildTask +"></"+currentlySelectedTask.Name+">";
            return createdBuildTask;
        }

        void WriteSuppliedConfigFile(string filePath, string fileValue){
        
        }
        
        void DgvTaskPropertiesCellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.RowIndex >=0 && string.Equals(dgvTaskProperties.Columns[e.ColumnIndex].Name,"propertyValue")) {
                    //clicked on button cell
                    BuildTaskProperty property = dgvTaskProperties.Rows[e.RowIndex].Cells["propObject"].Value as BuildTaskProperty;
                    if (property !=null) {
                        if (!string.IsNullOrEmpty(property.ConfigFileTemplate)) {
                    		ConfigFileTemplateForm form = new ConfigFileTemplateForm( (string.IsNullOrEmpty(property.SuppliedConfigFile) ? property.ConfigFileTemplate : property.SuppliedConfigFile));
                            DialogResult dialogResult = form.ShowDialog();
                            if (dialogResult == DialogResult.OK) {
                            	property.SuppliedConfigFile = form.Controls["txtConfigTemplate"].Text.Trim();
                                property.SuppliedConfigFilePath = form.Controls["txtConfigFilePath"].Text.Trim();
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }
    }
}
