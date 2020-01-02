using Backpropagation.NET.Models.Neurons.Abstract.Base;

namespace Backpropagation.NET.Models.Neurons.Abstract
{
    public interface IHiddenNeuron : INeuron, INeuronPermitsToAddOutputsConnections, INeuronPermitsToAddInputsConnections, INeuronWithDeltaError
    {
        void CalculateDeltaError();
    }
}
