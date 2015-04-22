using Rb.BookClassifier.Common.Snippet;

namespace Rb.System.Snippet
{
    internal class SnippetData : ISnippetData
    {
        public override string ToString()
        {
            return string.Format("Title: {0}\n\rText: {1}\n\rUrl: {2}", Title, Text, Url);
        }

        public string Text { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}