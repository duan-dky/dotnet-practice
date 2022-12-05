﻿using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
namespace neverMiss
{
    public partial class RemindForm : Form
    {
        private Form1 returnForm = null;//声明一个returnForm变量，用来保存被传递进来的Form1
        public RemindForm(Form1 form1)
        {
            InitializeComponent();
            returnForm = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                this.Close();
            returnForm.Visible = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private string path = "";
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // 设置打开文件对话框的初始目录
            openFileDialog1.InitialDirectory = "c:\\";

            // 设置打开文件对话框的标题
            openFileDialog1.Title = "选择文件";

            // 设置打开文件对话框可以选择的文件类型
            openFileDialog1.Filter = "可执行文件(*.exe)|*.exe";

            // 设置打开文件对话框默认选择的文件类型
            openFileDialog1.FilterIndex = 2;

            // 设置打开文件对话框是否记忆上次打开的目录
            openFileDialog1.RestoreDirectory = true;

            // 打开对话框，并判断用户是否选择了文件
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 获取用户选择的文件路径
                path = openFileDialog1.FileName;
                // 在这里添加代码，打开文件并进行处理
            }
        }
        private void DisplayToast()
        {
            //richTextBox1.Text = Directory.GetCurrentDirectory();
            // Construct the content and show the toast!
            new ToastContentBuilder()


    // Profile (app logo override) image
    .AddAppLogoOverride(new Uri(Directory.GetCurrentDirectory() + "\\neverMiss.png"), ToastGenericAppLogoCrop.Circle)
    .AddText("做.net作业")
    // Buttons
    .AddButton(new ToastButton()
        .SetContent("我知道了")
        .AddArgument("now")
        .SetBackgroundActivation())

    .AddButton(new ToastButton()
        .SetContent("稍等一下")
        .AddArgument("later")
        .SetBackgroundActivation())
    .Show(toast =>
    {
        toast.ExpirationTime = DateTime.Now.AddSeconds(30);
    });
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                CheckInput(toastArgs.Argument.ToString());
            };
        }
        private void CheckInput(string toastArgs)
        {
            setText(toastArgs);
        }
        private delegate void richTextBox1CallBack();
        private void setText(string str)
        {
            richTextBox1CallBack callback = delegate ()//使用委托 

            {

                richTextBox1.Text=str;

            };

            richTextBox1.Invoke(callback);
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RemindForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int isImportant = 0;
            if (radioButton1.Checked)
            {
                isImportant = 1;
            }
            if (radioButton2.Checked)
            {
                isImportant = 0;
            }
            string connectionString = "Data Source=demo.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // 执行一个查询
                int sum = 0;
                string count = "select count(*) from reminder";
                using (SQLiteCommand command = new SQLiteCommand(count, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sum = int.Parse(reader.GetValue(0).ToString());
                        }
                    }
                }
                string insert = "insert into reminder values (@id,@message,@datetime,@interval,@count,@keeping,@important,@path)";
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = insert;
                    cmd.Parameters.AddWithValue("@id", sum+1);
                    cmd.Parameters.AddWithValue("@message", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@datetime", dateTimePicker1.Value.ToString());
                    cmd.Parameters.AddWithValue("@interval", int.Parse(textBox2.Text));
                    cmd.Parameters.AddWithValue("@count", int.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@keeping", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@important", isImportant);
                    cmd.Parameters.AddWithValue("@path", path);
                    cmd.ExecuteNonQuery();
                }
                string query = "SELECT * FROM reminder";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for(int i = 0; i < 8; i++)
                            {
                                richTextBox1.Text = richTextBox1.Text + reader.GetValue(i) + " ";
                            }
                        }
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
