using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationEventTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            A a = new A(); // 定义首领A

            B b = new B(a); // 定义部下B

            C c = new C(a); // 定义部下C       

            // 首领A左手举杯
            a.Raise("左");
            Delay(10);
            
            // 首领A右手举杯
            a.Raise("右");
            Delay(10);

            // 首领A摔杯
            a.Fall();
            Delay(10);

            Console.ReadLine();
            // 由于B和C订阅了A的事件，所以无需任何代码，B和C均会按照约定进行动作。
        }

        public static bool Delay(int delayTime)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                //Application.DoEvents();
            }
            while (s < delayTime);
            return true;
        }
    }
}
