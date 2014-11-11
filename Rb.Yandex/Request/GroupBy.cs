using System.Xml.Serialization;

namespace Rb.Yandex.Request
{
    public class GroupBy
    {
        [XmlAttribute("attr")]
        public string Attribute { get; set; }

        [XmlAttribute("docs-in-group")]
        public int DocsInGroup { get; set; }

        [XmlAttribute("groups-on-page")]
        public int GroupsOnPage { get; set; }

        [XmlAttribute("mode")]
        public string Mode { get; set; }
    }
}