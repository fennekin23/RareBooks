namespace Rb.BookClassifier.Book
{
    internal class TestBook
    {
        public string Annotation { get; set; }

        public string Author { get; set; }

        public bool IsBbkExists { get; set; }

        public int InternalId { get; set; }

        public bool IsMoreInfoExist { get; set; }

        public int Language { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public long YandexResults { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", Title, Author, IsBbkExists, Language, Year, IsMoreInfoExist, YandexResults);
        }
    }
}