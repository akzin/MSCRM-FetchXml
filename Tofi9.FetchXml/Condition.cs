using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Tofi9.FetchXml
{
    [Serializable]
    public class Condition
    {
        [XmlAttribute("column")]
        public string Column { get; set; }

        [XmlAttribute("attribute")]
        public string Attribute { get; set; }

        [XmlAttribute("entityname")]
        public string EntityName { get; set; }

        [XmlAttribute("operator")]
        public ConditionOperator Operator { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }

        [XmlAttribute("alias")]
        public string Alias { get; set; }

        public static string TranslateValueToString(object value)
        {
            if (value is DateTime)
            {
                return ((DateTime)value).ToString("O");
            }

            return value.ToString();
        }
    }
}
