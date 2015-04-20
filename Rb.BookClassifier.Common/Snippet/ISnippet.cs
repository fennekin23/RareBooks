using System.Collections.Generic;

namespace Rb.BookClassifier.Common.Snippet
{
    public interface ISnippet
    {
        string Author { get; set; }

        List<ISnippetData> Data { get; set; }

        string Title { get; set; }

        int Year { get; set; }
    }
}