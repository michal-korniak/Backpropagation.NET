using BackpropagationNXOR.Models.ErrorFunctions.Abstract;
using BackpropagationNXOR.Models.Neurons.Abstract.Base;

namespace BackpropagationNXOR.Models.Neurons.Abstract
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
