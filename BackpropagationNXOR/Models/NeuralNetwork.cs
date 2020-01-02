using BackpropagationNXOR.Models.Abstract;
using BackpropagationNXOR.Models.Neurons;
using BackpropagationNXOR.Models.Neurons.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackpropagationNXOR.Models
{
    public class NeuralNetwork
    {
        public IEnumerable<IInputNeuron> InputLayer => _inputLayer;
        public IEnumerable<IOutputNeuron> OutputLayer => _outputLayer;
        public IErrorFunction ErrorFunction { get; }

        private List<InputNeuron> _inputLayer = new List<InputNeuron>();
        public List<OutputNeuron> _outputLayer = new List<OutputNeuron>();

        public NeuralNetwork(IErrorFunction errorFunction, List<InputNeuron> inputLayer, List<OutputNeuron> outputLayer)
        {
            ErrorFunction = errorFunction;
            _inputLayer = inputLayer;
            _outputLayer = outputLayer;
        }



    }
}
