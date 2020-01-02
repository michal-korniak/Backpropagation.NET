using System.Collections.Generic;
using Backpropagation.NET.Models.Connections.Abstract.Base;
using Backpropagation.NET.Models.Neurons.Abstract;

namespace Backpropagation.NET.Models.Neurons
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
