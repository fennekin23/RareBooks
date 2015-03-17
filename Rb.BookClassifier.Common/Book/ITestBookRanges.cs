using Rb.Common;

namespace Rb.BookClassifier.Common.Book
{
    public interface ITestBookRanges
    {
        Range Author { get; }

        Range Language { get; }

        Range Title { get; }

        Range Year { get; }
    }
}