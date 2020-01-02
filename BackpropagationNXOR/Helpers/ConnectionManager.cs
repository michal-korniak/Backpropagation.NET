using Backpropagation.NET.Models.Connections;
using Backpropagation.NET.Models.Connections.Abstract;
using Backpropagation.NET.Models.Neurons.Abstract.Base;

namespace Backpropagation.NET.Helpers
{
    public static class ConnectionManager
    {
        public static void CreateConnection(INeuronPermitsToAddOutputsConnections source, INeuronPermitsToAddInputsConnections destination)
        {
            var connection = new NeuronConnection(source, destination);
            source.AddOutputConnection(connection);
            destination.AddInputConnections(connection);
        }

        public static void CreateConnectionToBias(INeuronPermitsToAddInputsConnections neuron, IBiasConnection biasConnection)
        {
            neuron.AddInputConnections(biasConnection);
            biasConnection.AddDestination(neuron);
        }
    }
}
