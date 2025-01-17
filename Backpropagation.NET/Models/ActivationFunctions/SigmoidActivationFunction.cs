﻿using System;
using Backpropagation.NET.Models.ActivationFunctions.Abstract;

namespace Backpropagation.NET.Models.ActivationFunctions
{
    public class SigmoidActivationFunction : IActivationFunction
    {
        public double Invoke(double input)
        {
            return (1 / (1 + Math.Exp(-input)));
        }

        public double InvokeForDerivative(double input)
        {
            return Invoke(input) * (1 - Invoke(input));
        }
    }
}
