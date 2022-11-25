using System.Data;
using System.Data.Common;
using System.Text;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private string isSatisfied = "";
        private string job = "";
        private string number = "";
        private string t_feedback = "";
        private string s_feedback = "";
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            System.Environment.Exit(0);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            job = comboBox1.SelectedItem.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Enabled = false;
                isSatisfied = "��";
            }
            else
            {
                checkBox2.Enabled = true;
                isSatisfied = "��";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Enabled = false;
                isSatisfied = "��";
            }
            else
            {
                checkBox1.Enabled = true;
                isSatisfied = "��";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.AutoSize = true;
            s_feedback=textBox2.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_feedback = listBox1.SelectedItem.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                number = "0-5��";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                number = "6-50��";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                number = "50-100��";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                number = "100-500��";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                number = "500������";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (job == "" || isSatisfied == "" || number == "" || t_feedback == "" || s_feedback == "")
            {
                MessageBox.Show("����д������Ϣ��", "������Ϣ", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr=MessageBox.Show("��ȷ���ύ��", "��ʾ", MessageBoxButtons.OKCancel,
            MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                if (dr==DialogResult.OK)
                {
                    string[] str = new string[5] {"ְҵ","�����Ƿ�����","��֯����","��������","��������" };
                    string newFileName = "info.dat";
                    FileStream fileStream = File.Create(newFileName);
                    string s= str[0] + ": " + job + "\n" + str[1] +": " + isSatisfied + "\n" +  str[2] + ": " + number + "\n" +  str[3] + ": " + t_feedback + "\n" + str[4] + ": " + s_feedback + "\n";
                    byte[] bytes = new UTF8Encoding(true).GetBytes(s);
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Close();
                    MessageBox.Show("�ύ�ɹ�,��л���ķ������ټ���", "��ʾ", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                    System.Environment.Exit(0);
                }
            }
        }
    }
}