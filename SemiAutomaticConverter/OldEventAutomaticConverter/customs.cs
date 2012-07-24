using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OldEventAutomaticConverter {
    public partial class customs : Form {
        public customs() {
            InitializeComponent();
        }
        List<string> paths = new List<string>();
        private void btnAdd_Click(object sender, EventArgs e) {
            try {
                if (chkCol.Checked) {
                    txtinput.Text = Regex.Replace(txtinput.Text, "Line\\[\\d+\\]","Line");
                }
                Regex reg = new Regex("<ReachedPath>.*[\\r\\n]*.*</ReachedPath>");
              MatchCollection Mc =  Regex.Matches(txtinput.Text, "<ReachedPath>.*[\\r\\n]*.*</ReachedPath>");

              for (int i = 0; i < Mc.Count; i++) {
                  if(!paths.Contains(Mc[i].Value)){
                      paths.Add(Mc[i].Value);
                  }
              }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnex_Click(object sender, EventArgs e) {
            StreamWriter writer = new StreamWriter("G:\\out.txt");
            try {
                for (int i = 0; i < paths.Count; i++) {

                    writer.WriteLine(paths[i]);

                }
            } finally {

                if (writer!=null) {
                    writer.Close(); 
                }
            }
            
        }

        private void btnclear_Click(object sender, EventArgs e) {
            paths = new List<string>();
        }
    }
}
