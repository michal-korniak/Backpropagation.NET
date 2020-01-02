using BackpropagationNXOR.Models.Neurons;
using BackpropagationNXOR.Models.Neurons.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackpropagationNXOR.Models.ErrorFunctions.Abstract;

namespace BackpropagationNXOR.Models
{
    public class NeuralNetwork
    {
        public IEnumerable<IInputNeuron> InputLayer => _inputLayer;
        public IEnumerable<IHiddenNeuron> HiddenLayer => _hiddenLayer;
        public IEnumerable<IOutputNeuron> OutputLayer => _outputLayer;
        public IErrorFunction ErrorFunction { get; }

        private List<InputNeuron> _inputLayer = new List<InputNeuron>();
        private List<HiddenNeuron> _hiddenLayer = new List<HiddenNeuron>();
        private List<OutputNeuron> _outputLayer = new List<OutputNeuron>();

        public NeuralNetwork(IErrorFunction errorFunction, List<InputNeuron> inputLayer, List<HiddenNeuron> hiddenLayer, List<OutputNeuron> outputLayer)
        {
            ErrorFunction = errorFunction;
            _inputLayer = inputLayer;
            _hiddenLayer = hiddenLayer;
            _outputLayer = outputLayer;
        }


        public void FillInputNeurons(IEnumerable<double> input)
        {
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
