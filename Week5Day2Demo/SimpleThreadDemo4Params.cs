using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week5Day2Demo
{
    internal class SimpleThreadDemo4Params
    {
        private static void Show(object param)
        {
            string message = (string) param;

            for (int i = 1; i <= 500; i++)
            {
                Console.Write($"{message}{i} ");
            }
        }

        public static void Demo()
        {
            var t1 = new Thread(Show); // Foreground Thread
            var t2 = new Thread(Show); // Foreground Thread
            t1.Name = "A Thread";
            t2.Name = "B Thread";

            t1.Start("A");
            t2.Start("B");

            for (int i = 1; i <= 100; i++)
            {
                Console.Write($"C{i} ");
            }
        }
    }
}
