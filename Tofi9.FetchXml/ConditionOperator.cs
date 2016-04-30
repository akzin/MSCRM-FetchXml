using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Tofi9.FetchXml
{

    public enum ConditionOperator
    {
        [XmlEnum("eq")]
        Eq,

        [XmlEnum("neq")]
        Neq,

        [XmlEnum("ne")]
        Ne,

        [XmlEnum("gt")]
        Gt,

        [XmlEnum("ge")]
        Ge,

        [XmlEnum("le")]
        Le,

        [XmlEnum("lt")]
        Lt,

        [XmlEnum("like")]
        Like,

        [XmlEnum("not-like")]
        NotLike,
    }
}
