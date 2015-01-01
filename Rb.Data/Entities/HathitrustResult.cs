using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rb.Data.Entities
{
    public class HathitrustResult : BaseResult
    {
        public HathitrustResult()
        {
            Links = new Collection<HathitrustResultLink>();
        }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public virtual ICollection<HathitrustResultLink> Links { get; set; }

        public string Publisher { get; set; }

        public string Url { get; set; }
    }
}