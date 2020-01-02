using System;
using System.Collections.Generic;
using System.Text;
using Backpropagation.NET.Loggers.Abstract;

namespace Backpropagation.NET.Loggers
{
    class ConsoleLogger: ILogger
    {
        public void Info(string log)
        {
            Console.WriteLine(log);
        }
    }
}
