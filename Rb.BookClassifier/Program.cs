using System;
using System.Collections.Generic;
using System.Linq;
using Rb.BookClassifier.Binary.Book;
using Rb.BookClassifier.Binary.Neural;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.Common.Neural.Settings;

namespace Rb.BookClassifier.Binary
{
    internal class Program
    {
        private static void Main()
        {
            var testData = TestSetReader.Read("../../rarebooks.xlsx");
            var ranges = new TestBookRanges(testData);
            var vectorizer = new TestBookVectorizer(ranges);

            Console.WriteLine("Test set count: {0}", testData.Count);

            var trainSet = new List<TestBook>();
            var positiv = testData.Where(i => i.IsMoreInfoExist).OrderBy(i => i.Title).ToList();
            var negativ = testData.Where(i => !i.IsMoreInfoExist).OrderBy(i => i.Title).ToList();
            trainSet.AddRange(positiv.Take((int)(positiv.Count * 0.8)));
            trainSet.AddRange(negativ.Take((int)(negativ.Count * 0.8)));

            Console.WriteLine("Train set count: {0}", trainSet.Count);
            Console.WriteLine("Positiv set count: {0}", trainSet.Count(i => i.IsMoreInfoExist));
            Console.WriteLine("Negativ set count: {0}", trainSet.Count(i => !i.IsMoreInfoExist));

            var learningSettings = new LearningSettings(alpha: 0.95, learningRate: 0.35, momentum: 0.75);
            var stopConditions = new StopConditions(StopType.Error, maxMainSquareError: 1e-4);

            var inputSize = vectorizer.GetVector(trainSet[0]).Length;

            var network = new Network(learningSettings, inputSize, inputSize, 1);
            network.Learn(trainSet.Select(i => new TestCase(i, vectorizer)).Cast<ITestCase>().ToList(), stopConditions);

            var testSet = testData
                .Where(i => !trainSet.Contains(i))
                .Select(i => new TestCase(i, vectorizer))
                .Cast<ITestCase>()
                .ToList();
            var errors = network.Check(testSet);
            var errorsPercentage = Math.Round((double) errors.Count / testSet.Count * 100, 2);

            Console.WriteLine("Errors count: {0} - {1}%", errors.Count, errorsPercentage);

            if (errorsPercentage < 30)
            {
                network.Save("../networkSettings_" + errorsPercentage + ".txt");
                Console.WriteLine("Settings saved");
            }

            Console.ReadLine();
        }
    }
}