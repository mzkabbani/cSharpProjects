﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EnvironmentBuilder {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            for (int i = 0; i < 20; i++) {
                lblSpeed.Text = "Speed : " + DateTime.Now.Ticks;
                i = 2;
                Form2 form = new Form2();
                form.Show();
            }
        }
    }
}