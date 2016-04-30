using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tofi9.FetchXml
{
    [Serializable]
    public class Attribute
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
