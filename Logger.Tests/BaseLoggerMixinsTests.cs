namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {
        [TestMethod]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Error("",null!));
        }
        
        [TestMethod]
        public void Warning_WithNullLogger_ThrowsException()
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Warning("",null!));
        }
        
        [TestMethod]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Debug("",null!));
        }
        
        [TestMethod]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => BaseLoggerMixins.Information("",null!));
        }

        [TestMethod]
        public void Warning_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();
            
            // Act
            BaseLoggerMixins.Warning(LogCategory.Warning, logger);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 41: Warning", logger.LoggedMessages[0].Message);
        }
       
        [TestMethod]
        public void Error_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();
            
            // Act
            BaseLoggerMixins.Error(LogCategory.Error, logger);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 42: Error", logger.LoggedMessages[0].Message);
        }
        
        [TestMethod]
        public void Information_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();
            
            // Act
            BaseLoggerMixins.Information(LogCategory.Information, logger);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 40: Information", logger.LoggedMessages[0].Message);
        }
        
        [TestMethod]
        public void Debug_WithData_LogsMessage()
        {
            // Arrange
            var logger = new TestLogger();
            
            // Act
            BaseLoggerMixins.Debug(LogCategory.Debug, logger);

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Message 39: Debug", logger.LoggedMessages[0].Message);
        }
    }

    //Since for unit tests it does not like literals I created a class here that is dedicated just for containing error codes. 
    //Inspiration: https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp
    public static class LogCategory
    {
        public static string Error { get { return new string("Message 42: Error"); } }
        public static string Warning { get { return new string("Message 41: Warning"); } }
        public static string Information { get { return new string("Message 40: Information"); } }
        public static string Debug { get { return new string("Message 39: Debug"); } }
    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
