using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Aniket's Grade Book");

            System.Console.WriteLine("Please Enter a NAME");
            string namex = Console.ReadLine();

            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();


            System.Console.WriteLine($"The lowest grades is {stats.Low}");
            System.Console.WriteLine($"The Gighest grades is {stats.High}");
            System.Console.WriteLine($"The average is {stats.Average}");
            System.Console.WriteLine($"The average is {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        { 
            while (true)
            {
                System.Console.WriteLine("enter a number or q to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
                System.Console.WriteLine("Grade Was Added");
        }
    }
}
