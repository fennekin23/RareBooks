using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.RequestType.Book
{
    internal class TestBookVectorizer : TestBookVectorizer<TestBook, TestBookRanges>
    {
        public TestBookVectorizer(TestBookRanges ranges)
            : base(ranges)
        {
        }

        public override double[] GetVector(TestBook entity)
        {
            var result = GetBaseVector(entity);

            return result.ToArray();
        }
    }
}