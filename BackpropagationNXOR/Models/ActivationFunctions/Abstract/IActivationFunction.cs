﻿namespace Backpropagation.NET.Models.ActivationFunctions.Abstract
{
    public interface IActivationFunction
    {
        double Invoke(double input);

        double InvokeForDerivate(double input);
    }
}
