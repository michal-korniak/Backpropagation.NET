using System.Collections.Generic;
using Backpropagation.NET.Models.Connections.Abstract.Base;
using Backpropagation.NET.Models.Neurons.Abstract.Base;

namespace Backpropagation.NET.Models.Connections.Abstract
{
    public interface IBiasConnection: IConnection
    {
        public IEnumerable<INeuron> Destinations { get; }
        public void AddDestination(INeuron neuron);
    }
}
