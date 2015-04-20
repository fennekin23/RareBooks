using Rb.BookClassifier.Common.Book;

namespace Rb.BookClassifier.Binary.Book
{
    internal class Book : IBook
    {
        public bool IsMoreInfoExists { get; set; }

        public string Annotation { get; set; }

        public string Author { get; set; }

        public int InternalId { get; set; }

        public bool IsBbkExists { get; set; }

        public int Language { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}