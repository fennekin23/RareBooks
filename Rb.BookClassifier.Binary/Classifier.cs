using System;
using System.Collections.Generic;
using System.Linq;
using Rb.BookClassifier.Binary.Book;
using Rb.BookClassifier.Binary.Neural;
using Rb.BookClassifier.Common.Classifier;
using Rb.BookClassifier.Common.Neural.Settings;
using Rb.Common;

namespace Rb.BookClassifier.Binary
{
    internal class Classifier : ClassifierBase<TestBook>
    {
        private readonly object lockObject = new object();

        public Classifier()
        {
            var reader = new TestSetReader();
            TestData = reader.Read(TestDataFile, "BinaryClassifier");
            var ranges = new TestBookRanges(TestData);
            var vectorizer = new TestBookVectorizer(ranges);
            TestCaseFactory = new TestCaseFactory(vectorizer);

            Console.WriteLine("Test set count: {0}", TestData.Count);
        }

        protected override LearningSettings GetLearningSettings()
        {
            return new LearningSettings(0.95, 0.6, 0.65);
        }

        protected override StopConditions GetStopConditions()
        {
            return new StopConditions(
                StopType.Any,
                50000,
                1e-4,
                TimeSpan.FromSeconds(15));
        }

        protected override List<TestBook> GetTrainSet(int percentage)
        {
            lock (lockObject)
            {
                var fillPercentage = percentage / 100.0;
                var trainSet = new List<TestBook>();

                var positiv = TestData.Where(i => i.IsMoreInfoExists).ToList();
                var negativ = TestData.Where(i => !i.IsMoreInfoExists).ToList();
                trainSet.AddRange(positiv.Shuffle().Take((int) (positiv.Count * fillPercentage)));
                trainSet.AddRange(negativ.Shuffle().Take((int) (negativ.Count * fillPercentage)));

                return trainSet;
            }
        }
    }
}