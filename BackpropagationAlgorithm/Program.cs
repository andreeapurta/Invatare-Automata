using System;

namespace BackpropagationAlgorithm
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Backpropagation backpropagation = new();
            backpropagation.Compute();
            Console.ReadKey();
        }
    }
}