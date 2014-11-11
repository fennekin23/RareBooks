using System.Xml.Serialization;

namespace Rb.Yandex.Response
{
    public class Group
    {
        [XmlElement("categ")]
        public Category Category { get; set; }

        [XmlElement("doc")]
        public Document[] Documents { get; set; }

        [XmlElement("doccount")]
        public int DocumentsCount { get; set; }
    }
}