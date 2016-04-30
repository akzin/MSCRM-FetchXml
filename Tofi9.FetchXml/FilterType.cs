using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Tofi9.FetchXml
{
    [Serializable]
    public enum FilterType
    {
        [XmlEnum("and")]
        And,

        [XmlEnum("or")]
        Or,
    }
}
