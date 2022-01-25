using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week5Day2Demo
{
    internal class SimpleThreadDemo3
    {
        private static void Show()
        {
            for (int i = 1; i <= 500; i++)
            {
                Console.Write($"A{i} ");
            }
        }

        public static void Demo()
        {
            var t1 = new Thread(Show); // Foreground Thread
            var t2 = new Thread(Show); // Foreground Thread

            t1.Start();
            t2.Start();
        }
    }
}
