using System.Collections.Generic;
using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSnippetRanges : TestSnippetRangesBase<TestSnippet>
    {
        public TestSnippetRanges(List<TestSnippet> testSnippets)
            : base(testSnippets)
        {
        }
    }
}