using System.Linq;
using Rb.BookClassifier.Common;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.RequestType.Book;
using Rb.Common;

namespace Rb.BookClassifier.RequestType.Neural
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
                Output = book.RequestTypes.Select(i => i.ToDouble()).ToArray(),
                TestEntity = book
            };

            return testCase;
        }
    }
}