using System.Collections.Generic;
using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.RequestType.Book
{
    internal class TestBookRanges : TestBookRangesBase<TestBook>
    {
        public TestBookRanges(List<TestBook> testBooks)
            : base(testBooks)
        {
        }
    }
}