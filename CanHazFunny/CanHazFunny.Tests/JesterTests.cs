using Moq;

namespace CanHazFunny.Tests;
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
        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);

        JokeService jokeService = new();
        Mock<IJokeService> jokeServiceMock = new();
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

        //Asserts
        Assert.AreEqual<string>("Joke\n", stringWriter.ToString());

        //Clean Up
        stringWriter.Flush();
        stringWriter.Close();
    }
}
