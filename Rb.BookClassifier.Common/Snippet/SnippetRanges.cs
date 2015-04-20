using Rb.Common;

namespace Rb.BookClassifier.Common.Snippet
{
    public class SnippetRanges : ISnippetRanges
    {
        public SnippetRanges()
        {
            Text = new Range(0, 656);
            Title = new Range(1, 92);
        }

        public Range Text { get; private set; }

        public Range Title { get; private set; }
    }
}