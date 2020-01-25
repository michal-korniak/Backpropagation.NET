using Backpropagation.NET.Builders;
using Backpropagation.NET.Loggers;
using Backpropagation.NET.Loggers.Abstract;
using Backpropagation.NET.Models.ActivationFunctions;
using Backpropagation.NET.Models.ErrorFunctions;
using Backpropagation.NET.Models.NeuralNetwork;
using Backpropagation.NET.Training;
using Runner.Extensions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Runner.ArchitectureTest
{
    public class UnipolarNXORArchitectureTest
    {
        private readonly int _maxNumberOfEpochs;
        private readonly double _terminalEpochError;
        private readonly int _numberOfTests;

        public UnipolarNXORArchitectureTest(int maxNumberOfEpochs, double terminalEpochError, int numberOfTests)
        {
            _maxNumberOfEpochs = maxNumberOfEpochs;
            _terminalEpochError = terminalEpochError;
            _numberOfTests = numberOfTests;
        }

        public void Run()
        {
            var testConfigs = new List<ArchitectureTestConfig>()
            {
                new ArchitectureTestConfig(numberOfHiddenNeurons: 1, enableBias: false),
                new ArchitectureTestConfig(numberOfHiddenNeurons: 2, enableBias: false),
                new ArchitectureTestConfig(numberOfHiddenNeurons: 3, enableBias: false),
                new ArchitectureTestConfig(numberOfHiddenNeurons: 4, enableBias: false),
                new ArchitectureTestConfig(numberOfHiddenNeurons: 5, enableBias: false),
                new ArchitectureTestConfig(numberOfHiddenNeurons: 1, enableBias: true),
                new ArchitectureTestConfig(numberOfHiddenNeurons: 2, enableBias: true),
                new ArchitectureTestConfig(numberOfHiddenNeurons: 3, enableBias: true),
                new ArchitectureTestConfig(numberOfHiddenNeurons: 4, enableBias: true),
                new ArchitectureTestConfig(numberOfHiddenNeurons: 5, enableBias: true),
            };

            foreach (var testConfig in testConfigs)
            {
                var trainStatsCollection = TestConfiguration(testConfig);

                Console.WriteLine($"Number of neurons in hidden layer: {testConfig.NumberOfHiddenNeurons}");
                Console.WriteLine($"Bias: {(testConfig.EnableBias ? "YES" : "NO")}");

                double medianNumberOfEpochs = trainStatsCollection.Median(x => x.NumberOfEpochs);
                double medianError = trainStatsCollection.Median(x => x.Error);
                double elapsedSeconds = trainStatsCollection.Median(x => x.ElapsedSeconds);
                Console.WriteLine($"Median results: ");
                Console.WriteLine($"Number of epochs: {medianNumberOfEpochs}, average error: {medianError}, elapsed time: {elapsedSeconds} seconds");
                Console.WriteLine();
            }
        }

        private IEnumerable<TrainStats> TestConfiguration(ArchitectureTestConfig config)
        {
            var trainStatsCollection = new ConcurrentBag<TrainStats>();
            Parallel.For(0, _numberOfTests, x =>
            {
                trainStatsCollection.Add(ExecuteSingleIteration(config));
            });

            return trainStatsCollection;
        }
        private TrainStats ExecuteSingleIteration(ArchitectureTestConfig config)
        {
            var neuralNetworkBuilder = new NeuralNetworkBuilder()
                .SetActivationFunction(new SigmoidActivationFunction())
                .SetErrorFunction(new MeanSquaredErrorFunction(1))
                .SetNumberOfInputNeurons(2)
                .SetNumberOfHiddenNeurons(config.NumberOfHiddenNeurons)
                .SetNumberOfOutputNeurons(1);

            if (config.EnableBias)
            {
                neuralNetworkBuilder.AddBiasConnections();
            }

            var network = neuralNetworkBuilder.Build();

            var trainer = new Trainer(neuralNetwork: network, learningRate: 0.01, logger: new DummyLogger());
            var trainDataCollection = new[]
            {
                new TrainData(new double []{ 0, 0 },new double [] { 1 } ),
                new TrainData(new double []{ 1, 0 },new double [] { 0 } ),
                new TrainData(new double []{ 0, 1 },new double [] { 0 } ),
                new TrainData(new double []{ 1, 1 },new double [] { 1 } ),
            };
            var trainStats = trainer.Train(trainDataCollection, numberOfEpochs: _maxNumberOfEpochs, terminalEpochError: _terminalEpochError);

            return trainStats;
        }
    }
}
