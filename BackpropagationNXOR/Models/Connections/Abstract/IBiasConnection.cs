using System.Collections.Generic;
using BackpropagationNXOR.Models.Connections.Abstract.Base;
using BackpropagationNXOR.Models.Neurons.Abstract.Base;

namespace BackpropagationNXOR.Models.Connections.Abstract
{
    public interface IBiasConnection: IConnection
    {
        public IEnumerable<INeuron> Destinations { get; }
        public void AddDestination(INeuron neuron);
    }
}
