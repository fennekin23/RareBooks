namespace Rb.BookClassifier.Common.TestSet
{
    public interface ITestSetItem
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