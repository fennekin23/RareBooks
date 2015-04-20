using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.RequestType.Book
{
    public class Book : IBook
    {
        public bool[] RequestTypes { get; set; }

        public string Annotation { get; set; }

        public string Author { get; set; }

        public bool IsBbkExists { get; set; }

        public int InternalId { get; set; }

        public int Language { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}