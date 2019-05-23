using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PlayAGame
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            //Player No3.

            //Player No2.
            string st1 = ResourceTest.ResourceManager.GetObject("ts1").ToString();
            Console.Write(st1);
            Console.ReadLine();

            //Plyer No1.
            int i = 2, j = 3;
            Console.WriteLine(*Add(&i, &j));
            Console.ReadLine();

        }
        public static unsafe int* Add(int* x, int* y)
        {
            int sum = *x + *y;
            return &sum;
        }
    }

    class GameNo1
    {
        //序列化操作
        public static void SerializeMethod(List<Person> list)
        {
            using (FileStream fs = new FileStream("序列化.btn",FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, list);
                Console.WriteLine("序列化成功!");
            }
        }
        //反序列化操作
        public static List<Person> ReserializeMethod()
        {
            using (FileStream fs = new FileStream("序列化.btn", FileMode.Open))
            {

                BinaryFormatter bf = new BinaryFormatter();
                List<Person> list = (List<Person>)bf.Deserialize(fs);
                return list;
            }
        }

    }
    class Person
    {
        string A { get; set; }

        int B { get; set; }
    }
}
