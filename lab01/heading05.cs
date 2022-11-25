using System;
using System.Security;
using System.Threading.Tasks.Dataflow;
using System.Xml;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int x,y;
            Console.WriteLine("请输入数组的行数、列数：");
            string str_temp = Console.ReadLine();
            string[] temp = str_temp.Split(' ');
            x = int.Parse(temp[0]);
            y = int.Parse(temp[1]);
            int[,] arr = new int[x, y];
            Console.WriteLine("请输入数组中各个元素的值：");
            for(int i = 0; i < x; i++)
            {
                    string str = Console.ReadLine();
                    string[] array = str.Split(' ');
                    for(int k = 0; k < array.Length; k++)
                    {
                        arr[i, k] = int.Parse(array[k]);
                    }
            }
            int sum = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    int flag = 0;
                    for(int k = 0; k < y; k++)
                    {
                        if (k!=j&&arr[i, k] >= arr[i, j])
                        {
                            flag = 1;
                            break;
                        }
                    }
                    for(int p = 0; p < x; p++)
                    {
                        if (p!=i&&arr[p, j] <= arr[i, j])
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        Console.WriteLine("该数组的鞍点为" + arr[i, j]);
                        sum++;
                    }
                }
            }
            if (sum == 0)
            {
                Console.WriteLine("该数组没有鞍点！");
            }
        }
    }
}
