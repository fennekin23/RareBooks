using System.Collections.Generic;
using Rb.BookClassifier.Common.Snippet;

namespace Rb.Classifier.System.Snippet
{
    internal class Snippet : ISnippet
    {
        public string Author { get; set; }

        public List<ISnippetData> Data { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}