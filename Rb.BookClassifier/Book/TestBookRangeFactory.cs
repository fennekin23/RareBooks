using System.Collections.Generic;
using System.Linq;
using Rb.Common;

namespace Rb.BookClassifier.Book
{
    internal class TestBookRangeFactory
    {
        public static Range GetAuthorRange(List<TestBook> testBooks)
        {
            var min = testBooks.Where(i => !string.IsNullOrWhiteSpace(i.Author)).Min(i => i.Author.Length);
            var max = testBooks.Max(i => i.Author.Length);
            return new Range(min, max);
        }

        public static Range GetLanguageRange(List<TestBook> testBooks)
        {
            var min = testBooks.Min(i => i.Language);
            var max = testBooks.Max(i => i.Language);
            return new Range(min, max);
        }

        public static Range GetTitleRange(List<TestBook> testBooks)
        {
            var min = testBooks.Where(i => !string.IsNullOrWhiteSpace(i.Title)).Min(i => i.Title.Length);
            var max = testBooks.Max(i => i.Title.Length);
            return new Range(min, max);
        }

        public static Range GetYandexResultsRange(List<TestBook> testBooks)
        {
            var min = testBooks.Where(i => i.YandexResults > 0).Min(i => i.YandexResults);
            var max = testBooks.Max(i => i.YandexResults);
            return new Range(min, max);
        }

        public static Range GetYearRange(List<TestBook> testBooks)
        {
            var min = testBooks.Where(i => i.Year > 0).Min(i => i.Year);
            var max = testBooks.Max(i => i.Year);
            return new Range(min, max);
        }
    }
}