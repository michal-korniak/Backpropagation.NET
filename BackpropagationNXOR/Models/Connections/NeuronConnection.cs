using BackpropagationNXOR.Helpers;
using BackpropagationNXOR.Models.Connections.Abstract;
using BackpropagationNXOR.Models.Neurons.Abstract.Base;

namespace BackpropagationNXOR.Models.Connections
{
    class NeuronConnection: INeuronConnection
    {
        private INeuron _source;
        private INeuron _destination;

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
