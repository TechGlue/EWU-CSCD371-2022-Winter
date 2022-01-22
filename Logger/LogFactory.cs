namespace Logger
{
    public class LogFactory
    {
        //TODO:As private ????
        private string? ClassName { get; set; }
        private string? FilePath { get; set; }
        public LogFactory(string className)
        {
            ClassName = className;
        }
        private void ConfigureFileLogger(string filePath)
        {
           FilePath = filePath;
        }
        
        public BaseLogger? CreateLogger(string className)
        {
            if (FilePath is null)
            {
                return null;
            }
            
            return new FileLogger(ClassName,FilePath);
        }
    }
}
