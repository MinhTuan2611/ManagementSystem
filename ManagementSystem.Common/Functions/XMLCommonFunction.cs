using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ManagementSystem.Common
{
    public class XMLCommonFunction
    {
        public static string SerializeToXml(SearchCriteria searchCriteria)
        {
            var xmlStringBuilder = new StringBuilder();

            // Create an XmlWriter
            using (var xmlWriter = XmlWriter.Create(xmlStringBuilder))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("SearchCriteria");

                foreach (var entry in searchCriteria.Criterias)
                {
                    xmlWriter.WriteStartElement("Criteria");
                    xmlWriter.WriteElementString("Key", entry.Key);
                    xmlWriter.WriteElementString("Value", entry.Value.ToString());
                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }

            return xmlStringBuilder.ToString();
        }
    }
}
