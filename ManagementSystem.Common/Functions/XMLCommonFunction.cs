using ManagementSystem.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

        public static string GenerateXml<T>(IEnumerable<T> data, string rootElementName, string itemElementName)
        {
            XDocument doc = new XDocument(
                new XElement(rootElementName,
                    from item in data
                    select CreateXmlElement(item, itemElementName)
                )
            );

            return doc.ToString();
        }

        private static XElement CreateXmlElement<T>(T item, string elementName)
        {
            var properties = typeof(T).GetProperties();
            var element = new XElement(elementName);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(item);
                element.Add(new XElement(prop.Name, value));
            }

            return element;
        }
    }
}
