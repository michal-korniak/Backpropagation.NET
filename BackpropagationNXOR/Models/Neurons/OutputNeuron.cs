﻿using System.Collections.Generic;
using System.Linq;
using BackpropagationNXOR.Models.ActivationFunctions.Abstract;
using BackpropagationNXOR.Models.Connections.Abstract.Base;
using BackpropagationNXOR.Models.ErrorFunctions.Abstract;
using BackpropagationNXOR.Models.Neurons.Abstract;

namespace BackpropagationNXOR.Models.Neurons
{
    public class OutputNeuron : IOutputNeuron
    {
        private readonly IActivationFunction _activationFunction;
        private readonly List<IConnection> _inputConnections = new List<IConnection>();
        private double _error;
        private double _deltaError;


        public double NetOutput => _inputConnections.Sum(x => x.Output);
        public double Output => _activationFunction.Invoke(NetOutput);
        public double Error => _error;
        public double DeltaError => _deltaError;
        public IEnumerable<IConnection> InputConnections => _inputConnections;

        public OutputNeuron(IActivationFunction activationFunction)
        {
            _activationFunction = activationFunction;
        }

        public void AddInputConnections(IConnection connection)
        {
            _inputConnections.Add(connection);
        }

        public void CalculateError(IErrorFunction errorFunction, double expectedOutput)
        {
            _error = errorFunction.Invoke(Output, expectedOutput);
        }

        public void CalculateDeltaError(IErrorFunction errorFunction, double expectedOutput)
        {
            _deltaError = errorFunction.InvokeForDerivate(Output, expectedOutput) * _activationFunction.InvokeForDerivate(NetOutput);
        }
    }
}
