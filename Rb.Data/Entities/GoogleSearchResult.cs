using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rb.Data.Entities
{
    public class GoogleSearchResult : BaseEntity
    {
        public GoogleSearchResult()
        {
            Items = new Collection<GoogleSearchResultItem>();
        }

        public Book Book { get; set; }

        [Column(Order = 2)]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        [Column(Order = 3)]
        [ForeignKey("Book")]
        public int BookInternalId { get; set; }

        public virtual ICollection<GoogleSearchResultItem> Items { get; set; }

        public string QueryString { get; set; }

        public RequestType RequestType { get; set; }

        public DateTime TimeStamp { get; set; }

        public long TotalResults { get; set; }
    }
}