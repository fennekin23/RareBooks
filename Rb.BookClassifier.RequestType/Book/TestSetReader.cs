using Rb.BookClassifier.Common.Reader;

namespace Rb.BookClassifier.RequestType.Book
{
    internal class TestSetReader : TestSetReader<Book>
    {
        public TestSetReader()
            : base(new BookFactory())
        {
        }
    }
}