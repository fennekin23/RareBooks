using System.ComponentModel.DataAnnotations.Schema;

namespace Rb.Data.Entities
{
    public class WorldcatResult : BaseEntity
    {
        public virtual Book Book { get; set; }

        [ForeignKey("Book")]
        [Column(Order = 2)]
        public int BookId { get; set; }

        [ForeignKey("Book")]
        [Column(Order = 3)]
        public int BookInternalId { get; set; }

        public string Contents { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Notes { get; set; }
        public string OtherTitles { get; set; }
        public string Url { get; set; }
    }
}