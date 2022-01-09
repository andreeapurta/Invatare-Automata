using System;

namespace BackpropagationAlgorithm
{
    public class Neuron
    {
        public double Value { get; set; }
        public double Threshold { get; set; }

        public Neuron()
        {
            Random random = new();
            Threshold = random.NextDouble();
        }
    }
}