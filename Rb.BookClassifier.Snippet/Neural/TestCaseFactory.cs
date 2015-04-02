using Rb.BookClassifier.Common;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.Common.Neural.Snippet;
using Rb.BookClassifier.Snippet.Snippet;
using Rb.Common;

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
                Output = new[] { entity.IsMoreInfoExists.ToDouble() },
                TestEntity = entity
            };

            return testCase;
        }
    }
}