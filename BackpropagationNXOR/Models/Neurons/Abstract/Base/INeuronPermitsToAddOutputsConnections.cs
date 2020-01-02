using System.Collections.Generic;
using BackpropagationNXOR.Models.Connections.Abstract.Base;

namespace BackpropagationNXOR.Models.Neurons.Abstract.Base
{
    public interface INeuronPermitsToAddOutputsConnections : INeuron
    {
        public IEnumerable<IConnection> OutputConnections { get; }
        void AddOutputConnection(IConnection connection);
    }
}
