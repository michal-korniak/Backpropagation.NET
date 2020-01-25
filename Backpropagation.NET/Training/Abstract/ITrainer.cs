namespace Backpropagation.NET.Training
{
    interface ITrainer
    {
        TrainStats Train(TrainData[] trainDataCollection, int numberOfEpochs, double terminalEpochError);
    }
}