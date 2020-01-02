using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackpropagationNXOR.Models.Training
{
    class Trainer
    {
        private readonly NeuralNetwork _network;
        private readonly double _learningRate;

        public Trainer(NeuralNetwork neuralNetwork, double learningRate)
        {
            _network = neuralNetwork;
            _learningRate = learningRate;
        }

        public void Train(TrainData[] trainDataCollection, int numberOfEpochs, double terminalEpochError)
        {
            ValidateTrainData(trainDataCollection);

            for (int i = 0; i < numberOfEpochs; ++i)
            {
                var epochError = TrainForSingleEpoch(trainDataCollection);
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
                if (trainData.Input.Length != _network.InputLayer.Count())
                {
                    throw new Exception("Number of input values is not equal to number of input neurons");
                }
                if (trainData.ExpectedOutput.Length != _network.OutputLayer.Count())
                {
                    throw new Exception("Number of epected output values is not equal to number of output neurons");
                }

            }
        }
        private double TrainForSingleEpoch(TrainData[] trainDataCollection)
        {
            double epochError = 0;
            foreach (var trainData in trainDataCollection)
            {
                FillInputs(trainData);
                epochError += CalculateOutputsError(trainData);
            }
            return epochError;
        }

        private void FillInputs(TrainData trainData)
        {
            for (int i = 0; i < trainData.Input.Length; ++i)
            {
                _network.InputLayer.ElementAt(i).Output = trainData.Input[i];
            }
        }
        private double CalculateOutputsError(TrainData trainData)
        {
            double totalError = 0;
            for (int i = 0; i < trainData.ExpectedOutput.Length; ++i)
            {
                var outputNeuron = _network.OutputLayer.ElementAt(i);
                var expectedOutput = trainData.ExpectedOutput[i];

                outputNeuron.SetError(_network.ErrorFunction, expectedOutput);
                outputNeuron.SetDeltaError(_network.ErrorFunction, expectedOutput);
                totalError += outputNeuron.Error;
            }

            return totalError;
        }
    }
}
