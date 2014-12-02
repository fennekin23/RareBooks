using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rb.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
    }
}