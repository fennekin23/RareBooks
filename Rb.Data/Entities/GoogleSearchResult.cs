using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rb.Data.Entities
{
    public class GoogleSearchResult : BaseSearchResult
    {
        public GoogleSearchResult()
        {
            Items = new Collection<GoogleSearchResultItem>();
        }

        public virtual ICollection<GoogleSearchResultItem> Items { get; set; }

        public long TotalResults { get; set; }
    }
}