using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Diagnostics;
namespace neverMiss
{
    public partial class SettingForm : Form
    {
        private Form1 returnForm = null;//声明一个returnForm变量，用来保存被传递进来的Form1
        private PictureBox pictureBox1;
        public SettingForm(Form1 form1)
        {
            InitializeComponent();
            this.returnForm = form1;
        }
        public SettingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            returnForm.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 创建快捷方式
                string shortcutPath = "C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\nerverMiss.lnk";
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

                // 设置快捷方式属性
                shortcut.Description = "NeverMiss";
                shortcut.TargetPath = @"C:\Program Files\NeverMiss";
                shortcut.WorkingDirectory = @"C:\Program Files\NeverMiss";
                shortcut.IconLocation = @"C:\Program Files\NeverMiss\neverMiss.ico";

                // 保存快捷方式
                shortcut.Save();
                MessageBox.Show("设置成功");
            }
            catch (UnauthorizedAccessException)
            {
                try
                {
                    // 创建Process对象
                    Process process = new Process();

                    // 设置要执行的程序和命令行参数
                    process.StartInfo.FileName = Directory.GetCurrentDirectory()+"\\neverMiss.exe";
                    process.StartInfo.Arguments = "-arg1 -arg2";

                    // 设置添加UAC权限
                    process.StartInfo.UseShellExecute = true;
                    process.StartInfo.Verb = "runas";
                    // 启动程序
                    process.Start();

                    // 等待程序执行完毕
                    process.WaitForExit();
                }
                catch (Win32Exception)
                {
                    MessageBox.Show("操作被用户阻止！", "错误", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String url = Directory.GetCurrentDirectory() + "\\help.chm";
            Help.ShowHelp(null, url);
        }
    }
    }
