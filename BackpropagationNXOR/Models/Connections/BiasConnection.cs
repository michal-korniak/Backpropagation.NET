using System.Collections.Generic;
using BackpropagationNXOR.Helpers;
using BackpropagationNXOR.Models.Connections.Abstract;
using BackpropagationNXOR.Models.Neurons.Abstract.Base;

namespace BackpropagationNXOR.Models.Connections
{
    class BiasConnection : IBiasConnection
    {
        private List<INeuron> _destinationNeurons = new List<INeuron>();

        public double Output => Weight;
        public double Input => 1;
        public double Weight { get; set; }
        public IEnumerable<INeuron> Destinations => _destinationNeurons;

        public BiasConnection()
        {
            Weight = RandomHelper.NextDouble();
        }

        public void AddDestination(INeuron neuron)
        {
            _destinationNeurons.Add(neuron);
        }
    }
}
