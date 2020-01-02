using System;
using System.Collections.Generic;
using System.Text;
using BackpropagationNXOR.Models.Neurons.Abstract.Base;

namespace BackpropagationNXOR.Models.Neurons.Abstract
{
    public interface IInputNeuron : INeuronPermitsToAddOutputsConnections
    {
        public new double Output { get; set; }
    }
}
