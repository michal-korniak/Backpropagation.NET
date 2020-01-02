using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models
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
