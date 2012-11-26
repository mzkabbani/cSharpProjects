/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 11/8/2012
 * Time: 12:51 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Automation.Common.Controls {
    /// <summary>
    /// Description of AutomationFileBrowserTextBox.
    /// </summary>
    public partial class AutomationFileBrowserTextBox : TextBox {
        public AutomationFileBrowserTextBox() {
            InitializeComponent();
        }

        void AutomationFileBrowserTextBox_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        void AutomationFileBrowserTextBox_DragDrop(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                this.Text = filePaths[0];
            }
        }
    }
}
