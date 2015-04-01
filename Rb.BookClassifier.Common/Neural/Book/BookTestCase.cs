using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.Common.Neural
{
    public class BookTestCase<T> : ITestCase<T>
        where T : ITestBook
    {
        public double[] Input { get; set; }

        public double[] Output { get; set; }

        public T TestEntity { get; set; }
    }
}