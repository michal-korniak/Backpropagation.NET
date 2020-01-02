namespace Backpropagation.NET.Models.Neurons.Abstract.Base
{
    public interface INeuronWithDeltaError: INeuron
    {
        /// <summary>
        /// Derivatate of total error in respect to net output
        /// </summary>
        public double DeltaError { get; }
    }
}
