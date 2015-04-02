using System.Collections.Generic;
using System.Globalization;
using Rb.Common;

namespace Rb.BookClassifier.Common.Snippet
{
    public abstract class TestSnippetVectorizer<TS, TR> : IVectorizer<TS>
        where TS : ITestSnippet
        where TR : ITestSnippetRanges
    {
        protected TestSnippetVectorizer(TR ranges)
        {
            Ranges = ranges;
        }

        protected TR Ranges { get; private set; }

        protected List<double> GetBaseVector(ITestSnippet snippet)
        {
            var result = new List<double>();

            var titleIsInTitle = snippet.Title.ContainsLower(snippet.BookTitle).ToDouble();
            var fullTitleIsInTitle = snippet.Title.ContainsLower("\"" + snippet.BookTitle + "\"").ToDouble();
            var authorIsInTitle = snippet.Title.ContainsLower(snippet.BookAuthor).ToDouble();
            var yearIsInTitle = snippet.Title.ContainsLower(snippet.BookYear.ToString(CultureInfo.InvariantCulture)).ToDouble();

            var titleIsInText = snippet.Text.ContainsLower(snippet.BookTitle).ToDouble();
            var fullTitleIsInText = snippet.Text.ContainsLower("\"" + snippet.BookTitle + "\"").ToDouble();
            var authorIsInText = snippet.Text.ContainsLower(snippet.BookAuthor).ToDouble();
            var yearIsInText = snippet.Text.ContainsLower(snippet.BookYear.ToString(CultureInfo.InvariantCulture)).ToDouble();

            var urlIsWorldCat = snippet.Url.ContainsLower("worldcat.org").ToDouble();
            var urlIsHathitrust = snippet.Url.ContainsLower("hathitrust.org").ToDouble();
            var urlIsOpenLibrary = snippet.Url.ContainsLower("openlibrary.org").ToDouble();

            var textLengthVector = GetTextLengthVector(snippet.Text, Ranges.Text);

            result.Add(titleIsInTitle);
            result.Add(fullTitleIsInTitle);
            result.Add(authorIsInTitle);
            result.Add(yearIsInTitle);
            result.Add(titleIsInText);
            result.Add(fullTitleIsInText);
            result.Add(authorIsInText);
            result.Add(yearIsInText);
            result.Add(urlIsWorldCat);
            result.Add(urlIsHathitrust);
            result.Add(urlIsOpenLibrary);
            //result.AddRange(textLengthVector);

            return result;
        }

        private static double[] GetTextLengthVector(string text, Range range)
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

        public abstract double[] GetVector(TS entity);
    }
}