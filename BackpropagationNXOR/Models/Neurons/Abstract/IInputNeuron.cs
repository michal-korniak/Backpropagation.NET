using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Neurons.Abstract
{
    public interface IInputNeuron : INeuronPermitsToAddOutputsConnections
    {
        public new double Output { get; set; }
    }
}
