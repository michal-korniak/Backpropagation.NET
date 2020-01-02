using System;
using Backpropagation.NET.Models.ErrorFunctions.Abstract;

namespace Backpropagation.NET.Models.ErrorFunctions
{
    class MeanSquaredErrorFunction : IErrorFunction
    {
        public double Invoke(double actualError, double expectedError)
        {
            return 0.5 * Math.Pow(expectedError - actualError, 2);
        }

        public double InvokeForDerivate(double actualError, double expectedError)
        {
            return actualError - expectedError;
        }
    }
}
