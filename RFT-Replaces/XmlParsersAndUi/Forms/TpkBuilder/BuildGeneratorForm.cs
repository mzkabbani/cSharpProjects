/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/9/2012
 * Time: 3:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace XmlParsersAndUi.Forms.TpkBuilder
{
	/// <summary>
	/// Description of BuildGeneratorForm.
	/// </summary>
	public partial class BuildGeneratorForm : Form
	{
		public BuildGeneratorForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
	
		
		void BtnAddTaskClick(object sender, EventArgs e)
		{
			TaskAdditionForm form = new TaskAdditionForm();
			form.ShowDialog();
		}
		
		void LvAvailableTasksSelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvAvailableTasks.SelectedItems.Count >0) {
				if (lvAvailableTasks.SelectedItems[0].Tag != null) {
					wbTaskDetails.Navigate(lvAvailableTasks.SelectedItems[0].Tag.ToString());
				}
			}
		}
		
		void BuildGeneratorFormLoad(object sender, EventArgs e)
		{
			
		}
	}
}
