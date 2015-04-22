using System;
using AForge.Neuro;

namespace Rb.Classifier.System
{
    internal class NeuralNetwork
    {
        private readonly ActivationNetwork network;

        private NeuralNetwork(string path)
        {
            network = (ActivationNetwork) Network.Load(path);
        }

        public double[] Compute(double[] input)
        {
            var result = network.Compute(input);

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = Math.Round(result[i]);
            }

            return result;
        }

        public static NeuralNetwork Create(string path)
        {
            return new NeuralNetwork(path);
        }
    }
}