using Rb.BookClassifier.Common.Snippet;
using Rb.Common;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class TestSnippetVectorizer : TestSnippetVectorizer<TestSnippet, TestSnippetRanges>
    {
        public TestSnippetVectorizer(TestSnippetRanges ranges)
            : base(ranges)
        {
        }

        public override double[] GetVector(TestSnippet snippet)
        {
            var result = GetBaseVector(snippet);

            var titleToBookTitleLevinstein = Levinstein.ComputeDistance(snippet.Title, snippet.BookTitle);
            var titleToBookAuthorLevinstein = Levinstein.ComputeDistance(snippet.Title, snippet.BookAuthor);

            var textToBookTitleLevinstein = Levinstein.ComputeDistance(snippet.Text, snippet.BookTitle);
            var textToBookAuthorLevinstein = Levinstein.ComputeDistance(snippet.Text, snippet.BookAuthor);

            result.Add(NormalizeLevinstein(titleToBookTitleLevinstein, Ranges.Title));
            result.Add(NormalizeLevinstein(titleToBookAuthorLevinstein, Ranges.Title));

            result.Add(NormalizeLevinstein(textToBookTitleLevinstein, Ranges.Text));
            result.Add(NormalizeLevinstein(textToBookAuthorLevinstein, Ranges.Text));

            return result.ToArray();
        }

        private static double NormalizeLevinstein(int distance, Range range)
        {
            return distance / (double)range.Max;
        }
    }
}