using System;
using System.IO;

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
        
        private string ToText()
        {
           return $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt}\n{ClassName}\n{Status}\n{Message}";
        }
        
        public override void Log(LogLevel logLevel, string message)
        {
            Status = logLevel;
            Message = message;
            
            string? path = FilePath;
            if (File.Exists(path)) return;
            if (path == null) return;
            using StreamWriter sw = File.CreateText(path);
            sw.WriteLine(ToText());
        }
    }
}