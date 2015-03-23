using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.Common.Neural
{
    public class TestCase : ITestCase
    {
        public double[] Input { get; set; }

        public double[] Output { get; set; }

        public ITestBook TestBook { get; set; }
    }
}