namespace Rb.BookClassifier.Common.TestSet
{
    public class TestSetItem : ITestSetItem
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