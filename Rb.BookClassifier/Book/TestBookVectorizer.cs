using System;
using System.Collections.Generic;
using System.Linq;
using Rb.Common;
using Rb.Common.Enums;

namespace Rb.BookClassifier.Book
{
    internal static class TestBookVectorizer
    {
        private static double[] GetLanguageVector(int language)
        {
            var maxLanguage = (int)Enum.GetValues(typeof(LanguageCode)).Cast<LanguageCode>().Max();

            var languageVector = new double[maxLanguage + 1];
            languageVector[language] = 1;

            return languageVector;
        }

        private static double[] GetYearVector(int year, Range range)
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

        public static double[] Vectorize(this TestBook testBook, TestBookRanges ranges)
        {
            var title = GetNormalized(testBook.Title.Length, ranges.Title);
            var author = GetNormalized(testBook.Author.Length, ranges.Author);
            //var language = GetNormalized(testBook.Language, ranges.Language);
            //var year = GetNormalized(testBook.Year, ranges.Year);
            var bbk = testBook.IsBbkExists ? 1 : -1;
            var annotation = testBook.Annotation.Length != 0 ? 1 : -1;
            var yandexResults = GetNormalized(testBook.YandexResults, ranges.YandexResults);

            var result = new List<double>
            {
                title,
                author,
                bbk,
                0, //annotation,
                yandexResults
            };

            result.AddRange(GetLanguageVector(testBook.Language));
            result.AddRange(GetYearVector(testBook.Year, ranges.Year));

            return result.ToArray();
        }

        private static double GetNormalized(double value, Range range)
        {
            return (value - range.Min) / (range.Size / 2.0) - 1;
        }
    }
}