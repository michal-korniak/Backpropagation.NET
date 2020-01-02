using BackpropagationNXOR.Models.Abstract;
using BackpropagationNXOR.Models.Connections;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Neurons.Abstract
{
    public interface INeuronPermitsToAddOutputsConnections : INeuron
    {
        public IEnumerable<IConnection> OutputConnections { get; }
        void AddOutputConnection(IConnection connection);
    }
}
