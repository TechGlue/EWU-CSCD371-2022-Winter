using System;
using System.IO;
using Moq;
namespace CanHazFunny.Tests
{
    [TestClass]
    public class IJokesOutTests
    {
        //Come back idk how to test this efficiently before main code. 
        [TestMethod]
        public void PrintJoke_ValidJoke_JokeString()
        {
            //Arrange 
            var iJokesMock = new Mock<IJokesOut>();
            //setting up for console capture 
            var stringWriter = new StringWriter();
            
            //Act
            
            
            

            //Assert

        }

    }
}
