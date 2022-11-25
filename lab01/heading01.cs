using System;
using System.Threading.Tasks.Dataflow;
using System.Xml;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ofValue = new int[3] {-1,-1,-1};
            for (; ; )
            {
                Console.WriteLine("请输入边长：");
                string str="";
                for (int i = 0; i < 3; i++)
                {
                    str= Console.ReadLine();
                    if (str != "")
                        ofValue[i] = int.Parse(str);
                }
                if ((ofValue[0] <= 0 || ofValue[1] <= 0)&&str=="")
                {
                    Console.WriteLine("不是长方形，请重新输入！");
                }
                else if (str!=""&&(ofValue[2] <= 0||ofValue[0] + ofValue[1] - ofValue[2]<1e-6|| ofValue[0] + ofValue[2] - ofValue[1] < 1e-6|| ofValue[2] + ofValue[1] - ofValue[0] < 1e-6))
                {
                    Console.WriteLine("不是三角形，请重新输入！");
                }
                else
                {
                    break;
                }
            }
            if (ofValue[2] == -1)
            {
                Console.WriteLine("长方形周长为：" + (ofValue[0] + ofValue[1]) * 2 + "，面积为：" + ofValue[0] * ofValue[1]);
            }
            else
            {
                double p = (ofValue[0] + ofValue[1] + ofValue[2]) / 2;
                Console.WriteLine("三角形周长为：" + (ofValue[0] + ofValue[1] + ofValue[2]) + "，面积为：" + Math.Sqrt(p * (p - ofValue[0]) * (p - ofValue[1]) * (p - ofValue[2])));
            }
        }
    }
} 
