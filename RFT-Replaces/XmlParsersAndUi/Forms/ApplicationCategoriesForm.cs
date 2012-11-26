/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/31/2012
 * Time: 4:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Automation.Common.Classes;
using Automation.Common.Utils;
using XmlParsersAndUi.Classes;

namespace Manifest.Forms
{
	/// <summary>
	/// Description of ApplicationCategoriesForm.
	/// </summary>
	public partial class ApplicationCategoriesForm : Form
	{
		#region Variables
		DataTable AllCategories = new DataTable();
		#endregion
		

        
        #region Constructor
        #endregion
        
        #region Methods
        #endregion
        
        #region Events
        #endregion
		
		public ApplicationCategoriesForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		DataTable GetAllAvailableCategories(){
			return Automation.Backend.Classes.ApplicationEnumsBackend.GetAllAppEnums();
		}
		
		void ApplicationCategoriesFormLoad(object sender, EventArgs e)
		{
			try {
				AllCategories = GetAllAvailableCategories();
				
			} catch (Exception ex) {
				CommonUtils.ShowError(ex.Message,ex);
			}
		}
		
		void FillListboxWithRespectiveCategories( object cboSelectedValue){
			AllCategories.DefaultView.Sort = "index ASC";
			AllCategories = AllCategories.DefaultView.ToTable();
			DataRow[] result = AllCategories.Select("type='"+cboSelectedValue+"'");
			foreach (DataRow row in result) {
				ApplicationEnumObject app = new ApplicationEnumObject("","",1,DateTime.Now,"",0);
			}
			
		}
		
		void CboCategoryUsageSelectedIndexChanged(object sender, EventArgs e)
		{
			try {
				FillListboxWithRespectiveCategories(cboCategoryUsage.SelectedValue);
			} catch (Exception ex) {
				CommonUtils.ShowError(ex.Message,ex);
			}
		}
	}
}
