namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {

        [TestMethod]
        public void Initialize_FileLogger_IsNotNull()
        {   
            // Arrange
            FileLogger? logger;
            // Act
            string filePath = @"\test.txt";
            logger = new FileLogger(filePath, nameof(FileLoggerTests));
            // Assert
            Assert.IsNotNull(logger);
        }

        [TestMethod]
        public void ToText_FileLogger_ReturnsEqualText()
        {
            // Arrange
            FileLogger? logger;
            // Act
            logger = new FileLogger("Test", "Test", LogLevel.Error, "Test");

            string compareString = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt}\nTest\nError\nTest";

            // Assert
            Assert.AreEqual(logger.ToText(), compareString);
        }

        [TestMethod]
        public void LogCreatesFile_FileLogger_FileFound()
        {   
            //TODO: Figure out how to test when file isn't being created.
            
            // Arrange
            FileLogger? logger;
            // Act
            string filePath = @"\test.txt";
            logger = new FileLogger(filePath, nameof(FileLoggerTests));
            string message = "message";
            logger.Log(LogLevel.Error, message);
            // Assert
            Assert.IsTrue(File.Exists(filePath));
        }
    }
}
