using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.RequestType.Book
{
    internal class BookVectorizer : BookVectorizer<Book, BookRanges>
    {
        public BookVectorizer(BookRanges ranges)
            : base(ranges)
        {
        }

        public override double[] GetVector(Book snippet)
        {
            var result = GetBaseVector(snippet);
            return result.ToArray();
        }
    }
}