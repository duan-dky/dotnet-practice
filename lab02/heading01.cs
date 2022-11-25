using System;
using System.Security;
using System.Threading.Tasks.Dataflow;
using System.Xml;

namespace HelloWorld
{
    abstract class Adult
    {
        private double height;
        private double weight;
        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public double CalculateBMI()

        {
            return weight/((height/100.0)* (height / 100.0));
        }
        public abstract string Conclusion();
    }
    class Man : Adult
    {
        public override string Conclusion()
        {
            double cal = CalculateBMI();
            if (cal < 20)
            {
                return "过轻";
            }
            else if (cal>=20&&cal<25)
            {
                return "适中";
            }
            else if (cal >= 25 && cal < 30)
            {
                return "过重";
            }
            else if (cal >= 30 && cal < 35)
            {
                return "肥胖";
            }
            else
            {
                return "非常肥胖";
            }
        }
    }
    class Woman : Adult
    {
        public override string Conclusion()
        {
            double cal = CalculateBMI();
            if (cal < 19)
            {
                return "过轻";
            }
            else if (cal >= 19 && cal < 24)
            {
                return "适中";
            }
            else if (cal >= 24 && cal < 29)
            {
                return "过重";
            }
            else if (cal >= 29 && cal < 34)
            {
                return "肥胖";
            }
            else
            {
                return "非常肥胖";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double height, weight;
            Console.Write("请输入您的性别 (男/女)：");
            string sex = Console.ReadLine();
            while (sex != "男" && sex != "女")
            {
                Console.WriteLine("输入错误，请重新输入!");
                Console.Write("请输入您的性别 (男/女)：");
                sex = Console.ReadLine();
            }
            Console.Write("请输入您的身高(cm)：");
            height = Double.Parse(Console.ReadLine());
            Console.Write("请输入您的体重(kg)：");
            weight = Double.Parse(Console.ReadLine());
            Console.Write("您的体重");
            if (sex == "男")
            {
                Man m = new Man();
                m.Height = height;
                m.Weight = weight;
                Console.WriteLine(m.Conclusion()+"!");
            }
            else
            {
                Woman w = new Woman();
                w.Height = height;
                w.Weight = weight;
                Console.WriteLine(w.Conclusion() + "!");
            }
        }
    }
}
