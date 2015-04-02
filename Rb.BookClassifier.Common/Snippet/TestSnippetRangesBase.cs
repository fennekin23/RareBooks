using System.Collections.Generic;
using Rb.Common;

namespace Rb.BookClassifier.Common.Snippet
{
    public class TestSnippetRangesBase<T> : ITestSnippetRanges
        where T : ITestSnippet
    {
        public TestSnippetRangesBase(List<T> testSnippets)
        {
            TestSnippets = testSnippets;

            Text = new Range(0, 656);
            Title = new Range(1, 92);
        }

        protected List<T> TestSnippets { get; private set; }

        public Range Text { get; private set; }

        public Range Title { get; private set; }
    }
}