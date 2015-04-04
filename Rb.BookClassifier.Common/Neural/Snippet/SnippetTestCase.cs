using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Common.Neural.Snippet
{
    public class SnippetTestCase<T> : ITestCase<T>
        where T : ISnippet
    {
        public double[] Input { get; set; }

        public double[] Output { get; set; }

        public T TestEntity { get; set; }
    }
}