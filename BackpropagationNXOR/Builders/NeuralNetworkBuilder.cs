using BackpropagationNXOR.Helpers;
using BackpropagationNXOR.Models;
using BackpropagationNXOR.Models.Neurons;
using System;
using System.Collections.Generic;
using System.Text;
using BackpropagationNXOR.Models.ActivationFunctions.Abstract;
using BackpropagationNXOR.Models.Connections;
using BackpropagationNXOR.Models.ErrorFunctions.Abstract;

namespace BackpropagationNXOR.Builders
{
    class NeuralNetworkBuilder
    {
        private IErrorFunction _errorFunction;
        private IActivationFunction _activationFunction;

        private int _numberOfInputNeurons;
        private int _numberOfHiddenNeurons;
        private int _numberOfOutputNeurons;
        private bool _enableBias;


        public NeuralNetworkBuilder SetErrorFunction(IErrorFunction errorFunction)
        {
            _errorFunction = errorFunction;

            return this;
        }

        public NeuralNetworkBuilder SetActivationFunction(IActivationFunction activationFunction)
        {
            _activationFunction = activationFunction;

            return this;
        }

        public NeuralNetworkBuilder SetNumberOfInputNeurons(int numberOfInputNeurons)
        {
            _numberOfInputNeurons = numberOfInputNeurons;

            return this;
        }

        public NeuralNetworkBuilder SetNumberOfOutputNeurons(int numberOfOutputsNeurons)
        {
            _numberOfOutputNeurons = numberOfOutputsNeurons;

            return this;
        }

        public NeuralNetworkBuilder SetNumberOfHiddenNeurons(int numberOfHiddenNeurons)
        {
            _numberOfHiddenNeurons = numberOfHiddenNeurons;

            return this;
        }

        public NeuralNetworkBuilder AddBiasConnections()
        {
            _enableBias = true;

            return this;
        }


        public NeuralNetwork Build()
        {
            ValidateBeforeBuild();

            var inputLayer = CreateInputLayer();
            var hiddenLayer = CreateHiddenLayer();
            var outputLayer = CreateOutputLayer();

            CreateConnections(inputLayer, hiddenLayer, outputLayer);

            return new NeuralNetwork(_errorFunction, inputLayer, hiddenLayer, outputLayer);
        }

        private void ValidateBeforeBuild()
        {
            if (_errorFunction == null)
            {
                throw new Exception("Error function have to be defined");
            }
            if (_numberOfInputNeurons <= 0)
            {
                throw new Exception("Number of input neurons should be greater than 0");
            }
            if (_numberOfOutputNeurons <= 0)
            {
                throw new Exception("Number of output neurons should be greater than 0");
            }
            if (_activationFunction == null)
            {
                throw new Exception("Activation function should to be defined");
            }
        }
        private List<InputNeuron> CreateInputLayer()
        {
            var inputLayer = new List<InputNeuron>();
            for (int i = 0; i < _numberOfInputNeurons; ++i)
            {
                inputLayer.Add(new InputNeuron());
            }

            return inputLayer;
        }
        private List<HiddenNeuron> CreateHiddenLayer()
        {
            var hiddenLayer = new List<HiddenNeuron>();
            for (int i = 0; i < _numberOfHiddenNeurons; ++i)
            {
                hiddenLayer.Add(new HiddenNeuron(_activationFunction));
            }

            return hiddenLayer;
        }
        private List<OutputNeuron> CreateOutputLayer()
        {
            var outputLayer = new List<OutputNeuron>();
            for (int i = 0; i < _numberOfOutputNeurons; ++i)
            {
                outputLayer.Add(new OutputNeuron(_activationFunction));
            }

            return outputLayer;
        }
        private void CreateConnections(List<InputNeuron> inputLayer, List<HiddenNeuron> hiddenLayer, List<OutputNeuron> outputLayer)
        {
            CreateConnectionsBetweenLayers(inputLayer, hiddenLayer, outputLayer);
            if (_enableBias)
            {
                CreateConnectionsToBias(hiddenLayer, outputLayer);
            }


        }

        private static void CreateConnectionsBetweenLayers(List<InputNeuron> inputLayer, List<HiddenNeuron> hiddenLayer, List<OutputNeuron> outputLayer)
        {
            if (hiddenLayer.Count > 0)
            {
                foreach (var hiddenNeuron in hiddenLayer)
                {
                    foreach (var inputNeuron in inputLayer)
                    {
                        ConnectionManager.CreateConnection(inputNeuron, hiddenNeuron);
                    }
                    foreach (var outputNeuron in outputLayer)
                    {
                        ConnectionManager.CreateConnection(hiddenNeuron, outputNeuron);
                    }

                }
            }
            else
            {
                foreach (var inputNeuron in inputLayer)
                {
                    foreach (var outputNeuron in outputLayer)
                    {
                        ConnectionManager.CreateConnection(inputNeuron, outputNeuron);
                    }
                }
            }
        }


        private static void CreateConnectionsToBias(List<HiddenNeuron> hiddenLayer, List<OutputNeuron> outputLayer)
        {
            var hiddenLayerBias = new BiasConnection();
            var outputLayerBias = new BiasConnection();
            foreach (var hiddenNeuron in hiddenLayer)
            {
                ConnectionManager.CreateConnectionToBias(hiddenNeuron, hiddenLayerBias);
            }
            foreach (var outputNeuron in outputLayer)
            {
                ConnectionManager.CreateConnectionToBias(outputNeuron, outputLayerBias);
            }
        }

    }
}
