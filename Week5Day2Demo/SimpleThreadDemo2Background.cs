using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week5Day2Demo
{
    internal class SimpleThreadDemo2Background
    {
        private static void Show1()
        {
            for (int i = 1; i <= 10000; i++)
            {
                Console.Write($"A{i} ");
            }
        }

        private static void Show2()
        {
            for (int i = 1; i <= 5000; i++)
            {
                Console.Write($"B{i} ");
            }
        }

        public static void Demo()
        {
            var t1 = new Thread(Show1); 
            var t2 = new Thread(Show2);
            
            t1.IsBackground = true; // Background Thread
            t2.IsBackground = true; // Background Thread

            t1.Start();
            t2.Start();

            for (int i = 1; i <= 1000; i++)
            {
                Console.Write($"C{i} ");
            }
        }
    }
}
