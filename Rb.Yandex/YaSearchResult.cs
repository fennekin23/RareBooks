using System.Xml.Serialization;
using Rb.Yandex.Request;
using Rb.Yandex.Response;

namespace Rb.Yandex
{
    [XmlRoot("yandexsearch")]
    public class YaSearchResult
    {
        [XmlElement("request")]
        public YaRequest Request { get; set; }

        [XmlElement("response")]
        public YaResponse Response { get; set; }
    }
}