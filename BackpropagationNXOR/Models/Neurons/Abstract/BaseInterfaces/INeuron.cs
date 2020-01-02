using BackpropagationNXOR.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Neurons
{
    public interface INeuron
    {
        public double Output { get; }
    }
}
