using System;
using System.Collections.Generic;
using System.Linq;
using Rb.Common;
using Rb.Common.Enums;

namespace Rb.BookClassifier.Common.Book
{
    public abstract class TestBookVectorizerBase<TB, TR>
        where TB : ITestBook
        where TR : ITestBookRanges
    {
        private readonly ITestBookRanges ranges;

        protected TestBookVectorizerBase(TR ranges)
        {
            this.ranges = ranges;
        }

        public abstract double[] GetVector(TB testBook);

        protected List<double> GetBaseVector(ITestBook testBook)
        {
            var result = new List<double>();

            var title = GetNormalized(testBook.Title.Length, ranges.Title);
            var author = GetNormalized(testBook.Author.Length, ranges.Author);
            var bbk = testBook.IsBbkExists ? 1 : -1;
            var annotation = testBook.Annotation.Length != 0 ? 1 : -1;
            var language = GetLanguageVector(testBook.Language);
            var year = GetYearVector(testBook.Year, ranges.Year);

            result.Add(title);
            result.Add(author);
            result.Add(bbk);
            //result.Add(annotation);
            result.AddRange(language);
            result.AddRange(year);

            return result;
        }

        protected double[] GetLanguageVector(int language)
        {
            var maxLanguage = (int) Enum.GetValues(typeof (LanguageCode)).Cast<LanguageCode>().Max();

            var languageVector = new double[maxLanguage + 1];
            languageVector[language] = 1;

            return languageVector;
        }

        protected double GetNormalized(double value, Range range)
        {
            return (value - range.Min) / (range.Size / 2.0) - 1;
        }

        protected double[] GetYearVector(int year, Range range)
        {
            const int yearPeriod = 40;
            var minRoundedYear = range.Min.RoundOff(yearPeriod);
            var maxRoundedYear = range.Max.RoundOff(yearPeriod);
            var numberOfBits = ((maxRoundedYear - minRoundedYear) / yearPeriod) + 1;
            var yearPeriodBitNumber = (year - minRoundedYear) / yearPeriod;

            var yearVector = new double[numberOfBits];
            yearVector[yearPeriodBitNumber] = 1;

            return yearVector;
        }
    }
}