using System;
using System.Collections.Generic;
using System.Linq;
using Rb.BookClassifier.Common.Classifier;
using Rb.BookClassifier.Common.Neural.Settings;
using Rb.BookClassifier.Common.Snippet;
using Rb.BookClassifier.Snippet.Neural;
using Rb.BookClassifier.Snippet.Snippet;
using Rb.Common;

namespace Rb.BookClassifier.Snippet
{
    internal class Classifier : ClassifierBase<Snippet.Snippet>
    {
        private readonly object lockObject = new object();

        public Classifier()
        {
            var reader = new TestSetReader();
            TestData = reader.Read(TestDataFile, "SnippetClassifier");
            var ranges = new SnippetRanges();
            var vectorizer = new SnippetVectorizer(ranges);
            TestCaseFactory = new TestCaseFactory(vectorizer);

            Console.WriteLine("Test set count: {0}", TestData.Count);
        }

        protected override LearningSettings GetLearningSettings()
        {
            return new LearningSettings(0.45, 0.45, 0.85);
        }

        protected override StopConditions GetStopConditions()
        {
            return new StopConditions(
                StopType.Any,
                8000,
                1e-4,
                TimeSpan.FromSeconds(30));
        }

        protected override List<Snippet.Snippet> GetTrainSet(int percentage)
        {
            lock (lockObject)
            {
                var fillPercentage = percentage / 100.0;
                var trainSet = new List<Snippet.Snippet>();

                var positiv = TestData.Where(i => i.IsMoreInfoExists).ToList();
                var negativ = TestData.Where(i => !i.IsMoreInfoExists).ToList();
                trainSet.AddRange(positiv.Shuffle().Take((int) (positiv.Count * fillPercentage)));
                trainSet.AddRange(negativ.Shuffle().Take((int) (negativ.Count * fillPercentage)));

                return trainSet;
            }
        }
    }
}