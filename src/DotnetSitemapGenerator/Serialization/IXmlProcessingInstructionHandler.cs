using System.Xml;
using DotnetSitemapGenerator.StyleSheets;

namespace DotnetSitemapGenerator.Serialization
{
    interface IXmlProcessingInstructionHandler
    {
        void AddStyleSheets(XmlWriter xmlWriter, IHasStyleSheets model);
    }
}