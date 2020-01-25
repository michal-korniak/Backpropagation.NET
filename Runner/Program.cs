using Backpropagation.NET.Loggers;
using Runner.ArchitectureTest;
using Runner.ArchitectureTest.UnipolarNXORArchitectureTest;
using System;

namespace Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var logger = new ConsoleLogger(); //odkomentować, aby uzyskać dokładniejsze logi
            var logger = new QuickLogger();
            Examples.UnipolarNXORExample(logger);

            //wyszukwianie optymalnej architektury dla NXOR
            //var architectureTest = new UnipolarNXORArchitectureTest(100000, 0.1, 100);
            //architectureTest.Run();


            Console.ReadKey();
        }
    }
}
