using Rb.Common;

namespace Rb.BookClassifier.Common.Book
{
    public class BookRanges : IBookRanges
    {
        public BookRanges()
        {
            Author = new Range(0, 80);
            Language = new Range(0, 14);
            Title = new Range(5, 247);
            Year = new Range(1497, 1918);
        }

        public Range Author { get; private set; }

        public Range Language { get; private set; }

        public Range Title { get; private set; }

        public Range Year { get; private set; }
    }
}