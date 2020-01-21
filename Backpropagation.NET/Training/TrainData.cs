namespace Backpropagation.NET.Training
{
    public class TrainData
    {
        public double[] Inputs { get;}
        public double[] ExpectedOutputs { get; }

        public TrainData(double[] inputs, double[] expectedOutputs)
        {
            Inputs = inputs;
            ExpectedOutputs = expectedOutputs;
        }
    }
}
