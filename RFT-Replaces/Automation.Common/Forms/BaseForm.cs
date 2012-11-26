/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 11/15/2012
 * Time: 9:50 AM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using Automation.Common.Classes.Monitoring;

namespace Automation.Common.Forms {
    /// <summary>
    /// Description of BaseForm.
    /// </summary>
    public partial class BaseForm : Form {
        
    	public BaseForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        private void InitSecureMonitor(Form form) {
            try {
                if (!string.IsNullOrEmpty(MonitorObject.username)) {
                    MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(form.Name, DateTime.Now));
                }
            } catch (Exception ex) {
				
            }
        }

        protected void LoadForm(Form form) {
            InitSecureMonitor(form);
        }

        void BaseFormLoad(object sender, EventArgs e) {
            LoadForm(this);
        }
    }
}
