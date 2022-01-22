using System;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private string? ClassName { get; set; }
        private LogLevel Status { get; set; }
        private string? Message { get; set; }
        private string? FilePath { get; set; }
        
        public FileLogger(string? className, string? filePath) 
        {
            ClassName = className;
            FilePath = filePath;
        }
        
        public string ToText()
        {
           return $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt} {ClassName} {Status} {Message}";
        }
        
        public override void Log(LogLevel logLevel, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}