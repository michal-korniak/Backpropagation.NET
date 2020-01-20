using Backpropagation.NET.Loggers;
using Backpropagation.NET.Loggers.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backpropagation.NET.Factories
{
    public class LoggerFactory
    {
        public ILogger Create(string loggerName)
        {
            switch(loggerName.ToLower())
            {
                case "console":
                    return new ConsoleLogger();
                case "quick":
                    return new QuickLogger();
                case "mixed":
                    return new MixedLogger();
                case "file":
                    return new FileLogger();
                default:
                    throw new Exception($"Logger with name {loggerName} doesn't exists");
            }
        }
    }
}
