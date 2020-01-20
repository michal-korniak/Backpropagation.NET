using System;
using Backpropagation.NET.Builders;
using Backpropagation.NET.Loggers;
using Backpropagation.NET.Models.ActivationFunctions;
using Backpropagation.NET.Models.ErrorFunctions;
using Backpropagation.NET.Training;

namespace Backpropagation.NET
{
    class Program
    {
        static void Main()
        {
            UnipolarNXORExample();
            Console.ReadKey();
        }
        static void UnipolarNXORExample()
        {
            var neuralNetworkBuilder = new NeuralNetworkBuilder();
            var network = neuralNetworkBuilder
                .AddBiasConnections()
                .SetActivationFunction(new SigmoidActivationFunction())
                .SetErrorFunction(new MeanSquaredErrorFunction(1))
                .SetNumberOfInputNeurons(2)
                .SetNumberOfHiddenNeurons(3)
                .SetNumberOfOutputNeurons(1)
                .Build();


            var trainer = new Trainer(neuralNetwork: network, learningRate: 0.01, logger: new QuickConsoleLogger());
            var trainDataCollection = new[]
            {
                new TrainData(new double []{ 0, 0 },new double [] { 1 } ),
                new TrainData(new double []{ 1, 0 },new double [] { 0 } ),
                new TrainData(new double []{ 0, 1 },new double [] { 0 } ),
                new TrainData(new double []{ 1, 1 },new double [] { 1 } ),
            };
            trainer.Train(trainDataCollection, numberOfEpochs: 100000, terminalEpochError: 0.01);


            foreach (var trainData in trainDataCollection)
            {
                network.FillInputNeurons(trainData.Inputs);
                var output = network.CalculateOutput();
                Console.WriteLine($"F({string.Join(",", trainData.Inputs)})=({string.Join(",", output)}) [expected={string.Join(",", trainData.ExpectedOutputs)}]");
            }

        }
        static void BipolarNXORExample()
        {
            var neuralNetworkBuilder = new NeuralNetworkBuilder();
            var network = neuralNetworkBuilder
                .AddBiasConnections()
                .SetActivationFunction(new TANHActivationFunction())
                .SetErrorFunction(new MeanSquaredErrorFunction(1))
                .SetNumberOfInputNeurons(2)
                .SetNumberOfHiddenNeurons(3)
                .SetNumberOfOutputNeurons(1)
                .Build();


            var trainer = new Trainer(neuralNetwork: network, learningRate: 0.01, logger: new ConsoleLogger());
            var trainDataCollection = new[]
            {
                new TrainData(new double []{ -1, -1 },new double [] { 1 } ),
                new TrainData(new double []{ 1, -1 },new double [] { -1 } ),
                new TrainData(new double []{ -1, 1 },new double [] { -1 } ),
                new TrainData(new double []{ 1, 1 },new double [] { 1 } ),
            };
            trainer.Train(trainDataCollection, numberOfEpochs: 100000, terminalEpochError: 0.01);


            foreach (var trainData in trainDataCollection)
            {
                network.FillInputNeurons(trainData.Inputs);
                var output = network.CalculateOutput();
                Console.WriteLine($"F({string.Join(",", trainData.Inputs)})=({string.Join(",", output)}) [expected={string.Join(",", trainData.ExpectedOutputs)}]");
            }

        }
    }
}
