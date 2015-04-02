namespace Rb.BookClassifier.Common.Snippet
{
    public interface ITestSnippet
    {
        string BookAuthor { get; set; }

        string BookTitle { get; set; }

        int BookYear { get; set; }

        int InternalBookId { get; set; }

        bool IsMoreInfoExists { get; set; }

        string Text { get; set; }

        string Title { get; set; }

        string Url { get; set; }
    }
}