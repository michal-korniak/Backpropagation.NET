using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Abstract
{
    public interface IActivationFunction
    {
        double Invoke(double input);

        double InvokeForDerivate(double input);
    }
}
