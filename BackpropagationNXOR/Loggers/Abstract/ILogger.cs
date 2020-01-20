using System;
using System.Collections.Generic;
using System.Text;

namespace Backpropagation.NET.Loggers.Abstract
{
    public interface ILogger
    {
        void Trace(string log);
        void Info(string log);
    }
}
