using System;
namespace HelloWorld
{
    class Hello {
        public void hello(){
            Console.WriteLine("hello world");
        }
    }
    class World {
        public void world(){
            Console.WriteLine("world");
        }
    }
    class Test: Hello {
        public void test(){
            Console.WriteLine("test");
            new Hello().hello();
        }
    }
    interface IEquatable<T>
    {
        bool Equals(T obj);
    }
    public class Car: IEquatable<Car>
    {
        public string? Make {
            get;
            set;
        }
        public string? Model {
            get;
            set;
        }
        public string? Year {
            get;
            set;
        }
        public bool Equals(Car? car){
            return (this.Make, this.Model,this.Year) == (car?.Make, car?.Model,car?.Year);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Random r=new Random();
            // Console.WriteLine(r.NextDouble());
            // DateTime d=DateTime.Now;
            // Console.WriteLine(d);
            // double @double = 3141592.6;
            // string str=@double.ToString("(###) #-###");
            // Console.WriteLine(str);
            // int k=0;
            // do{
            //     k++;
            // }while(k<10);
            // Console.WriteLine(k);
            // String a="54",b="54",c="54";
            // if(Convert.ToDouble(a)+Convert.ToDouble(b)>Convert.ToDouble(c)){
            //     if(Convert.ToDouble(a)+Convert.ToDouble(c)>Convert.ToDouble(b)){
            //         if(Convert.ToDouble(b)+Convert.ToDouble(c)>Convert.ToDouble(a)){
            //             double p=(Convert.ToDouble(a)+Convert.ToDouble(b)+Convert.ToDouble(c))/2;
            //             double s=System.Math.Sqrt(p*(p-Convert.ToDouble(a))*(p-Convert.ToDouble(b))*(p-Convert.ToDouble(c)));
            //             Console.WriteLine(s);           
            //         }
            //         else{
            //             Console.WriteLine("三角形不存在");
            //         }
            //     }
            //     else{
            //         Console.WriteLine("三角形不存在");
            //     }
            // }
            // else{
            //     Console.WriteLine("三角形不存在");
            // }
            // int []array=new int[6];
            // int s1=1,sum=0;
            // for(int i=1;i<=3;i++){
            //     s1=1;
            //     for(int j=1;j<=i;j++){
            //         s1=j*s1;
            //     }
            //     sum=sum+s1;
            // }
            // Console.WriteLine(sum);
            int []a = new[]{5,4,2,3};
            int [,]b;
            b=new int[3,4];
            b[0,1]=1;
            // Console.WriteLine(b[1,2]);
            // Console.WriteLine(a);
            // Test hello = new Test();
            // hello.hello();
            Car car = new Car();
            Car car1 = new Car();
            car1.Make = "";
            car1.Model = "";
            car1.Year = "";
            Console.WriteLine(car.Equals(car1));
        }
    }
}