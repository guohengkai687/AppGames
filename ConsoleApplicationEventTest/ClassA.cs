using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationEventTest
{
    public delegate void RaiseEventHandler(string hand);
    public delegate void FallEventHandler();
    /// <summary>
    /// 首领A
    /// </summary>
    public class A
    {
        /// <summary>
        /// 首领A举杯事件
        /// </summary>
        public event RaiseEventHandler RaiseEvent;
        /// <summary>
        /// 首领A摔杯事件
        /// </summary>
        public event FallEventHandler FallEvent;
        /// <summary>
        /// 举杯
        /// </summary>
        /// <param name="hand">手：左、右</param>
        public void Raise(string hand)
        {
            Console.WriteLine("首领A{0}手举杯", hand);
            // 调用举杯事件，传入左或右手作为参数
            if (RaiseEvent != null)
            {
                RaiseEvent(hand);
            }
        }
        /// <summary>
        /// 摔杯
        /// </summary>
        public void Fall()
        {
            Console.WriteLine("首领A摔杯");
            // 调用摔杯事件
            if (FallEvent != null)
            {
                FallEvent();
            }
        }
    }
}
