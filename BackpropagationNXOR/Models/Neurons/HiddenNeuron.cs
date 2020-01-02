using BackpropagationNXOR.Helpers;
using BackpropagationNXOR.Models.Abstract;
using BackpropagationNXOR.Models.Neurons;
using BackpropagationNXOR.Models.Neurons.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackpropagationNXOR.Models
{
    public class HiddenNeuron : IHiddenNeuron
    {
        private readonly IActivationFunction _activationFunction;
        private List<IConnection> _inputConnections = new List<IConnection>();
        private List<IConnection> _outputsConnections = new List<IConnection>();


        public double NetOutput => _inputConnections.Sum(x => x.Output);
        public double Output =>   _activationFunction.Invoke(NetOutput);

        public HiddenNeuron(IActivationFunction activationFunction)
        {
            _activationFunction = activationFunction;
        }

        public void AddOutputConnection(IConnection connection)
        {
            _outputsConnections.Add(connection);
        }

        public void AddInputConnections(IConnection connection)
        {
            _inputConnections.Add(connection);
        }
    }
}
