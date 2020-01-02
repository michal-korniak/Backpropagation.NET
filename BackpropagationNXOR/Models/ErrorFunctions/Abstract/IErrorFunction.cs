namespace Backpropagation.NET.Models.ErrorFunctions.Abstract
{
    public interface IErrorFunction
    {
        double Invoke(double actualOutput, double expectedOutput);

        double InvokeForDerivate(double actualOutput, double expectedOutput);
    }
}
