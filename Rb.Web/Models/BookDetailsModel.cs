using System.Collections.Generic;

namespace Rb.Web.Models
{
    public class BookDetailsModel
    {
        public string Annotation { get; set; }

        public string Author { get; set; }

        public IList<HathitrustDetailsModel> HathitrustDetails { get; set; }

        public string Language { get; set; }

        public string PublishPlace { get; set; }

        public int PublishYear { get; set; }

        public string Publisher { get; set; }

        public string Size { get; set; }

        public string Title { get; set; }

        public IList<WorlcatDetailsModel> WorlcatDetails { get; set; }

        public class HathitrustDetailsModel
        {
            public string Author { get; set; }

            public string Description { get; set; }

            public string Language { get; set; }

            public virtual IList<string> Links { get; set; }

            public string Publisher { get; set; }

            public string Url { get; set; }
        }

        public class WorlcatDetailsModel
        {
            public string Contents { get; set; }

            public string Description { get; set; }

            public string Genre { get; set; }

            public string Notes { get; set; }

            public string OtherTitles { get; set; }

            public string Url { get; set; }
        }
    }
}