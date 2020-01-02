using System.Collections.Generic;
using System.Linq;
using BackpropagationNXOR.Models.ActivationFunctions.Abstract;
using BackpropagationNXOR.Models.Connections.Abstract;
using BackpropagationNXOR.Models.Connections.Abstract.Base;
using BackpropagationNXOR.Models.Neurons.Abstract;

namespace BackpropagationNXOR.Models.Neurons
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
