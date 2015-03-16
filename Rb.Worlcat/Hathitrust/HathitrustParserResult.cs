using System.Collections.Generic;

namespace Rb.WebParsers.Hathitrust
{
    public class HathitrustParserResult
    {
        public HathitrustParserResult()
        {
            Links = new List<string>();
        }

        public string Author { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public List<string> Links { get; set; }

        public string Publisher { get; set; }
    }
}