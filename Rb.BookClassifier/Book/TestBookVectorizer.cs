using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.Binary.Book
{
    internal class TestBookVectorizer : TestBookVectorizerBase<TestBook, TestBookRanges>
    {
        private readonly TestBookRanges ranges;

        public TestBookVectorizer(TestBookRanges ranges)
            : base(ranges)
        {
            this.ranges = ranges;
        }

        public override double[] GetVector(TestBook testBook)
        {
            var result = GetBaseVector(testBook);

            var yandexResults = GetNormalized(testBook.YandexResults, ranges.YandexResults);

            result.Add(yandexResults);

            return result.ToArray();
        }
    }
}