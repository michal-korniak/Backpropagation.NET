using BackpropagationNXOR.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models
{
    class SigmoidActivationFunction : IActivationFunction
    {
        public double Invoke(double input)
        {
            return (1 / (1 + Math.Exp(-input)));
        }

        public double InvokeForDerivate(double input)
        {
            return Invoke(input) * (1 - Invoke(input));
        }
    }
}
