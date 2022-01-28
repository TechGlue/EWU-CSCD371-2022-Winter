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

        public FileLogger(string? className, string? filePath, LogLevel status, string? message)
        {
            ClassName = className;
            FilePath = filePath;
            Status = status;
            Message = message;
        }

        public string ToText()
        {
            return $"{DateTime.Now:MM/dd/yyyy hh:mm:ss tt}\n{ClassName}\n{Status}\n{Message}\n";
        }

        public override void Log(LogLevel logLevel, string message)
        {
            Status = logLevel;
            Message = message;
            string filePath = "";
            if (FilePath != null)
            {
                filePath = FilePath;
            }
            var fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new(fs);
            sw.WriteLine(ToText());
            sw.Close();
        }
    }
}