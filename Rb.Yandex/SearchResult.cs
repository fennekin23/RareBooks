using System.Xml.Serialization;
using Rb.Yandex.Request;
using Rb.Yandex.Response;

namespace Rb.Yandex
{
    [XmlRoot("yandexsearch")]
    public class SearchResult
    {
        [XmlElement("request")]
        public YandexRequest Request { get; set; }

        [XmlElement("response")]
        public YandexResponse Response { get; set; }
    }
}