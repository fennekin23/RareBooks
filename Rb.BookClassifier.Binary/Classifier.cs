using System;
using System.Collections.Generic;
using System.IO;
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
            TestData = TestSetReader.Read(TestDataFile);
            var ranges = new TestBookRanges(TestData);
            var vectorizer = new TestBookVectorizer(ranges);
            TestCaseFactory = new TestCaseFactory(vectorizer);

            Console.WriteLine("Test set count: {0}", TestData.Count);
        }

        public void SaveClassified()
        {
            if (File.Exists(NetworkSettingsFile))
            {
                var errors = Check().Select(i => i.InternalId).ToArray();
                var classified = TestData.Where(i => !errors.Contains(i.InternalId) && i.IsMoreInfoExists).ToList();
                TestSetWriter.Write(classified, "Classified", TestDataFile);
            }
            else
            {
                Console.WriteLine(NetworkSettingsFile + " file does not exists, learn and save settings first.");
            }
        }

        protected override List<TestBook> GetTrainSet(int percentage)
        {
            lock (lockObject)
            {
                var fillPercentage = percentage / 100.0;
                var trainSet = new List<TestBook>();

                var positiv = TestData.Where(i => i.IsMoreInfoExists).ToList();
                var negativ = TestData.Where(i => !i.IsMoreInfoExists).ToList();
                trainSet.AddRange(positiv.Shuffle().Take((int)(positiv.Count * fillPercentage)));
                trainSet.AddRange(negativ.Shuffle().Take((int)(negativ.Count * fillPercentage)));
                //trainSet.AddRange(positiv.Take((int)(positiv.Count * fillPercentage)));
                //trainSet.AddRange(negativ.Take((int)(negativ.Count * fillPercentage)));

                return trainSet;
            }
        }

        protected override LearningSettings GetLearningSettings()
        {
            return new LearningSettings(0.95, 0.6, 0.65);
        }

        protected override StopConditions GetStopConditions()
        {
            return new StopConditions(
                StopType.Any, 
                maxEpochCount: 50000, 
                maxMainSquareError: 1e-4,
                maxTimeForLearning: TimeSpan.FromSeconds(15));
        }
    }
}