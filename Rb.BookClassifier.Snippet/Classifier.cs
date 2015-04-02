using System;
using System.Collections.Generic;
using System.Linq;
using Rb.BookClassifier.Common.Classifier;
using Rb.BookClassifier.Common.Neural.Settings;
using Rb.BookClassifier.Snippet.Neural;
using Rb.BookClassifier.Snippet.Snippet;
using Rb.Common;

namespace Rb.BookClassifier.Snippet
{
    internal class Classifier : ClassifierBase<TestSnippet>
    {
        public Classifier()
        {
            TestData = TestSetReader.Read(TestDataFile);
            var ranges = new TestSnippetRanges(TestData);
            var vectorizer = new TestSnippetVectorizer(ranges);
            TestCaseFactory = new TestCaseFactory(vectorizer);

            Console.WriteLine("Test set count: {0}", TestData.Count);
        }

        public void SaveClassified()
        {
            //if (File.Exists(networkSettingsFile))
            //{
            //    var errors = CheckNetwork(testData).Select(i => i.InternalId).ToArray();
            //    var classified = testData.Where(i => !errors.Contains(i.InternalId) && i.IsMoreInfoExist).ToList();
            //    TestSetWriter.Write(classified, "Classified", testDataFile);
            //}
            //else
            //{
            //    Console.WriteLine(networkSettingsFile + " file does not exists, learn and save settings first.");
            //}
        }

        protected override LearningSettings GetLearningSettings()
        {
            return new LearningSettings(0.95, 0.4, 0.8);
        }

        protected override StopConditions GetStopConditions()
        {
            return new StopConditions(StopType.Error | StopType.Time, maxMainSquareError: 1e-4, maxTimeForLearning: TimeSpan.FromSeconds(30));
        }

        protected override List<TestSnippet> GetTrainSet(int percentage)
        {
            var fillPercentage = percentage / 100.0;
            var trainSet = new List<TestSnippet>();

            var positiv = TestData.Where(i => i.IsMoreInfoExists).ToList();
            var negativ = TestData.Where(i => !i.IsMoreInfoExists).ToList();
            trainSet.AddRange(positiv.Shuffle().Take((int) (positiv.Count * fillPercentage)));
            trainSet.AddRange(negativ.Shuffle().Take((int) (negativ.Count * fillPercentage)));

            return trainSet;
        }
    }
}