using System;
using System.Threading.Tasks.Dataflow;
using System.Xml;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            for(; ; )
            {
                Console.Write("请输入月份：");
                int month = int.Parse(Console.ReadLine());
                switch (month)
                {
                    case 12:
                    case 1:
                    case 2:
                        Console.WriteLine("现在是冬季！");
                        break;
                    case 3:
                    case 4:
                    case 5:
                        Console.WriteLine("现在是春季！");
                        break;
                    case 6:
                    case 7:
                    case 8:
                        Console.WriteLine("现在是夏季！");
                        break;
                    case 9:
                    case 10:
                    case 11:
                        Console.WriteLine("现在是秋季！");
                        break;
                    default:
                        Console.WriteLine("非法输入，请重新输入！");
                        break;
                }
                Console.WriteLine("是否继续（y/n）");
                string str = Console.ReadLine();
                if (str == "n" || str == "N")
                {
                    Console.WriteLine("程序即将退出!");
                    break;
                }
            }
        }
    }
}
