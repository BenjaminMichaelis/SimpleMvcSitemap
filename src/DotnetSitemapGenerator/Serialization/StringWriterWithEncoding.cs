using System.IO;
using System.Text;

namespace DotnetSitemapGenerator.Serialization
{
    sealed class StringWriterWithEncoding : StringWriter
    {
        public StringWriterWithEncoding(Encoding encoding)
        {
            Encoding = encoding;
        }

        public override Encoding Encoding { get; }
    }
}