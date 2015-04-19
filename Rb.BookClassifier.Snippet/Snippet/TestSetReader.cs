using Rb.BookClassifier.Common.Reader;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSetReader : TestSetReader<Snippet>
    {
        public TestSetReader()
            : base(new TestSnippetFactory())
        {
        }
    }
}