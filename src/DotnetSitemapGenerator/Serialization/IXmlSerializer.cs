using System.IO;

namespace DotnetSitemapGenerator.Serialization
{
    public interface IXmlSerializer
    {
        string Serialize<T>(T data);
        string Serialize<T>(T data, string fileLocation, bool readable);
        void SerializeToStream<T>(T data, Stream stream, bool readable = false);
    }
}