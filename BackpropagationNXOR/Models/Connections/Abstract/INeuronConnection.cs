using Backpropagation.NET.Models.Connections.Abstract.Base;
using Backpropagation.NET.Models.Neurons.Abstract.Base;

namespace Backpropagation.NET.Models.Connections.Abstract
{
    public interface INeuronConnection : IConnection
    {
        public INeuron Source { get; }
        public INeuron Destination { get; }
    }
}
