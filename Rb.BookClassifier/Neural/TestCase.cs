using System.Diagnostics;
using Rb.BookClassifier.Book;

namespace Rb.BookClassifier.Neural
{
    internal class TestCase
    {
        public TestCase(TestBook testBook, TestBookRanges ranges)
        {
            Input = testBook.Vectorize(ranges);
            Output = new[] { testBook.IsMoreInfoExist ? 1.0 : 0.0 };
            TestBook = testBook;
        }

        [DebuggerDisplay("[{Input.Length}]")]
        public double[] Input { get; set; }

        [DebuggerDisplay("{Output[0]}")]
        public double[] Output { get; set; }

        [DebuggerDisplay("{TestBook.Title")]
        public TestBook TestBook { get; set; }
    }
}