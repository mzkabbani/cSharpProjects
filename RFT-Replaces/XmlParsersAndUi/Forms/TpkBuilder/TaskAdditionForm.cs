﻿/*
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
using Automation.Common.Classes;
using Automation.Common.Classes.TPKBuilder;
using Automation.Common.Utils;
using Manifest.Forms.TpkBuilder;

namespace XmlParsersAndUi.Forms.TpkBuilder {
    /// <summary>
    /// Description of TaskAdditionForm.
    /// </summary>
    public partial class TaskAdditionForm : Form {

        #region Variables
        public BuildTask currentlySelectedTask = new BuildTask();
        List<FilledBuildTaskProperty> suppliedProperties = new List<FilledBuildTaskProperty>();    
		public BuildTargetObject selectedOwner;       
        #endregion
        
        #region Constructor
        #endregion
        
        #region Methods
        #endregion
        
        #region Events
        #endregion
        
        public TaskAdditionForm( BuildTask tpkBuildTask, List<BuildTargetObject> definedTargets, List<BuildTask> usedMacrodefs) {
            InitializeComponent();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            currentlySelectedTask = tpkBuildTask;
            BindTargetComboBox(definedTargets, usedMacrodefs);
        }
        
        private void BindTargetComboBox(List<BuildTargetObject> definedTargets, List<BuildTask> usedMacrodefs){
        	foreach (BuildTargetObject buildTarget in definedTargets) {
        		cboOwnerTarget.Items.Add(buildTarget);
        	}        	
        	foreach (BuildTask macrodef in usedMacrodefs) {
        		cboOwnerTarget.Items.Add(macrodef);
        	}        	
        	cboOwnerTarget.SelectedIndex = 0;
        }
        
        public TaskAdditionForm( BuildTask tpkBuildTask) {
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

        private void UpdateUIFromSelectedTask(BuildTask buildTask) {
            lblTaskName.Text = buildTask.Name;
            FillDatagridFromPropertyList(buildTask.TaskProperties);
        }

        private void FillDatagridFromPropertyList(List<BuildTaskProperty> taskProperties) {
            foreach (BuildTaskProperty property in taskProperties) {
                //add name, value, propertyObject
                //property with no config files
                //FIXME: change this when we add prop types
                if ((int)property.PropertyTypeId == (int)ApplicationEnumerations.PropertyType.ConfigFile ||property.PropertyTypeId == (int)ApplicationEnumerations.PropertyType.ConfigFileNested ) {
                    //property with config file
                    property.SuppliedConfigFile = string.Empty;
                    property.SuppliedConfigFilePath = string.Empty;
                    int rowIndex = dgvTaskProperties.Rows.Add(property.Name, "Config",property);
                } else {
                    int rowIndex = -1;
                    property.SuppliedValue = string.Empty;
                    if (string.IsNullOrEmpty(property.DefaultValue)) {
                        rowIndex = dgvTaskProperties.Rows.Add(property.Name, "",property);
                        dgvTaskProperties.Rows[rowIndex].Cells["propertyValue"] = new DataGridViewTextBoxCell();
                        dgvTaskProperties.Rows[rowIndex].Cells["propertyValue"].Value = "";
                    } else {
                        rowIndex = dgvTaskProperties.Rows.Add(property.Name, property.DefaultValue,property);
                        dgvTaskProperties.Rows[rowIndex].Cells["propertyValue"] = new DataGridViewTextBoxCell();
                        dgvTaskProperties.Rows[rowIndex].Cells["propertyValue"].Value = property.DefaultValue;
                    }
                }
            }
        }

        private void TaskAdditionFormLoad(object sender, EventArgs e) {
            try {
                UpdateUIFromSelectedTask(currentlySelectedTask);
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

        private bool ValidateGrid() {
            bool validProperties = true;
            suppliedProperties = new List<FilledBuildTaskProperty>();
            //check if default value, check if mandatory, check propertyTypeID
            foreach (DataGridViewRow row in dgvTaskProperties.Rows) {
                BuildTaskProperty property = row.Cells["propObject"].Value as BuildTaskProperty;
                if (property != null) {
                    string propertySuppliedValue= row.Cells["propertyValue"].Value.ToString();
                    property.SuppliedValue = propertySuppliedValue;                    
                    //FIXME: Add validation for different types of properties
                    //FIXME: change this when we add prop types                    
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
                    //FIXME: change this when we add prop types
                    //AppEnums.PropertyType                    
                    if (!string.IsNullOrEmpty(property.ConfigFileTemplate) && !string.IsNullOrEmpty(property.SuppliedConfigFile)) {
                        suppliedProperties.Add(new FilledBuildTaskProperty(property.Name,true,property.SuppliedConfigFilePath,property.SuppliedConfigFile,property.PropertyTypeId));						                   
                    } else if( !string.IsNullOrEmpty(propertySuppliedValue)) {
                        suppliedProperties.Add(new FilledBuildTaskProperty(property.Name,propertySuppliedValue,property.PropertyTypeId));                    	
                    }
                }
            }
            if (!validProperties) {
                CommonUtils.ShowInformation("Some mandatory properties, highlighted in red, where not supplied",true);
            }
            return validProperties;
        }

        private void BtnProceedBuildTaskClick(object sender, EventArgs e) {
            try {
                if (ValidateGrid()) {
                    currentlySelectedTask.GeneratedText = CreateBuildTask();
                    currentlySelectedTask.SuppliedComment =  txtComment.Text.Trim();                    
                    if ((cboOwnerTarget.SelectedItem as BuildTargetObject) != null) {
                    currentlySelectedTask.OwnedByTarget = 	cboOwnerTarget.SelectedItem as BuildTargetObject;
                    }else{
                      currentlySelectedTask.OwnedByMacrodef = 	cboOwnerTarget.SelectedItem as BuildTask;                 
                    }                                        
                    this.DialogResult = DialogResult.OK;
                } else {
                    this.DialogResult = DialogResult.None;
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

        private string CreateBuildTask() {
            string createdBuildTask = "<"+currentlySelectedTask.Name+" ";
            //FIXME: check for different types of properties, ex: nested type
            foreach (FilledBuildTaskProperty property in suppliedProperties) {
                createdBuildTask =  string.Concat(createdBuildTask,property.PropertyName,"=\"",property.PropertyValue+property.PropertyConfigFilePath+"\" ");
                if (property.HasConfigFile) {
                    //FIXME: write config file
                    WriteSuppliedConfigFile(property.PropertyConfigFilePath,property.PropertyConfigFileValue);
                }
            }
            createdBuildTask = createdBuildTask +"></"+currentlySelectedTask.Name+">";
            return createdBuildTask;
        }

        private void WriteSuppliedConfigFile(string filePath, string fileValue) {

        }

        private  void DgvTaskPropertiesCellClick(object sender, DataGridViewCellEventArgs e) {
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

        private void AddCommonPropertyToolStripMenuItemClick(object sender, EventArgs e) {
            try {
                //FIXME:getcommon property list from db
                List<BuildTaskProperty> commonProps = new List<BuildTaskProperty>();
                AddCommonPropertyForm form = new AddCommonPropertyForm(commonProps);
                DialogResult dial = form.ShowDialog();
                if (dial == DialogResult.OK) {
                    FillDatagridFromPropertyList(form.selectedCommonProperties);
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }
    }
}
