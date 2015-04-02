using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSnippet : ITestSnippet
    {
        public string BookAuthor { get; set; }

        public string BookTitle { get; set; }

        public int BookYear { get; set; }

        public int InternalBookId { get; set; }

        public bool IsMoreInfoExists { get; set; }

        public string Text { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}