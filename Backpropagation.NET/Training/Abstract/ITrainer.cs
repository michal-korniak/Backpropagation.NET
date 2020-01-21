namespace Backpropagation.NET.Training
{
    interface ITrainer
    {
        void Train(TrainData[] trainDataCollection, int numberOfEpochs, double terminalEpochError);
    }
}