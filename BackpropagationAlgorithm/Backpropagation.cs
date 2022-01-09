using System;
using System.Collections.Generic;

namespace BackpropagationAlgorithm
{
    public class Backpropagation
    {
        private readonly int hiddenLayer = 2;
        private readonly double learningRate = 1;
        private readonly int outputLayer = 1;
        private readonly int outsideEntries = 2;
        private readonly double finish = Math.Pow(10, -28);
        private int epoch = 1;
        private double epochError = 1;
        private Entry<Neuron>[] hiddenLayerNeurons;
        private Neuron[] outputNeurons;
        private Entry<double>[] outsideEntriesList;
        private Random rnd;
        private List<XOR> XORs;

        public Backpropagation()
        {
            Initialize();
        }

        public void Compute()
        {
            while (epochError > finish)
            {
                epochError = 0;
                foreach (var element in XORs)
                {
                    Console.WriteLine("Input [{0}, {1}]: ", element.X1, element.X2);

                    outsideEntriesList[0].Value = element.X1;
                    outsideEntriesList[1].Value = element.X2;

                    ComputeHiddenNeurons();
                    ComputeOutputNeurons();

                    epochError += ComputeTotalError(element.Result);

                    RecomputeOutputLayerBiases(element.Result);
                    UpdateHiddenLayerBiases(element.Result);
                    RecomputeInputWeights(element.Result);
                    UpdateHiddenLayerWeights(element.Result);
                }

                Console.WriteLine("Epoch {0}, Error {1}: ", epoch++, epochError);
            }
        }

        public void Initialize()
        {
            rnd = new Random();

            XORs = new List<XOR>
            {
                new XOR(0.1, 0.1, 0.1),
                new XOR(0.1, 0.9, 0.9),
                new XOR(0.9, 0.1, 0.9),
                new XOR(0.9, 0.9, 0.1)
            };

            outsideEntriesList = new Entry<double>[outsideEntries];

            double[] entryWeights = new double[hiddenLayer];
            for (int i = 0; i < hiddenLayer; i++)
            {
                entryWeights[i] = rnd.NextDouble();
            }

            for (int i = 0; i < outsideEntries; i++)
            {
                outsideEntriesList[i] = new Entry<double>(0, entryWeights);
            }

            double[] hiddenLayerWeights = new double[outputLayer];
            for (int j = 0; j < outputLayer; j++)
            {
                hiddenLayerWeights[j] = rnd.NextDouble();
            }

            hiddenLayerNeurons = new Entry<Neuron>[hiddenLayer];
            for (int i = 0; i < hiddenLayer; i++)
            {
                hiddenLayerNeurons[i] = new Entry<Neuron>(new Neuron(), hiddenLayerWeights);
            }

            outputNeurons = new Neuron[outputLayer];
            for (int i = 0; i < outputLayer; i++)
            {
                outputNeurons[i] = new Neuron();
            }
        }

        private void ComputeHiddenNeurons()
        {
            for (int i = 0; i < hiddenLayer; i++)
            {
                double S = 0;
                for (int j = 0; j < outsideEntries; j++)
                {
                    S += outsideEntriesList[j].Value * outsideEntriesList[j].Weights[i];
                }
                hiddenLayerNeurons[i].Value.Value = S + hiddenLayerNeurons[i].Value.Threshold;
                hiddenLayerNeurons[i].Value.Value = 1 / (1 + Math.Exp(-hiddenLayerNeurons[i].Value.Value));
            }
        }

        private void ComputeOutputNeurons()
        {
            for (int i = 0; i < outputLayer; i++)
            {
                double S = 0;
                for (int j = 0; j < hiddenLayer; j++)
                {
                    S += hiddenLayerNeurons[j].Value.Value * hiddenLayerNeurons[j].Weights[i];
                }
                outputNeurons[i].Value = S + outputNeurons[i].Threshold;
                outputNeurons[i].Value = 1 / (1 + Math.Exp(-outputNeurons[i].Value));
                Console.WriteLine("Output: {0}", outputNeurons[i].Value);
            }
        }

        private double ComputeTotalError(double output)
        {
            double error = 0;
            for (int i = 0; i < outputLayer; i++)
            {
                error += Math.Pow(outputNeurons[i].Value - output, 2);
            }
            return error;
        }

        private double F(double value)
        {
            return value * (1 - value);
        }

        private void UpdateHiddenLayerBiases(double result)
        {
            foreach (var neuron in hiddenLayerNeurons)
            {
                double S = 0;
                for (int i = 0; i < outputLayer; i++)
                {
                    S += (outputNeurons[i].Value - result) * F(outputNeurons[i].Value) * neuron.Weights[i];
                }
                double derivate = 2 * S * F(neuron.Value.Value);
                neuron.Value.Threshold = neuron.Value.Threshold - learningRate * derivate;
            }
        }

        private void UpdateHiddenLayerWeights(double result)
        {
            foreach (var neuron in hiddenLayerNeurons)
            {
                for (int i = 0; i < outputLayer; i++)
                {
                    double derivate = 2 * (outputNeurons[i].Value - result) * F(outputNeurons[0].Value) * neuron.Value.Value;
                    neuron.Weights[i] = neuron.Weights[i] - learningRate * derivate;
                }
            }
        }

        private void RecomputeInputWeights(double result)
        {
            for (int i = 0; i < outsideEntries; i++)
            {
                for (int j = 0; j < hiddenLayer; j++)
                {
                    double S = 0;
                    for (int k = 0; k < outputLayer; k++)
                    {
                        S += (outputNeurons[k].Value - result) * F(outputNeurons[k].Value) * hiddenLayerNeurons[j].Weights[k];
                    }
                    double derivate = 2 * S * F(hiddenLayerNeurons[j].Value.Value) * outsideEntriesList[i].Value;
                    outsideEntriesList[i].Weights[j] = outsideEntriesList[i].Weights[j] - learningRate * derivate;
                }
            }
        }

        private void RecomputeOutputLayerBiases(double result)
        {
            foreach (var neuron in outputNeurons)
            {
                double derivate = 2 * (neuron.Value - result) * F(neuron.Value);
                neuron.Threshold -= learningRate * derivate;
            }
        }
    }
}