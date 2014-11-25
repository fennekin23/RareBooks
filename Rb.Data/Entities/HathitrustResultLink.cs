namespace Rb.Data.Entities
{
    public class HathitrustResultLink : BaseEntity
    {
        public virtual HathitrustResult HathitrustResult { get; set; }
        public int HathitrustResultId { get; set; }
        public string Url { get; set; }
    }
}