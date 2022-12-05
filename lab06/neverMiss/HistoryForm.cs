using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace neverMiss
{
    public partial class HistoryForm : Form
    {
        private Form1 returnForm = null;//声明一个returnForm变量，用来保存被传递进来的Form1
        public HistoryForm(Form1 f)
        {
            InitializeComponent();
            this.returnForm = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            returnForm.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
