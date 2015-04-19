using Rb.BookClassifier.Common.Reader;

namespace Rb.BookClassifier.Binary.Book
{
    internal class TestSetReader : TestSetReader<TestBook>
    {
        public TestSetReader()
            : base(new TestBookFactory())
        {
        }
    }
}