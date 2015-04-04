using System.Collections.Generic;
using Rb.BookClassifier.Common.Snippet;

namespace Rb.BookClassifier.Snippet.Snippet
{
    internal class Snippet : ISnippet
    {
        public string Author { get; set; }

        public bool IsMoreInfoExists { get; set; }

        public List<ISnippetData> Snippets { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}