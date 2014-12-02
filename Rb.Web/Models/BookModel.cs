using Rb.Data.Entities;

namespace Rb.Web.Models
{
    public class BookModel
    {
        public string Author { get; set; }
        public HathitrustResult HathitrustResult { get; set; }
        public string PublishPlace { get; set; }
        public int PublishYear { get; set; }
        public string Publisher { get; set; }
        public string Size { get; set; }
        public string Title { get; set; }
        public WorldcatResult WorldcatResult { get; set; }
    }
}