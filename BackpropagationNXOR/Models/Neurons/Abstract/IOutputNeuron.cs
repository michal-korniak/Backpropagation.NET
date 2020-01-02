using Backpropagation.NET.Models.ErrorFunctions.Abstract;
using Backpropagation.NET.Models.Neurons.Abstract.Base;

namespace Backpropagation.NET.Models.Neurons.Abstract
{
    public interface IOutputNeuron : INeuron, INeuronPermitsToAddInputsConnections, INeuronWithDeltaError
    {
        /// <summary>
        /// Sum of connections outputs
        /// </summary>
        public double NetOutput { get; }
        public double Error { get; }


        void CalculateError(IErrorFunction errorFunction, double expectedOutput);
        void CalculateDeltaError(IErrorFunction errorFunction, double expectedOutput);
    }
}
