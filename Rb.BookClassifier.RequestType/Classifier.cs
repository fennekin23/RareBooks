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
        public Classifier()
        {
            TestData = TestSetReader.Read(TestDataFile);
            var ranges = new TestBookRanges(TestData);
            var vectorizer = new TestBookVectorizer(ranges);
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
            return new LearningSettings(0.95, 0.6, 0.6);
        }

        protected override StopConditions GetStopConditions()
        {
            return new StopConditions(StopType.Error, maxMainSquareError: 1e-4);
        }

        protected override List<TestBook> GetTrainSet(int percentage)
        {
            var fillPercentage = percentage / 100.0;
            var trainSet = TestData.Shuffle().Take((int) (TestData.Count * fillPercentage)).ToList();

            return trainSet;
        }
    }
}