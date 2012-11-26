/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/9/2012
 * Time: 3:04 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Automation.Common;
using Automation.Common.Classes;
using Automation.Common.Classes.TPKBuilder;
using Automation.Common.Forms;
using Automation.Common.Utils;
using Manifest.Forms.TpkBuilder;

namespace XmlParsersAndUi.Forms.TpkBuilder {
    /// <summary>
    /// Description of BuildGeneratorForm.
    /// </summary>
    public partial class BuildGeneratorForm : BaseForm {

        #region Variables

        BuildTask currentlySelectedTask = null;
        List<string> buildTasks = new List<string>();
        string buildInitialText = "<project default=\"run\">\r\n\t<target name=\"run\">\r\n\t</target>\r\n</project>";
        List<BuildTargetObject> availableTargets = new List<BuildTargetObject>();
        List<BuildTask> macrodefsUsed = new List<BuildTask>();
        List<BuildTask> AllMacrodefsUsed = new List<BuildTask>();

        #endregion

        #region Constructor
        
        public BuildGeneratorForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        #endregion

        #region Methods

        private void GenerateOutputToUI(List<BuildTargetObject> targets) {
            tvBuildSequence.Nodes.Clear();
            string joinedTargets = string.Empty;
            TreeNode projectNode = tvBuildSequence.Nodes.Add("projectMain","Project Name:Main Default:run");
            foreach (BuildTargetObject target in targets) {
                #region Text
                macrodefsUsed = new List<BuildTask>();
                joinedTargets =  string.Concat(joinedTargets,target.GetTextRepresentation(out macrodefsUsed));
                joinedTargets =joinedTargets + AddUsedMacrodefs(macrodefsUsed,AllMacrodefsUsed);
                foreach (BuildTask macrodef in macrodefsUsed) {
                    if (!AllMacrodefsUsed.Contains(macrodef)) {
                        AllMacrodefsUsed.Add(macrodef);
                    }
                }
                #endregion

                #region TreeView

                BuildSubtreeForTarget(target);

                #endregion
            }
            string xmlRepresentation = CommonUtils.FormatXml("<project name=\"Main\" default=\"run\">"+ joinedTargets+"\r\n</project>");
            txtEditorBText.Text = xmlRepresentation;
            tvBuildSequence.ExpandAll();

            #region datagrid

            #endregion
        }

        private string AddUsedMacrodefs( List<BuildTask> usedMacrodefs,List<BuildTask> macrodefsWithTasks) {
            string textRepresentation = string.Empty;
            foreach (BuildTask usedMacrodef in usedMacrodefs) {
                int index = macrodefsWithTasks.FindIndex(
                delegate(BuildTask macrodef) {
                    return macrodef.Name.Equals(usedMacrodef.Name,StringComparison.Ordinal);
                }
                            );
                if (index != -1) {
                    usedMacrodef.TasksInsideMacrodef = macrodefsWithTasks[index].TasksInsideMacrodef;
                }
                textRepresentation= "\r\n\t"+usedMacrodef.GetMacroDefTextRepresentation();
            }
            return textRepresentation;
        }

        private void BuildSubtreeForTarget(BuildTargetObject target) {
            TreeNode targetNode =  tvBuildSequence.Nodes[0].Nodes.Add(target.Name);
            targetNode.Tag = target;
            foreach (BuildTask buildTask in target.BuildTasks) {
                TreeNode taskNode = targetNode.Nodes.Add(buildTask.GetTextRepresentation());
                taskNode.Tag = buildTask;
            }
        }

        private BuildTask GetCopyOfCurrentTask(BuildTask selectedtask) {
            BuildTask task = new BuildTask(selectedtask.Id,selectedtask.Name,selectedtask.DetailsLink,selectedtask.CategoryId,selectedtask.AddedByUserId,selectedtask.DateAdded,selectedtask.ModifiedByUserId,selectedtask.DateModified);
            task.OwnedByTarget = selectedtask.OwnedByTarget;
            task.SuppliedComment = selectedtask.SuppliedComment;
            foreach (BuildTaskProperty prop in selectedtask.TaskProperties) {
                BuildTaskProperty newProp = new BuildTaskProperty(prop.Id,prop.Name,prop.DefaultValue,prop.PropertyTypeId,prop.IsMandatory,prop.ConfigFileTemplate,prop.BuildTaskId,prop.AddedByUserId,prop.DateAdded,prop.ModifiedByUserId,prop.DateModified);
                newProp.SuppliedConfigFile = prop.SuppliedConfigFile;
                newProp.SuppliedConfigFilePath = prop.SuppliedConfigFilePath;
                newProp.SuppliedValue = prop.SuppliedValue;
                task.TaskProperties.Add(newProp);
            }
            return task;
        }

        private void SetPopularity(int popularity) {
            srcTaskRating.m_hoverStar = 0;
            srcTaskRating.m_selectedStar = 0;
            srcTaskRating.Invalidate();
            srcTaskRating.m_hoverStar = popularity;
            srcTaskRating.m_selectedStar = popularity;
            srcTaskRating.m_hovering = true;
            srcTaskRating.Invalidate();
        }

        #endregion

        #region Events

        private void BtnAddTaskClick(object sender, EventArgs e) {
            buildInitialText = "<project default=\"run\">\r\n\t<target name=\"run\">\r\n\t</target>\r\n</project>";
            if(string.IsNullOrEmpty(txtEditorBText.Text)) {
                txtEditorBText.Text = buildInitialText;
            }
            BuildTask task = GetCopyOfCurrentTask(currentlySelectedTask);
            TaskAdditionForm form = new TaskAdditionForm(task, availableTargets,AllMacrodefsUsed);
            DialogResult dial =  form.ShowDialog();
            if (dial == DialogResult.OK) {
                //Add results to output controls
                string completedTask = form.currentlySelectedTask.GeneratedText;
                string taskComment = form.currentlySelectedTask.SuppliedComment;
                BuildTargetObject ownedByTarget = form.currentlySelectedTask.OwnedByTarget;
                BuildTask ownedByMacrodef = form.currentlySelectedTask.OwnedByMacrodef;
                if (ownedByTarget==null) {
                    //owned by macrodef
                    // ownedByMacrodef.TasksInsideMacrodef.Add(form.currentlySelectedTask);
                    int index = AllMacrodefsUsed.FindIndex(
                    delegate(BuildTask macrodef) {
                        return macrodef.Name.Equals(ownedByMacrodef.Name,StringComparison.Ordinal);
                    }
                                );
                    AllMacrodefsUsed[index].TasksInsideMacrodef.Add(form.currentlySelectedTask);
                } else {
                    //owned by target
                    availableTargets[availableTargets.IndexOf(form.currentlySelectedTask.OwnedByTarget)].AddBuildTask(task);
                }
                GenerateOutputToUI(availableTargets);
                //FIXME: remove this add
                buildTasks.Add(completedTask);
                dgvBuildTasks.Rows.Add(dgvBuildTasks.Rows.Count+1,completedTask,dgvBuildTasks.Rows.Count+1);
                dgvBuildTasks.ClearSelection();
                //reseting values
                currentlySelectedTask.SuppliedComment = string.Empty;
                foreach (BuildTaskProperty prop in currentlySelectedTask.TaskProperties) {
                    prop.SuppliedConfigFile = string.Empty;
                    prop.SuppliedValue = string.Empty;
                    prop.SuppliedConfigFilePath = string.Empty;
                }
                lvAvailableTasks.Items[0].Selected = true;
            }
        }

        private void LvAvailableTasksSelectedIndexChanged(object sender, EventArgs e) {
            if (lvAvailableTasks.SelectedItems.Count >0) {
                BuildTask selectedBuildTask =  lvAvailableTasks.SelectedItems[0].Tag as BuildTask ;
                if (selectedBuildTask != null) {
                    currentlySelectedTask = selectedBuildTask;
                    SetPopularity(4);
                    wbTaskDetails.Navigate(currentlySelectedTask.DetailsLink);
                }
            }
        }

        private void BuildGeneratorFormLoad(object sender, EventArgs e) {
            try {
                base.LoadForm(this);
                txtEditorBText.SetHighlighting("XML");
                //FillAvailableTasks();
                //FIXME: add properties categories and build task categories here
                BuildTask selectedBuildTask = new BuildTask(0,"automation.comparisonguixml"
                        ,"http://globalqa/qa/infrastructure/doc/runtime/v2.3/AutoAntTasks/AutoAntCompareTableGeneric.html"
                        ,(int)ApplicationEnumerations.BuildTaskCat.Default,1,DateTime.Now,4,DateTime.Now.AddDays(3));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ReachedDocument","${datastore}.screen.reached.xml",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ReachedGimDocument","",1, true,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ExpectedDocument","",1, true,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ExpectedGimDocument","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ReachedGimFile","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ExpectedFile","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ExpectedGimFile","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("Customs","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("Fast","False",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("doCompare","True",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("doColor","True",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty(0,"name","",(int)ApplicationEnumerations.PropertyType.ConfigFileNested,true,"configFileTemplate",1,8,DateTime.Now,8,DateTime.Now));
                ListViewItem item = lvAvailableTasks.Items.Add(selectedBuildTask.Name);
                item.Tag = selectedBuildTask;
                TreeNode projectNode =  tvBuildSequence.Nodes.Add("projectDefRun","project default=\"run\"");
                BuildTargetObject buildTarget = new BuildTargetObject("Run",new List<BuildTask>());
                availableTargets.Add(buildTarget);
                TreeNode targetNode =projectNode.Nodes.Add(buildTarget.Name);
                targetNode.Tag = buildTarget;
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

        private void MacrodefToolStripMenuItemClick(object sender, EventArgs e) {
            try {
                //FIXME: pass available task list for name uniqueness
                DefineMacrodefForm form = new DefineMacrodefForm();
                DialogResult dial = form.ShowDialog();
                if (dial == DialogResult.OK) {
                    if (form.GeneratedBuildTask != null) {
                        ListViewItem item = lvAvailableTasks.Items.Add(form.GeneratedBuildTask.Name);
                        item.Tag = form.GeneratedBuildTask;
                        //FIXME: add support for adding macrodefs
                    }
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

        private void TargetToolStripMenuItemClick(object sender, EventArgs e) {
            try {
                AddTargetForm form = new AddTargetForm(availableTargets);
                DialogResult dial = form.ShowDialog();
                if (dial == DialogResult.OK) {
                    BuildTargetObject buildTarget = new BuildTargetObject(form.buildTargetName,new List<BuildTask>());
                    availableTargets.Add(buildTarget);
                }
            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }

        #endregion
    }
}