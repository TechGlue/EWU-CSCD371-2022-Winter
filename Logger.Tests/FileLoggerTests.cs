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
            logger = new FileLogger(nameof(FileLoggerTests), filePath);
            // Assert
            Assert.IsNotNull(logger);
        }

        [TestMethod]
        public void ToText_FileLogger_ReturnsEqualText()
        {
            // Arrange
            FileLogger? logger;
            // Act
            logger = new FileLogger(nameof(FileLoggerTests), "Test", LogLevel.Error, "Test");
            string compareString = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt}\n{nameof(FileLoggerTests)}\nError\nTest\n";
            // Assert
            Assert.AreEqual(logger.ToText(), compareString);
        }

        [TestMethod]
        public void Log_LogLevelAnd_message_LogsMessageToFile()
        {
            //Arrange
            string path = "../../../TestFile.txt";
            FileLogger logger = new(nameof(FileLoggerTests), path, LogLevel.Error, "Test");
            string message = "Test";
            //Act 
            logger.Log(LogLevel.Error, message);
            //Assert
            var fileText = File.ReadLines(path);
            Assert.IsTrue(fileText.ToString()!.Length > 1);
            Assert.IsTrue(File.Exists(path));
            //CleanUp

        }

        [TestMethod]
        public void LogCreatesFile_FileLogger_FileFound()
        {
            //Arrange
            string path = "../../../TestFile.txt";
            FileLogger logger = new(nameof(FileLoggerTests), path, LogLevel.Error, "Test");
            string message = "This is a test";
            //Act 
            logger.Log(LogLevel.Error, message);
            //Assert 
            Assert.IsTrue(File.Exists(path));
            //CleanUp
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
