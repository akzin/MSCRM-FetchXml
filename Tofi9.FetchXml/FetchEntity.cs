using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tofi9.FetchXml
{
    [Serializable]
    public class FetchEntity
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("filter")]
        public Filter Filter { get; set; }

        [XmlElement("all-attributes", typeof(AllAttributes))]
        [XmlElement("attribute", typeof(Attribute))]
        public List<Attribute> Attributes { get; set; }
    }
}
