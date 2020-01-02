using BackpropagationNXOR.Helpers;
using BackpropagationNXOR.Models.Abstract;
using BackpropagationNXOR.Models.Neurons.Abstract;
using System.Collections.Generic;

namespace BackpropagationNXOR.Models.Neurons
{
    public class InputNeuron : IInputNeuron
    {
        public double Output { get; set; }
        private List<IConnection> _outputsConnections = new List<IConnection>();

        public IEnumerable<IConnection> OutputConnections => _outputsConnections;

        public void AddOutputConnection(IConnection connection)
        {
            _outputsConnections.Add(connection);
        }
    }
}
