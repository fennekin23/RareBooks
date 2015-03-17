using Rb.BookClassifier.Binary.Book;
using Rb.BookClassifier.Common.Book;
using Rb.BookClassifier.Common.Neural;

namespace Rb.BookClassifier.Binary.Neural
{
    internal class TestCase : ITestCase
    {
        public TestCase(TestBook testBook, TestBookVectorizer vectorizer)
        {
            Input = vectorizer.GetVector(testBook);
            Output = new[] { testBook.IsMoreInfoExist ? 1.0 : 0.0 };
            TestBook = testBook;
        }

        public double[] Input { get; set; }

        public double[] Output { get; set; }

        public ITestBook TestBook { get; set; }
    }
}