using System.Collections.Generic;
using Backpropagation.NET.Helpers;
using Backpropagation.NET.Models.Connections.Abstract;
using Backpropagation.NET.Models.Neurons.Abstract.Base;

namespace Backpropagation.NET.Models.Connections
{
    public class BiasConnection : IBiasConnection
    {
        private readonly List<INeuron> _destinationNeurons = new List<INeuron>();

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
