using Rb.Common;

namespace Rb.BookClassifier.Common.Book
{
    public interface IBookRanges
    {
        Range Author { get; }

        Range Language { get; }

        Range Title { get; }

        Range Year { get; }
    }
}