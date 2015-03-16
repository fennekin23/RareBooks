using System.Collections.Generic;
using System.Linq;
using Rb.Common;

namespace Rb.BookClassifier.Book
{
    internal class TestBookRanges
    {
        private readonly List<TestBook> testBooks;

        public TestBookRanges(List<TestBook> testBooks)
        {
            this.testBooks = testBooks;
            Author = GetAuthorRange();
            Language = GetLanguageRange();
            Title = GetTitleRange();
            YandexResults = GetYandexResultsRange();
            Year = GetYearRange();
        }

        public Range Author { get; private set; }

        public Range Language { get; private set; }

        public Range Title { get; private set; }

        public Range YandexResults { get; private set; }

        public Range Year { get; private set; }

        private Range GetAuthorRange()
        {
            var min = testBooks.Where(i => !string.IsNullOrWhiteSpace(i.Author)).Min(i => i.Author.Length);
            var max = testBooks.Max(i => i.Author.Length);
            return new Range(min, max);
        }

        private Range GetLanguageRange()
        {
            var min = testBooks.Min(i => i.Language);
            var max = testBooks.Max(i => i.Language);
            return new Range(min, max);
        }

        private Range GetTitleRange()
        {
            var min = testBooks.Where(i => !string.IsNullOrWhiteSpace(i.Title)).Min(i => i.Title.Length);
            var max = testBooks.Max(i => i.Title.Length);
            return new Range(min, max);
        }

        private Range GetYandexResultsRange()
        {
            var min = testBooks.Where(i => i.YandexResults > 0).Min(i => i.YandexResults);
            var max = testBooks.Max(i => i.YandexResults);
            return new Range(min, max);
        }

        private Range GetYearRange()
        {
            var min = testBooks.Where(i => i.Year > 0).Min(i => i.Year);
            var max = testBooks.Max(i => i.Year);
            return new Range(min, max);
        }
    }
}