using System;
using Week5Day2Demo.InternationalStudents;

namespace Week5Day2Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NoThreadDemo.Demo();
            //SimpleThreadDemo.Demo();

            //SimpleThreadDemo2Background.Demo();
            //SimpleThreadDemo3.Demo();
            //SimpleThreadDemo4Params.Demo();

            Console.Write("Press any key to start...");
            Console.ReadKey();
            Console.WriteLine("STARTED!!");

            InternationalStudentManagementNoThread.Demo();
            InternationalStudentManagement.Demo();
        }
    }
}
