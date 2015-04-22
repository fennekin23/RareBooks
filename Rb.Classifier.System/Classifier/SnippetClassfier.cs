using System;
using Rb.System.Snippet;

namespace Rb.System.Classifier
{
    internal class SnippetClassfier : BaseClassifier<bool, Snippet.Snippet>
    {
        private readonly Vectorizer vectorizer;

        public SnippetClassfier()
            : base("Snippet")
        {
            vectorizer = new Vectorizer();
        }

        public override bool GetResult(Snippet.Snippet item)
        {
            var vector = vectorizer.GetVector(item);
            var result = Network.Compute(vector);

            return Math.Abs(result[0]) > 0.5;
        }
    }
}