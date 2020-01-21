using Backpropagation.NET.Models.ActivationFunctions.Abstract;
using Backpropagation.NET.Models.ErrorFunctions.Abstract;
using Backpropagation.NET.Models.NeuralNetwork;

namespace Backpropagation.NET.Builders.Abstract
{
    interface INeuralNetworkBuilder
    {
        NeuralNetworkBuilder AddBiasConnections();
        NeuralNetwork Build();
        NeuralNetworkBuilder SetActivationFunction(IActivationFunction activationFunction);
        NeuralNetworkBuilder SetErrorFunction(IErrorFunction errorFunction);
        NeuralNetworkBuilder SetNumberOfHiddenNeurons(int numberOfHiddenNeurons);
        NeuralNetworkBuilder SetNumberOfInputNeurons(int numberOfInputNeurons);
        NeuralNetworkBuilder SetNumberOfOutputNeurons(int numberOfOutputsNeurons);
    }
}