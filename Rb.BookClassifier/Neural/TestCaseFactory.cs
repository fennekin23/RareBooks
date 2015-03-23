using Rb.BookClassifier.Binary.Book;
using Rb.BookClassifier.Common.Book;
using Rb.BookClassifier.Common.Neural;

namespace Rb.BookClassifier.Binary.Neural
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
                Output = new[] { book.IsMoreInfoExist ? 1.0 : 0.0 },
                TestBook = book
            };

            return testCase;
        }
    }
}