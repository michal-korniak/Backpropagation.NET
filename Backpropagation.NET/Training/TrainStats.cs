using System;
using System.Collections.Generic;
using System.Text;

namespace Backpropagation.NET.Training
{
    public class TrainStats
    {
        public int NumberOfEpochs { get; private set; }
        public double Error { get; private set; }
        public double ElapsedSeconds { get; set; }

        public TrainStats(int numberOfEpochs, double error, double elapsedSeconds)
        {
            NumberOfEpochs = numberOfEpochs;
            Error = error;
            ElapsedSeconds = elapsedSeconds;
        }
    }
}
