using Rb.BookClassifier.Common;
using Rb.BookClassifier.Common.Neural;
using Rb.BookClassifier.Common.Neural.Snippet;
using Rb.Common;

namespace Rb.BookClassifier.Snippet.Neural
{
    internal class TestCaseFactory : ITestCaseFactory<Snippet.Snippet>
    {
        private readonly IVectorizer<Snippet.Snippet> vectorizer;

        public TestCaseFactory(IVectorizer<Snippet.Snippet> vectorizer)
        {
            this.vectorizer = vectorizer;
        }

        public ITestCase<Snippet.Snippet> Create(Snippet.Snippet entity)
        {
            var testCase = new SnippetTestCase<Snippet.Snippet>
            {
                Input = vectorizer.GetVector(entity),
                Output = new[] { entity.IsMoreInfoExists.ToDouble() },
                TestEntity = entity
            };

            return testCase;
        }
    }
}