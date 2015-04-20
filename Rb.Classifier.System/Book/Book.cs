using Rb.BookClassifier.Common.Book;

namespace Rb.Classifier.System.Book
{
    internal class Book : IBook
    {
        public string Annotation { get; set; }

        public string Author { get; set; }

        public int InternalId { get; set; }

        public bool IsBbkExists { get; set; }

        public int Language { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}