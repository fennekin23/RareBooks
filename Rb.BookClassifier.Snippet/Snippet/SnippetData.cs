using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class SnippetData : ISnippetData
    {
        public string Text { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}