using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSnippetVectorizer : TestSnippetVectorizer<TestSnippet, TestSnippetRanges>
    {
        public TestSnippetVectorizer(TestSnippetRanges ranges)
            : base(ranges)
        {
        }

        public override double[] GetVector(TestSnippet entity)
        {
            return GetBaseVector(entity).ToArray();
        }
    }
}