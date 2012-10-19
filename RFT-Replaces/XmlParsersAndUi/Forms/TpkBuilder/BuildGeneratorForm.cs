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
using Automation.Common.Utils;

namespace XmlParsersAndUi.Forms.TpkBuilder {
    /// <summary>
    /// Description of BuildGeneratorForm.
    /// </summary>
    public partial class BuildGeneratorForm : Form {

        #region Variables
        TpkBuildTask currentlySelectedTask = null;
        List<string> buildTasks = new List<string>();
        string buildInitialText = "<project default=\"run\">\r\n\t<target name=\"run\">\r\n\t</target>\r\n</project>";

        #endregion

        public BuildGeneratorForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        void BtnAddTaskClick(object sender, EventArgs e) {
            buildInitialText = "<project default=\"run\">\r\n\t<target name=\"run\">\r\n\t</target>\r\n</project>";
            
   if (string.IsNullOrEmpty(txtEditorBText.Text)) {
                txtEditorBText.Text = buildInitialText;
            }
            TaskAdditionForm form = new TaskAdditionForm(currentlySelectedTask);
            DialogResult dial =  form.ShowDialog();
            if (dial == DialogResult.OK) {
                //Add results to output controls
                string completedTask = form.createdFinalBuildTask;
                buildTasks.Add(completedTask);
                dgvBuildTasks.Rows.Add(dgvBuildTasks.Rows.Count+1,completedTask,dgvBuildTasks.Rows.Count+1);

                tvBuildSequence.Nodes.Add((dgvBuildTasks.Rows.Count+1).ToString(),completedTask);

//                for (int i = 0; i < buildTasks.Count; i++) {
//                    buildInitialText = buildInitialText.Replace("</target>",buildTasks[i]+"\r\n</target>");
//                    dgvBuildTasks.Rows.Add(dgvBuildTasks.Rows.Count+1,buildTasks[i]);
//                }
//

               dgvBuildTasks.ClearSelection();

               txtEditorBText.Text = txtEditorBText.Text.Replace("</target>",completedTask+"\r\n</target>");;
               lvAvailableTasks.Items[0].Selected = true;
            }
        }

        void LvAvailableTasksSelectedIndexChanged(object sender, EventArgs e) {
            if (lvAvailableTasks.SelectedItems.Count >0) {

                TpkBuildTask selectedBuildTask =  lvAvailableTasks.SelectedItems[0].Tag as TpkBuildTask ;

                if (selectedBuildTask != null) {
                    currentlySelectedTask = selectedBuildTask;
                    SetPopularity(4);
                    wbTaskDetails.Navigate(currentlySelectedTask.DetailsLink);
                }
            }
        }

        void SetPopularity(int popularity) {
            srcTaskRating.m_hoverStar = 0;
            srcTaskRating.m_selectedStar = 0;
            srcTaskRating.Invalidate();
            srcTaskRating.m_hoverStar = popularity;
            srcTaskRating.m_selectedStar = popularity;
            srcTaskRating.m_hovering = true;
            srcTaskRating.Invalidate();

        }

        void BuildGeneratorFormLoad(object sender, EventArgs e) {
            try {

                txtEditorBText.SetHighlighting("XML");

                //FillAvailableTasks();
                TpkBuildTask selectedBuildTask = new TpkBuildTask(0,"automation.comparisonguixml"
                        ,"http://globalqa/qa/infrastructure/doc/runtime/v2.3/AutoAntTasks/AutoAntCompareTableGeneric.html"
                        ,1,8,DateTime.Now,9,DateTime.Now.AddDays(3));

                selectedBuildTask.TaskProperties.Add(new BuildTaskProperty("ReachedDocument","${datastore}.screen.reached.xml",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ReachedGimDocument","",1, true,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ExpectedDocument","",1, true,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add(new BuildTaskProperty("ExpectedGimDocument","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ReachedGimFile","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ExpectedFile","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("ExpectedGimFile","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("Customs","",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("Fast","False",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add( new BuildTaskProperty("doCompare","True",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add(new BuildTaskProperty("doColor","True",1, false,8,DateTime.Now));
                selectedBuildTask.TaskProperties.Add(new BuildTaskProperty(0,"name","",2,true,"configFileTemplate",1,8,DateTime.Now,8,DateTime.Now));

                ListViewItem item = lvAvailableTasks.Items.Add(selectedBuildTask.Name);
                item.Tag = selectedBuildTask;

            } catch (Exception ex) {
                CommonUtils.ShowError(ex.Message,ex);
            }
        }
    }
}
