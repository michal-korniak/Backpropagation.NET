using System;
using System.Collections.Generic;
using System.Text;

namespace BackpropagationNXOR.Models.Abstract
{
    public interface IConnection
    {
        double Output { get; }
        double Input { get; }
        double Weight { get; set; }
       
    }
}
