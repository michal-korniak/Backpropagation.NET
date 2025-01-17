﻿using System;
using System.Collections.Generic;
using System.Text;
using Backpropagation.NET.Loggers.Abstract;

namespace Backpropagation.NET.Loggers
{
    public class ConsoleLogger: ILogger
    {
        public void Trace(string log)
        {
            Console.WriteLine(log);
        }
        public void Info(string log)
        {
            Console.WriteLine(log);
        }
    }
}
