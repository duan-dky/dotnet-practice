﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace neverMiss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        { 
            e.Cancel = true;    //取消窗体关闭事件
            this.WindowState = FormWindowState.Minimized;   //最小化窗口
            this.ShowInTaskbar = false;		//在Windows任务栏中不显示窗体
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String url=Application.StartupPath.ToString() + "help.chm";
            Help.ShowHelp(null, url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemindForm remindForm = new RemindForm(this);
            remindForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm(this);
            historyForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(this);
            settingForm.Show();
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }

            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;

                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否最小化到系统托盘", "提示", MessageBoxButtons.YesNoCancel,
           MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {

            }
            if(dr==DialogResult.No)
            {
                this.Close();
                System.Environment.Exit(0);
            }
        }
    }
}
