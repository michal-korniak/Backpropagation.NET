using System.Collections.Generic;
using BackpropagationNXOR.Models.Connections.Abstract.Base;

namespace BackpropagationNXOR.Models.Neurons.Abstract.Base
{
    public interface INeuronPermitsToAddInputsConnections : INeuron
    {
        public IEnumerable<IConnection> InputConnections { get; }
        void AddInputConnections(IConnection connection);
    }
}
