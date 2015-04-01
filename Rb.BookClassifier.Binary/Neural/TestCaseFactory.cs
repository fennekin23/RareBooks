using Rb.BookClassifier.Binary.Book;
using Rb.BookClassifier.Common;
using Rb.BookClassifier.Common.Neural;

namespace Rb.BookClassifier.Binary.Neural
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
                Output = new[] { book.IsMoreInfoExists ? 1.0 : 0.0 },
                TestEntity = book
            };

            return testCase;
        }
    }
}