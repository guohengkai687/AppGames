using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDemoDBEntities entities = new EFDemoDBEntities();
            T_Customer t_Customer = new T_Customer { Address = "北洼西里", Age = 18, UserName = "guohk" };
            //entities.T_Customer.Add(t_Customer);
            //entities.SaveChanges();

            var result = from a in entities.T_Customer select a;
            var result2 = entities.T_Customer.Where<T_Customer>(x => x.Id == 1);
            IQueryable<T_Customer> _Customers = (from a in entities.T_Customer
                                                 orderby a.Age
                                                 select a).Skip(0).Take(10);


            Console.Write(result2);
            Console.ReadKey();
        }
    }
}
