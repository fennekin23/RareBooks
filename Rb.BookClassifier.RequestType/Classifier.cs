using System;
using System.Collections.Generic;
using System.Linq;
using Rb.BookClassifier.Common.Classifier;
using Rb.BookClassifier.Common.Neural.Settings;
using Rb.BookClassifier.RequestType.Book;
using Rb.BookClassifier.RequestType.Neural;
using Rb.Common;

namespace Rb.BookClassifier.RequestType
{
    internal class Classifier : ClassifierBase<TestBook>
    {
        private readonly object lockObject = new object();

        public Classifier()
        {
            var reader = new TestSetReader();
            TestData = reader.Read(TestDataFile, "RequestTypeClassifier");
            var ranges = new TestBookRanges(TestData);
            var vectorizer = new TestBookVectorizer(ranges);
            TestCaseFactory = new TestCaseFactory(vectorizer);

            Console.WriteLine("Test set count: {0}", TestData.Count);
        }

        protected override LearningSettings GetLearningSettings()
        {
            return new LearningSettings(0.75, 0.4, 0.85);
        }

        protected override StopConditions GetStopConditions()
        {
            return new StopConditions(
                StopType.Any,
                50000,
                1e-4,
                TimeSpan.FromSeconds(30));
            //return new StopConditions(StopType.Error, maxMainSquareError: 1e-4);
        }

        protected override List<TestBook> GetTrainSet(int percentage)
        {
            lock (lockObject)
            {
                var fillPercentage = percentage / 100.0;
                var takeCount = (int) (TestData.Count * fillPercentage);
                var trainSet = TestData.Shuffle().Take(takeCount).ToList();
                return trainSet;
            }
        }
    }
}