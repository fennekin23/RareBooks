using Rb.BookClassifier.Common.Book;

namespace Rb.Classifier.System.Book
{
    internal class Vectorizer : BookVectorizer<Book, BookRanges>
    {
        public Vectorizer()
            : base(new BookRanges())
        {
        }

        public override double[] GetVector(Book item)
        {
            var result = GetBaseVector(item);
            return result.ToArray();
        }
    }
}