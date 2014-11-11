using System.Xml.Serialization;

namespace Rb.Yandex.Response
{
    public class Passage
    {
        [XmlText(DataType = "string", Type = typeof (string))]
        public string Text { get; set; }
    }
}