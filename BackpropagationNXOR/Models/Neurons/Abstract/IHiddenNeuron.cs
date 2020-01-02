using BackpropagationNXOR.Models.Neurons.Abstract.Base;

namespace BackpropagationNXOR.Models.Neurons.Abstract
{
    public interface IHiddenNeuron : INeuron, INeuronPermitsToAddOutputsConnections, INeuronPermitsToAddInputsConnections, INeuronWithDeltaError
    {
        void CalculateDeltaError();
    }
}
