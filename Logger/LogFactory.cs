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
        
        //I understand so when we create a logger it will first need to be configured if it's not been configured then we are going to have a null. 
        public BaseLogger? CreateLogger(string className)
        {
            if (FilePath is not null) return new FileLogger(ClassName, FilePath);
            return null;
        }
    }
}
