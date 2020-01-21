using System;
using System.Collections.Generic;
using System.Linq;
using Backpropagation.NET.Models.ErrorFunctions.Abstract;
using Backpropagation.NET.Models.NeuralNetwork.Abstract;
using Backpropagation.NET.Models.Neurons;
using Backpropagation.NET.Models.Neurons.Abstract;

namespace Backpropagation.NET.Models.NeuralNetwork
{
    public class NeuralNetwork : INeuralNetwork
    {
        public IEnumerable<IInputNeuron> InputLayer => _inputLayer;
        public IEnumerable<IHiddenNeuron> HiddenLayer => _hiddenLayer;
        public IEnumerable<IOutputNeuron> OutputLayer => _outputLayer;
        public IErrorFunction ErrorFunction { get; }

        private readonly List<InputNeuron> _inputLayer = new List<InputNeuron>();
        private readonly List<HiddenNeuron> _hiddenLayer = new List<HiddenNeuron>();
        private readonly List<OutputNeuron> _outputLayer = new List<OutputNeuron>();

        public NeuralNetwork(IErrorFunction errorFunction, List<InputNeuron> inputLayer, List<HiddenNeuron> hiddenLayer, List<OutputNeuron> outputLayer)
        {
            ErrorFunction = errorFunction;
            _inputLayer = inputLayer;
            _hiddenLayer = hiddenLayer;
            _outputLayer = outputLayer;
        }


        public void FillInputNeurons(IEnumerable<double> input)
        {
            if(input.Count() !=_inputLayer.Count)
            {
                throw new ArgumentException("Length of input collection is not equal to number of input neurons");
            }
            for (int i = 0; i < input.Count(); ++i)
            {
                InputLayer.ElementAt(i).Output = input.ElementAt(i);
            }
        }
        public IEnumerable<double> CalculateOutput()
        {
            return _outputLayer.Select(x => x.Output);
        }



    }
}
