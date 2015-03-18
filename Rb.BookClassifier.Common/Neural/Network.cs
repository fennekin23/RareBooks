using System;
using System.Collections.Generic;
using System.Diagnostics;
using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;
using Rb.BookClassifier.Common.Book;
using Rb.BookClassifier.Common.Neural.Settings;

namespace Rb.BookClassifier.Common.Neural
{
    public class Network
    {
        private readonly ActivationNetwork network;
        private readonly BackPropagationLearning teacher;

        public Network(LearningSettings learningSettings, int inputSize, params int[] layers)
        {
            Neuron.RandRange = new Range(-0.1f, 0.1f);
            network = new ActivationNetwork(new SigmoidFunction(learningSettings.Alpha), inputSize, layers);
            teacher = new BackPropagationLearning(network)
            {
                LearningRate = learningSettings.LearningRate,
                Momentum = learningSettings.Momentum
            };
        }

        public Network(string path)
        {
            network = (ActivationNetwork) AForge.Neuro.Network.Load(path);
        }

        public List<ITestBook> Check(List<ITestCase> testSet)
        {
            var errors = new List<ITestBook>();
            foreach (var test in testSet)
            {
                var networkResult = network.Compute(test.Input);

                if (GetAverageOutputError(networkResult, test.Output) > 0.4)
                {
                    errors.Add(test.TestBook);
                }
            }

            return errors;
        }

        public Dictionary<int, double> Learn(List<ITestCase> trainSet, StopConditions stopConditions)
        {
            var learnHistory = new Dictionary<int, double>();

            var input = new double[trainSet.Count][];
            var output = new double[trainSet.Count][];

            for (var i = 0; i < trainSet.Count; i++)
            {
                input[i] = trainSet[i].Input;
                output[i] = trainSet[i].Output;
            }

            var epochCount = 0;
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            var isStopConditionsReached = false;
            while (!isStopConditionsReached)
            {
                var errorPerOutPut = teacher.RunEpoch(input, output) * 2.0 / trainSet.Count;
                learnHistory.Add(epochCount++, errorPerOutPut);

                if (epochCount % 1000 == 0)
                {
                    isStopConditionsReached = stopConditions.IsStopConditionsReached(epochCount, errorPerOutPut, stopWatch.Elapsed);
                    Console.WriteLine("Epoch: {0}, Error: {1}", epochCount, errorPerOutPut);
                }
            }
            stopWatch.Stop();

            return learnHistory;
        }

        public void Save(string path)
        {
            network.Save(path);
        }

        private static double GetAverageOutputError(double[] networkOutput, double[] testOutput)
        {
            var totalError = 0.0;
            var outputsCount = networkOutput.Length;

            for (var i = 0; i < networkOutput.Length; i++)
            {
                totalError += Math.Abs(networkOutput[i] - testOutput[i]);
            }

            return totalError / outputsCount;
        }
    }
}