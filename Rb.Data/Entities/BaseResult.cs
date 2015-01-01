using System.ComponentModel.DataAnnotations.Schema;

namespace Rb.Data.Entities
{
    public abstract class BaseResult : BaseEntity
    {
        [ForeignKey("BookId, BookInternalId")]
        public Book Book { get; set; }

        public int BookId { get; set; }

        public int BookInternalId { get; set; }
    }
}