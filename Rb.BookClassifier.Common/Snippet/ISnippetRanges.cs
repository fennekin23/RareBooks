using Rb.Common;

namespace Rb.BookClassifier.Common.Snippet
{
    public interface ISnippetRanges
    {
        Range Text { get; }

        Range Title { get; }
    }
}