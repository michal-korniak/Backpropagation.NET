using BackpropagationNXOR.Models.Abstract;
using BackpropagationNXOR.Models.Connections;
using BackpropagationNXOR.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models
{
    class BiasConnection : IBiasConnection
    {
        private readonly double _weight;
        public double Output => _weight;

        public BiasConnection()
        {
            _weight = RandomHelper.NextDouble();
        }
    }
}
