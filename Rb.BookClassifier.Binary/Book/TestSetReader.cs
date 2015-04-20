using Rb.BookClassifier.Common.Reader;

namespace Rb.BookClassifier.Binary.Book
{
    internal class TestSetReader : TestSetReader<Book>
    {
        public TestSetReader()
            : base(new BookFactory())
        {
        }
    }
}