using Backpropagation.NET.Models.Neurons.Abstract.Base;

namespace Backpropagation.NET.Models.Neurons.Abstract
{
    public interface IInputNeuron : INeuronPermitsToAddOutputsConnections
    {
        public new double Output { get; set; }
    }
}
