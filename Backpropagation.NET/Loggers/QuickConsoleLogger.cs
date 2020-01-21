using Backpropagation.NET.Loggers.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backpropagation.NET.Loggers
{
    class QuickLogger : ILogger
    {
        public void Info(string log)
        {
            Console.WriteLine(log);
        }

        public void Trace(string log)
        {
            //Ignore
        }
    }
}
