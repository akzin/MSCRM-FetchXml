using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tofi9.FetchXml.ObjectModel
{
    [Serializable]
    [XmlRoot("fetch")]
    public class FetchXmlObject
    {
        [XmlElement("entity")]
        public FetchEntity Entity { get; set; }

        public override string ToString()
        {
            var serializer = new XmlSerializer(typeof(FetchXmlObject));
            var writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.ToString();
        }
    }

    [Serializable]
    public class FetchEntity
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("filter")]
        public Filter Filter { get; set; }

        [XmlElement("all-attributes", typeof(AllAttributes))]
        [XmlElement("attribute", typeof(Attribute))]
        public List<Attribute> Attributes { get; } = new List<Attribute>();
    }

    [Serializable]
    public class Attribute
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }


    [Serializable]
    public class AllAttributes : Attribute
    {
    }

    [Serializable]
    public class Filter
    {
        [XmlElement("filter")]
        public List<Filter> Filters { get; } = new List<Filter>();

        [XmlElement("condition")]
        public List<Condition> Conditions { get; } = new List<Condition>();

        [XmlAttribute("type")]
        [DefaultValue(FilterType.And)]
        public FilterType Type { get; set; }
    }

    [Serializable]
    public enum FilterType
    {
        [XmlEnum("and")]
        And,

        [XmlEnum("or")]
        Or,
    }

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

            return value?.ToString();
        }
    }

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
