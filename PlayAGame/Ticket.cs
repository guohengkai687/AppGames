using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayAGame
{
    class Ticket
    {
        public Ticket(double length)
        {
            this.length = length;
        }
        double length;
        double price;
        public double Length
        {
            get
            {
                if (length < 0)
                {
                    length = 0;
                }
                return length;
            }
        }
        public double Price
        {
            get
            {
                if (length <= 100)
                {
                    price = length;
                }
                else if (length > 100 && length <= 200)
                {
                    price = 0.95 * length;
                }
                else if (length > 200 && length <= 300)
                {
                    price = 0.9 * length;
                }
                else if (length > 300)
                {
                    price = 0.8 * length;
                }
                return price;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("距离：{0},票价：{1}", Length, Price);
        }
    }
}
