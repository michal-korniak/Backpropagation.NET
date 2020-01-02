using System.Collections.Generic;
using BackpropagationNXOR.Models.ErrorFunctions.Abstract;
using BackpropagationNXOR.Models.Neurons.Abstract;

namespace BackpropagationNXOR.Models.NeuralNetwork.Abstract
{
    public interface INeuralNetwork
    {
        IEnumerable<IInputNeuron> InputLayer { get; }
        IEnumerable<IHiddenNeuron> HiddenLayer { get; }
        IEnumerable<IOutputNeuron> OutputLayer { get; }
        IErrorFunction ErrorFunction { get; }
        void FillInputNeurons(IEnumerable<double> input);
        IEnumerable<double> CalculateOutput();
    }
}