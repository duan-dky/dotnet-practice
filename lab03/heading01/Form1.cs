namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        double a = 0;
        double b = 0;
        bool c = false;
        string d;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.AutoSize = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "8";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            c = true;
            if (textBox1.Text == "")
            {
                b = 0;
            }
            else
                b = double.Parse(textBox1.Text);
            d = "*";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            c = true;
            if (textBox1.Text == "")
            {
                b = 0;
            }
            else
                b = double.Parse(textBox1.Text);
            d = "-";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            switch (d)
            {
                case "+": a = b + double.Parse(textBox1.Text); break;
                case "-": a = b - double.Parse(textBox1.Text); break;
                case "*": a = b * double.Parse(textBox1.Text); break;
                case "/": a = b / double.Parse(textBox1.Text); break;
                case "^": a = Math.Pow(b,2);break;
                case "sqrt": a = Math.Sqrt(b);break;
                case "log": a = Math.Log10(b); break;
                case "ln": a = Math.Log(b);break;
                default:break;

            }
                textBox1.Text = a + "";
                c = true;
        }

    private void button4_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "9";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "4";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "5";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "6";
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "1";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "2";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "3";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (c == true)
            {
                textBox1.Text = "";
                c = false;
            }
            textBox1.Text += "0";
            if (d == "/")
            {
                textBox1.Clear();
                MessageBox.Show("除数不能为零", "错误提示", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            c = true;
            if (textBox1.Text == "")
            {
                b = 0;
            }
            else
                b = double.Parse(textBox1.Text);
            d = "+";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            c = true;
            if (textBox1.Text == "")
            {
                b = 0;
            }
            else
                b = double.Parse(textBox1.Text);
            d = "/";
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            c = true;
            if (textBox1.Text == "")
            {
                b = 0;
            }
            else
                b = double.Parse(textBox1.Text);
            d = "^";
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            c = true;
            if (textBox1.Text == "")
            {
                b = 0;
            }
            else
                b = double.Parse(textBox1.Text);
            if (b < 0)
            {
                textBox1.Clear();
                MessageBox.Show("无效输入", "错误提示", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
                d = "sqrt";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            c = true;
            if (textBox1.Text == "")
            {
                b = 0;
            }
            else
                b = double.Parse(textBox1.Text);
            if (Math.Abs(b) < 1e-6 || b <= 0)
            {
                textBox1.Clear();
                MessageBox.Show("无效输入", "错误提示", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
                d = "log";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            c = true;
            if (textBox1.Text == "")
            {
                b = 0;
            }
            else
                b = double.Parse(textBox1.Text);
            if (Math.Abs(b)<1e-6||b<=0)
            {
                textBox1.Clear();
                MessageBox.Show("无效输入", "错误提示", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else
                d = "ln";
        }
    }
}