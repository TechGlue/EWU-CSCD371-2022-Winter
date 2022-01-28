namespace Logger
{
    public class LogFactory
    {
        public string? FilePath { get; private set; }
        public void ConfigureFileLogger(string filePath)
        {
            FilePath = filePath;
        }
        public BaseLogger? CreateLogger(string className)
        {
            if (FilePath is not null) return new FileLogger(className, FilePath);
            return null;
        }
    }
}
