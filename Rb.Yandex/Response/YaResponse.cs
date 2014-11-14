using System;
using System.Xml.Serialization;

namespace Rb.Yandex.Response
{
    [XmlRoot("response")]
    public class YaResponse
    {
        [XmlAttribute("date")]
        public string DateString { get; set; }

        [XmlIgnore]
        public DateTime DateTime
        {
            get { return DateTime.ParseExact(DateString, "yyyyMMddTHHmmss", null); }
        }

        [XmlElement("error")]
        public Error Error { get; set; }

        [XmlElement("misspell")]
        public Misspell Misspell { get; set; }

        [XmlElement("results")]
        public Results Results { get; set; }
    }
}