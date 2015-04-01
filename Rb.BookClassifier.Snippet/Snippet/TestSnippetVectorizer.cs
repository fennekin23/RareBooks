using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSnippetVectorizer : TestSnippetVectorizer<TestSnippet>
    {
        public override double[] GetVector(TestSnippet entity)
        {
            return GetBaseVector(entity).ToArray();
        }
    }
}