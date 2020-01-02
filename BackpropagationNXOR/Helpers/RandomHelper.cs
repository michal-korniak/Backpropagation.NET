using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Services
{
    public static class RandomHelper
    {
        private static Random _random = new Random();

        public static double NextDouble() => _random.NextDouble();


    }
}
