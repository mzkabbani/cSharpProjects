using System.Windows.Forms;
/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 11/8/2012
 * Time: 12:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Automation.Common.Controls
{
	partial class AutomationFileBrowserTextBox
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// AutomationFileBrowserTextBox
			// 
		//	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "AutomationFileBrowserTextBox";
			this.AllowDrop = true;
			this.DragEnter += AutomationFileBrowserTextBox_DragEnter;
    		this.DragDrop += AutomationFileBrowserTextBox_DragDrop;
		}
		
		 
        }
		
	}

