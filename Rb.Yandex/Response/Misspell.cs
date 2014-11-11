using System.Xml.Serialization;

namespace Rb.Yandex.Response
{
    public class Misspell
    {
        [XmlElement("rule")]
        public string Rule { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }
    }
}