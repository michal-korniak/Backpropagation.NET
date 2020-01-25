using System;
using Backpropagation.NET.Models.ErrorFunctions.Abstract;

namespace Backpropagation.NET.Models.ErrorFunctions
{
    public class MeanSquaredErrorFunction : IErrorFunction
    {
        private readonly int _outputsNumber;

        public MeanSquaredErrorFunction(int outputsNumber)
        {
            _outputsNumber = outputsNumber;
        }

        public double Invoke(double actualError, double expectedError)
        {
            return 1/(double) _outputsNumber * Math.Pow(expectedError - actualError, 2);
        }

        public double InvokeForDerivate(double actualError, double expectedError)
        {
            return actualError - expectedError;
        }
    }
}
