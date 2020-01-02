using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Neurons.Abstract.BaseInterfaces
{
    public interface INeuronWithDeltaError: INeuron
    {
        /// <summary>
        /// Derivatate of total error in respect to net output
        /// </summary>
        public double DeltaError { get; }
    }
}
