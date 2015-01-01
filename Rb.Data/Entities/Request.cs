using Rb.Common.Enums;

namespace Rb.Data.Entities
{
    public class Request : BaseEntity
    {
        public string Description { get; set; }

        public RequestType Type { get; set; }
    }
}