using System.Xml.Serialization;

namespace Rb.Yandex.Response
{
    public class Error
    {
        [XmlAttribute("code")]
        public int Code { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}