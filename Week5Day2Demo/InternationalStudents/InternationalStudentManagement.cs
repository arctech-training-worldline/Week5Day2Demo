using System;
using System.Threading;

namespace Week5Day2Demo.InternationalStudents
{
    /// <summary>
    /// We have data of students from USA and India in 2 text files
    /// Write a program to load the load from the Usa text file and the India text files
    /// Then calculate the average marks of India students vs USA students
    /// Also display the passing count and pass percentage of USA vs India
    /// Note: This is a multi threading assignment, so we can skip the file reading
    /// and hard code/simulate 1000 students from India and 500 from USA for this demo
    /// </summary>

    struct ThreadParameterData
    {
        public Student[] Students { get; set; }
        public string CountryName { get; set; }
    }

    internal class InternationalStudentManagement
    {
        internal static void Demo()
        {
            // Simulating reading student marks data from File
            // But doing some random data load for testing.
            var random = new Random();
            var studentsIndia = new Student[500];

            for (var i = 0; i < studentsIndia.Length; i++)
            {
                studentsIndia[i].Marks = random.Next(20, 95);  // Random numbers between 20 to 95
            }

            var studentsUsa = new Student[200];
            for (var i = 0; i < studentsUsa.Length; i++)
            {
                studentsUsa[i].Marks = random.Next(10, 75);  // Random numbers between 10 to 75
            }

            //CalculateMarks(studentsIndia, "India");
            //CalculateMarks(studentsUsa, "USA");

            var t1 = new Thread(CalculateMarks);
            var t2 = new Thread(CalculateMarks);

            var threadParameterData1 = new ThreadParameterData {CountryName = "India", Students = studentsIndia};
            t1.Start(threadParameterData1);

            var threadParameterData2 = new ThreadParameterData { CountryName = "USA", Students = studentsUsa };
            t2.Start(threadParameterData2);
        }

        private static void CalculateMarks(object param)
        {
            var threadParameterData = (ThreadParameterData) param;

            Console.WriteLine($"Started calculating for {threadParameterData.CountryName} at {DateTime.Now}");
            long totalMarks = 0;
            long passingCount = 0;

            foreach (var student in threadParameterData.Students)
            {
                Thread.Sleep(5);
                totalMarks += student.Marks;

                if(student.Marks >= 35)
                    passingCount++;
            }

            var average = (double)totalMarks / threadParameterData.Students.Length;
            var passingPercent = passingCount == 0 ? 0 : passingCount * 100.0f / threadParameterData.Students.Length;
            
            Console.WriteLine($"{threadParameterData.CountryName} => Average:{average:n}, Total Passing:{passingCount:n0}/{threadParameterData.Students.Length}, Pass%:{passingPercent:n}");
            Thread.Sleep(2000);
            Console.WriteLine($"Finished calculating for {threadParameterData.CountryName} at {DateTime.Now}");
        }
    }
}
