using System.Xml.Serialization;

namespace Rb.Yandex.Response
{
    public class Page
    {
        [XmlText]
        public int Current { get; set; }

        [XmlAttribute("first")]
        public int First { get; set; }

        [XmlAttribute("last")]
        public int Last { get; set; }
    }
}