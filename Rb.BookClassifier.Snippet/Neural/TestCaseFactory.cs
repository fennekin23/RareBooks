using Rb.BookClassifier.Common;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.Common.Neural.Snippet;
using Rb.BookClassifier.Snippet.Snippet;

namespace Rb.BookClassifier.Snippet.Neural
{
    internal class TestCaseFactory : ITestCaseFactory<TestSnippet>
    {
        private readonly IVectorizer<TestSnippet> vectorizer;

        public TestCaseFactory(IVectorizer<TestSnippet> vectorizer)
        {
            this.vectorizer = vectorizer;
        }

        public ITestCase<TestSnippet> Create(TestSnippet entity)
        {
            var testCase = new SnippetTestCase<TestSnippet>
            {
                Input = vectorizer.GetVector(entity),
                Output = new[] { entity.IsMoreInfoExists ? 1.0 : 0.0 },
                TestEntity = entity
            };

            return testCase;
        }
    }
}