using System;
using System.Collections.Generic;
using System.Text;

namespace Runner.ArchitectureTest
{
    public class ArchitectureTestConfig
    {
        public int NumberOfHiddenNeurons { get; private set; }
        public bool EnableBias { get; private set; }

        public ArchitectureTestConfig(int numberOfHiddenNeurons, bool enableBias)
        {
            NumberOfHiddenNeurons = numberOfHiddenNeurons;
            EnableBias = enableBias;
        }
    }
}
