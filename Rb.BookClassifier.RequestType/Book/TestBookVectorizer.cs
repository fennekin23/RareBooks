using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.RequestType.Book
{
    internal class TestBookVectorizer : TestBookVectorizer<TestBook, TestBookRanges>
    {
        public TestBookVectorizer(TestBookRanges ranges)
            : base(ranges)
        {
        }

        public override double[] GetVector(TestBook testBook)
        {
            var result = GetBaseVector(testBook);

            return result.ToArray();
        }
    }
}