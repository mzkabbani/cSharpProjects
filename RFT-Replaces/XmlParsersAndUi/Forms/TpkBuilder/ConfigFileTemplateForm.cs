/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/17/2012
 * Time: 11:53 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using Automation.Common.Utils;

namespace XmlParsersAndUi.Forms.TpkBuilder
{
	/// <summary>
	/// Description of ConfigFileTemplateForm.
	/// </summary>
	public partial class ConfigFileTemplateForm : Form
	{
		
		#region Variables
			string ConfigFileTemplate = string.Empty;
		#endregion
		
		public ConfigFileTemplateForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public ConfigFileTemplateForm(string configTemplate)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//			
			InitializeComponent();
			ConfigFileTemplate =  configTemplate;
			txtConfigTemplate.Text = ConfigFileTemplate;
			txtConfigFilePath.Text = "${datastore}.configs.config.xml";	
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		
		void BtnProceedConfigFileClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtConfigTemplate.Text) || string.IsNullOrEmpty(txtConfigFilePath.Text)) {
				CommonUtils.ShowInformation("[Config file path] and [template] are mandatory fields",true);
			}
		}
	}
}
