using System.Collections.Generic;
using Backpropagation.NET.Models.ErrorFunctions.Abstract;
using Backpropagation.NET.Models.Neurons.Abstract;

namespace Backpropagation.NET.Models.NeuralNetwork.Abstract
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