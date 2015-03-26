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
                var classified = TestData.Where(i => !errors.Contains(i.InternalId) && i.IsMoreInfoExist).ToList();
                TestSetWriter.Write(classified, "Classified", TestDataFile);
            }
            else
            {
                Console.WriteLine(NetworkSettingsFile + " file does not exists, learn and save settings first.");
            }
        }

        protected override List<TestBook> GetTrainSet(int percentage)
        {
            var fillPercentage = percentage / 100.0;
            var trainSet = new List<TestBook>();

            var positiv = TestData.Where(i => i.IsMoreInfoExist).ToList();
            var negativ = TestData.Where(i => !i.IsMoreInfoExist).ToList();
            trainSet.AddRange(positiv.Shuffle().Take((int) (positiv.Count * fillPercentage)));
            trainSet.AddRange(negativ.Shuffle().Take((int) (negativ.Count * fillPercentage)));

            return trainSet;
        }

        protected override LearningSettings GetLearningSettings()
        {
            return new LearningSettings(0.95, 0.6, 0.6);
        }

        protected override StopConditions GetStopConditions()
        {
            return new StopConditions(StopType.Error, maxMainSquareError: 1e-4);
        }
    }
}