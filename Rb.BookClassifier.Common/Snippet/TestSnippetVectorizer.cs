using System.Collections.Generic;

namespace Rb.BookClassifier.Common.Snippet
{
    public abstract class TestSnippetVectorizer<T> : IVectorizer<T>
        where T : ITestSnippet
    {
        protected List<double> GetBaseVector(ITestSnippet testSnippet)
        {
            return null;
        }

        public abstract double[] GetVector(T entity);
    }
}