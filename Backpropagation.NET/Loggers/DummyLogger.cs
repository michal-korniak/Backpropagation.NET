using Backpropagation.NET.Loggers.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backpropagation.NET.Loggers
{
    public class DummyLogger : ILogger
    {
        public void Info(string log)
        {
        }

        public void Trace(string log)
        {
        }
    }
}
