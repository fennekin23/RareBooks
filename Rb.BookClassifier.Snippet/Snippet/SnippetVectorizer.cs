using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class SnippetVectorizer : SnippetVectorizer<Snippet, SnippetRanges>
    {
        public SnippetVectorizer(SnippetRanges ranges)
            : base(ranges)
        {
        }

        public override double[] GetVector(Snippet snippet)
        {
            var result = GetBaseVector(snippet);
            return result.ToArray();
        }
    }
}