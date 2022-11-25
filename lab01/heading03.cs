using System;
using System.Threading.Tasks.Dataflow;
using System.Xml;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int i=1;
            while(true)
            {
                i++;
                if (i % 2 == 1 && i % 3 == 1 && i % 4 == 1)
                {
                    break;
                }
            }
            Console.WriteLine("这篮鸡蛋至少有" + i + "个");
        }
    }
}
