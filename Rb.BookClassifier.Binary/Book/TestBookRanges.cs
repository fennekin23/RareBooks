using System.Collections.Generic;
using Rb.BookClassifier.Common.Book;
using Rb.Common;

namespace Rb.BookClassifier.Binary.Book
{
    internal class TestBookRanges : TestBookRangesBase<TestBook>
    {
        public TestBookRanges(List<TestBook> testBooks)
            : base(testBooks)
        {
            YandexResults = new Range(3, 11111452);
        }

        public Range YandexResults { get; private set; }

        //private Range GetYandexResultsRange()
        //{
        //    var min = TestBooks.Where(i => i.YandexResults > 0).Min(i => i.YandexResults);
        //    var max = TestBooks.Max(i => i.YandexResults);
        //    return new Range(min, max);
        //}
    }
}