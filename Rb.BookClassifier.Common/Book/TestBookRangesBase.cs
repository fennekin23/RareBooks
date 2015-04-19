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

        public Range Author { get; private set; }

        public Range Language { get; private set; }

        public Range Title { get; private set; }

        public Range Year { get; private set; }
    }
}