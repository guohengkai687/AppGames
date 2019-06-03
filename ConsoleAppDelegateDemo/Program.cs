using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> evenNum = num.FindAll(new Program().GetEvenNum);

            foreach (var item in evenNum)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("使用Lambda的方式");

            List<int> evenNumLam = num.FindAll(x => x % 2 == 0);
            foreach (var item in evenNumLam)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
        public bool GetEvenNum(int num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
