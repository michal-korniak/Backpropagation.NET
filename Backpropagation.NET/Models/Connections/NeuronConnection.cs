using Backpropagation.NET.Helpers;
using Backpropagation.NET.Models.Connections.Abstract;
using Backpropagation.NET.Models.Neurons.Abstract.Base;

namespace Backpropagation.NET.Models.Connections
{
    public class NeuronConnection: INeuronConnection
    {
        private readonly INeuron _source;
        private readonly INeuron _destination;

        public double Weight { get; set; }
        public double Output => Weight * _source.Output;
        public double Input => _source.Output;
        public INeuron Source => _source;
        public INeuron Destination => _destination;

        public NeuronConnection(INeuronPermitsToAddOutputsConnections source, INeuronPermitsToAddInputsConnections destination)
        {
            _source = source;
            _destination = destination;
            Weight = RandomHelper.NextDouble();
        }


    }
}
