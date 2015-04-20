using Rb.BookClassifier.Common;
using Rb.BookClassifier.Common.Neural;
using Rb.Common;

namespace Rb.BookClassifier.Binary.Neural
{
    internal class TestCaseFactory : ITestCaseFactory<Book.Book>
    {
        private readonly IVectorizer<Book.Book> vectorizer;

        public TestCaseFactory(IVectorizer<Book.Book> vectorizer)
        {
            this.vectorizer = vectorizer;
        }

        public ITestCase<Book.Book> Create(Book.Book book)
        {
            var testCase = new BookTestCase<Book.Book>
            {
                Input = vectorizer.GetVector(book),
                Output = new[] { book.IsMoreInfoExists.ToDouble() },
                TestEntity = book
            };

            return testCase;
        }
    }
}