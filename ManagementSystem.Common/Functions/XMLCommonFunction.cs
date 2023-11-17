using ManagementSystem.Common.Models;
using ManagementSystem.Common.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static string GenerateXml(List<InvoiceDto> invoices)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement invoicesElement = xmlDoc.CreateElement("Invoices");
            xmlDoc.AppendChild(invoicesElement);

            foreach (var invoice in invoices)
            {
                XmlElement invElement = xmlDoc.CreateElement("Inv");
                invoicesElement.AppendChild(invElement);

                XmlElement invoiceElement = xmlDoc.CreateElement("Invoice");
                invElement.AppendChild(invoiceElement);

                // Add Invoice properties
                AddXmlElement(xmlDoc, invoiceElement, "TaxAuthorityCode", invoice.TaxAuthorityCode);
                AddXmlElement(xmlDoc, invoiceElement, "Ikey", invoice.Ikey);

                if (string.IsNullOrEmpty(invoice.CusCode) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "CusCode", invoice.CusCode);
                }

                if (string.IsNullOrEmpty(invoice.Buyer) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "Buyer", invoice.Buyer);
                }

                if (string.IsNullOrEmpty(invoice.CusName) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "CusName", invoice.CusName);
                }

                if (string.IsNullOrEmpty(invoice.Email) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "Email", invoice.Email);
                }

                if (string.IsNullOrEmpty(invoice.EmailCC) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "EmailCC", invoice.EmailCC);
                }

                if (string.IsNullOrEmpty(invoice.CusAddress) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "CusAddress", invoice.CusAddress);
                }

                if (string.IsNullOrEmpty(invoice.CusBankName) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "CusBankName", invoice.CusBankName);
                }

                if (string.IsNullOrEmpty(invoice.CusBankNo) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "CusBankNo", invoice.CusBankNo);
                }

                if (string.IsNullOrEmpty(invoice.CusPhone) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "CusPhone", invoice.CusPhone);
                }

                if (string.IsNullOrEmpty(invoice.CusPhone) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "CusTaxCode", invoice.CusTaxCode);
                }

                AddXmlElement(xmlDoc, invoiceElement, "PaymentMethod", invoice.PaymentMethod);
                AddXmlElement(xmlDoc, invoiceElement, "ArisingDate", DateTime.Now.ToString("dd/MM/yyyy"));
                AddXmlElement(xmlDoc, invoiceElement, "ExchangeRate", invoice.ExchangeRate);
                AddXmlElement(xmlDoc, invoiceElement, "CurrencyUnit", invoice.CurrencyUnit);
                if (string.IsNullOrEmpty(invoice.Extra) != true)
                {
                    AddXmlElement(xmlDoc, invoiceElement, "Extra", invoice.Extra);
                }

                // Add Products
                XmlElement productsElement = xmlDoc.CreateElement("Products");
                invoiceElement.AppendChild(productsElement);

                foreach (var product in invoice.Products)
                {
                    XmlElement productElement = xmlDoc.CreateElement("Product");
                    productsElement.AppendChild(productElement);

                    // Add Product properties
                    AddXmlElement(xmlDoc, productElement, "Code", product.Code);
                    AddXmlElement(xmlDoc, productElement, "No", product.No.ToString());
                    AddXmlElement(xmlDoc, productElement, "Feature", product.Feature);
                    AddXmlElement(xmlDoc, productElement, "ProdName", product.ProdName);
                    AddXmlElement(xmlDoc, productElement, "ProdUnit", product.ProdUnit);
                    AddXmlElement(xmlDoc, productElement, "ProdQuantity", product.ProdQuantity.ToString());
                    AddXmlElement(xmlDoc, productElement, "ProdPrice", product.ProdPrice.ToString());
                    AddXmlElement(xmlDoc, productElement, "Discount", product.Discount.ToString());
                    AddXmlElement(xmlDoc, productElement, "DiscountAmount", product.DiscountAmount.ToString());
                    AddXmlElement(xmlDoc, productElement, "Total", product.Total.ToString());
                    AddXmlElement(xmlDoc, productElement, "VATRate", product.VATRate.ToString());
                    AddXmlElement(xmlDoc, productElement, "VATRateOther", product.VATRateOther.ToString());
                    AddXmlElement(xmlDoc, productElement, "VATAmount", product.VATAmount.ToString());
                    AddXmlElement(xmlDoc, productElement, "Amount", product.Amount.ToString());

                    if (string.IsNullOrEmpty(product.Extra) != true)
                    {
                        AddXmlElement(xmlDoc, productElement, "Extra", product.Extra);
                    }
                }
            }

            using (StringWriter stringWriter = new StringWriter())
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                xmlDoc.WriteTo(xmlTextWriter);
                return stringWriter.ToString();
            }
        }

        public static string GenerateInvoiceModificationXml(InvoiceModifyRequestDto invoice)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement invoicesElement = xmlDoc.CreateElement("AdjustInv");
            xmlDoc.AppendChild(invoicesElement);



            // Add Invoice properties
            AddXmlElement(xmlDoc, invoicesElement, "TaxAuthorityCode", invoice.TaxAuthorityCode);
            AddXmlElement(xmlDoc, invoicesElement, "Ikey", invoice.Ikey);
            AddXmlElement(xmlDoc, invoicesElement, "CusCode", invoice.CusCode);
            AddXmlElement(xmlDoc, invoicesElement, "Buyer", invoice.Buyer);
            AddXmlElement(xmlDoc, invoicesElement, "CusName", invoice.CusName);
            AddXmlElement(xmlDoc, invoicesElement, "Email", invoice.Email);
            AddXmlElement(xmlDoc, invoicesElement, "EmailCC", invoice.EmailCC);
            AddXmlElement(xmlDoc, invoicesElement, "CusAddress", invoice.CusAddress);
            AddXmlElement(xmlDoc, invoicesElement, "CusBankName", invoice.CusBankName);
            AddXmlElement(xmlDoc, invoicesElement, "CusBankNo", invoice.CusBankNo);
            AddXmlElement(xmlDoc, invoicesElement, "CusPhone", invoice.CusPhone);
            AddXmlElement(xmlDoc, invoicesElement, "CusTaxCode", invoice.CusTaxCode);
            AddXmlElement(xmlDoc, invoicesElement, "PaymentMethod", invoice.PaymentMethod);
            AddXmlElement(xmlDoc, invoicesElement, "ArisingDate", DateTime.Now.ToString("dd/MM/yyyy"));
            AddXmlElement(xmlDoc, invoicesElement, "ExchangeRate", invoice.ExchangeRate);
            AddXmlElement(xmlDoc, invoicesElement, "CurrencyUnit", invoice.CurrencyUnit);
            AddXmlElement(xmlDoc, invoicesElement, "Extra", invoice.Extra);

            // Add Products
            XmlElement productsElement = xmlDoc.CreateElement("Products");
            invoicesElement.AppendChild(productsElement);

            foreach (var product in invoice.Products)
            {
                XmlElement productElement = xmlDoc.CreateElement("Product");
                productsElement.AppendChild(productElement);

                // Add Product properties
                AddXmlElement(xmlDoc, productElement, "Code", product.Code);
                AddXmlElement(xmlDoc, productElement, "No", product.No.ToString());
                AddXmlElement(xmlDoc, productElement, "Feature", product.Feature);
                AddXmlElement(xmlDoc, productElement, "ProdName", product.ProdName);
                AddXmlElement(xmlDoc, productElement, "ProdUnit", product.ProdUnit);
                AddXmlElement(xmlDoc, productElement, "ProdQuantity", product.ProdQuantity.ToString());
                AddXmlElement(xmlDoc, productElement, "ProdPrice", product.ProdPrice.ToString());
                AddXmlElement(xmlDoc, productElement, "Discount", product.Discount.ToString());
                AddXmlElement(xmlDoc, productElement, "DiscountAmount", product.DiscountAmount.ToString());
                AddXmlElement(xmlDoc, productElement, "Total", product.Total.ToString());
                AddXmlElement(xmlDoc, productElement, "VATRate", product.VATRate.ToString());
                AddXmlElement(xmlDoc, productElement, "VATRateOther", product.VATRateOther.ToString());
                AddXmlElement(xmlDoc, productElement, "VATAmount", product.VATAmount.ToString());
                AddXmlElement(xmlDoc, productElement, "Amount", product.Amount.ToString());
                AddXmlElement(xmlDoc, productElement, "Extra", product.Extra);
            }


            using (StringWriter stringWriter = new StringWriter())
            {
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                xmlDoc.WriteTo(xmlTextWriter);
                return stringWriter.ToString();
            }
        }
        private static void AddXmlElement(XmlDocument xmlDoc, XmlElement parentElement, string elementName, string elementValue)
        {
            XmlElement xmlElement = xmlDoc.CreateElement(elementName);
            xmlElement.InnerText = elementValue;
            parentElement.AppendChild(xmlElement);
        }
    }
}
