using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Tamir.SharpSsh;
using System.Text.RegularExpressions;

namespace XmlParsersAndUi.Forms {
    public partial class RemoteServer : Form {
        public RemoteServer() {
            InitializeComponent();
        }

        SshStream ssh;


        private void btnTest_Click(object sender, EventArgs e) {
            try {
                ssh = new SshStream("dell036srv", "autoengine", "");
                //Set the end of response matcher character
                ssh.Prompt = "$";
                //Remove terminal emulation characters
                ssh.RemoveTerminalEmulationCharacters = true;
                //Writing to the SSH channel
                ssh.Write("cd /dell036srv3/apps/qa27144_TPK0001018_6297137");
                //Reading from the SSH channel
                string response = ssh.ReadResponse();
                ssh.Write("ll -ltr *all*");
                //Reading from the SSH channel
                response = ssh.ReadResponse();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
        
        private string ExecuteCommandReturnResult(string commandText) {
            //Writing to the SSH channel
            ssh.Write(commandText);
            //Reading from the SSH channel           
            return ssh.ReadResponse();
        }

        private void btnInit_Click(object sender, EventArgs e) {
            try {
                SshStream ssh = new SshStream(txtHost.Text, "autoengine", "");
                //Set the end of response matcher character
                ssh.Prompt = "$";
                //Remove terminal emulation characters
                ssh.RemoveTerminalEmulationCharacters = true;
                //Writing to the SSH channel
                ssh.Write("cd " + txtAppdir.Text);
                //Reading from the SSH channel
                string response = ssh.ReadResponse();
                ssh.Write("cd " + txtAppdir.Text);
                response = ssh.ReadResponse();
                //    ssh.Write("ll -ltr *all*");
                //    //Reading from the SSH channel
                //    response = ssh.ReadResponse();
                //
                //dell036srv autoengine /dell036srv3/apps/qa27144_TPK0001018_6297137/
                if (response.Contains(txtHost.Text + " autoengine " + txtAppdir.Text)) {
                    lblConnected.BackColor = Color.LightGreen;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnLauncAll_Click(object sender, EventArgs e) {
            try {
                ExecuteCommandReturnResult("launchAllServices.sh");
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
    }
}
