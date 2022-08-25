using System.Collections.Generic;
using System.Xml.Serialization;

namespace DotnetSitemapGenerator.Serialization
{
    interface IXmlNamespaceBuilder
    {
        XmlSerializerNamespaces Create(IEnumerable<string> namespaces);
    }
}