using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace neverMiss
{
    public partial class SettingForm : Form
    {
        private Form1 returnForm = null;//声明一个returnForm变量，用来保存被传递进来的Form1
        public SettingForm(Form1 form1)
        {
            InitializeComponent();
            this.returnForm = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            returnForm.Visible = true;
        }
    }
}
