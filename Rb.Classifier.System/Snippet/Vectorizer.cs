using Rb.BookClassifier.Common.Snippet;

namespace Rb.System.Snippet
{
    internal class Vectorizer : SnippetVectorizer<Snippet, SnippetRanges>
    {
        public Vectorizer()
            : base(new SnippetRanges())
        {
        }

        public override double[] GetVector(Snippet snippet)
        {
            var result = GetBaseVector(snippet);
            return result.ToArray();
        }
    }
}