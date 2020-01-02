using BackpropagationNXOR.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Neurons.Abstract
{
    public interface INeuronPermitsToAddInputsConnections : INeuron
    {
        void AddInputConnections(IConnection connection);
    }
}
