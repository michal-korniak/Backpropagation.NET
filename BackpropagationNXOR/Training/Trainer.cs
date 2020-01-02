﻿using System;
using System.Linq;
using Backpropagation.NET.Loggers.Abstract;
using Backpropagation.NET.Models.Connections.Abstract;
using Backpropagation.NET.Models.NeuralNetwork.Abstract;
using Backpropagation.NET.Models.Neurons.Abstract.Base;

namespace Backpropagation.NET.Training
{
    class Trainer
    {
        private readonly INeuralNetwork _network;
        private readonly double _learningRate;
        private readonly ILogger _logger;

        public Trainer(INeuralNetwork neuralNetwork, double learningRate, ILogger logger)
        {
            _network = neuralNetwork;
            _learningRate = learningRate;
            _logger = logger;
        }

        public void Train(TrainData[] trainDataCollection, int numberOfEpochs, double terminalEpochError)
        {
            ValidateTrainData(trainDataCollection);

            for (int i = 0; i < numberOfEpochs; ++i)
            {
                var epochError = TrainForSingleEpoch(trainDataCollection);
                _logger.Info($"Epoch {i+1}, error: {epochError}");
                if (epochError <= terminalEpochError)
                {
                    break;
                }

            }
        }
        private void ValidateTrainData(TrainData[] trainDataCollection)
        {
            foreach (var trainData in trainDataCollection)
            {
                if (trainData.Inputs.Length != _network.InputLayer.Count())
                {
                    throw new Exception("Number of input values is not equal to number of input neurons");
                }
                if (trainData.ExpectedOutputs.Length != _network.OutputLayer.Count())
                {
                    throw new Exception("Number of epected output values is not equal to number of output neurons");
                }

            }
        }

        private double TrainForSingleEpoch(TrainData[] trainDataCollection)
        {
            double totalEpochError = 0;
            foreach (var trainData in trainDataCollection)
            {
                _network.FillInputNeurons(trainData.Inputs);
                HandleOutputLayer(trainData.ExpectedOutputs);
                HandleHiddenLayer();
                UpdateWeights();
                totalEpochError += _network.OutputLayer.Sum(x => x.Error);
            }
            return totalEpochError;

        }

        private void HandleOutputLayer(double[] expectedOutputs)
        {
            for (int i = 0; i < expectedOutputs.Length; ++i)
            {
                var outputNeuron = _network.OutputLayer.ElementAt(i);
                var expectedOutput = expectedOutputs[i];

                outputNeuron.CalculateError(_network.ErrorFunction, expectedOutput);
                outputNeuron.CalculateDeltaError(_network.ErrorFunction, expectedOutput);
            }
        }
        private void HandleHiddenLayer()
        {
            foreach (var hiddenNeuron in _network.HiddenLayer)
            {
                hiddenNeuron.CalculateDeltaError();
            }
        }

        private void UpdateWeights()
        {
            var connectionsInNetwork = _network.OutputLayer.SelectMany(x => x.InputConnections).Concat(_network.HiddenLayer.SelectMany(x => x.InputConnections));
            foreach (var connection in connectionsInNetwork)
            {
                if (connection is INeuronConnection neuronConnection)
                {
                    UpdateNeuronConnectionWeight(neuronConnection);
                }
                else if (connection is IBiasConnection biasConnection)
                {
                    UpdateBiasConnectionWeight(biasConnection);
                }
            }
        }
        private void UpdateBiasConnectionWeight(IBiasConnection biasConnection)
        {
            var derivatateOfTotalErrorToWeight = biasConnection.Destinations.Select(x => x as INeuronWithDeltaError).Sum(x => x.DeltaError);
            biasConnection.Weight -= _learningRate * derivatateOfTotalErrorToWeight;
        }
        private void UpdateNeuronConnectionWeight(INeuronConnection neuronConnection)
        {
            var destinationNeuron = neuronConnection.Destination as INeuronWithDeltaError;
            var derivatateOfTotalErrorToWeight = neuronConnection.Input * destinationNeuron.DeltaError;
            neuronConnection.Weight -= _learningRate * derivatateOfTotalErrorToWeight;
        }
    }
}
