using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplicationASN1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //开启监听线程
            Thread myThead = new Thread(new ThreadStart(SocketTest.Listen));
            myThead.Start();            

        }
    }
}
