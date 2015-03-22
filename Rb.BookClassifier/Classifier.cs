using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Rb.BookClassifier.Binary.Book;
using Rb.BookClassifier.Binary.Neural;
using Rb.BookClassifier.Common.Book;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.Common.Neural.Settings;
using Rb.Common;

namespace Rb.BookClassifier.Binary
{
    internal class Classifier
    {
        private const string networkSettingsFile = "../networkSettings.txt";
        private const string testDataFile = "../../rarebooks.xlsx";

        private TestBookRanges ranges;
        private List<TestBook> testData;
        private TestBookVectorizer vectorizer;

        public Classifier()
        {
            InitializeAndLoad();
        }

        public void Check()
        {
            if (File.Exists(networkSettingsFile))
            {
                var errors = CheckNetwork(testData);
                PrintErrorStatistic(errors.Count, testData.Count);
            }
            else
            {
                Console.WriteLine(networkSettingsFile + " file does not exists, learn and save settings first.");
            }
        }

        public void Learn()
        {
            var trainSet = GetTrainSet(80);
            PrintTrainSetInfo(trainSet);

            var learningSettings = new LearningSettings(0.95, 0.6, 0.6);
            var stopConditions = new StopConditions(StopType.Error, maxMainSquareError: 1e-4);

            var inputSize = vectorizer.GetVector(trainSet[0]).Length;

            var network = new Network(learningSettings, inputSize, inputSize, 1);
            network.Learn(GetTestCases(trainSet), stopConditions);

            var testSet = GetTestCases(testData.Where(i => !trainSet.Contains(i)));

            var errors = network.Check(testSet);
            PrintErrorStatistic(errors.Count, testSet.Count);

            SaveNetworkSettings(network);
        }

        public void RandomTest()
        {
            var testResults = new List<Tuple<int, double>>();

            var learningSettings = new LearningSettings(0.95, 0.6, 0.6);
            var stopConditions = new StopConditions(
                StopType.Error | StopType.Time, 
                maxMainSquareError: 5e-5, 
                maxTimeForLearning: TimeSpan.FromSeconds(15));

            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine("Start test: {0}", i + 1);

                var trainSet = GetTrainSet(80);
                var inputSize = vectorizer.GetVector(trainSet[0]).Length;

                var network = new Network(learningSettings, inputSize, inputSize, 1);
                network.Learn(GetTestCases(trainSet), stopConditions);
                var testSet = GetTestCases(testData.Where(b => !trainSet.Contains(b)));
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

        public void SaveClassified()
        {
            if (File.Exists(networkSettingsFile))
            {
                var errors = CheckNetwork(testData).Select(i => i.InternalId).ToArray();
                var classified = testData.Where(i => !errors.Contains(i.InternalId) && i.IsMoreInfoExist).ToList();
                TestSetWriter.Write(classified, "Classified", testDataFile);
            }
            else
            {
                Console.WriteLine(networkSettingsFile + " file does not exists, learn and save settings first.");
            }
        }

        private List<ITestBook> CheckNetwork(IEnumerable<TestBook> testSetData)
        {
            var network = new Network(networkSettingsFile);
            var testSet = GetTestCases(testSetData);
            var errors = network.Check(testSet);

            return errors;
        }

        private static double GetActualError(int errorsCount, int testSetCount)
        {
            return Math.Round((double) errorsCount / testSetCount * 100, 2);
        }

        private List<ITestCase> GetTestCases(IEnumerable<TestBook> testBooks)
        {
            return testBooks.Select(i => new TestCase(i, vectorizer)).Cast<ITestCase>().ToList();
        }

        private List<TestBook> GetTrainSet(int percentage)
        {
            var fillPercentage = percentage / 100.0;
            var trainSet = new List<TestBook>();

            var positiv = testData.Where(i => i.IsMoreInfoExist).ToList();
            var negativ = testData.Where(i => !i.IsMoreInfoExist).ToList();
            trainSet.AddRange(positiv.Shuffle().Take((int) (positiv.Count * fillPercentage)));
            trainSet.AddRange(negativ.Shuffle().Take((int) (negativ.Count * fillPercentage)));

            return trainSet;
        }

        private void InitializeAndLoad()
        {
            testData = TestSetReader.Read(testDataFile);
            ranges = new TestBookRanges(testData);
            vectorizer = new TestBookVectorizer(ranges);

            Console.WriteLine("Test set count: {0}", testData.Count);
        }

        private static void PrintErrorStatistic(int errorsCount, int testSetCount)
        {
            var errorsPercentage = GetActualError(errorsCount, testSetCount);
            Console.WriteLine("Errors count: {0} - {1}%", errorsCount, errorsPercentage);
        }

        private static void PrintTrainSetInfo(List<TestBook> trainSet)
        {
            Console.WriteLine("Train set count: {0}", trainSet.Count);
            Console.WriteLine("Positiv set count: {0}", trainSet.Count(i => i.IsMoreInfoExist));
            Console.WriteLine("Negativ set count: {0}", trainSet.Count(i => !i.IsMoreInfoExist));
        }

        private static void SaveNetworkSettings(Network network)
        {
            Console.WriteLine("Save network settings? [y/n]");
            if (Console.ReadLine() == "y")
            {
                network.Save(networkSettingsFile);
                Console.WriteLine("Settings saved...");
            }
        }
    }
}