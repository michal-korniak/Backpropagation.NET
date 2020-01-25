using Backpropagation.NET.Builders;
using Backpropagation.NET.Loggers.Abstract;
using Backpropagation.NET.Models.ActivationFunctions;
using Backpropagation.NET.Models.ErrorFunctions;
using Backpropagation.NET.Models.NeuralNetwork;
using Backpropagation.NET.Training;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runner
{
    public static class Examples
    {
        public static void UnipolarNXORExample(ILogger logger)
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

            TestNetwork(network, trainDataCollection, logger);
        }
        public static void BipolarNXORExample(ILogger logger)
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

            TestNetwork(network, trainDataCollection, logger);

        }

        private static void TestNetwork(NeuralNetwork network, TrainData[] trainDataCollection, ILogger logger)
        {
            Console.WriteLine("Test: ");
            foreach (var trainData in trainDataCollection)
            {
                network.FillInputNeurons(trainData.Inputs);
                var output = network.CalculateOutput();
                Console.WriteLine($"F({string.Join(",", trainData.Inputs)})=({string.Join(",", output)}) [expected = {string.Join(",", trainData.ExpectedOutputs)}]");
            }
        }
    }
}
