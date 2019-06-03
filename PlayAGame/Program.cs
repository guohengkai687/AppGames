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
        static void Main(string[] args)
        {
           
        }
        //序列化操作
        public static void SerializeMethod(List<Person> list)
        {
            using (FileStream fs = new FileStream("序列化.btn", FileMode.Create))
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
