using System;
using System.Security;
using System.Threading.Tasks.Dataflow;
using System.Xml;

namespace HelloWorld
{
    interface IShape
    {
        public int initialize(double line);
        public double getPerimeter();
        public double getArea();
    }
    interface IDisplayresult
    {
        public void Display();
    }
    class Square:IShape,IDisplayresult
    {
        private double line;
        public int initialize(double line)
        {
            this.line = line;
            return 0;
        }
        public double getPerimeter()
        {
            return line * 4;
        }
        public double getArea()
        {
            return line * line;
        }
        public void Display()
        {
            Console.WriteLine("正方形周长为" + getPerimeter() + "，面积为" + getArea());
        }
    }
    class Circle
    {
        private double radius;
        private const double PI = 3.1415926;
        public int initialize(double radius)
        {
            this.radius = radius;
            return 0;
        }
        public double getPerimeter()
        {
            return radius * 2 * PI;
        }
        public double getArea()
        {
            return radius * radius * PI;
        }
        public void Display()
        {
            Console.WriteLine("圆的周长为" + getPerimeter() + "，面积为" + getArea());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请选择：\n1.正方形\n2.圆形");
            string num = Console.ReadLine();
            while (num != "1"&&num!="2")
            {
                Console.WriteLine("输入错误，请重新输入！");
                Console.WriteLine("请选择：\n1.正方形\n2.圆形");
                num = Console.ReadLine();
            }
            if (num == "1")
            {
                Square s = new Square();
                Console.Write("请输入正方形的边长:");
                s.initialize(Double.Parse(Console.ReadLine()));
                s.Display();
            }
            else
            {
                Circle c = new Circle();
                Console.Write("请输入圆的半径:");
                c.initialize(Double.Parse(Console.ReadLine()));
                c.Display();
            }
        }
    }
}