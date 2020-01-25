using Backpropagation.NET.Loggers;
using Runner.ArchitectureTest;
using System;

namespace Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var logger = new QuickLogger();
            //Examples.BipolarNXORExample(logger);


            var architectureTest = new UnipolarNXORArchitectureTest(100000, 0.1, 100);
            architectureTest.Run();


            Console.ReadKey();
        }
    }
}
