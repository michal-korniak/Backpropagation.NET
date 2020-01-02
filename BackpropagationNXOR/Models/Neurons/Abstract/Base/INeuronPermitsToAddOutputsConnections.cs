using System.Collections.Generic;
using Backpropagation.NET.Models.Connections.Abstract.Base;

namespace Backpropagation.NET.Models.Neurons.Abstract.Base
{
    public interface INeuronPermitsToAddOutputsConnections : INeuron
    {
        public IEnumerable<IConnection> OutputConnections { get; }
        void AddOutputConnection(IConnection connection);
    }
}
