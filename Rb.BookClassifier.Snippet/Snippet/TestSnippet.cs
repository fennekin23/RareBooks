using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSnippet : ITestSnippet
    {
        public int InternalBookId { get; set; }

        public bool IsMoreInfoExists { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}