namespace Rb.Data.Entities
{
    public class WorldcatResult : BaseEntity
    {
        public int BookId { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Notes { get; set; }
        public string OtherTitles { get; set; }
        public string Url { get; set; }
    }
}