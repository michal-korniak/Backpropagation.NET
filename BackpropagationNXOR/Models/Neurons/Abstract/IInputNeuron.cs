using BackpropagationNXOR.Models.Neurons.Abstract.Base;

namespace BackpropagationNXOR.Models.Neurons.Abstract
{
    public interface IInputNeuron : INeuronPermitsToAddOutputsConnections
    {
        public new double Output { get; set; }
    }
}
