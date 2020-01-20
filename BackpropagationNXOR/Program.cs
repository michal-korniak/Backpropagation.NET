using System;
using Backpropagation.NET.Builders;
using Backpropagation.NET.Factories;
using Backpropagation.NET.Loggers;
using Backpropagation.NET.Loggers.Abstract;
using Backpropagation.NET.Models.ActivationFunctions;
using Backpropagation.NET.Models.ErrorFunctions;
using Backpropagation.NET.Training;

namespace Backpropagation.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length!=1)
            {
                throw new Exception("Invoke with logger name argument");
            }
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.Create(args[0]);

            UnipolarNXORExample(logger);
            Console.ReadKey();
        }
        static void UnipolarNXORExample(ILogger logger)
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


            var trainer = new Trainer(neuralNetwork: network, learningRate: 0.01, logger: logger);
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
        static void BipolarNXORExample(ILogger logger)
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


            var trainer = new Trainer(neuralNetwork: network, learningRate: 0.01, logger: logger);
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
