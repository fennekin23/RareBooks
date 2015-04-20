using System;
using System.Collections.Generic;
using System.Linq;
using Rb.Common;
using Rb.Common.Enums;

namespace Rb.BookClassifier.Common.Book
{
    public abstract class BookVectorizer<TB, TR> : IVectorizer<TB>
        where TB : IBook
        where TR : IBookRanges
    {
        protected BookVectorizer(TR ranges)
        {
            Ranges = ranges;
        }

        protected TR Ranges { get; private set; }

        protected List<double> GetBaseVector(IBook book)
        {
            var result = new List<double>();

            var title = GetNormalized(book.Title.Length, Ranges.Title);
            //var author = GetNormalized(testBook.Author.Length, Ranges.Author);
            var bbk = book.IsBbkExists ? 1 : -1;
            //var annotation = testBook.Annotation.Length != 0 ? 1 : -1;
            var language = GetLanguageVector(book.Language);
            var year = GetYearVector(book.Year, Ranges.Year);

            result.Add(title);
            //result.Add(author);
            result.Add(bbk);
            //result.Add(annotation);
            result.AddRange(language);
            result.AddRange(year);

            return result;
        }

        protected double GetNormalized(double value, Range range)
        {
            return (value - range.Min) / (range.Size / 2.0) - 1;
        }

        private static IEnumerable<double> GetLanguageVector(int language)
        {
            var maxLanguage = (int) Enum.GetValues(typeof (LanguageCode)).Cast<LanguageCode>().Max();

            var languageVector = new double[maxLanguage + 1];
            languageVector[language] = 1;

            return languageVector;
        }

        private static IEnumerable<double> GetYearVector(int year, Range range)
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

        public abstract double[] GetVector(TB snippet);
    }
}