using BackpropagationNXOR.Models.Connections.Abstract.Base;
using BackpropagationNXOR.Models.Neurons.Abstract.Base;

namespace BackpropagationNXOR.Models.Connections.Abstract
{
    public interface INeuronConnection : IConnection
    {
        public INeuron Source { get; }
        public INeuron Destination { get; }
    }
}
