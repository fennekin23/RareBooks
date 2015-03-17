namespace Rb.BookClassifier.Common.Book
{
    public interface ITestBook
    {
        string Annotation { get; set; }

        string Author { get; set; }

        int InternalId { get; set; }

        bool IsBbkExists { get; set; }

        int Language { get; set; }

        string Title { get; set; }

        int Year { get; set; }
    }
}