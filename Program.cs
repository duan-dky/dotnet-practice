using System;
namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r=new Random();
            Console.WriteLine(r.NextDouble());
            DateTime d=DateTime.Now;
            Console.WriteLine(d);
            double @double = 3141592.6;
            string str=@double.ToString("(###) #-###");
            Console.WriteLine(str);
            int k=0;
            do{
                k++;
            }while(k<10);
            Console.WriteLine(k);
            String a="54",b="54",c="54";
            if(Convert.ToDouble(a)+Convert.ToDouble(b)>Convert.ToDouble(c)){
                if(Convert.ToDouble(a)+Convert.ToDouble(c)>Convert.ToDouble(b)){
                    if(Convert.ToDouble(b)+Convert.ToDouble(c)>Convert.ToDouble(a)){
                        double p=(Convert.ToDouble(a)+Convert.ToDouble(b)+Convert.ToDouble(c))/2;
                        double s=System.Math.Sqrt(p*(p-Convert.ToDouble(a))*(p-Convert.ToDouble(b))*(p-Convert.ToDouble(c)));
                        Console.WriteLine(s);           
                    }
                    else{
                        Console.WriteLine("三角形不存在");
                    }
                }
                else{
                    Console.WriteLine("三角形不存在");
                }
            }
            else{
                Console.WriteLine("三角形不存在");
            }
            int []array=new int[6];
            int s1=1,sum=0;
            for(int i=1;i<=3;i++){
                s1=1;
                for(int j=1;j<=i;j++){
                    s1=j*s1;
                }
                sum=sum+s1;
            }
            Console.WriteLine(sum);
        }
    }
}