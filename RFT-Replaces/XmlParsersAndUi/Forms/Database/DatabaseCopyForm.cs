/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 11/15/2012
 * Time: 3:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using Automation.Common.Forms;
using Manifest.Forms.Database;

namespace XmlParsersAndUi.Forms
{
	/// <summary>
	/// Description of DatabaseCopyForm.
	/// </summary>
	public partial class DatabaseCopyForm : BaseForm
	{
		public DatabaseCopyForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
				
		void DatabaseCopyFormLoad(object sender, EventArgs e){
			base.LoadForm(this);					
		}
		
		void CopyTable(DatabaseTable table ){
		
		}
		
		void BtnStartClick(object sender, EventArgs e){			
			DatabaseTable table = new DatabaseTable();
		}
	}
}
