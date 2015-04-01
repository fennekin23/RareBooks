namespace Rb.BookClassifier.Common.Snippet
{
    public interface ITestSnippet
    {
        int InternalBookId { get; set; }

        bool IsMoreInfoExists { get; set; }

        string Text { get; set; }

        string Title { get; set; }

        string Url { get; set; }
    }
}