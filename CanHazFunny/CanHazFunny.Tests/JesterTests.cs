
using System;
using System.IO;
using Moq;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        //We are mocking this method 
        //Specifically JokeService because we don't want to stay calling
        //The API that gives us the joke just want to ensure . 
        
        //Unnecessary test but good for practice
        [TestMethod]
        public void GetJoke_NoParameters_RetrievesJoke()
        {
           //Arrange
           var jokeServiceMock = new Mock<IJokeService>();
           jokeServiceMock
               .SetupSequence(x => x.GetJoke())
               .Returns("Insert Joke Here")
               .Returns("Insert Joke 2 Here");
           //Act
           Assert.AreEqual<string?>("Insert Joke Here", jokeServiceMock.Object.GetJoke());
           Assert.AreEqual<string?>("Insert Joke 2 Here", jokeServiceMock.Object.GetJoke());
           //Assert
           jokeServiceMock.Verify<string?>(x => x.GetJoke(), Times.Exactly(2));
        }
        
        //continue later
        [TestMethod]
        public void TellJoke_NoParams_NoChuckNorrisJoke()
        {
            //Arrange
            var jokeServiceMock = new Mock<IJokeService>();
            jokeServiceMock
                .SetupSequence(x => x.GetJoke())
                .Returns("Chuck Norris Joke")
                .Returns("Insert Joke 2 Here");
            
            var jokeOutMock = new Mock<IJokesOut>();
            
            //Act
            var jokeService = new Jester(jokeServiceMock.Object, jokeOutMock.Object);
            jokeService.TellJoke();
            //Asserts
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JesterClass_NullInterfaces_ThrowsNullException()
        { 
            new Jester(null, null);
        }

    }
}
