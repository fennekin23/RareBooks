using System.Collections.Generic;

namespace Rb.BookClassifier.Common.Snippet
{
    public interface ISnippet
    {
        string Author { get; set; }

        bool IsMoreInfoExists { get; set; }

        List<ISnippetData> Snippets { get; set; }

        string Title { get; set; }

        int Year { get; set; }
    }
}