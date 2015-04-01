using System.Linq;
using Rb.BookClassifier.Common;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.RequestType.Book;

namespace Rb.BookClassifier.RequestType.Neural
{
    internal class TestCaseFactory : ITestCaseFactory<TestBook>
    {
        private readonly IVectorizer<TestBook> vectorizer;

        public TestCaseFactory(IVectorizer<TestBook> vectorizer)
        {
            this.vectorizer = vectorizer;
        }

        public ITestCase<TestBook> Create(TestBook book)
        {
            var testCase = new BookTestCase<TestBook>
            {
                Input = vectorizer.GetVector(book),
                Output = book.RequestTypes.Select(i => i ? 1.0 : 0.0).ToArray(),
                TestEntity = book
            };

            return testCase;
        }
    }
}