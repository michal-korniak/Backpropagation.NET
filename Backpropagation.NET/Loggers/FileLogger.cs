using Backpropagation.NET.Loggers.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Backpropagation.NET.Loggers
{
    public class FileLogger : ILogger
    {
        public FileLogger()
        {

        }
        public void Info(string log)
        {
            LogToFile(log);
        }
        public void Trace(string log)
        {
            LogToFile(log);
        }

        public static void LogToFile(string log)
        {
            string fileName = $"{DateTime.Now.Date.ToString("yyyy-MM-dd")}.log";
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            using (var streamWriter = new StreamWriter(filePath,append:true))
            {
                streamWriter.WriteLine(log);
            }
        }
    }
}
