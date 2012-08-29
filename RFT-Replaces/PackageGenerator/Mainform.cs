﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using PackageGenerator.Forms;
using Automation.Common.Utils;
using Automation.Common;

namespace PackageGenerator {
    public partial class Mainform : Form {
        public Mainform() {
            InitializeComponent();
        }

        private void Mainform_Load(object sender, EventArgs e) {
            try {
                AddHeaderCheckBox();
                //FrontendUtils.SendUsageNotification("Started");

                try {
                    FrontendUtils.SendEmail("mkabbani@murex.com", "mkabbani@murex.com", "Generator Started", "Generator has been started");
                } catch (Exception) {
                }

                cboPropertyType.SelectedIndex = 0;
                //populate all props from installer file

                string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";

                PopulateAllAvailableProperties(pathToInstallerFile);
                // PopulateAllAvailableProps();
                lbAvailableProps.SelectedIndex = 0;


                string pathToUtilsFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\FrontendUtilities.groovy";
                LoadAvailableFunctionsToList(pathToUtilsFile);

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }


        #region DGV CheckboxCol
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;

        private void AddHeaderCheckBox() {
            HeaderCheckBox = new CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.dgvOutputOperations.Controls.Add(HeaderCheckBox);

            HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
            HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
            dgvOutputOperations.CellValueChanged +=
               new DataGridViewCellEventHandler(dgvSelectAll_CellValueChanged);
            dgvOutputOperations.CurrentCellDirtyStateChanged +=
              new EventHandler(dgvSelectAll_CurrentCellDirtyStateChanged);
            dgvOutputOperations.CellPainting +=
              new DataGridViewCellPaintingEventHandler(dgvSelectAll_CellPainting);
        }

        private void dgvSelectAll_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            if (dgvOutputOperations.CurrentCell is DataGridViewCheckBoxCell)
                dgvOutputOperations.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvSelectAll_CellPainting(object sender,
             DataGridViewCellPaintingEventArgs e) {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex) {
            //Get the column header cell bounds
            Rectangle oRectangle = this.dgvOutputOperations.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.X = oRectangle.Location.X + oRectangle.Width - HeaderCheckBox.Width - 2;

            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox.Location = oPoint;
        }

        private void dgvSelectAll_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 0) {
                if (!IsHeaderCheckBoxClicked)
                    RowCheckBoxClick((DataGridViewCheckBoxCell)dgvOutputOperations[e.ColumnIndex, e.RowIndex]);
            }
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox) {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in dgvOutputOperations.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["CommentUsage"]).Value = HCheckBox.Checked;

            dgvOutputOperations.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }

        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e) {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox) {
            if (RCheckBox != null) {
                //Modify Counter;            
                if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
                    TotalCheckedCheckBoxes++;
                else if (TotalCheckedCheckBoxes > 0)
                    TotalCheckedCheckBoxes--;

                //Change state of the header CheckBox.
                if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                    HeaderCheckBox.Checked = false;
                else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                    HeaderCheckBox.Checked = true;
            }
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);

        }
        #endregion

        string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);




        private void LoadAvailableFunctionsToList(string utilsFilePath) {
            string readFile = FrontendUtils.ReadFile(utilsFilePath);

            Regex regex = new Regex("(public).*?(\\S+).?\\((.*)\\)\\{");
            MatchCollection matches = regex.Matches(readFile);

            foreach (Match match in matches) {
                string functionName = match.Groups[2].Value;
                string allFunctionVariables = match.Groups[3].Value;

                string[] variables = allFunctionVariables.Split(',');
                Dictionary<string, List<string>> variableTypAndName = new Dictionary<string, List<string>>();
                variableTypAndName.Add("boolean", new List<string>());
                variableTypAndName.Add("other", new List<string>());

                string functionCall = string.Empty;

                List<string> variablesIndexes = new List<string>();

                for (int i = 0; i < variables.Length; i++) {
                    string[] variableTypeAndName = variables[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    if (variableTypeAndName.Length > 1) {
                        functionCall = functionCall + variableTypeAndName[1] + " ,";
                        if (string.Equals(variableTypeAndName[0], "boolean") || string.Equals(variableTypeAndName[0], "Boolean")) {
                            variableTypAndName["boolean"].Add(variableTypeAndName[1]);
                            variablesIndexes.Add(variableTypeAndName[1]);
                        } else {
                            variableTypAndName["other"].Add(variableTypeAndName[1]);
                            variablesIndexes.Add(variableTypeAndName[1]);
                        }
                    }
                }
                functionCall = functionCall.Trim(new char[] { ',' });
                CustomizationFunction function = new CustomizationFunction(functionName, "desc", variableTypAndName, functionCall);
                function.variablesIndexes = variablesIndexes;
                function.localDescription = GetDiscription(function.localName, readFile);

                lbAvailableFunctions.Items.Add(function);
                //Label lbl = new Label();
                //lbl.Text = variableTypeAndName[1];
                //pnlParameters.Controls.Add(lbl);
                //lbl.Dock = DockStyle.Top;
                //if (string.Equals(variableTypeAndName[0], "boolean") || string.Equals(variableTypeAndName[0], "Boolean")) {
                //    ComboBox cbo = new ComboBox();
                //    cbo.Items.Add("True");
                //    cbo.Items.Add("False");
                //    cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                //    cbo.Name = variableTypeAndName[1];
                //    pnlParameters.Controls.Add(cbo);
                //    cbo.Dock = DockStyle.Top;
                //} else {
                //    TextBox txt = new TextBox();
                //    txt.Name = variableTypeAndName[1];
                //    pnlParameters.Controls.Add(txt);
                //    txt.Dock = DockStyle.Top;
                //}

            }
        }

        private string GetDiscription(string functionName, string inputText) {
            string description = string.Empty;
            Regex reg = new Regex("//desc-start.*Name:(" + functionName + ")(.*?)//desc-end", RegexOptions.Singleline);
            Match match = reg.Match(inputText);
            if (match.Groups.Count > 0) {
                string funName = match.Groups[1].Value;
                string desc = match.Groups[2].Value;
                desc = desc.Replace("//", "").Replace("Description:", "").Replace("\t", "").Replace("\r", "").Replace("\n", "");
                desc = desc.Replace("Parameter", "\r\nParameter");
                description = desc;
            }
            return description;
        }

        private void lbAvailableFunctions_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                pnlParameters.Visible = false;
                UpdateUiFromSelectedItem(lbAvailableFunctions.SelectedItem as CustomizationFunction);
                pnlParameters.Visible = true;
                txtFunctionComment.Text = "Add comment here...";
                btnSave.Enabled = false;
                btnAdd.Enabled = true;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void UpdateUiFromSelectedItem(CustomizationFunction customizationFunction) {
            pnlParameters.Controls.Clear();
            txtFunctionName.Text = customizationFunction.localName;
            txtDescription.Text = customizationFunction.localDescription;
            for (int i = 0; i < customizationFunction.localVariableTypeAndName.Count; i++) {
                for (int j = 0; j < customizationFunction.localVariableTypeAndName.ElementAt(i).Value.Count; j++) {

                    Label lbl = new Label();
                    lbl.Visible = false;
                    lbl.Text = customizationFunction.localVariableTypeAndName.ElementAt(i).Value[j].Substring(0, 1).ToUpperInvariant() +
                    customizationFunction.localVariableTypeAndName.ElementAt(i).Value[j].Substring(1);
                    lbl.Dock = DockStyle.Top;


                    if (string.Equals(customizationFunction.localVariableTypeAndName.ElementAt(i).Key, "boolean")) {
                        ComboBox cbo = new ComboBox();
                        cbo.Visible = false;
                        cbo.Items.Add("True");
                        cbo.Items.Add("False");
                        cbo.DropDownStyle = ComboBoxStyle.DropDown;
                        cbo.Name = customizationFunction.localVariableTypeAndName.ElementAt(i).Value[j];
                        cbo.Dock = DockStyle.Top;
                        cbo.SelectedIndex = 0;
                        cbo.ContextMenuStrip = cmsAddPropertyMenu;
                        pnlParameters.Controls.Add(cbo);
                        pnlParameters.Controls.Add(lbl);
                       

                    } else {
                        TextBox txt = new TextBox();
                        txt.Visible = false;
                        txt.Name = customizationFunction.localVariableTypeAndName.ElementAt(i).Value[j];
                        txt.Dock = DockStyle.Top;
                        //txt.Text = "\"\"";
                        txt.ContextMenuStrip = cmsAddPropertyMenu;
                        pnlParameters.Controls.Add(txt);
                        pnlParameters.Controls.Add(lbl);
                        
                    }
                }
            }
            foreach (Control control in pnlParameters.Controls) {
                control.Visible = true;
            }

        }

        //void txt_TextChanged(object sender, EventArgs e) {
        //    TextBox txt = sender as TextBox;
        //    if(!string.IsNullOrEmpty(txt.Text)){
        //        if(!txt.Text.StartsWith("\"")){
        //            txt.Text = "\"" + txt.Text;
        //        }
        //        if(!txt.Text.EndsWith("\"")){
        //            txt.Text = txt.Text + "\"";
        //        }
        //    }
        //}
        int counter = 1;
        private void btnAdd_Click(object sender, EventArgs e) {
            try {

                if (lbAvailableFunctions.SelectedItem != null) {
                    if (IsValidToAddOperation()) {
                        string operationValue = GetAllVariables();
                        //txtOutput.Text = txtOutput.Text + "\r\n\r\n" + counter + "- " + operationValue;
                        int rowIndex = dgvOutputOperations.Rows.Add();

                        Regex regexForQuotationEscape = new Regex("[A-Za-z0-9](\")[A-Za-z0-9]");


                        dgvOutputOperations.Rows[rowIndex].Cells["Steps"].Value = rowIndex + 1;
                        dgvOutputOperations.Rows[rowIndex].Cells["Operations"].Value = regexForQuotationEscape.Replace(operationValue, "$1\\\"$3");
                        dgvOutputOperations.Rows[rowIndex].Cells["Key"].Value = rowIndex;
                        dgvOutputOperations.Rows[rowIndex].Cells["Comment"].Value = txtFunctionComment.Text.Trim();
                        dgvOutputOperations.Rows[rowIndex].Cells["CommentUsage"].Value = true;


                        ValidateInsertedRow(operationValue, dgvOutputOperations.Rows[rowIndex]);

                        counter++;
                        dgvOutputOperations.ClearSelection();
                        dgvOutputOperations.FirstDisplayedScrollingRowIndex = rowIndex;
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ValidateInsertedRow(string operationValue, DataGridViewRow dataGridViewRow) {
            if (operationValue.Contains("\"\"")) {
                dataGridViewRow.DefaultCellStyle.BackColor = Color.LightCoral;
            } else {
                dataGridViewRow.DefaultCellStyle.BackColor = new Color();
            }
        }

        private bool IsValidToAddOperation() {
            foreach (Control control in pnlParameters.Controls) {
                if (control is TextBox) {
                    Regex reg = new Regex(@"\b" + control.Name + @"\b");
                    if (!control.Text.Contains("{")) {
                        //         returnValue = reg.Replace(returnValue, control.Text);
                        // returnValue = returnValue.Replace(control.Name, "\"" + control.Text + "\"");
                    } else {
                        //propname+asdasdasdasd
                        Regex propBracketReg = new Regex("\\{(\\S+)\\}");
                        string propertyName = "PROP_" + propBracketReg.Match(control.Text).Groups[1].Value;
                        //         returnValue = reg.Replace(returnValue, control.Text.Replace("{" + propBracketReg.Match(control.Text).Groups[1].Value + "}", "PROP_" + propBracketReg.Match(control.Text).Groups[1].Value));

                    }
                } else if (control is ComboBox) {
                    Regex reg = new Regex(@"\b" + control.Name + @"\b");
                    //returnValue = returnValue + (string.Equals(control.Text, "True") ? true : false) + " ,";
                    if (!control.Text.Contains("{")) {
                        //           returnValue = reg.Replace(returnValue, (string.Equals(control.Text, "True") ? "true" : "false"));
                        //returnValue =    returnValue.Replace(control.Name, (string.Equals(control.Text, "True") ? true : false).ToString());
                    } else {
                        //           returnValue = reg.Replace(returnValue, "PROP_" + control.Text.Trim(new char[] { '{', '}' }));

                    }
                }
            }

            return true;
        }



        private void btnRemove_Click(object sender, EventArgs e) {
            try {
                if (dgvOutputOperations.Rows.Count > 0) {
                    dgvOutputOperations.Rows.RemoveAt(dgvOutputOperations.Rows.Count - 1);
                }

                //txtOutput.Text = txtOutput.Text.Remove(txtOutput.Text.LastIndexOf("\r\n\r\n"));
                counter--;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private string GetAllVariables() {
            //update this to consider properties
            string returnValue = (lbAvailableFunctions.SelectedItem as CustomizationFunction).functionCall;
            foreach (Control control in pnlParameters.Controls) {
                if (control is TextBox) {
                    Regex reg = new Regex(@"\b" + control.Name + @"\b");
                    if (!control.Text.Contains("{") && !control.Text.Contains("AppDir")) {
                        returnValue = reg.Replace(returnValue, "\"" + control.Text.Replace("\"", "\\\"") + "\"");
                        // returnValue = returnValue.Replace(control.Name, "\"" + control.Text + "\"");
                    } else if (control.Text.Contains("AppDir")) {
                        if (!control.Text.Contains("\"")) {
                            returnValue = reg.Replace(returnValue, control.Text.Replace("+ ", "+ \"") + "\"");

                        } else {
                            returnValue = reg.Replace(returnValue, control.Text);
                        }
                        //else {
                        //    returnValue = reg.Replace(returnValue, control.Text.Replace("\"", "\\\""));
                        //}

                    } else {
                        //propname+asdasdasdasd
                        Regex propBracketReg = new Regex("\\{(\\S+)\\}");
                        string propertyName = "PROP_" + propBracketReg.Match(control.Text).Groups[1].Value;
                        returnValue = reg.Replace(returnValue, control.Text.Replace("{" + propBracketReg.Match(control.Text).Groups[1].Value + "}", "PROP_" + propBracketReg.Match(control.Text).Groups[1].Value));

                    }
                } else if (control is ComboBox) {
                    Regex reg = new Regex(@"\b" + control.Name + @"\b");
                    //returnValue = returnValue + (string.Equals(control.Text, "True") ? true : false) + " ,";
                    if (!control.Text.Contains("{")) {
                        returnValue = reg.Replace(returnValue, (string.Equals(control.Text, "True") ? "true" : "false"));
                        //returnValue =    returnValue.Replace(control.Name, (string.Equals(control.Text, "True") ? true : false).ToString());
                    } else {
                        returnValue = reg.Replace(returnValue, "PROP_" + control.Text.Trim(new char[] { '{', '}' }));

                    }
                }
            }
            return returnValue;
        }

        private void btnGeneratePackage_Click(object sender, EventArgs e) {
            try {
                string workingDir = Path.GetTempPath() + "\\Migration";



                PreparePackageForGeneration();

                #region Copy Migration And get linked files
                if (Directory.Exists(pathToThisExec + @"\MIGRATION")) {
                    if (Directory.Exists(workingDir)) {
                        Directory.Delete(workingDir, true);
                    }

                    FrontendUtils.CopyDirectory(pathToThisExec + @"\MIGRATION", workingDir + @"\MIGRATION");

                }
                string pathToAppDir = workingDir + @"\MIGRATION\FIRSTPACKAGE\trunk\";

                GetLinkedFiles(pathToAppDir);

                #endregion

                #region Create Generation Command and Generate

                FolderBrowserDialog dial = new FolderBrowserDialog();

                dial.ShowNewFolderButton = true;

                dial.Description = "Generated Package Location";

                PackageNameForm form = new PackageNameForm();

                DialogResult dialogPackageName = form.ShowDialog();


                if (dialogPackageName == DialogResult.OK) {

                    string pathToCisPackage = workingDir + @"\MIGRATION\FIRSTPACKAGE\cis-mxpack-1.0-full.jar";
                    string pathToConfigFile = workingDir + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\ci.xml";
                    string pathTomainConfigFile = workingDir + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\ci-main.xml";

                    string configFileText = File.ReadAllText(pathTomainConfigFile).Replace("Migration-Package", form.Controls["txtPackageName"].Text);
                    FrontendUtils.WriteFile(pathToConfigFile, configFileText);



                    if (dial.ShowDialog() == DialogResult.OK) {
                        string pathToTarget = dial.SelectedPath;
                        string pathToSource = workingDir + @"\MIGRATION\FIRSTPACKAGE\trunk";

                        string packageId = "MigrationPackage";

                        string commandToExecute = "java -jar \"" + pathToCisPackage + "\"" +
                                                  " " +
                                                  "-configfile:\"" + pathToConfigFile + "\"" +
                                                  " " +
                                                  "-source:\"" + pathToSource + "\"" +
                                                  " " +
                                                  "-target:\"" + pathToTarget + "\"" +
                                                  " " +
                                                  "-packageid:" + packageId;


                        FrontendUtils.WriteFile(workingDir + @"\compile.cmd", commandToExecute);
                        FrontendUtils.ExecuteCommandSync(workingDir + @"\compile.cmd");
                    }
                }
                #endregion

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void GetLinkedFiles(string pathToAppDir) {
            SharpSvn.SvnClient client = new SharpSvn.SvnClient();
            client.Authentication.Clear();
            for (int i = 0; i < dgvFilesToImport.Rows.Count; i++) {
                //Relative || Link//
                string fileRelativePath = dgvFilesToImport.Rows[i].Cells["relativePath"].Value.ToString();
                string fileLink = dgvFilesToImport.Rows[i].Cells["fileLink"].Value.ToString();

                SharpSvn.SvnUriTarget target = new SharpSvn.SvnUriTarget(dgvFilesToImport.Rows[i].Cells["fileLink"].Value.ToString());
                Directory.CreateDirectory(pathToAppDir + @"\" + dgvFilesToImport.Rows[i].Cells["relativePath"].Value.ToString());
                try {
                    SharpSvn.SvnExportArgs svnExportArgs = new SharpSvn.SvnExportArgs();
                    svnExportArgs.Overwrite = true;
                    client.Export(target,
                        pathToAppDir + @"\" + dgvFilesToImport.Rows[i].Cells["relativePath"].Value.ToString() + @"\" + Path.GetFileName(dgvFilesToImport.Rows[i].Cells["fileLink"].Value.ToString()),
                        svnExportArgs);
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                }

            }
        }

        private void PreparePackageForGeneration() {
            #region Prepare Package for Generations

            string pathToMainInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";
            string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\Installer.groovy";
            string pathToOriginalOperationFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\main.groovy";
            string pathToOperationFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\Operations.groovy";


            #region Installer File

            //Copy Installer File
            File.Copy(pathToMainInstallerFile, pathToInstallerFile, true);
            //Read fresh Installer File
            string installerFile = FrontendUtils.ReadFile(pathToInstallerFile);

            Regex reg = new Regex(@"//Start-Properties(.*)End-Properties", RegexOptions.Singleline);

            string replacementAllProperties = GetAllProperties();

            installerFile = reg.Replace(installerFile, "//Start-Properties\n\n" + replacementAllProperties + "\n\n//End-Properties");
            //write new Installer File
            FrontendUtils.WriteFile(pathToInstallerFile, installerFile);

            #endregion


            #region Operations file

            //copy fresh operations file
            File.Copy(pathToOriginalOperationFile, pathToOperationFile, true);

            //Read fresh operations file
            string operationFile = FrontendUtils.ReadFile(pathToOperationFile);

            //get formatted properties from UI
            //add properties to operations file
            string allProperties = GetAllPropertiesForOperations();
            operationFile = operationFile.Replace("\t//Start-Operations", allProperties + "\r\n\r\n//Start-Operations");


            //get formatted function calls from UI
            //add function calls to operations file
            //string GeneratedOperationsFile = GetFormatedFunctions(txtOutput.Text);

            string GeneratedOperationsFile = ExtractOperationsFromGridView();
            Regex startEndOperationsRegex = new Regex("//Start-Operations.*//End-Operations", RegexOptions.Singleline);

            operationFile = startEndOperationsRegex.Replace(operationFile, "//Start-Operations" + GeneratedOperationsFile + "\r\n\t//End-Operations");
            //operationFile = operationFile.Replace("}}", GeneratedOperationsFile + "\r\n\r\n}}");

            //write new operations file
            FrontendUtils.WriteFile(pathToOperationFile, operationFile);

            #endregion

            #endregion
        }

        private string ExtractOperationsFromGridView() {
            string extractedOperations = string.Empty;
            string funtionComment = string.Empty;
            for (int i = 0; i < dgvOutputOperations.Rows.Count; i++) {
                funtionComment = dgvOutputOperations.Rows[i].Cells["Comment"].Value.ToString();
                extractedOperations = extractedOperations + "\r\n\t\r\n\t/*" + funtionComment + "*/\r\n\tfrontEndUtilities." + dgvOutputOperations.Rows[i].Cells["Operations"].Value + ";";
            }
            return extractedOperations;
        }

        private string GetAllPropertiesForOperations() {
            string propertiesInOperations = string.Empty;
            for (int i = 0; i < lbAvailableProps.Items.Count; i++) {
                InstallerProp prop = lbAvailableProps.Items[i] as InstallerProp;
                propertiesInOperations = propertiesInOperations + "def PROP_" + prop.localName + " = properties.get(\"" + prop.localName + "\");\n\r";

            }
            return propertiesInOperations;
        }

        private string GetAllProperties() {
            string propertyAndAddition = string.Empty;

            for (int i = 0; i < lbAvailableProps.Items.Count; i++) {
                InstallerProp prop = lbAvailableProps.Items[i] as InstallerProp;
                propertyAndAddition = propertyAndAddition + "\r\nproperty(name:'" + prop.localName + "'){\r\n" +
                                                                   "description = '" + prop.localDescription + "'\r\n" +
                                                                   "type = " + (prop.localType == InstallerProp.PropType.BooleanProperty ? "boolean" : "String") + "\r\n" +
                                                                   "defaultValue = " + (prop.localType == InstallerProp.PropType.StringProperty ? "'" : "") + prop.localDefaultValue + (prop.localType == InstallerProp.PropType.StringProperty ? "'" : "") + "\r\n}\r\n" +
                                                                   "props.put(\"" + prop.localName + "\", " + prop.localName + ")\r\n";

            }

            return propertyAndAddition;
        }

        //private string GetFormatedFunctions(string outputText) {
        //    string formattedOutput = string.Empty;
        //    string[] outputByLine = txtOutput.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        //    Regex reg = new Regex("\\d+-.");
        //    for (int i = 0; i < outputByLine.Length; i++) {
        //        if (!string.IsNullOrEmpty(outputByLine[i].Trim())) {
        //            formattedOutput = formattedOutput + "\n\t" + "frontEndUtilities." + reg.Replace(outputByLine[i], "");
        //        }
        //    }
        //    return formattedOutput;
        //}

        private void btnClear_Click(object sender, EventArgs e) {
            try {
                //txtOutput.Clear();
                if (dgvOutputOperations.Rows.Count > 0) {
                    DialogResult dial = FrontendUtils.ShowConformation("Are you sure you want to clear all [Operations]?");

                    if (dial == DialogResult.Yes) {

                        dgvOutputOperations.Rows.Clear();
                        counter = 1;
                        btnSave.Enabled = false;
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnExportCi_Click(object sender, EventArgs e) {
            try {
                if (dgvOutputOperations.Rows.Count > 0 || dgvFilesToImport.Rows.Count > 0) {

                    PreparePackageForGeneration();

                    string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    string pathToDotCiFolder = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk";
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    dialog.ShowNewFolderButton = true;
                    if (dialog.ShowDialog() == DialogResult.OK) {
                        FrontendUtils.CopyDirectory(pathToDotCiFolder, dialog.SelectedPath);
                        File.Delete(dialog.SelectedPath + @"\.ci\package\murex\Migration\main.groovy");
                        File.Delete(dialog.SelectedPath + @"\.ci\package\murex\Migration\installMain.groovy");
                        File.Delete(dialog.SelectedPath + @"\.ci\ci-main.xml");


                        if (dgvFilesToImport.Rows.Count > 0) {
                            DialogResult dialogExportCiAndFileList =
                                         MessageBox.Show("Do you want to export both [.Ci] and [File List] objects?" +
                                                         "\nPress [Yes] for exporting all objects, [No] for exporting [.Ci] only.", "Export Package", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogExportCiAndFileList == DialogResult.Yes) {
                                string outputFileName = dialog.SelectedPath + @"\ImportFileList.txt";
                                ExportFileList(outputFileName);
                            }
                        }

                        FrontendUtils.ShowInformation("Export Completed!");
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void cboPropertyType_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                // 0 String
                // 1 Boolean
                if (cboPropertyType.SelectedIndex == 0) {
                    txtPropertyValue.Visible = true;
                    cboPropertyValue.Visible = false;
                } else {
                    txtPropertyValue.Visible = false;
                    cboPropertyValue.Visible = true;
                    cboPropertyValue.SelectedIndex = 0;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            try {

                //if (string.Equals(tabControl1.SelectedTab.Text, "Properties")) {
                //    //populate all props from installer file

                //    string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";

                //    PopulateAllAvailableProperties(pathToInstallerFile);
                //    lbAvailableProps.SelectedIndex = 0;

                //}
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }



        private void PopulateAllAvailableProperties(string pathToInstallerFile) {
            lbAvailableProps.Items.Clear();

            // string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //  string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";

            string installerFile = FrontendUtils.ReadFile(pathToInstallerFile);

            Regex reg = new Regex(@"\bStart-Properties(.*)End-Properties\b", RegexOptions.Singleline);

            string match = reg.Match(installerFile).Groups[1].Value;

            Regex propertyValues = new Regex(@"\bproperty\(name:'(\S+)'.*?description = '(.*?)'.*?type = (\S+).*?(defaultValue = (\S+))\b", RegexOptions.Singleline);

            MatchCollection propertyValuesMatches = propertyValues.Matches(match);


            foreach (Match propertyValuesMatch in propertyValuesMatches) {

                InstallerProp installerPropertyObject
                    = new InstallerProp(propertyValuesMatch.Groups[1].Value,
                propertyValuesMatch.Groups[2].Value,
                string.Equals(propertyValuesMatch.Groups[3].Value.Trim(new char[] { '\'' }), "boolean") ? InstallerProp.PropType.BooleanProperty : InstallerProp.PropType.StringProperty,
                propertyValuesMatch.Groups[5].Value.Trim(new char[] { '\'' }));

                lbAvailableProps.Items.Add(installerPropertyObject);
            }
        }

        //private void PopulateAllAvailableProps() {
        //    lbAvailableProps.Items.Clear();

        //    string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        //    string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";

        //    string installerFile = FrontendUtils.ReadFile(pathToInstallerFile);

        //    Regex reg = new Regex(@"\bStart-Properties(.*)End-Properties\b", RegexOptions.Singleline);

        //    string match = reg.Match(installerFile).Groups[1].Value;

        //    Regex propertyValues = new Regex(@"\bproperty\(name:'(\S+)'.*?description = '(.*?)'.*?type = (\S+).*?(defaultValue = (\S+))\b", RegexOptions.Singleline);

        //    MatchCollection propertyValuesMatches = propertyValues.Matches(match);


        //    foreach (Match propertyValuesMatch in propertyValuesMatches) {

        //        InstallerProp installerPropertyObject
        //            = new InstallerProp(propertyValuesMatch.Groups[1].Value,
        //        propertyValuesMatch.Groups[2].Value,
        //        string.Equals(propertyValuesMatch.Groups[3].Value.Trim(new char[] { '\'' }), "boolean") ? InstallerProp.PropType.BooleanProperty : InstallerProp.PropType.StringProperty,
        //        propertyValuesMatch.Groups[5].Value.Trim(new char[] { '\'' }));

        //        lbAvailableProps.Items.Add(installerPropertyObject);
        //    }
        //}

        private void lbAvailableProps_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                txtPropertyName.ReadOnly = true;
                btnAddProperty.Enabled = false;
                btnSaveProperty.Enabled = true;


                InstallerProp selectedInstallerPropertyObject = lbAvailableProps.SelectedItem as InstallerProp;
                if (selectedInstallerPropertyObject != null) {

                    txtPropertyName.Text = selectedInstallerPropertyObject.localName;
                    txtPropertyDesc.Text = selectedInstallerPropertyObject.localDescription;

                    cboPropertyType.SelectedIndex = (selectedInstallerPropertyObject.localType == InstallerProp.PropType.BooleanProperty) ? 1 : 0;
                    if (cboPropertyType.SelectedIndex == 0) {
                        txtPropertyValue.Text = selectedInstallerPropertyObject.localDefaultValue.ToString();
                    } else {
                        cboPropertyValue.SelectedIndex = string.Equals(selectedInstallerPropertyObject.localDefaultValue.ToString(), "true") ? 0 : 1;
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                ResetPorpertyDefinitionPart();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ResetPorpertyDefinitionPart() {
            lbAvailableProps.ClearSelected();
            btnAddProperty.Enabled = true;
            btnSaveProperty.Enabled = false;

            txtPropertyName.ReadOnly = false;
            txtPropertyName.Clear();
            txtPropertyDesc.Clear();
            txtPropertyValue.Clear();
            cboPropertyValue.SelectedIndex = 0;
            cboPropertyType.SelectedIndex = 0;
        }

        private void btnAddProperty_Click(object sender, EventArgs e) {

            try {
                if (IsValidToAddProperty(gbProperty.Controls)) {
                    if (lbAvailableProps.FindStringExact(txtPropertyName.Text) == ListBox.NoMatches) {

                        InstallerProp selectedInstallerPropertyObject =
                                    new InstallerProp(txtPropertyName.Text,
                                                      txtPropertyDesc.Text,
                                                      cboPropertyType.SelectedIndex == 0 ? InstallerProp.PropType.StringProperty : InstallerProp.PropType.BooleanProperty,
                                                      txtPropertyValue.Visible ? txtPropertyValue.Text : cboPropertyValue.SelectedItem.ToString().ToLower());

                        lbAvailableProps.Items.Add(selectedInstallerPropertyObject);
                        ResetPorpertyDefinitionPart();
                    } else {
                        FrontendUtils.ShowInformation("The property name is already in use, please choose a unique name!");
                    }

                } else {
                    FrontendUtils.ShowInformation("Please make sure all fields are filled");
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private bool IsValidToAddProperty(Control.ControlCollection controlCollection) {
            foreach (Control control in controlCollection) {
                if (control is TextBox && control.Visible) {
                    if (string.IsNullOrEmpty(control.Text)) {
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnRemoveProperty_Click(object sender, EventArgs e) {
            try {
                lbAvailableProps.Items.Remove(lbAvailableProps.SelectedItem);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnSaveProperty_Click(object sender, EventArgs e) {
            try {
                if (IsValidToAddProperty(gbProperty.Controls)) {
                    InstallerProp installerProp = lbAvailableProps.Items[lbAvailableProps.FindStringExact(txtPropertyName.Text)] as InstallerProp;

                    installerProp.localDescription = txtPropertyDesc.Text;
                    installerProp.localType = cboPropertyType.SelectedIndex == 0 ? InstallerProp.PropType.StringProperty : InstallerProp.PropType.BooleanProperty;
                    installerProp.localDefaultValue = txtPropertyValue.Visible ? txtPropertyValue.Text : cboPropertyValue.SelectedItem.ToString().ToLower();

                } else {
                    FrontendUtils.ShowInformation("Please make sure all fields are filled");
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private void dgvOutputOperations_MouseMove(object sender, MouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                // If the mouse moves outside the rectangle, start the drag.         
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y)) {
                    // Proceed with the drag and drop, passing in the list item.                                 
                    DragDropEffects dropEffect = dgvOutputOperations.DoDragDrop(dgvOutputOperations.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        private void dgvOutputOperations_MouseDown(object sender, MouseEventArgs e) {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dgvOutputOperations.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1) {
                // Remember the point where the mouse down occurred.       
                // The DragSize indicates the size that the mouse can move       
                // before a drag event should be started.
                Size dragSize = SystemInformation.DragSize;
                // Create a rectangle using the DragSize, with the mouse position being         
                // at the center of the rectangle.         
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            } else {
                // Reset the rectangle if the mouse is not over an item in the ListBox.         
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void dgvOutputOperations_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvOutputOperations_DragDrop(object sender, DragEventArgs e) {
            // The mouse locations are relative to the screen, so they must be      
            // converted to client coordinates.     
            Point clientPoint = dgvOutputOperations.PointToClient(new Point(e.X, e.Y));
            // Get the row index of the item the mouse is below.      
            rowIndexOfItemUnderMouseToDrop = dgvOutputOperations.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move) {
                DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                dgvOutputOperations.Rows.RemoveAt(rowIndexFromMouseDown);
                dgvOutputOperations.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
            }

            int counter = 1;
            foreach (DataGridViewRow row in dgvOutputOperations.Rows) {
                row.Cells[0].Value = counter;
                counter++;
            }
        }

        /// <summary> /// Gets controls for context menu ///
        /// </summary> /// <param name="Sender">Sender object from menu event handler</param> ///
        /// <returns></returns> 
        private object GetSourceControl(Object Sender) {
            // ContextMenuStrip sended?
            if (Sender as ContextMenuStrip != null) {
                ContextMenuStrip cms = Sender as ContextMenuStrip;
                return cms.SourceControl;
            }
            var item = Sender as ToolStripItem;
            // move to root item   
            while (item.OwnerItem != null) {
                item = item.OwnerItem;
            }
            // we have root item now, so lets take ContextMenuStrip object   
            var menuObject = item.Owner as ContextMenuStrip;
            if (menuObject != null) {
                return menuObject.SourceControl;
            }
            return null;
        }

        private void addPropertyToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                //  AddPropertyForm form = new AddPropertyForm(lbAvailableProps.Items);
                AddPropertyForm form = new AddPropertyForm(lbAvailableProps.Items);
                // form.Parent = this.Parent;
                form.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK) {
                    Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
                    if (control != null) {
                        if (string.Equals(control.Text, "\"\"")) {
                            control.Text = "";
                        }
                        control.Text = control.Text + "{" + form.selectedInstallerProp.localName + "}";
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        string pathOfImportedCi = string.Empty;

        private void btnImportCi_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dial = new FolderBrowserDialog();
                dial.Description = "Select folder containing .ci and file list";
                if (dial.ShowDialog() == DialogResult.OK) {
                    if (Directory.Exists(dial.SelectedPath + @"\.ci")) {
                        pathOfImportedCi = dial.SelectedPath;
                        if (dgvOutputOperations.Rows.Count > 0) {
                            DialogResult dialogAppend = MessageBox.Show("Do you want to append to the existing operations list?", "Import Mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogAppend == DialogResult.Yes) {
                                StartImportOfCi(dial.SelectedPath, true);
                            } else {
                                StartImportOfCi(dial.SelectedPath, false);
                            }
                        } else {
                            StartImportOfCi(dial.SelectedPath, false);
                        }
                        btnReloadCi.Enabled = true;
                    }
                    string[] applicableImportFileListFiles = Directory.GetFiles(dial.SelectedPath, "*.txt");
                    if (applicableImportFileListFiles.Length > 0) {
                        ImportFilesListFile(applicableImportFileListFiles[0]);
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void StartImportOfCi(string PathToCiFolder, bool isAppendEnabled) {
            if (!isAppendEnabled) {
                dgvOutputOperations.Rows.Clear();
            }
            string[] installerFile = Directory.GetFiles(PathToCiFolder, "Installer.groovy", SearchOption.AllDirectories);
            string[] OperationsFile = Directory.GetFiles(PathToCiFolder, "Operations.groovy", SearchOption.AllDirectories);
            ParseCiProperties(installerFile[0]);
            ParseCiFunctions(OperationsFile[0]);
        }

        private void ParseCiFunctions(string pathToOperationsFile) {
            Regex operationsRegex = new Regex("//Start-Operations(.*)//End-Operations", RegexOptions.Singleline);
            string readOperationsFile = FrontendUtils.ReadFile(pathToOperationsFile);

            string allOperations = operationsRegex.Match(readOperationsFile).Groups[1].Value;

            //Regex anOperation = new Regex(@"frontEndUtilities.(.*);");
            //Regex anOperation = new Regex(@"/\*(.*?)\*/.*?frontEndUtilities.(.*?);");
            Regex anOperation = new Regex("/\\*(.*?)\\*/.*?frontEndUtilities.(.*?);", RegexOptions.Singleline);
            MatchCollection mCollection = anOperation.Matches(allOperations);

            foreach (Match match in mCollection) {
                //SetUtilsLogDir(logDir, );
                int rowIndex = dgvOutputOperations.Rows.Add();
                dgvOutputOperations.Rows[rowIndex].Cells["Steps"].Value = (rowIndex + 1);
                dgvOutputOperations.Rows[rowIndex].Cells["Operations"].Value = match.Groups[2].Value;
                dgvOutputOperations.Rows[rowIndex].Cells["Key"].Value = rowIndex;
                dgvOutputOperations.Rows[rowIndex].Cells["CommentUsage"].Value = true;
                dgvOutputOperations.Rows[rowIndex].Cells["Comment"].Value = match.Groups[1].Value;
                ValidateInsertedRow(dgvOutputOperations.Rows[rowIndex].Cells["Operations"].Value.ToString(), dgvOutputOperations.Rows[rowIndex]);
            }
        }

        private void ParseCiProperties(string pathToInstallerFile) {
            PopulateAllAvailableProperties(pathToInstallerFile);
        }

        private void relAppdirToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
                if (control != null) {
                    control.Text = "AppDir + \"/\"";
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReloadCi_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(pathOfImportedCi)) {
                    DialogResult dial = FrontendUtils.ShowConformation("Are you sure you want to reload from the saved Ci?");
                    if (dial == DialogResult.Yes) {
                        StartImportOfCi(pathOfImportedCi, false);
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        int currentlySelectedKey = -1;

        private void dgvOutputOperations_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (dgvOutputOperations.SelectedRows.Count > 0) {
                    DataGridViewRow row = dgvOutputOperations.SelectedRows[0];
                    currentlySelectedKey = Convert.ToInt32(dgvOutputOperations.SelectedRows[0].Cells["Key"].Value);

                    //"AppendTextToFile( \"\" ,\"\" )"
                    CustomizationFunction customizationFunction = GuessCustomizationFunctionFromGrid(dgvOutputOperations.SelectedRows[0].Cells["Operations"].Value);
                    //add comment to ui
                    txtFunctionComment.Text = row.Cells["Comment"].Value.ToString();

                    btnSave.Enabled = true;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private CustomizationFunction GuessCustomizationFunctionFromGrid(object functionValue) {
            string functionValueWithParameters = functionValue.ToString();

            Regex regexFunctionName = new Regex("[A-Za-z]+");
            string functionName = regexFunctionName.Match(functionValueWithParameters).Value;


            CustomizationFunction customizationFunction = GetCustomFunctionByName(functionName);
            
            pnlParameters.Visible = false;
            UpdateUiFromSelectedItem(customizationFunction);
            pnlParameters.Visible = true;

            Regex regexFunctionParameters = new Regex("\\(.*\\)");

            string[] parameters = regexFunctionParameters.Match(functionValueWithParameters).Value.Split(new char[] { ',' });

            for (int i = 0; i < customizationFunction.variablesIndexes.Count; i++) {
                Control targetedControl = pnlParameters.Controls[customizationFunction.variablesIndexes[i]];
                string parameterValue = parameters[i].Trim(new char[] { '(', ')', ' ' });
                if (targetedControl is TextBox) {
                    if (parameterValue.Contains("PROP_")) {
                        Regex regexPropertyFinder = new Regex("PROP_(\\S+)");
                        Match matchedProperty = regexPropertyFinder.Match(parameterValue);
                        parameterValue = parameterValue.Replace(matchedProperty.Value, "{" + matchedProperty.Groups[1].Value + "}");
                        targetedControl.Text = parameterValue;
                    } else {
                        targetedControl.Text = parameterValue.Replace("\"", "");
                    }

                } else if (targetedControl is ComboBox) {
                    targetedControl.Text = string.Equals(parameterValue, "true") ? "True" : "False";
                }
            }
            return customizationFunction;

        }

        private CustomizationFunction GetCustomFunctionByName(string functionName) {
            foreach (CustomizationFunction item in lbAvailableFunctions.Items) {
                if (string.Equals(item.localName, functionName)) {
                    lbAvailableFunctions.SelectedItem = item;
                    return item;
                }
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e) {
            DataGridView grid = dgvOutputOperations;
            try {
                int totalRows = grid.Rows.Count;
                int idx = grid.SelectedCells[0].OwningRow.Index;
                if (idx == 0)
                    return;
                int col = grid.SelectedCells[0].OwningColumn.Index;
                DataGridViewRowCollection rows = grid.Rows;
                DataGridViewRow row = rows[idx];
                rows.Remove(row);
                rows.Insert(idx - 1, row);
                //grid.ClearSelection();

                int counter = 1;
                grid.ClearSelection();
                grid.Rows[idx - 1].Cells[col].Selected = true;
                dgvOutputOperations.FirstDisplayedScrollingRowIndex = idx - 1;
                foreach (DataGridViewRow arow in dgvOutputOperations.Rows) {
                    arow.Cells[1].Value = counter;
                    counter++;
                }


            } catch { }
        }

        private void btnMoveRowDown_Click(object sender, EventArgs e) {
            DataGridView grid = dgvOutputOperations;
            try {
                int totalRows = grid.Rows.Count;
                if (totalRows != 2) {
                    int idx = grid.SelectedCells[0].OwningRow.Index;
                    if (idx == totalRows - 1)
                        return;
                    int col = grid.SelectedCells[0].OwningColumn.Index;
                    DataGridViewRowCollection rows = grid.Rows;
                    DataGridViewRow row = rows[idx];
                    rows.Remove(row);
                    rows.Insert(idx + 1, row);
                    //  grid.ClearSelection();

                    int counter = 1;
                    grid.ClearSelection();
                    grid.Rows[idx + 1].Cells[col].Selected = true;
                    dgvOutputOperations.FirstDisplayedScrollingRowIndex = idx + 1;
                    foreach (DataGridViewRow arow in dgvOutputOperations.Rows) {
                        arow.Cells[1].Value = counter;
                        counter++;
                    }


                }

            } catch { }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                string operationValue = GetAllVariables();
                //txtOutput.Text = txtOutput.Text + "\r\n\r\n" + counter + "- " + operationValue;
                int rowIndex = GetRowIndexFromCurrentlySelectedKey(currentlySelectedKey);

                Regex regexForQuotationEscape = new Regex("[A-Za-z0-9](\")[A-Za-z0-9]");
                dgvOutputOperations.Rows[rowIndex].Cells["Operations"].Value =
                    regexForQuotationEscape.Match(operationValue).Success ? operationValue : regexForQuotationEscape.Replace(operationValue, "$1\\\"$3");
                dgvOutputOperations.Rows[rowIndex].Cells["Comment"].Value = txtFunctionComment.Text.Trim();

                ValidateInsertedRow(operationValue, dgvOutputOperations.Rows[rowIndex]);


                dgvOutputOperations.ClearSelection();
                dgvOutputOperations.FirstDisplayedScrollingRowIndex = rowIndex;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private int GetRowIndexFromCurrentlySelectedKey(int currentlySelectedKey) {
            int rowIndex = -1;
            for (int i = 0; i < dgvOutputOperations.Rows.Count; i++) {
                if (string.Equals(dgvOutputOperations.Rows[i].Cells["Key"].Value, currentlySelectedKey)) {
                    return rowIndex = i;
                }
            }
            return rowIndex;
        }

        private void btnImportFileList_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    string exportFilePath = dialog.FileName;
                    ImportFilesListFile(exportFilePath);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ImportFilesListFile(string exportFilePath) {
            if (dgvFilesToImport.Rows.Count > 0) {
                DialogResult dial = FrontendUtils.ShowConformation("Do you want to append the files to the existing list?");
                if (dial == DialogResult.Yes) {
                    ReadFileAndInsertIntoList(exportFilePath, true);
                } else {
                    ReadFileAndInsertIntoList(exportFilePath, false);
                }
            } else {
                ReadFileAndInsertIntoList(exportFilePath, false);
            }
        }

        private void ReadFileAndInsertIntoList(string inputFilePath, bool appendEnabled) {
            string fileRead = FrontendUtils.ReadFile(inputFilePath);
            string[] fileLines = fileRead.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            bool inputcorrupt = false;
            for (int i = 0; i < fileLines.Length; i++) {
                string[] fileLinesSplit = fileLines[i].Split(new char[] { ';' });
                string fileLink = fileLinesSplit[0].Trim(new char[] { '\\', '/' });
                string fileRelPath = fileLinesSplit.Length > 0 ? fileLinesSplit[1].Trim(new char[] { '\\', '/' }) : "";
                if (IsValidToAddFileImport(fileLink, fileRelPath, true)) {
                    int rowIndex = dgvFilesToImport.Rows.Add();
                    dgvFilesToImport.Rows[rowIndex].Cells["fileLink"].Value = fileLink;//relative
                    dgvFilesToImport.Rows[rowIndex].Cells["relativePath"].Value = fileRelPath;//link
                } else {
                    inputcorrupt = true;
                }
            }
            if (inputcorrupt) {
                FrontendUtils.ShowInformation("Not all files were added, input file has errors");
            }
        }

        private void btnAddFileToImport_Click(object sender, EventArgs e) {
            try {
                string fileLink = txtImportFileLink.Text.Trim(new char[] { '\\', '/' });
                string fileRelPath = txtRelativePathToImport.Text.Trim(new char[] { '\\', '/' });
                if (IsValidToAddFileImport(fileLink, fileRelPath, false)) {
                    int rowIndex = dgvFilesToImport.Rows.Add();
                    dgvFilesToImport.Rows[rowIndex].Cells["relativePath"].Value = txtRelativePathToImport.Text;//relative
                    dgvFilesToImport.Rows[rowIndex].Cells["fileLink"].Value = txtImportFileLink.Text;//link 
                    ResetFileImportPart();
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }



        private bool IsValidToAddFileImport(string fileLink, string fileRelPath, bool bulkImport) {
            if (string.IsNullOrEmpty(fileLink)) {
                if (!bulkImport) {
                    FrontendUtils.ShowInformation("[File Link] cannot be empty!");
                }
                return false;
            }

            bool duplicate = false;
            for (int i = 0; i < dgvFilesToImport.Rows.Count && !duplicate; i++) {
                if (string.Equals(dgvFilesToImport.Rows[i].Cells["relativePath"].Value, fileRelPath) &&
                    string.Equals(dgvFilesToImport.Rows[i].Cells["fileLink"].Value, fileLink)) {
                    if (!bulkImport) {
                        FrontendUtils.ShowInformation("File already exists!");
                    }
                    dgvFilesToImport.FirstDisplayedScrollingRowIndex = i;
                    dgvFilesToImport.Rows[i].Selected = true;
                    duplicate = true;
                    return false;
                }
            }
            return true;
        }

        private void btnSaveFileToImport_Click(object sender, EventArgs e) {
            try {
                int rowIndex = dgvFilesToImport.SelectedRows[0].Index;
                dgvFilesToImport.Rows[rowIndex].Cells["relativePath"].Value = txtRelativePathToImport.Text;//relative
                dgvFilesToImport.Rows[rowIndex].Cells["fileLink"].Value = txtImportFileLink.Text;//link
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnDelteFileToImport_Click(object sender, EventArgs e) {
            try {
                if (dgvFilesToImport.SelectedRows.Count > 0) {
                    DialogResult dial = FrontendUtils.ShowConformation("Are you sure you want to delete the file import operation?");

                    if (dial == DialogResult.Yes) {
                        dgvFilesToImport.Rows.RemoveAt(dgvFilesToImport.SelectedRows[0].Index);
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnResetFileToImport_Click(object sender, EventArgs e) {
            try {
                ResetFileImportPart();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ResetFileImportPart() {
            btnAddFileToImport.Enabled = true;
            btnSaveFileToImport.Enabled = false;
            txtImportFileLink.ResetText();
            txtRelativePathToImport.ResetText();
            dgvFilesToImport.ClearSelection();
        }

        private void dgvFilesToImport_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (dgvFilesToImport.SelectedRows.Count > 0) {
                    btnSaveFileToImport.Enabled = true;
                    btnAddFileToImport.Enabled = false;
                    string fileRelPath = dgvFilesToImport.SelectedRows[0].Cells["relativePath"].Value.ToString();
                    string fileLink = dgvFilesToImport.SelectedRows[0].Cells["fileLink"].Value.ToString();
                    txtImportFileLink.Text = fileLink;
                    txtRelativePathToImport.Text = fileRelPath;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnExportFiles_Click(object sender, EventArgs e) {
            try {
                if (dgvFilesToImport.Rows.Count > 0) {
                    SaveFileDialog fileSave = new SaveFileDialog();
                    DialogResult dial = fileSave.ShowDialog();
                    if (dial == DialogResult.OK) {
                        if (!string.IsNullOrEmpty(fileSave.FileName)) {
                            string outputFilePath = fileSave.FileName;
                            ExportFileList(outputFilePath);
                        } else {
                            FrontendUtils.ShowInformation("Filename cannot be empty!");
                        }
                    }
                } else {
                    FrontendUtils.ShowInformation("There are no items in the import list!");
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ExportFileList(string outputFilePath) {
            string fileToExport = string.Empty;
            for (int i = 0; i < dgvFilesToImport.Rows.Count; i++) {
                fileToExport = fileToExport + dgvFilesToImport.Rows[i].Cells["fileLink"].Value.ToString() +
                                    ";" + dgvFilesToImport.Rows[i].Cells["relativePath"].Value.ToString() + "\r\n";
            }
            FrontendUtils.WriteFile(outputFilePath, fileToExport);
        }

        private void exportCustomizationLogToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (dgvOutputOperations.Rows.Count > 0) {
                    SaveFileDialog fileSave = new SaveFileDialog();
                    DialogResult dial = fileSave.ShowDialog();
                    if (dial == DialogResult.OK) {
                        if (!string.IsNullOrEmpty(fileSave.FileName)) {
                            string outputFilePath = fileSave.FileName;
                            ExportOperationsLogFile(outputFilePath);
                        } else {
                            FrontendUtils.ShowInformation("Filename cannot be empty!");
                        }
                    }
                } else {
                    FrontendUtils.ShowInformation("There are no items operations list!");

                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ExportOperationsLogFile(string outputFilePath) {
            string logToExport = string.Empty;
            dgvOutputOperations.ClearSelection();
            DataSet set = new DataSet("Customizations Log Set");

            DataTable table = new DataTable("Checked Operations Log");
            table.Columns.Add("Step");           
            table.Columns.Add("Comment");
            table.Columns.Add("Operation");

            DataTable tableOriginal = new DataTable("Original Operations Log");
            tableOriginal.Columns.Add("Step");           
            tableOriginal.Columns.Add("Comment");
            tableOriginal.Columns.Add("Operation");

            DataTable tableLinkedFiles = new DataTable("Linked File List");
            tableLinkedFiles.Columns.Add("FileLink");
            tableLinkedFiles.Columns.Add("RelativePath");
            

            for (int i = 0; i < dgvOutputOperations.Rows.Count; i++) {
                if ((bool)dgvOutputOperations.Rows[i].Cells["CommentUsage"].Value == true) {
                    if (!string.Equals(dgvOutputOperations.Rows[i].Cells["Comment"].Value ,"")) {
                        table.Rows.Add(new object[] { dgvOutputOperations.Rows[i].Cells["Steps"].Value,                                                 
                                                      dgvOutputOperations.Rows[i].Cells["Comment"].Value,
                                                      dgvOutputOperations.Rows[i].Cells["Operations"].Value}); 
                    }
                }
                tableOriginal.Rows.Add(new object[] { dgvOutputOperations.Rows[i].Cells["Steps"].Value,
                                                      dgvOutputOperations.Rows[i].Cells["Comment"].Value,
                                                      dgvOutputOperations.Rows[i].Cells["Operations"].Value}); 
            }


            for (int j = 0; j < dgvFilesToImport.Rows.Count; j++) {
                tableLinkedFiles.Rows.Add(new object[] {dgvFilesToImport.Rows[j].Cells["fileLink"].Value,
                                                        dgvFilesToImport.Rows[j].Cells["relativePath"].Value});
            }

            set.Tables.Add(tableLinkedFiles);
            set.Tables.Add(table);
            set.Tables.Add(tableOriginal);


            FastExportingMethod.ExportToExcel(set, outputFilePath);


        }
        //string checkedVals = "True";
        bool checkedVals = true;
        private void selectGroupToolStripMenuItem_Click(object sender, EventArgs e) {
            try {

                DataGridViewSelectedRowCollection selectedRows = dgvOutputOperations.SelectedRows;
                for (int i = 0; i < selectedRows.Count; i++) {
                    selectedRows[i].Cells["CommentUsage"].Value = checkedVals;

                }
                checkedVals = !checkedVals;
                //if (string.Equals(checkedVals, "True")) {
                //    checkedVals = "False";
                //} else {
                //    checkedVals = "True";                
                //}
                dgvOutputOperations.ClearSelection();

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void dgvOutputOperations_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            if (e.ColumnIndex == 0) {
                for (int i = 0; i < dgvOutputOperations.Rows.Count; i++) {
                    dgvOutputOperations.Rows[i].Cells[0].Value = dgvColumnHeader.CheckAll;
                }
            }
        }

        private void releasePackageToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                StartReleaseProcess();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }



        private void StartReleaseProcess() {


            SelectPackageNameAndStorageForm selectPackageNameAndStorageForm = new SelectPackageNameAndStorageForm();
            selectPackageNameAndStorageForm.ShowDialog();
               
            if (selectPackageNameAndStorageForm.DialogResult == DialogResult.OK) {
                //     if (!string.IsNullOrEmpty(releaseStorageLocation) && !string.IsNullOrEmpty(releasePackageName)) {
                string stamp = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                stamp = stamp.Replace('/', '-').Replace(" ", "").Replace(":","");
                string releaseStorageLocation = selectPackageNameAndStorageForm.Controls["gbOutputSettings"].Controls["txtOutputPath"].Text;
                releaseStorageLocation = releaseStorageLocation+"/"+stamp+"-Release";
                string releasePackageName = selectPackageNameAndStorageForm.Controls["gbOutputSettings"].Controls["txtPackageName"].Text;
                stamp = DateTime.Now.Ticks.ToString();
                //1
                GeneratePackageJarAndExportCiAndFileList(releaseStorageLocation, releasePackageName, stamp);
                ExportOperationsLogFile(releaseStorageLocation + "/"+stamp+"-Release-CustomizationLog.xls");
                FrontendUtils.ShowInformation("Release Completed!");
                // } 
            }




        }

        private void GeneratePackageJarAndExportCiAndFileList(string storageLocation, string packageName, string stamp) {
            string workingDir = Path.GetTempPath() + "\\Migration";

            #region Write Operation and Installer files to this exec path

            PreparePackageForGeneration();

            #endregion

            #region Export Ci from exec path And Linked Files List
            string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string pathToDotCiFolder = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk";


            string pathToExportDirectory = storageLocation + "\\"+stamp+"-Release-Export";
            if (Directory.Exists(pathToExportDirectory)) {
                Directory.Delete(pathToExportDirectory,true);
                Directory.CreateDirectory(pathToExportDirectory);
            }
            FrontendUtils.CopyDirectory(pathToDotCiFolder, pathToExportDirectory);
           
            File.Delete(pathToExportDirectory + @"\.ci\package\murex\Migration\main.groovy");
            File.Delete(pathToExportDirectory + @"\.ci\package\murex\Migration\installMain.groovy");
            File.Delete(pathToExportDirectory + @"\.ci\ci-main.xml");


            if (dgvFilesToImport.Rows.Count > 0) {
                string outputFileName = pathToExportDirectory + @"\ImportFileList.txt";
                ExportFileList(outputFileName);

            }
            #endregion                   

            #region Copy Migration ready from exec path to temp dir And get linked files

            if (Directory.Exists(pathToThisExec + @"\MIGRATION")) {
                if (Directory.Exists(workingDir)) {
                    Directory.Delete(workingDir, true);
                }

                FrontendUtils.CopyDirectory(pathToThisExec + @"\MIGRATION", workingDir + @"\MIGRATION");

            }
            string pathToAppDir = workingDir + @"\MIGRATION\FIRSTPACKAGE\trunk\";

            GetLinkedFiles(pathToAppDir);

            #endregion

            #region Create Generation Command and Generate

            string pathToCisPackage = workingDir + @"\MIGRATION\FIRSTPACKAGE\cis-mxpack-1.0-full.jar";
            string pathToConfigFile = workingDir + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\ci.xml";
            string pathTomainConfigFile = workingDir + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\ci-main.xml";

            string configFileText = File.ReadAllText(pathTomainConfigFile).Replace("Migration-Package", stamp+"-"+packageName );
            FrontendUtils.WriteFile(pathToConfigFile, configFileText);




            string pathToTarget = storageLocation;
            string pathToSource = workingDir + @"\MIGRATION\FIRSTPACKAGE\trunk";

            string packageId = "MigrationPackage";

            string commandToExecute = "java -jar \"" + pathToCisPackage + "\"" +
                                      " " +
                                      "-configfile:\"" + pathToConfigFile + "\"" +
                                      " " +
                                      "-source:\"" + pathToSource + "\"" +
                                      " " +
                                      "-target:\"" + pathToTarget + "\"" +
                                      " " +
                                      "-packageid:" + packageId;


            FrontendUtils.WriteFile(workingDir + @"\compile.cmd", commandToExecute);
            FrontendUtils.ExecuteCommandSync(workingDir + @"\compile.cmd");


            #endregion

        }

        private void dgvOutputOperations_SelectionChanged(object sender, EventArgs e) {
            try {
                if (dgvOutputOperations.SelectedRows.Count > 0) {
                    DataGridViewRow row = dgvOutputOperations.SelectedRows[0];

                    if (dgvOutputOperations.SelectedRows[0].Cells["Operations"].Value != null) {
                        currentlySelectedKey = Convert.ToInt32(dgvOutputOperations.SelectedRows[0].Cells["Key"].Value);

                        //"AppendTextToFile( \"\" ,\"\" )"
                        CustomizationFunction customizationFunction = GuessCustomizationFunctionFromGrid(dgvOutputOperations.SelectedRows[0].Cells["Operations"].Value);
                        //add comment to ui
                        txtFunctionComment.Text = row.Cells["Comment"].Value.ToString();

                        btnSave.Enabled = true;
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void dgvOutputOperations_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {
           
        }

        private void dgvOutputOperations_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e) {

        }


    }
}