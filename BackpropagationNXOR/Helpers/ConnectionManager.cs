using BackpropagationNXOR.Models;
using BackpropagationNXOR.Models.Connections;
using BackpropagationNXOR.Models.Neurons;
using BackpropagationNXOR.Models.Neurons.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Helpers
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
