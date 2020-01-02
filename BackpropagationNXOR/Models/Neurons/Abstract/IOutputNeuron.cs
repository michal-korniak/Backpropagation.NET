using BackpropagationNXOR.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Neurons.Abstract
{
    public interface IOutputNeuron : INeuron, INeuronPermitsToAddInputsConnections
    {
        public double NetOutput { get; }
        public double Error { get; }
        public double DeltaError { get; }

        void SetError(IErrorFunction errorFunction, double expectedOutput);
        void SetDeltaError(IErrorFunction errorFunction, double expectedOutput);
    }
}
