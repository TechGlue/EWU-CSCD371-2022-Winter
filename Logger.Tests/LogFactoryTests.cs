namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        
        [TestMethod]
        public void ConfigureFileLogger_WithValidFilePath_PrivateMemberFilePathIsSet()
        {
            //Arrange
            LogFactory logFactory = new();
            //Act
            logFactory.ConfigureFileLogger("/Users/luis/"); 
            // Assert
            Assert.AreEqual("/Users/luis/", logFactory.FilePath);
        }

        [TestMethod]
        public void CreateLogger_WithNullParameters_ReturnsNull()
        {
            //Arrange 
            LogFactory logFactory = new();
            //Act
            BaseLogger? baseLogger = logFactory.CreateLogger(GetType().Name);
            //Assert
            Assert.IsNull(baseLogger);
        }


        [TestMethod]
        public void CreateLogger_WithValidParameters_CreatesFileLogger()
        {
            //Arrange
            LogFactory logFactory = new();
            //Act
            logFactory.ConfigureFileLogger("/Users/luis/");
            BaseLogger? baseLogger = logFactory.CreateLogger(GetType().Name);
            //Assert
            Assert.IsNotNull(baseLogger);
        }
    }
}
