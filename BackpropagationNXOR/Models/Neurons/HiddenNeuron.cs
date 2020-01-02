using System.Collections.Generic;
using System.Linq;
using Backpropagation.NET.Models.ActivationFunctions.Abstract;
using Backpropagation.NET.Models.Connections.Abstract;
using Backpropagation.NET.Models.Connections.Abstract.Base;
using Backpropagation.NET.Models.Neurons.Abstract;

namespace Backpropagation.NET.Models.Neurons
{
    public class HiddenNeuron : IHiddenNeuron
    {
        private readonly IActivationFunction _activationFunction;
        private readonly List<IConnection> _inputConnections = new List<IConnection>();
        private readonly List<IConnection> _outputConnections = new List<IConnection>();
        private double _deltaError;

        public double NetOutput => _inputConnections.Sum(x => x.Output);
        public double Output => _activationFunction.Invoke(NetOutput);
        public double DeltaError => _deltaError;
        public IEnumerable<IConnection> InputConnections => _inputConnections;
        public IEnumerable<IConnection> OutputConnections => _outputConnections;

        public HiddenNeuron(IActivationFunction activationFunction)
        {
            _activationFunction = activationFunction;
        }

        public void AddOutputConnection(IConnection connection)
        {
            _outputConnections.Add(connection);
        }

        public void AddInputConnections(IConnection connection)
        {
            _inputConnections.Add(connection);
        }

        public void CalculateDeltaError()
        {
            double derrivateOfTotalErrorToNeuronOutput = 0;
            foreach (var outputConnections in _outputConnections)
            {
                var neuronConnection = outputConnections as INeuronConnection;
                var outputNeuron = neuronConnection.Destination as IOutputNeuron;
                derrivateOfTotalErrorToNeuronOutput += outputNeuron.DeltaError * neuronConnection.Weight;
            }
            _deltaError = derrivateOfTotalErrorToNeuronOutput * _activationFunction.InvokeForDerivate(NetOutput);
        }
    }
}
