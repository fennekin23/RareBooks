using System;
using Rb.Common.Enums;

namespace Rb.Data.Entities
{
    public abstract class BaseSearchResult : BaseResult
    {
        public string QueryString { get; set; }

        public RequestType RequestType { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}