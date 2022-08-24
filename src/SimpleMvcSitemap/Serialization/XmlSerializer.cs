using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SimpleMvcSitemap.StyleSheets;

namespace SimpleMvcSitemap.Serialization
{
    class XmlSerializer : IXmlSerializer
    {
        private readonly IXmlNamespaceBuilder xmlNamespaceBuilder;
        private readonly XmlProcessingInstructionHandler xmlProcessingInstructionHandler;

        public XmlSerializer()
        {
            xmlNamespaceBuilder = new XmlNamespaceBuilder();
            xmlProcessingInstructionHandler = new XmlProcessingInstructionHandler();
        }

        public string Serialize<T>(T data, string fileLocation , bool readable)
        {
            StringWriter stringWriter = new StringWriterWithEncoding(Encoding.UTF8);
            SerializeToStream(data, settings => XmlWriter.Create(stringWriter, settings), readable);
            File.WriteAllText(fileLocation, stringWriter.ToString());
            return stringWriter.ToString();
        }

        public string Serialize<T>(T data)
        {
            StringWriter stringWriter = new StringWriterWithEncoding(Encoding.UTF8);
            SerializeToStream(data, settings => XmlWriter.Create(stringWriter, settings));
            return stringWriter.ToString();
        }

        public void SerializeToStream<T>(T data, Stream stream, bool readable = false)
        {
            SerializeToStream(data, settings => XmlWriter.Create(stream, settings), readable);
        }

        private void SerializeToStream<T>(T data, Func<XmlWriterSettings, XmlWriter> createXmlWriter, bool readable = false)
        {
            IXmlNamespaceProvider namespaceProvider = data as IXmlNamespaceProvider;
            IEnumerable<string> namespaces = namespaceProvider != null ? namespaceProvider.GetNamespaces() : Enumerable.Empty<string>();
            XmlSerializerNamespaces xmlSerializerNamespaces = xmlNamespaceBuilder.Create(namespaces);

            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                NamespaceHandling = NamespaceHandling.OmitDuplicates
            };
            if (readable)
            {
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineChars = Environment.NewLine;
                xmlWriterSettings.NewLineOnAttributes = true;
            }

            using (XmlWriter writer = createXmlWriter(xmlWriterSettings))
            {
                if (data is IHasStyleSheets)
                {
                    xmlProcessingInstructionHandler.AddStyleSheets(writer, data as IHasStyleSheets);
                }

                xmlSerializer.Serialize(writer, data, xmlSerializerNamespaces);
            }
        }
    }
}