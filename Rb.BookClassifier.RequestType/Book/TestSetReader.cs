using Rb.BookClassifier.Common.Reader;

namespace Rb.BookClassifier.RequestType.Book
{
    internal class TestSetReader : TestSetReader<TestBook>
    {
        public TestSetReader()
            : base(new TestBookFactory())
        {
        }
    }
}