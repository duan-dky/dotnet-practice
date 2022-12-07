using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace neverMiss
{
    public class timer
    {
        private string path = "";

        private void DisplayToast(string id,string msg,string important,string keeping,string path)
        {
            string is_important = "";
            if (important == "1")
            {
                is_important = "重要";
            }
            if (important == "0")
            {
                is_important = "";
            }
            // Construct the content and show the toast!
            new ToastContentBuilder()


    // Profile (app logo override) image
    .AddAppLogoOverride(new Uri(Directory.GetCurrentDirectory() + "\\neverMiss.png"), ToastGenericAppLogoCrop.Circle)
    .AddText(is_important)
    .AddText(msg)
    // Buttons
    .AddButton(new ToastButton()
        .SetContent("我知道了")
        .AddArgument("now")
        .SetBackgroundActivation())
    .AddButton(new ToastButton()
        .SetContent("稍等一下")
        .AddArgument("later")
        .SetBackgroundActivation())
    .AddButton(new ToastButton()
        .SetContent("我已完成")
        .AddArgument("finish")
        .SetBackgroundActivation())
    .Show(toast =>
    {
        toast.ExpirationTime = DateTime.Now.AddSeconds(int.Parse(keeping)*60);
    });
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                CheckInput(id,toastArgs.Argument.ToString(),path);
            };
        }
        private void CheckInput(string id,string toastArgs,string path)
        {
            string connectionString = "Data Source=demo.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            if (toastArgs == "now")
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = path;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();
                    process.WaitForExit();
                }
                catch (InvalidOperationException)
                {

                }
            }
            else if (toastArgs == "later")
            {
                // 使用 SQLiteCommand 执行 SQL 语句
                string sql = "UPDATE reminder SET count = count -1 WHERE id = " + id + ";";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                // 关闭数据库连接
                connection.Close();
            }
            else
            {
                // 使用 SQLiteCommand 执行 SQL 语句
                string sql = "UPDATE reminder SET finish = 1 WHERE id = " + id + ";";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();

                // 关闭数据库连接
                connection.Close();
            }
        }
        public int getSum()
        {
            string connectionString = "Data Source=demo.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                sum = 0;
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
                connection.Close();
            }
            return sum;
        }
        private static int sum=0;
        public void QueryTimer(string time, reminder[]reminder)
        {
            string connectionString = "Data Source=demo.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM reminder";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = int.Parse(reader.GetValue(0).ToString());
                            reminder[id-1].datetime = reader.GetValue(2).ToString();
                            if (reminder[id-1].datetime ==time)
                            {
                                if (reader.GetValue(8).ToString() == "0")
                                {
                                    if (int.Parse(reader.GetValue(4).ToString()) >= 0)
                                    {
                                        reminder[id-1].count = int.Parse(reader.GetValue(4).ToString());
                                        reminder[id-1].datetime = reader.GetValue(2).ToString();
                                        DisplayToast(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(6).ToString(), reader.GetValue(5).ToString(), reader.GetValue(7).ToString());
                                        DateTime dateTime = Convert.ToDateTime(reminder[id-1].datetime);
                                        TimeSpan timeSpan = new TimeSpan(0, int.Parse(reader.GetValue(3).ToString()), 0);
                                        dateTime.Add(timeSpan);
                                    }
                                }
                            }
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
