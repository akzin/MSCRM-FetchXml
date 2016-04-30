using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace Tofi9.FetchXml
{
    [Serializable]
    public class Filter
    {
        [XmlElement("filter")]
        public List<Filter> Filters { get; set; }
        [XmlElement("condition")]
        public List<Condition> Conditions { get; set; }
        [XmlAttribute("type")]
        [DefaultValue(FilterType.And)]
        public FilterType Type { get; set; }
    }
}
