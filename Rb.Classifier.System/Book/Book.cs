using Rb.BookClassifier.Common.Book;
using Rb.Common;
using Rb.Common.Enums;

namespace Rb.System.Book
{
    internal class Book : IBook
    {
        public override string ToString()
        {
            return string.Format("Title: {0}, Author: {1}, Year: {2}, Language: {3}, BBK: {4}",
                Title,
                Author,
                Year,
                ((LanguageCode) Language).GetDescription(),
                IsBbkExists);
        }

        public string Annotation { get; set; }

        public string Author { get; set; }

        public int InternalId { get; set; }

        public bool IsBbkExists { get; set; }

        public int Language { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}