using System;
using System.Threading.Tasks.Dataflow;
using System.Xml;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("请输入数组中元素的个数:");
            n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int ji=0, ou=0;
            Console.WriteLine("请输入数组中各个元素的值:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if (arr[i] % 2 == 0)
                {
                    ou += arr[i];
                }
                else
                {
                    ji += arr[i];
                }
            }
            Console.WriteLine("数组中奇数之和为" + ji + "，偶数之和为" + ou);
        }
    }
}
