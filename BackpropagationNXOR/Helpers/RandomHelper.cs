﻿using System;

namespace Backpropagation.NET.Helpers
{
    public static class RandomHelper
    {
        private static readonly Random _random = new Random();

        public static double NextDouble() => _random.NextDouble();


    }
}
