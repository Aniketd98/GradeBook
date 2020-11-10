using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
           var book=new Book("Aniket's Grade Book");
           book.AddGrade(89.1);
           book.AddGrade(90.5);
           book.AddGrade(77.5);
           
           var stats= book.GetStatistics();


           System.Console.WriteLine($"The lowest grades is {stats.Low}");
            System.Console.WriteLine($"The Gighest grades is {stats.High}");
            System.Console.WriteLine($"The average is {stats.Average}");
        }
    }
}
