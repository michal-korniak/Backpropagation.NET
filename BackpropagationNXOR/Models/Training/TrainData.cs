using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models
{
    public class TrainData
    {
        public double[] Input { get;}
        public double[] ExpectedOutput { get; }

        public TrainData(double[] input, double[] expectedOutput)
        {
            Input = input;
            ExpectedOutput = expectedOutput;
        }
    }
}
