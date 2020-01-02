using BackpropagationNXOR.Builders;
using BackpropagationNXOR.Helpers;
using BackpropagationNXOR.Models;
using BackpropagationNXOR.Models.ErrorFunctions;
using BackpropagationNXOR.Models.Neurons;
using BackpropagationNXOR.Models.Training;
using System;

namespace BackpropagationNXOR
{
    class Program
    {
        static void Main(string[] args)
        {
            var neuralNetworkBuilder = new NeuralNetworkBuilder();
            var network = neuralNetworkBuilder.EnableBiasConnection()
                .SetActivationFunction(new SigmoidActivationFunction())
                .SetErrorFunction(new MeanSquaredErrorFunction())
                .SetNumberOfInputNeurons(2)
                .SetNumberOfHiddenNeurons(2)
                .SetNumberOfOutputNeurons(1)
                .Build();


            var trainer = new Trainer(network, 0.1);
            var trainDataCollection = new[]
            {
                new TrainData(new []{ 0.0, 0.0 },new [] { 1.0 } )
            };
            trainer.Train(trainDataCollection, 1, 0.0001);
        }
    }
}
