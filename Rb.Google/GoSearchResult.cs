using System.Collections.Generic;

namespace Rb.Google
{
    public class GoSearchResult
    {
        public string Query { get; set; }

        public List<GoSearchResultItem> ResultItems { get; set; }

        public long TotalResults { get; set; }
    }
}