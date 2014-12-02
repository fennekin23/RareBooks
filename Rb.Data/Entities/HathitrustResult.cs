using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rb.Data.Entities
{
    public class HathitrustResult : BaseEntity
    {
        public HathitrustResult()
        {
            Links = new Collection<HathitrustResultLink>();
        }

        public string Author { get; set; }
        public Book Book { get; set; }

        [Column(Order = 2)]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        [Column(Order = 3)]
        [ForeignKey("Book")]
        public int BookInternalId { get; set; }

        public string Description { get; set; }
        public string Language { get; set; }
        public virtual ICollection<HathitrustResultLink> Links { get; set; }
        public string Publisher { get; set; }
        public string Url { get; set; }
    }
}