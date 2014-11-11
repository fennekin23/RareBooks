using System.Xml.Serialization;

namespace Rb.Yandex.Request
{
    public class SortBy
    {
        [XmlAttribute("order")]
        public string Order { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}