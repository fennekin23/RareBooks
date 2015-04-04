using System.Collections.Generic;
using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class SnippetRanges : SnippetRangesBase<Snippet>
    {
        public SnippetRanges(List<Snippet> testSnippets)
            : base(testSnippets)
        {
        }
    }
}