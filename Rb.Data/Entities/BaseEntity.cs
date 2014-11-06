using System.ComponentModel.DataAnnotations;

namespace Rb.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}