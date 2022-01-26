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
       
        //ToDo: double check logic once all methods implemented. 
        public override void Log(LogLevel logLevel, string message)
        {
            Status = logLevel;
            Message = message;
            
            if (!File.Exists(FilePath)) return;
            using StreamWriter sw = File.CreateText(FilePath);
            sw.WriteLine(ToText());
            sw.Close();
        }
    }
}