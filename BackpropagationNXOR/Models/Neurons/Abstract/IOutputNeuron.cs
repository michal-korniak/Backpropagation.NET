using BackpropagationNXOR.Models.Abstract;
using BackpropagationNXOR.Models.Neurons.Abstract.BaseInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Neurons.Abstract
{
    public interface IOutputNeuron : INeuron, INeuronPermitsToAddInputsConnections, INeuronWithDeltaError
    {
        /// <summary>
        /// Sum of connections outputs
        /// </summary>
        public double NetOutput { get; }
        public double Error { get; }


        void CalcualteError(IErrorFunction errorFunction, double expectedOutput);
        void CalculateDeltaError(IErrorFunction errorFunction, double expectedOutput);
    }
}
