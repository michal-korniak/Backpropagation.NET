using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Abstract
{
    public interface IErrorFunction
    {
        double Invoke(double actualOutput, double expectedOutput);

        double InvokeForDerivate(double actualOutput, double expectedOutput);
    }
}
