using System.Collections.Generic;
using System.Globalization;
using Rb.Common;

namespace Rb.BookClassifier.Common.Snippet
{
    public abstract class SnippetVectorizer<TS, TR> : IVectorizer<TS>
        where TS : ISnippet
        where TR : ISnippetRanges
    {
        protected SnippetVectorizer(TR ranges)
        {
            Ranges = ranges;
        }

        protected TR Ranges { get; private set; }

        protected List<double> GetBaseVector(ISnippet snippet)
        {
            var result = new List<double>();

            result.AddRange(GetSnippetDataVectors(snippet));

            result.AddRange(AddEmptySnippetDataVectors(snippet));

            return result;
        }

        private IEnumerable<double> AddEmptySnippetDataVectors(ISnippet snippet)
        {
            const int maxSnippetsCount = 10;
            var result = new List<double>();

            if (snippet.Snippets.Count < maxSnippetsCount)
            {
                var snippetDataMock = new SnippetDataMock();
                var dimensionsCount = GetSnippetDataVector(snippetDataMock, "", "", 0).Count;
                result.AddRange(GetEmptySnippetDataVector(maxSnippetsCount - snippet.Snippets.Count, dimensionsCount));
            }

            return result;
        }

        private static IEnumerable<double> GetEmptySnippetDataVector(int count, int dimensionsCount)
        {
            var result = new List<double>();

            for (var i = 0; i < count; i++)
            {
                result.AddRange(new double[dimensionsCount]);
            }

            return result;
        }

        private List<double> GetSnippetDataVector(ISnippetData snippet, string bookAuthor, string bookTitle, int bookYear)
        {
            var result = new List<double>();

            var bookTitleIsInTitle = snippet.Title.ContainsLower(bookTitle).ToDouble();
            var fullBookTitleIsInTitle = snippet.Title.ContainsLower("\"" + bookTitle + "\"").ToDouble();
            var bookAuthorIsInTitle = snippet.Title.ContainsLower(bookAuthor).ToDouble();
            var bookYearIsInTitle = snippet.Title.ContainsLower(bookYear.ToString(CultureInfo.InvariantCulture)).ToDouble();

            var bookTitleIsInText = snippet.Text.ContainsLower(bookTitle).ToDouble();
            var fullBookTitleIsInText = snippet.Text.ContainsLower("\"" + bookTitle + "\"").ToDouble();
            var bookAuthorIsInText = snippet.Text.ContainsLower(bookAuthor).ToDouble();
            var bookYearIsInText = snippet.Text.ContainsLower(bookYear.ToString(CultureInfo.InvariantCulture)).ToDouble();

            var urlIsWorldCat = snippet.Url.ContainsLower("worldcat.org").ToDouble();
            var urlIsHathitrust = snippet.Url.ContainsLower("hathitrust.org").ToDouble();
            var urlIsOpenLibrary = snippet.Url.ContainsLower("openlibrary.org").ToDouble();

            var titleToBookTitleLevinstein = Levinstein.ComputeDistance(snippet.Title, bookTitle);
            var titleToBookAuthorLevinstein = Levinstein.ComputeDistance(snippet.Title, bookAuthor);

            var textToBookTitleLevinstein = Levinstein.ComputeDistance(snippet.Text, bookTitle);
            var textToBookAuthorLevinstein = Levinstein.ComputeDistance(snippet.Text, bookAuthor);

            result.Add(NormalizeLevinstein(titleToBookTitleLevinstein, Ranges.Title));
            result.Add(NormalizeLevinstein(titleToBookAuthorLevinstein, Ranges.Title));

            result.Add(NormalizeLevinstein(textToBookTitleLevinstein, Ranges.Text));
            result.Add(NormalizeLevinstein(textToBookAuthorLevinstein, Ranges.Text));

            //var textLengthVector = GetTextLengthVector(snippet.Text, Ranges.Text);

            result.Add(bookTitleIsInTitle);
            result.Add(fullBookTitleIsInTitle);
            result.Add(bookAuthorIsInTitle);
            result.Add(bookYearIsInTitle);
            result.Add(bookTitleIsInText);
            result.Add(fullBookTitleIsInText);
            result.Add(bookAuthorIsInText);
            result.Add(bookYearIsInText);
            result.Add(urlIsWorldCat);
            result.Add(urlIsHathitrust);
            result.Add(urlIsOpenLibrary);
            //result.AddRange(textLengthVector);

            return result;
        }

        private IEnumerable<double> GetSnippetDataVectors(ISnippet snippet)
        {
            var result = new List<double>();

            foreach (var snippetData in snippet.Snippets)
            {
                var snippetDataVector = GetSnippetDataVector(snippetData, snippet.Author, snippet.Title, snippet.Year);
                result.AddRange(snippetDataVector);
            }

            return result;
        }

        private static IEnumerable<double> GetTextLengthVector(string text, Range range)
        {
            const int period = 50;
            var minRoundedLength = range.Min.RoundOff(period);
            var maxRoundedLength = range.Max.RoundOff(period);
            var numberOfBits = ((maxRoundedLength - minRoundedLength) / period) + 1;
            var lengthPeriodBitNumber = (text.Length - minRoundedLength) / period;

            var lengthVector = new double[numberOfBits];
            lengthVector[lengthPeriodBitNumber] = 1;

            return lengthVector;
        }

        private static double NormalizeLevinstein(int distance, Range range)
        {
            return distance / (double) range.Max;
        }

        public abstract double[] GetVector(TS snippet);

        private class SnippetDataMock : ISnippetData
        {
            public SnippetDataMock()
            {
                Text = string.Empty;
                Title = string.Empty;
                Url = string.Empty;
            }

            public string Text { get; set; }

            public string Title { get; set; }

            public string Url { get; set; }
        }
    }
}