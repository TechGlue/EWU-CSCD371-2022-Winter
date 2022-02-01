using System;
using System.IO;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JesterClass_NullInterfaces_ThrowsArgumentNullException()
        { 
            new Jester(null, null);
        }
        
        //Message to reviewer - I think I maybe complicated this test.  
        [TestMethod]
        public void TellJoke_NoParams_NoChuckNorrisJoke()
        {
            //Arrange
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            JokeService jokeService = new JokeService();
            var jokeServiceMock = new Mock<IJokeService>();
            jokeServiceMock
                .SetupSequence(x => x.GetJoke())
                .Returns("Chuck Norris Joke")
                .Returns("cHuck norris Joke")
                .Returns("chuck norris Joke")
                .Returns("CHUCk NoRRis Joke")
                .Returns("Joke");
            
            //Act
            var jester = new Jester(jokeServiceMock.Object, jokeService);
            jester.TellJoke();
            bool didItPrintOutChuckNorris = stringWriter.ToString().Contains("Chuck Norris");
            
            //Asserts
            Assert.IsFalse(didItPrintOutChuckNorris);
        }
    }
}
