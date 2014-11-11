using System.Xml.Serialization;

namespace Rb.Yandex.Response
{
    public class Results
    {
        [XmlElement("grouping")]
        public Grouping Grouping { get; set; }
    }
}