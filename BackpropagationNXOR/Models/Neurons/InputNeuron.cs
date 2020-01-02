using BackpropagationNXOR.Models.Neurons.Abstract;
using System.Collections.Generic;
using BackpropagationNXOR.Models.Connections.Abstract.Base;

namespace BackpropagationNXOR.Models.Neurons
{
    public class InputNeuron : IInputNeuron
    {
        public double Output { get; set; }
        private readonly List<IConnection> _outputsConnections = new List<IConnection>();

        public IEnumerable<IConnection> OutputConnections => _outputsConnections;

        public void AddOutputConnection(IConnection connection)
        {
            _outputsConnections.Add(connection);
        }
    }
}
