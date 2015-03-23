using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Rb.BookClassifier.Common.Book;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.Common.Neural.Settings;

namespace Rb.BookClassifier.Common.Classifier
{
    public abstract class ClassifierBase<TB>
        where TB : ITestBook
    {
        protected const string NetworkSettingsFile = "../networkSettings.txt";
        protected const string TestDataFile = "../../../rarebooks.xlsx";

        private Network network;

        protected ITestCaseFactory<TB> TestCaseFactory { get; set; }

        protected List<TB> TestData { get; set; }

        public List<ITestBook> Check()
        {
            var errors = new List<ITestBook>();

            if (File.Exists(NetworkSettingsFile))
            {
                errors = CheckNetwork(TestData);
                PrintErrorStatistic(errors.Count, TestData.Count);
            }
            else
            {
                Console.WriteLine(NetworkSettingsFile + " file does not exists, learn and save settings first.");
            }

            return errors;
        }

        public void Learn()
        {
            var trainSet = GetTrainSet(80);
            Console.WriteLine("Train set count: {0}", trainSet.Count);

            var learningSettings = GetLearningSettings();
            var stopConditions = GetStopConditions();

            var testCase = TestCaseFactory.Create(trainSet[0]);
            var inputSize = testCase.Input.Length;
            var outputSize = testCase.Output.Length;

            network = new Network(learningSettings, inputSize, inputSize, outputSize);
            network.Learn(GetTestCases(trainSet), stopConditions);

            var testSet = GetTestCases(TestData.Where(i => !trainSet.Contains(i)));

            var errors = network.Check(testSet);
            PrintErrorStatistic(errors.Count, testSet.Count);

            SaveNetworkSettings(network);
        }

        public void RandomTest()
        {
            var testResults = new List<Tuple<int, double>>();

            var learningSettings = GetLearningSettings();
            var stopConditions = new StopConditions(
                StopType.Error | StopType.Time,
                maxMainSquareError: GetStopConditions().MaxMainSquareError,
                maxTimeForLearning: TimeSpan.FromSeconds(20));

            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine("Start test: {0}", i + 1);

                var trainSet = GetTrainSet(80);
                var testCase = TestCaseFactory.Create(trainSet[0]);
                var inputSize = testCase.Input.Length;
                var outPutSize = testCase.Output.Length;

                network = new Network(learningSettings, inputSize, inputSize, outPutSize);
                network.Learn(GetTestCases(trainSet), stopConditions);

                var testSet = GetTestCases(TestData.Where(b => !trainSet.Contains(b)));
                var errors = network.Check(testSet).Count;
                var actualError = GetActualError(errors, testSet.Count);

                testResults.Add(new Tuple<int, double>(errors, actualError));

                Console.WriteLine("Finish test: {0}", i + 1);
            }

            Console.WriteLine("Results:");
            foreach (var testResult in testResults)
            {
                Console.WriteLine("Errors count: {0}, error: {1}%", testResult.Item1, testResult.Item2);
            }
            Console.WriteLine("Min error: {0}%", testResults.Min(i => i.Item2));
            Console.WriteLine("Max error: {0}%", testResults.Max(i => i.Item2));
            Console.WriteLine("Avarage error: {0}%", testResults.Average(i => i.Item2));
        }

        protected abstract LearningSettings GetLearningSettings();

        protected abstract StopConditions GetStopConditions();

        protected abstract List<TB> GetTrainSet(int i);

        private List<ITestBook> CheckNetwork(IEnumerable<TB> testSetData)
        {
            network = new Network(NetworkSettingsFile);
            var testSet = GetTestCases(testSetData);
            var errors = network.Check(testSet);

            return errors;
        }

        private static double GetActualError(int errorsCount, int testSetCount)
        {
            return Math.Round((double) errorsCount / testSetCount * 100, 2);
        }

        private List<ITestCase> GetTestCases(IEnumerable<TB> testSetData)
        {
            return testSetData.Select(TestCaseFactory.Create).ToList();
        }

        private static void PrintErrorStatistic(int errorsCount, int testSetCount)
        {
            var errorsPercentage = GetActualError(errorsCount, testSetCount);
            Console.WriteLine("Errors count: {0} - {1}%", errorsCount, errorsPercentage);
        }

        private static void SaveNetworkSettings(Network network)
        {
            Console.WriteLine("Save network settings? [y/n]");
            if (Console.ReadLine() == "y")
            {
                network.Save(NetworkSettingsFile);
                Console.WriteLine("Settings saved...");
            }
        }
    }
}