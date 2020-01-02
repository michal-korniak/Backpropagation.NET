using BackpropagationNXOR.Models.Connections;
using BackpropagationNXOR.Models.Neurons;
using BackpropagationNXOR.Models.Neurons.Abstract;
using BackpropagationNXOR.Services;

namespace BackpropagationNXOR.Models
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
