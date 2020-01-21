using System.Collections.Generic;
using Backpropagation.NET.Models.Connections.Abstract.Base;

namespace Backpropagation.NET.Models.Neurons.Abstract.Base
{
    public interface INeuronPermitsToAddInputsConnections : INeuron
    {
        public IEnumerable<IConnection> InputConnections { get; }
        void AddInputConnections(IConnection connection);
    }
}
