using System.Xml.Serialization;

namespace Rb.Yandex.Response
{
    public class Found
    {
        [XmlText]
        public int Count { get; set; }

        [XmlAttribute("priority")]
        public string Prioriry { get; set; }
    }
}