using System.Linq;
using Rb.BookClassifier.Common.Book;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.RequestType.Book;

namespace Rb.BookClassifier.RequestType.Neural
{
    internal class TestCaseFactory : ITestCaseFactory<TestBook>
    {
        private readonly ITestBookVectorizer<TestBook> vectorizer;

        public TestCaseFactory(ITestBookVectorizer<TestBook> vectorizer)
        {
            this.vectorizer = vectorizer;
        }

        public ITestCase Create(TestBook book)
        {
            var testCase = new TestCase
            {
                Input = vectorizer.GetVector(book),
                Output = book.RequestTypes.Select(i => i ? 1.0 : 0.0).ToArray(),
                TestBook = book
            };

            return testCase;
        }
    }
}