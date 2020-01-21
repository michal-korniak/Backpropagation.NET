using Backpropagation.NET.Models.ActivationFunctions.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backpropagation.NET.Models.ActivationFunctions
{
    public class TANHActivationFunction : IActivationFunction
    {
        public double Invoke(double input)
        {
            double result = (Math.Exp(input * 2.0) - 1.0) / (Math.Exp(input * 2.0) + 1.0);
            return result;
        }

        public double InvokeForDerivative(double input)
        {
            return (1.0 - Math.Pow(Invoke(input), 2.0));
        }
    }
}
