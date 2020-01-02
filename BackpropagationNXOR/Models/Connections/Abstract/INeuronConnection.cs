using BackpropagationNXOR.Models.Abstract;
using BackpropagationNXOR.Models.Neurons;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Connections
{
    public interface INeuronConnection: IConnection
    {
        public INeuron Source { get; }
        public INeuron Destination { get; }
    }
}
