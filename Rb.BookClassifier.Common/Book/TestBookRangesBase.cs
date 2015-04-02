using System.Collections.Generic;
using Rb.Common;

namespace Rb.BookClassifier.Common.Book
{
    public class TestBookRangesBase<T> : ITestBookRanges
        where T : ITestBook
    {
        public TestBookRangesBase(List<T> testBooks)
        {
            TestBooks = testBooks;

            Author = new Range(0, 80);
            Language = new Range(0, 14);
            Title = new Range(5, 247);
            Year = new Range(1497, 1918);
        }

        protected List<T> TestBooks { get; private set; }

        //private Range GetAuthorRange()
        //{
        //    var min = testBooks.Where(i => !string.IsNullOrWhiteSpace(i.Author)).Min(i => i.Author.Length);
        //    var max = testBooks.Max(i => i.Author.Length);
        //    return new Range(min, max);
        //}

        //private Range GetLanguageRange()
        //{
        //    var min = testBooks.Min(i => i.Language);
        //    var max = testBooks.Max(i => i.Language);
        //    return new Range(min, max);
        //}

        //private Range GetTitleRange()
        //{
        //    var min = testBooks.Where(i => !string.IsNullOrWhiteSpace(i.Title)).Min(i => i.Title.Length);
        //    var max = testBooks.Max(i => i.Title.Length);
        //    return new Range(min, max);
        //}

        //private Range GetYearRange()
        //{
        //    var min = testBooks.Where(i => i.Year > 0).Min(i => i.Year);
        //    var max = testBooks.Max(i => i.Year);
        //    return new Range(min, max);
        //}

        public Range Author { get; private set; }

        public Range Language { get; private set; }

        public Range Title { get; private set; }

        public Range Year { get; private set; }
    }
}