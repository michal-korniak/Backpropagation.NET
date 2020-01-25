using Backpropagation.NET.Loggers;
using System;

namespace Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            var logger = new QuickLogger();
            Examples.BipolarNXORExample(logger);

            Console.ReadKey();
        }
    }
}
