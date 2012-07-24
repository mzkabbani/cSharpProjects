using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Tutorial {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            // 1 - read the input file
            // 2 - REGEX
            //        1- seach
            //        2 - replace

            string replacement;
            string replaceFile;
            StreamReader reader = new StreamReader(txtFileName.Text);
            try {
                string fileRead = reader.ReadToEnd();


                Regex regex = new Regex(".*");

                Match match = regex.Match(fileRead);

                replacement = txtdbName.Text;


                replaceFile = regex.Replace(fileRead, replacement);
            } finally {
                reader.Close();
            }
            
           

           

           

            StreamWriter writer = new StreamWriter(txtFileName.Text);
            writer.Write(replaceFile);
            writer.Close();
            
        }
    }
}
