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
            string filePath = "";
            if (FilePath != null)
            {
                filePath = FilePath; 
            }
            //come back and verify if it can append new lines to existing files.  
            StreamWriter sw = new(filePath, true);
            sw.WriteLine(ToText());
            sw.Close();
        }
    }
}