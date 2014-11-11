using System.Xml.Serialization;

namespace Rb.Yandex.Response
{
    public class Properties
    {
        [XmlElement("lang")]
        public string Language { get; set; }

        [XmlElement("_PassagesType", typeof (int))]
        public int PassagesType { get; set; }
    }
}