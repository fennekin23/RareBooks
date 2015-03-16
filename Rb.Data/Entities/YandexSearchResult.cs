namespace Rb.Data.Entities
{
    public class YandexSearchResult : BaseSearchResult
    {
        public string DocumentDomain { get; set; }

        public string DocumentLanguage { get; set; }

        public string DocumentPassages { get; set; }

        public int DocumentSize { get; set; }

        public string DocumentTitle { get; set; }

        public string DocumentUrl { get; set; }

        public long FoundDocuments { get; set; }
    }
}