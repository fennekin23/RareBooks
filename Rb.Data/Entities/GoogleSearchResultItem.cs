namespace Rb.Data.Entities
{
    public class GoogleSearchResultItem : BaseEntity
    {
        public virtual GoogleSearchResult SearchResult { get; set; }

        public string Snippet { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }
    }
}