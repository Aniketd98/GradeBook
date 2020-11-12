using System;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

        
    public class TypeTests
    {

      int count =0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
           
            log += ReturnMessage;
            log += IncrementCounte;

            var result = log("Hello");
            Assert.Equal(3, count);
        }
        string IncrementCounte(string message)
        {
          count++;
          return message.ToLower();
        }

        string ReturnMessage(string message)
        {
          count++;
          return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name= "Aniket";

            string upper =MakeUpperCase(name);

            Assert.Equal("Aniket",name); 
            Assert.Equal("ANIKET",upper); 
            
        }

        private string MakeUpperCase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42,x);

        }
        private int GetInt()
        {
            return 3;

        }
        private int SetInt(ref int x)
        {
            x=42;
            return x;
        }

        [Fact]
         public void CSharpIsPassByRef()
        {
          var book1= GetBook("Book 1");
          GetBookSetName(ref book1,"New Name");

          Assert.Equal("New Name" , book1.Name);
         
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            
            book=new InMemoryBook(name);
            book.Name= name;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
          var book1= GetBook("Book 1");
          GetBookSetName(book1,"New Name");

          Assert.Equal("Book 1" , book1.Name);
         
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            
            book=new InMemoryBook(name);
           
        }


        [Fact]
        public void CanSetNameFromReference()
        {
          var book1= GetBook("Book 1");
          SetName(book1,"New Name");

          Assert.Equal("New Name" , book1.Name);
         
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name=name;
        }


        [Fact]
        public void GetBookReturnDifferentObjects()
        {
          var book1= GetBook("Book 1");
          var book2= GetBook("Book 2");

          Assert.Equal("Book 1" , book1.Name);
          Assert.Equal("Book 2" , book2.Name);
          Assert.NotSame(book1,book2);
        }
        [Fact]
         public void TwoVarsCanReferenceSameObject()
        {
          var book1= GetBook("Book 1");
          var book2= book1;

          Assert.Same(book1,book2);
          Assert.True(Object.ReferenceEquals(book1,book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
           
        
    }
}
