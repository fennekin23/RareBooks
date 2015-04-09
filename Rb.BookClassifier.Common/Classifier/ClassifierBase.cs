using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.Common.Neural.Settings;
using Rb.Common;

namespace Rb.BookClassifier.Common.Classifier
{
    public abstract class ClassifierBase<TEntity>
    {
        private const string learningProcessFile = "../learningProcess.csv";
        protected const string NetworkSettingsFile = "../networkSettings.txt";
        protected const string TestDataFile = "../../../rarebooks.xlsx";

        protected ITestCaseFactory<TEntity> TestCaseFactory { get; set; }

        protected List<TEntity> TestData { get; set; }

        public List<TEntity> Check()
        {
            var errors = new List<TEntity>();

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
            var learningSettings = GetLearningSettings();
            var stopConditions = GetStopConditions();
            var networkSize = GetNetworkSize();

            var network = CreateNetwork(learningSettings, networkSize);
            var learningResult = LearnNetwork(network, stopConditions);

            Console.WriteLine("Errors count: {0} - {1}%", learningResult.Errors, learningResult.ActualError);

            SaveNetworkSettings(network);
            SaveLearningProcess(learningResult.LearningProcess);
        }

        public void RandomTest()
        {
            const int testsCount = 20;

            var learningSettings = GetLearningSettings();
            var stopConditions = GetStopConditions();
            var networkSize = GetNetworkSize();

            var tasks = new Task<LearningResult>[testsCount];
            for (var i = 0; i < testsCount; i++)
            {
                var network = CreateNetwork(learningSettings, networkSize);
                var task = new Task<LearningResult>(() => LearnNetwork(network, stopConditions));
                tasks[i] = task;
            }

            for (var i = 0; i < testsCount; i += 2)
            {
                tasks[i].Start();
                if (i + 1 < testsCount)
                {
                    tasks[i + 1].Start();
                }

                tasks[i].Wait();
                if (i + 1 < testsCount)
                {
                    tasks[i + 1].Wait();
                }

            }

            Task.WaitAll(tasks);

            var testResults = tasks.Select(i => i.Result).ToArray();

            Console.WriteLine("Results:");
            foreach (var testResult in testResults)
            {
                Console.WriteLine("Errors count: {0}, error: {1}%", testResult.Errors, testResult.ActualError);
            }
            Console.WriteLine("Min error: {0}%", testResults.Min(i => i.ActualError));
            Console.WriteLine("Max error: {0}%", testResults.Max(i => i.ActualError));
            Console.WriteLine("Avarage error: {0}%", testResults.Average(i => i.ActualError));
        }

        protected abstract LearningSettings GetLearningSettings();

        protected abstract StopConditions GetStopConditions();

        protected abstract List<TEntity> GetTrainSet(int i);

        private List<TEntity> CheckNetwork(IEnumerable<TEntity> testData)
        {
            var network = new Network(NetworkSettingsFile);
            var testSet = GetTestCases(testData);
            var errors = network.Check(testSet);

            return errors;
        }

        private static Network CreateNetwork(LearningSettings learningSettings, NetworkSize size)
        {
            var network = new Network(learningSettings, size.Input, size.Input, size.Output);
            return network;
        }

        private static double GetActualError(int errorsCount, int testSetCount)
        {
            return Math.Round((double) errorsCount / testSetCount * 100, 2);
        }

        private NetworkSize GetNetworkSize()
        {
            var testCase = TestCaseFactory.Create(TestData[0]);
            var inputSize = testCase.Input.Length;
            var outputSize = testCase.Output.Length;

            return new NetworkSize(inputSize, outputSize);
        }

        private List<ITestCase<TEntity>> GetTestCases(IEnumerable<TEntity> testSetData)
        {
            return testSetData.Select(TestCaseFactory.Create).ToList();
        }

        private LearningResult LearnNetwork(Network network, StopConditions stopConditions)
        {
            var trainSet = GetTrainSet(75);
            var learningProcess = network.Learn(GetTestCases(trainSet), stopConditions);
            var testSet = GetTestCases(TestData.Where(b => !trainSet.Contains(b)));
            var errors = network.Check(testSet).Count;
            var actualError = GetActualError(errors, testSet.Count);

            return new LearningResult(actualError, errors, learningProcess);
        }

        private static void PrintErrorStatistic(int errorsCount, int testSetCount)
        {
            var errorsPercentage = GetActualError(errorsCount, testSetCount);
            Console.WriteLine("Errors count: {0} - {1}%", errorsCount, errorsPercentage);
        }

        private static void SaveLearningProcess(Dictionary<int, double> learningProcess)
        {
            Console.WriteLine("Save learning process to csv? [y/n]");
            if (Console.ReadLine() == "y")
            {
                var csvString = learningProcess.ToCsvString();
                File.WriteAllText(learningProcessFile, csvString);
                Console.WriteLine("Learning process saved...");
            }
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