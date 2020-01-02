﻿using BackpropagationNXOR.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Neurons.Abstract
{
    public interface IHiddenNeuron : INeuron, INeuronPermitsToAddOutputsConnections, INeuronPermitsToAddInputsConnections
    {
    }
}