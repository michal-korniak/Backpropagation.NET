﻿using BackpropagationNXOR.Models.Abstract;
using BackpropagationNXOR.Models.Neurons;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Connections
{
    public interface IBiasConnection: IConnection
    {
        public IEnumerable<INeuron> Destinations { get; }
        public void AddDestination(INeuron neuron);
    }
}
