using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
           var book=new Book("");
           book.AddGrade(89.1);
           book.AddGrade(90.5);
           book.AddGrade(77.5);


           var result = book.GetStatistics();

           Assert.Equal(85.7,result.Average);
            Assert.Equal(90.5,result.High);
             Assert.Equal(77.5,result.Low);
         
        }
    }
}
