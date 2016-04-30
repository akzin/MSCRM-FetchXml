using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Tofi9.FetchXml
{
    [Serializable]
    [XmlRoot("fetch")]
    public class FetchXml
    {
        [XmlElement("entity")]
        public FetchEntity Entity { get; set; }

        public override string ToString()
        {
            var serializer = new XmlSerializer(typeof(FetchXml));
            var writer = new StringWriter();
            serializer.Serialize(writer, this);
            return writer.ToString();
        }
    }
}
