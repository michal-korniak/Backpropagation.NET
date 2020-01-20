using Backpropagation.NET.Loggers.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backpropagation.NET.Loggers
{
    public class MixedLogger : ILogger
    {
        public void Info(string log)
        {
            FileLogger.LogToFile(log);
            Console.WriteLine(log);
        }

        public void Trace(string log)
        {
            FileLogger.LogToFile(log);
        }
    }
}
