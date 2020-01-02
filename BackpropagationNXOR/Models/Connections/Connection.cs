using BackpropagationNXOR.Models.Abstract;
using BackpropagationNXOR.Models.Neurons;
using BackpropagationNXOR.Models.Neurons.Abstract;
using BackpropagationNXOR.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models
{
    class Connection: IConnection
    {
        private INeuron _source;
        private INeuron _destination;
        private double _weight;

        public double Output => _weight * _source.Output;

        public Connection(INeuronPermitsToAddOutputsConnections source, INeuronPermitsToAddInputsConnections destination)
        {
            _source = source;
            _destination = destination;
            _weight = RandomHelper.NextDouble();
        }
    }
}
