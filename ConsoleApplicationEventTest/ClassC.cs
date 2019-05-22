using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationEventTest
{
     /// <summary>
     /// 部下C
     /// </summary>
    public class C
    {
        A a;
        public C(A a)
        {
            this.a = a;
            a.RaiseEvent += new RaiseEventHandler(a_RaiseEvent); // 订阅举杯事件
            a.FallEvent += new FallEventHandler(a_FallEvent); // 订阅摔杯事件
        }
        /// <summary>
        /// 首领举杯时的动作
        /// </summary>
        /// <param name="hand">若首领A右手举杯，则攻击</param>
        void a_RaiseEvent(string hand)
        {
            if (hand.Equals("右"))
            {
                Attack();
            }
        }

        /// <summary>
        /// 首领摔杯时的动作
        /// </summary>
        void a_FallEvent()
        {
            Attack();
        }
        /// <summary>
        /// 攻击
        /// </summary>
        public void Attack()
        {
            Console.WriteLine("部下C发起攻击，一套落英神掌打得虎虎生威~");
        }
    }
}
